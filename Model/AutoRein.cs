using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using _4RTools.Utils;

namespace _4RTools.Model
{
    public class AutoRein : Action
    {
        public static string ACTION_NAME_AUTOREIN = "AutoRein";
        private _4RThread thread;
        public int checkDelay { get; set; } = 50; // Verificar a cada 50ms

        [JsonIgnore]
        public List<String> listCities { get; set; }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                Stop();
                if (this.listCities == null || this.listCities.Count == 0)
                    this.listCities = LocalServerManager.GetListCities();

                this.thread = AutoReinThread(roClient);
                _4RThread.Start(this.thread);
            }
        }

        public _4RThread AutoReinThread(Client c)
        {
            _4RThread autoReinThread = new _4RThread(_ =>
            {
                try
                {
                    // ===== USAR SISTEMA INTEGRADO DO CLIENT =====
                    // O processamento da rédea automática com validação de desmonte manual
                    // agora é feito diretamente no Client através do método ProcessAutoRein()
                    c.ProcessAutoRein();

                    return checkDelay;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Erro no AutoRein thread: {ex.Message}");
                    return checkDelay;
                }
            });

            return autoReinThread;
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
            return ACTION_NAME_AUTOREIN;
        }
    }
}