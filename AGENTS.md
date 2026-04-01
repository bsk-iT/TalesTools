# TalesTools — Agent Guidelines

**Language**: C# (.NET Framework 4.7.2)  
**UI Framework**: WinForms (desktop)  
**Build System**: MSBuild (legacy `.csproj`, NuGet `packages.config`)  
**Main Namespaces**: `_4RTools.Utils`, `_4RTools.Model`, `_4RTools.Forms`

---

## Build, Lint & Test Commands

### Build
```bash
msbuild TalesTools.sln /p:Configuration=Release /p:Platform="Any CPU"
msbuild TalesTools.sln /p:Configuration=Debug                          # Debug build
```
Output: `bin/Release/` or `bin/Debug/`

### Clean
```bash
msbuild TalesTools.sln /t:Clean
```

### Run
Open `TalesTools.sln` in Visual Studio or run the compiled `.exe`:
```bash
bin/Release/TalesTools.exe
```

### No Test Framework
**Important**: This project has no automated test suite. No unit tests, no integration tests, no CI/CD. Manual testing only.

---

## Code Style Guidelines

### Naming Conventions

**Classes & Methods**: `PascalCase`
```csharp
public class Autopot : Action
public void StartMacro()
public string GetActionName()
```

**Properties**: `PascalCase` with auto-properties
```csharp
public Key hpKey { get; set; }
public int delay { get; set; } = 15;
public bool stopWitchFC { get; set; } = false;
```

**Constants**: `UPPER_SNAKE_CASE` as `public static` or `public const`
```csharp
public const int WM_HOTKEY_MSG_ID = 0x0312;
public static string ACTION_NAME_AUTOPOT = "Autopot";
```

**Local Variables & Parameters**: `camelCase`
```csharp
int hpPercent = 80;
string profileName = "Default";
```

**Private Fields**: `camelCase` (no underscore prefix, except Observer pattern: `_observers`)
```csharp
private _4RThread thread;
private Subject subject = new Subject();
```

### Imports
1. System namespaces (`System.*`, `System.Windows.Forms`)
2. Third-party (`Newtonsoft.Json`)
3. Project namespaces (`_4RTools.Utils`, `_4RTools.Model`)

### Formatting & Types

- **Access Modifiers**: Always explicit (`public`, `private`, `protected`, `internal`)
- **Properties**: Use `{ get; set; }` with optional defaults
- **Braces**: Allman style (opening brace on new line)
- **Type References**: Full namespace in diagnostics; use `using` statements otherwise

### Error Handling

**UI-Level Swallowing** (acceptable):
```csharp
try { textBox.SelectionStart = textBox.Text.Length; }
catch { }  // Non-critical UI operation
```

**Thread Exceptions** (log to console):
```csharp
catch (Exception ex)
{
    Console.WriteLine("[4RThread Exception] Error: " + ex.Message);
}
```

Never silently ignore critical errors—log or rethrow.

### Threading

Use `_4RThread` for background work:
```csharp
private _4RThread thread = new _4RThread(_ => MyMethod());
_4RThread.Start(thread);  // Start
_4RThread.Stop(thread);   // Stop (calls Suspend)
```

`_4RThread` features:
- Wraps `Thread.SetApartmentState(ApartmentState.STA)` (WinForms requirement)
- Infinite loop with 5ms `Thread.Sleep()` between cycles
- Automatic exception catching with logging

Do NOT use raw `Thread` or `Task`—always use `_4RThread`.

### JSON Serialization (Newtonsoft.Json)

```csharp
using Newtonsoft.Json;

public class Autopot : Action
{
    public Key hpKey { get; set; }
    
    [JsonIgnore]  // Exclude from serialization
    public List<string> listCities { get; set; }
    
    public string GetConfiguration()
    {
        return JsonConvert.SerializeObject(this);
    }
}
```

### Architecture Patterns

**Action Interface** (domain contract):
```csharp
public interface Action
{
    void Start();
    void Stop();
    string GetActionName();
    string GetConfiguration();
}
```

**Observer Pattern** (cross-form communication):
```csharp
public partial class Container : Form, IObserver
{
    private Subject subject = new Subject();
    
    public Container()
    {
        subject.Attach(this);
    }
    
    public void Update(ISubject subject)
    {
        // React to changes
    }
}
```

**Form Lifecycle** (WinForms):
- `*Form.cs` — UI logic and event handlers
- `*Form.Designer.cs` — auto-generated (do NOT edit manually)
- Use `partial class` to separate concerns
- Follow `Set*Window()` naming for MDI children

### Configuration & Constants

Static config in `AppConfig.cs`:
```csharp
public static string Name = "BSKTools";
public static string Version = "v5.2.1";
```

Magic numbers and Windows IDs in `Constants.cs`:
```csharp
public const int WM_HOTKEY_MSG_ID = 0x0312;
```

---

## Common Tasks

### Adding a New Action
1. Create `Model/*Action.cs` implementing `Action` interface
2. Add all required methods: `Start()`, `Stop()`, `GetActionName()`, `GetConfiguration()`
3. Use `_4RThread` for background work
4. Serialize state with `JsonConvert.SerializeObject(this)`

### Modifying Forms
1. Open `Forms/*Form.Designer.cs` in Visual Studio designer (right-click → **Open with Designer**)
2. Edit layout and controls
3. Implement event handlers in `Forms/*Form.cs`
4. Never manually edit `.Designer.cs`

### Error Handling in Threads
Wrap all thread methods in `try-catch`:
```csharp
catch (Exception ex)
{
    Console.WriteLine("[4RThread Exception] " + ex.Message);
}
```

---

## Notes for Agents

- **No tests**: Manual testing required; no test runner.
- **Legacy project**: .NET Framework 4.7.2 (not .NET Core/5+).
- **WinForms complexity**: Designer files are auto-generated; avoid manual edits.
- **Observer pattern critical**: Forms communicate via `Subject.Notify()`—breaking this breaks UI.
- **Thread safety**: Always use `_4RThread`, never raw `Thread`.
- **Profile system**: Serializes actions to JSON; deserialization on app startup.

---

# context-mode — MANDATORY routing rules

You have context-mode MCP tools available. These rules are NOT optional — they protect your context window from flooding. A single unrouted command can dump 56 KB into context and waste the entire session.

## BLOCKED commands — do NOT attempt these

### curl / wget — BLOCKED
Any shell command containing `curl` or `wget` will be intercepted and blocked by the context-mode plugin. Do NOT retry.
Instead use:
- `context-mode_ctx_fetch_and_index(url, source)` to fetch and index web pages
- `context-mode_ctx_execute(language: "javascript", code: "const r = await fetch(...)")` to run HTTP calls in sandbox

### Inline HTTP — BLOCKED
Any shell command containing `fetch('http`, `requests.get(`, `requests.post(`, `http.get(`, or `http.request(` will be intercepted and blocked. Do NOT retry with shell.
Instead use:
- `context-mode_ctx_execute(language, code)` to run HTTP calls in sandbox — only stdout enters context

### Direct web fetching — BLOCKED
Do NOT use any direct URL fetching tool. Use the sandbox equivalent.
Instead use:
- `context-mode_ctx_fetch_and_index(url, source)` then `context-mode_ctx_search(queries)` to query the indexed content

## REDIRECTED tools — use sandbox equivalents

### Shell (>20 lines output)
Shell is ONLY for: `git`, `mkdir`, `rm`, `mv`, `cd`, `ls`, `npm install`, `pip install`, and other short-output commands.
For everything else, use:
- `context-mode_ctx_batch_execute(commands, queries)` — run multiple commands + search in ONE call
- `context-mode_ctx_execute(language: "shell", code: "...")` — run in sandbox, only stdout enters context

### File reading (for analysis)
If you are reading a file to **edit** it → reading is correct (edit needs content in context).
If you are reading to **analyze, explore, or summarize** → use `context-mode_ctx_execute_file(path, language, code)` instead. Only your printed summary enters context.

### grep / search (large results)
Search results can flood context. Use `context-mode_ctx_execute(language: "shell", code: "grep ...")` to run searches in sandbox. Only your printed summary enters context.

## Tool selection hierarchy

1. **GATHER**: `context-mode_ctx_batch_execute(commands, queries)` — Primary tool. Runs all commands, auto-indexes output, returns search results. ONE call replaces 30+ individual calls.
2. **FOLLOW-UP**: `context-mode_ctx_search(queries: ["q1", "q2", ...])` — Query indexed content. Pass ALL questions as array in ONE call.
3. **PROCESSING**: `context-mode_ctx_execute(language, code)` | `context-mode_ctx_execute_file(path, language, code)` — Sandbox execution. Only stdout enters context.
4. **WEB**: `context-mode_ctx_fetch_and_index(url, source)` then `context-mode_ctx_search(queries)` — Fetch, chunk, index, query. Raw HTML never enters context.
5. **INDEX**: `context-mode_ctx_index(content, source)` — Store content in FTS5 knowledge base for later search.

## Output constraints

- Keep responses under 500 words.
- Write artifacts (code, configs, PRDs) to FILES — never return them as inline text. Return only: file path + 1-line description.
- When indexing content, use descriptive source labels so others can `search(source: "label")` later.

## ctx commands

| Command | Action |
|---------|--------|
| `ctx stats` | Call the `stats` MCP tool and display the full output verbatim |
| `ctx doctor` | Call the `doctor` MCP tool, run the returned shell command, display as checklist |
| `ctx upgrade` | Call the `upgrade` MCP tool, run the returned shell command, display as checklist |
