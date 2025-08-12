using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _4RTools.Utils
{
    public static class MouseHook
    {
        #region interop
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool UnhookWindowsHookEx(IntPtr idHook);
        #endregion

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr hMouseHook = IntPtr.Zero;
        private static HookProc mouseHookProc = new HookProc(MouseFilter);

        public delegate bool MousePressed();

        private static System.Collections.Generic.Dictionary<int, MousePressed> handledMouseDown = new System.Collections.Generic.Dictionary<int, MousePressed>();

        private static bool MouseEnabled;

        private const int WH_MOUSE_LL = 14;
        private const int WM_XBUTTONDOWN = 0x020B;

        public static bool Enable()
        {
            if (MouseEnabled == false)
            {
                try
                {
                    using (Process curProcess = Process.GetCurrentProcess())
                    using (ProcessModule curModule = curProcess.MainModule)
                        hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, mouseHookProc, GetModuleHandle(curModule.ModuleName), 0);
                    MouseEnabled = true;
                    return true;
                }
                catch
                {
                    MouseEnabled = false;
                    return false;
                }
            }
            else
                return false;
        }

        public static bool Disable()
        {
            if (MouseEnabled == true)
            {
                try
                {
                    UnhookWindowsHookEx(hMouseHook);
                    MouseEnabled = false;
                    return true;
                }
                catch
                {
                    MouseEnabled = true;
                    return false;
                }
            }
            else
                return false;
        }

        private static IntPtr MouseFilter(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool result = true;

            if (nCode >= 0)
            {
                if (wParam == (IntPtr)WM_XBUTTONDOWN)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    int button = (int)(hookStruct.mouseData >> 16);

                    // button == 1 para XButton1 (Back/Browser Back)
                    // button == 2 para XButton2 (Forward/Browser Forward)
                    result = OnMouseDown(button);
                }
            }

            return result ? CallNextHookEx(hMouseHook, nCode, wParam, lParam) : new IntPtr(1);
        }

        public static bool AddMouseDown(int button, MousePressed callback)
        {
            if (!handledMouseDown.ContainsKey(button))
            {
                handledMouseDown.Add(button, callback);
                return true;
            }
            else
                return false;
        }

        public static bool RemoveMouseDown(int button)
        {
            return handledMouseDown.Remove(button);
        }

        private static bool OnMouseDown(int button)
        {
            if (handledMouseDown.ContainsKey(button))
                return handledMouseDown[button]();
            else
                return true;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
    }
}