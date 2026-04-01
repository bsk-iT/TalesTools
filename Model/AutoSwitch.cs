using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using _4RTools.Utils;
using System.Linq;

namespace _4RTools.Model
{

  public class AutoSwitch : Action
  {
    public static string ACTION_NAME_AUTOSWITCH = "AutoSwitch";
    public const string item = "ITEM";
    public const string skill = "SKILL";
    public const string nextItem = "NEXTITEM";

    private _4RThread thread;
    public int delay { get; set; } = 500;
    public int switchEquipDelay { get; set; } = 1000;
    public Dictionary<EffectStatusIDs, Key> buffMapping = new Dictionary<EffectStatusIDs, Key>();
    public List<AutoSwitchConfig> autoSwitchMapping = new List<AutoSwitchConfig>();
    public List<AutoSwitchConfig> autoSwitchGenericMapping = new List<AutoSwitchConfig>();

    public List<EffectStatusIDs> autoSwitchOrder { get; set; } = new List<EffectStatusIDs>();
    [JsonIgnore]
    public List<String> listCities { get; set; }

    // Estado da máquina de estados para pet skills
    private enum PetState
    {
      IDLE,           // Aguardando para invocar pet (única vez que pressiona Item key)
      SKILL_USED,     // Pet invocado, aguardando buff aparecer (NÃO pressiona nada)
      BUFF_ACTIVE     // Buff confirmado ativo, next item equipado
    }

    public class AutoSwitchConfig
    {
      public EffectStatusIDs skillId { get; set; }
      public Key itemKey { get; set; }
      public Key skillKey { get; set; }
      public Key nextItemKey { get; set; }

      public AutoSwitchConfig(EffectStatusIDs id, Key key, String type = null)
      {
        this.skillId = id;
        if (type != null)
        {
          switch (type)
          {
            case item:
              this.itemKey = key;
              break;

            case skill:
              this.skillKey = key;
              break;

            case nextItem:
              this.nextItemKey = key;
              break;
          }

        }
      }


    }

    public void Start()
    {
      Client roClient = ClientSingleton.GetClient();
      if (roClient != null)
      {
        Stop();
        if (this.listCities == null || this.listCities.Count == 0) this.listCities = GlobalVariablesHelper.CityList;
        this.thread = AutoSwitchThread(roClient);
        _4RThread.Start(this.thread);
      }
    }

    /// <summary>
    /// Busca a configuração de uma skill em ambos os mappings (exclusivo e genérico).
    /// </summary>
    private AutoSwitchConfig findSkillConfig(EffectStatusIDs skillId)
    {
      var config = autoSwitchMapping.FirstOrDefault(x => x.skillId == skillId);
      if (config == null)
      {
        config = autoSwitchGenericMapping.FirstOrDefault(x => x.skillId == skillId);
      }
      return config;
    }

    /// <summary>
    /// Verifica se QUALQUER tecla de pet configurada foi fisicamente pressionada pelo jogador
    /// após o tick especificado. PostMessage (ações automatizadas) NÃO dispara o hook,
    /// então apenas teclas FÍSICAS são detectadas.
    /// </summary>
    private bool detectManualPetKeyPress(long afterTick, List<EffectStatusIDs> petSkillIds)
    {
      var allPetConfigs = autoSwitchMapping.Concat(autoSwitchGenericMapping)
          .Where(x => petSkillIds.Contains(x.skillId));

      foreach (var cfg in allPetConfigs)
      {
        if (cfg.itemKey != Key.None)
        {
          Keys wk = (Keys)Enum.Parse(typeof(Keys), cfg.itemKey.ToString());
          if (KeyboardHook.WasKeyPressedAfter(wk, afterTick)) return true;
        }
        if (cfg.nextItemKey != Key.None)
        {
          Keys wk = (Keys)Enum.Parse(typeof(Keys), cfg.nextItemKey.ToString());
          if (KeyboardHook.WasKeyPressedAfter(wk, afterTick)) return true;
        }
      }
      return false;
    }

    public _4RThread AutoSwitchThread(Client c)
    {
      // Vajra state
      bool equipVajra = false;
      int contVajra = 0;

      List<EffectStatusIDs> effectStatusProcMapping = new List<EffectStatusIDs>
            {
                EffectStatusIDs.PROVOKE,
                EffectStatusIDs.OVERTHRUST,
                EffectStatusIDs.RECOGNIZEDSPELL,
                EffectStatusIDs.GN_CARTBOOST,
                EffectStatusIDs.MINDBREAKER
            };

      // === MÁQUINA DE ESTADOS PARA PET SKILLS ===
      PetState petState = PetState.IDLE;
      EffectStatusIDs currentPetSkill = EffectStatusIDs.PROVOKE;
      int petBuffGoneCount = 0;
      bool nextItemEquipped = false;
      const int BUFF_GONE_CONFIRM = 3;

      // === DETECÇÃO DE MORTE ===
      uint lastKnownHp = 0;

      // === DETECÇÃO DE INTERFERÊNCIA MANUAL ===
      long lastPetActionTick = DateTime.UtcNow.Ticks;

      // === VERIFICAÇÃO INICIAL DE BUFF AO LIGAR ===
      // Na primeira iteração, verifica se algum buff de pet JÁ está ativo.
      // Isso permite recuperação ao religar o programa (Off → On):
      // se o buff ainda existir, pula direto para BUFF_ACTIVE + Next Item.
      bool isFirstRun = true;

      _4RThread autoSwitchThread = new _4RThread(_ =>
      {
        List<AutoSwitchConfig> skillClone = new List<AutoSwitchConfig>(this.autoSwitchMapping.Where(x => x.itemKey != Key.None));
        List<AutoSwitchConfig> skillCloneGeneric = new List<AutoSwitchConfig>(this.autoSwitchGenericMapping.Where(x => x.itemKey != Key.None));
        string currentMap = c.ReadCurrentMap();
        bool hasAntiBot = hasBuff(c, EffectStatusIDs.ANTI_BOT);
        bool stopBuffsCity = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity;
        bool isInCityList = this.listCities.Contains(currentMap);
        bool hasOpenChat = c.ReadOpenChat();
        bool stopOpenChat = ProfileSingleton.GetCurrent().UserPreferences.stopWithChat;

        bool canSwitch = !hasAntiBot
            && !(hasOpenChat && stopOpenChat)
            && !(stopBuffsCity && isInCityList);

        if (KeyboardHookHelper.HandlePriorityKey())
          return 0;

        // === VERIFICAÇÃO INICIAL: BUFF JÁ ATIVO AO LIGAR ===
        // Roda UMA vez na primeira iteração.
        // Se o buff do pet já está ativo (ex: usuário religou o programa),
        // pula direto para BUFF_ACTIVE e pressiona Next Item.
        if (isFirstRun && canSwitch)
        {
          isFirstRun = false;

          for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
          {
            uint currentStatus = c.CurrentBuffStatusCode(i);
            if (currentStatus == uint.MaxValue) continue;

            EffectStatusIDs status = (EffectStatusIDs)currentStatus;

            if (effectStatusProcMapping.Contains(status))
            {
              var cfg = findSkillConfig(status);
              if (cfg != null && cfg.itemKey != Key.None)
              {
                currentPetSkill = status;

                if (cfg.nextItemKey != Key.None)
                {
                  this.equipNextItem(cfg.nextItemKey);
                  nextItemEquipped = true;
                }

                petState = PetState.BUFF_ACTIVE;
                lastPetActionTick = DateTime.UtcNow.Ticks;
                petBuffGoneCount = 0;
                break;
              }
            }
          }
        }

        // === DETECÇÃO DE MORTE ===
        uint currentHp = c.ReadCurrentHp();

        if (lastKnownHp > 0 && currentHp == 0)
        {
          petState = PetState.IDLE;
          nextItemEquipped = false;
          petBuffGoneCount = 0;
          lastPetActionTick = DateTime.UtcNow.Ticks;
        }

        lastKnownHp = currentHp;

        if (canSwitch)
        {
          // Check SP baixo para heal pet
          if (c.IsSpBelow(ProfileSingleton.GetCurrent().AutoSwitchHeal.spPercent) && c.IsHpAbove(10))
          {
            switchPet();
            petState = PetState.IDLE;
            nextItemEquipped = false;
            petBuffGoneCount = 0;
            lastPetActionTick = DateTime.UtcNow.Ticks;
          }

          // === FASE 1: VARREDURA DE BUFFS ATIVOS ===
          bool petBuffFound = false;

          for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
          {
            uint currentStatus = c.CurrentBuffStatusCode(i);
            if (currentStatus == uint.MaxValue) { continue; }

            EffectStatusIDs status = (EffectStatusIDs)currentStatus;

            if (petState != PetState.IDLE && status == currentPetSkill)
            {
              petBuffFound = true;
            }

            if (autoSwitchMapping.Exists(x => x.skillId == status))
            {
              skillClone = skillClone.Where(sk => sk.skillId != status).ToList();
            }

            if (autoSwitchGenericMapping.Exists(x => x.skillId == status))
            {
              skillCloneGeneric = skillCloneGeneric.Where(sk => sk.skillId != status).ToList();
            }

            // Vajra handling
            if (status == EffectStatusIDs.THURISAZ || status == EffectStatusIDs.FIGHTINGSPIRIT)
            {
              if (equipVajra)
              {
                equipVajra = false;
                var vajraCfg = findSkillConfig(EffectStatusIDs.THURISAZ);
                if (vajraCfg != null)
                {
                  this.equipNextItem(vajraCfg.nextItemKey);
                }
              }
              skillClone = validadeVajraSkills(skillClone, status);
            }
          }

          // === FASE 2: MÁQUINA DE ESTADOS DO PET ===
          switch (petState)
          {
            case PetState.SKILL_USED:
              if (petBuffFound)
              {
                if (!nextItemEquipped)
                {
                  var cfg = findSkillConfig(currentPetSkill);
                  if (cfg != null && cfg.nextItemKey != Key.None)
                  {
                    lastPetActionTick = DateTime.UtcNow.Ticks;
                    this.equipNextItem(cfg.nextItemKey);
                    nextItemEquipped = true;
                  }
                }
                petState = PetState.BUFF_ACTIVE;
                petBuffGoneCount = 0;
              }
              break;

            case PetState.BUFF_ACTIVE:
              if (petBuffFound)
              {
                // Buff ainda ativo — verificar interferência manual via hook
                if (detectManualPetKeyPress(lastPetActionTick, effectStatusProcMapping))
                {
                  var cfg = findSkillConfig(currentPetSkill);
                  if (cfg != null && cfg.nextItemKey != Key.None)
                  {
                    Thread.Sleep(switchEquipDelay);
                    lastPetActionTick = DateTime.UtcNow.Ticks;
                    this.equipNextItem(cfg.nextItemKey);
                  }
                }
                petBuffGoneCount = 0;
              }
              else
              {
                petBuffGoneCount++;
                if (petBuffGoneCount >= BUFF_GONE_CONFIRM)
                {
                  // Buff expirou (confirmado 3x consecutivas).
                  // Volta para IDLE para re-invocar o pet no próximo ciclo.
                  petState = PetState.IDLE;
                  nextItemEquipped = false;
                  petBuffGoneCount = 0;
                }
              }
              break;
          }

          // === FASE 3: PROCESSAR BUFFS FALTANTES ===
          var order = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder;
          skillClone.AddRange(skillCloneGeneric);

          skillClone = skillClone
              .OrderBy(p => order.IndexOf(p.skillId) == -1 ? int.MaxValue : order.IndexOf(p.skillId))
              .ToList();

          skillClone = skillClone.Where(p => p == skillClone.FirstOrDefault() || !order.Contains(p.skillId)).ToList();

          foreach (var skill in skillClone)
          {
            if (effectStatusProcMapping.Contains(skill.skillId) && skill.itemKey != Key.None)
            {
              if (petState == PetState.IDLE)
              {
                currentPetSkill = skill.skillId;
                Thread.Sleep(switchEquipDelay);
                lastPetActionTick = DateTime.UtcNow.Ticks;
                this.useAutobuff(skill.itemKey, skill.skillKey);
                petState = PetState.SKILL_USED;
                nextItemEquipped = false;
                petBuffGoneCount = 0;
              }
            }
            else if (skill.skillId == EffectStatusIDs.THURISAZ || skill.skillId == EffectStatusIDs.FIGHTINGSPIRIT)
            {
              contVajra++;

              if (contVajra > 50) { contVajra = 0; equipVajra = false; }

              if (!equipVajra)
              {
                Thread.Sleep(delay);
                this.useAutobuff(skill.itemKey, skill.skillKey);
                equipVajra = true;
              }
            }
            else if (c.ReadCurrentSp() > 8)
            {
              this.useAutobuff(skill.itemKey, skill.skillKey);
              Thread.Sleep(switchEquipDelay);

              bool buffDetected = false;
              int maxAttempts = 10;
              int attempts = 0;

              while (!buffDetected && attempts < maxAttempts)
              {
                if (hasBuff(c, skill.skillId))
                {
                  buffDetected = true;
                  this.equipNextItem(skill.nextItemKey);
                  Thread.Sleep(switchEquipDelay);
                }
                else
                {
                  Thread.Sleep(500);
                  attempts++;
                }
              }

              if (!buffDetected)
              {
                this.equipNextItem(skill.nextItemKey);
                Thread.Sleep(switchEquipDelay);
              }
            }
          }
        }
        Thread.Sleep(delay);
        return 0;

      });

      return autoSwitchThread;
    }

    private List<AutoSwitchConfig> validadeVajraSkills(List<AutoSwitchConfig> skillClone, EffectStatusIDs status)
    {
      if (status == EffectStatusIDs.THURISAZ)
      {
        if (autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.FIGHTINGSPIRIT))
        {
          skillClone = skillClone.Where(skill => skill.skillId != EffectStatusIDs.FIGHTINGSPIRIT).ToList();
        }
      }

      if (status == EffectStatusIDs.FIGHTINGSPIRIT)
      {
        if (autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.THURISAZ))
        {
          skillClone = skillClone.Where(skill => skill.skillId != EffectStatusIDs.THURISAZ).ToList();
        }
      }

      return skillClone;
    }

    private bool hasBuff(Client c, EffectStatusIDs buff)
    {
      for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
      {
        uint currentStatus = c.CurrentBuffStatusCode(i);
        if (currentStatus == (int)buff) { return true; }
      }
      return false;
    }

    public void ClearKeyMapping()
    {
      buffMapping.Clear();
    }

    public void Stop()
    {
      if (this.thread != null)
      {
        _4RThread.Stop(this.thread);
      }
    }

    public string GetConfiguration()
    {
      return JsonConvert.SerializeObject(this);
    }

    public string GetActionName()
    {
      return ACTION_NAME_AUTOSWITCH;
    }

    private void useAutobuff(Key item, Key skill)
    {
      if ((item != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
        Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), item.ToString()), 0);
      Thread.Sleep(switchEquipDelay);
      if ((skill != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
        Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), skill.ToString()), 0);
    }

    private void equipNextItem(Key next)
    {
      if ((next != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
        Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), next.ToString()), 0);
    }

    public void SetAutoSwitchOrder(List<EffectStatusIDs> buffs)
    {
      this.autoSwitchOrder = buffs;
    }

    private void pressKey(Key key)
    {
      if ((key != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
      {
        Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), key.ToString()), 0);
      }
    }
    private void switchPet()
    {
      pressKey(ProfileSingleton.GetCurrent().AutoSwitchHeal.itemKey);
      Thread.Sleep(1500);
      foreach (var i in Enumerable.Range(0, ProfileSingleton.GetCurrent().AutoSwitchHeal.qtdSkill))
      {
        pressKey(ProfileSingleton.GetCurrent().AutoSwitchHeal.skillKey);
        Thread.Sleep(ProfileSingleton.GetCurrent().AutoSwitchHeal.switchDelay);
      }
      pressKey(ProfileSingleton.GetCurrent().AutoSwitchHeal.nextItemKey);
      Thread.Sleep(ProfileSingleton.GetCurrent().AutoSwitch.switchEquipDelay);
    }
  }
}