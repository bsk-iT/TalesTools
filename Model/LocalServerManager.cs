using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _4RTools.Model
{
    internal class LocalServerManager
    {

        private static readonly string localServerName = "supported_servers.json";
        private static readonly string localCityName = "city_name.json";
        private static List<String> cityList;

        private static string GetLocalServerFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localServerName);
        }

        public static void AddServer(string hpAddress, string nameAddress, string processName)
        {
            if (!isValid(hpAddress))
            {
                throw new ArgumentException("HP Address is Invalid. Please type a valid Hex value.");
            }

            if (!isValid(nameAddress))
            {
                throw new ArgumentException("Name Address is Invalid. Please type a valid Hex value.");
            }
            ClientDTO dto = new ClientDTO(processName, null, hpAddress, nameAddress, null);
            ClientListSingleton.AddClient(new Client(dto));

            List<ClientDTO> clients = GetLocalClients();
            clients.Add(dto);
            OverwriteLocalFile(clients);
        }

        public static void RemoveClient(ClientDTO dto)
        {
            List<ClientDTO> clients = GetLocalClients();
            clients.RemoveAt(dto.index);
            OverwriteLocalFile(clients);
            ClientListSingleton.RemoveClient(Client.FromDTO(dto));
        }

        private static void OverwriteLocalFile(List<ClientDTO> clients)
        {
            string filePath = GetLocalServerFilePath();
            string output = JsonConvert.SerializeObject(clients, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }


        private static string LoadLocalServerFile()
        {
            string filePath = GetLocalServerFilePath();

            // JSON padrão atualizado incluindo novos campos x_pos_offset e entity_list_offset
            string startJson = "[\r\n  {\r\n    \"name\": \"rtales.bin\",\r\n    \"description\": \"Ragna Tales\",\r\n    \"hpAddress\": \"0x015874D0\",\r\n    \"nameAddress\": \"0x0158A120\",\r\n    \"mapAddress\": \"0x01583574\",\r\n    \"x_pos_offset\": \"0x0156FD4C\",\r\n    \"entity_list_offset\": \"0x00D9FE2C\"\r\n  }\r\n]";

            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, startJson);
                    return startJson;
                }

                string json = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(json) || json.Length < 10)
                {
                    File.WriteAllText(filePath, startJson);
                    return startJson;
                }
                return json;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"LoadLocalServerFile error reading '{filePath}': {ex.Message}");
#endif
                // fallback para padrão embutido
                return startJson;
            }
        }

        public static List<ClientDTO> GetLocalClients()
        {
            string localServers = LoadLocalServerFile();

            if (string.IsNullOrEmpty(localServers)) return new List<ClientDTO>();

            try
            {
                return JsonConvert.DeserializeObject<List<ClientDTO>>(localServers);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"Failed to deserialize {localServerName}: {ex.Message}");
                Debug.WriteLine("Backing up invalid file and restoring default.");
#endif
                // criar backup para análise
                try
                {
                    string filePath = GetLocalServerFilePath();
                    string backupPath = filePath + ".invalid." + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                    if (File.Exists(filePath))
                        File.Copy(filePath, backupPath);
                    // regravar padrão
                    File.WriteAllText(filePath, LoadLocalServerFile());
                }
                catch (Exception inner)
                {
#if DEBUG
                    Debug.WriteLine($"Error during recovery of supported_servers.json: {inner.Message}");
#endif
                }
                return new List<ClientDTO>();
            }
        }

        // Retorna o caminho do arquivo city_name.json ao lado do executável
        private static string GetLocalCityFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localCityName);
        }

        // Carrega ou cria o arquivo city_name.json com um conteúdo padrão
        private static string LoadLocalCityNameFile()
        {
            string filePath = GetLocalCityFilePath();
            string startJson = "[\r\n  \"prontera\",\r\n  \"morocc\",\r\n  \"geffen\",\r\n  \"payon\",\r\n  \"alberta\",\r\n  \"izlude\",\r\n  \"aldebaran\",\r\n  \"xmas\",\r\n  \"comodo\",\r\n  \"yuno\",\r\n  \"amatsu\",\r\n  \"gonryun\",\r\n  \"umbala\",\r\n  \"niflheim\",\r\n  \"louyang\",\r\n  \"jawaii\",\r\n  \"ayothaya\",\r\n  \"einbroch\",\r\n  \"lighthalzen\",\r\n  \"einbech\",\r\n  \"hugel\",\r\n  \"rachel\",\r\n  \"veins\",\r\n  \"moscovia\",\r\n  \"brasilis\",\r\n  \"harboro1\",\r\n  \"wave_vip\",\r\n  \"moc_para01\",\r\n  \"party_room\",\r\n  \"market_01\",\r\n  \"market_02\",\r\n  \"verus04\",\r\n  \"map_events\",\r\n  \"pay_arche\",\r\n  \"ecl_tdun04\",\r\n  \"purgatory\",\r\n  \"prt_monk\"\r\n]";

      try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, startJson);
                    return startJson;
                }

                string json = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(json) || json.Length < 10)
                {
                    File.WriteAllText(filePath, startJson);
                    return startJson;
                }
                return json;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"LoadLocalCityNameFile error reading '{filePath}': {ex.Message}");
#endif
                return startJson;
            }
        }

        // Retorna a lista de cidades (cacheada)
        public static List<string> GetListCities()
        {
            if (cityList == null || cityList.Count == 0)
            {
                string json = LoadLocalCityNameFile();
                if (string.IsNullOrEmpty(json))
                    return new List<string>();

                try
                {
                    cityList = JsonConvert.DeserializeObject<List<string>>(json);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debug.WriteLine($"Failed to deserialize {localCityName}: {ex.Message}");
#endif
                    cityList = new List<string>();
                }
            }
            return cityList;
        }

        private static string CleanHexString(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            s = s.Trim();
            if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                s = s.Substring(2);
            return s;
        }

        private static bool isValid(IEnumerable<char> chars)
        {
            // Normaliza entrada (pode vir com "0x")
            string s = new string(chars.ToArray());
            string cleaned = CleanHexString(s);
            return IsHex(cleaned) && cleaned.Length == 8;
        }

        public static bool IsHex(IEnumerable<char> chars)
        {
            if (chars == null) return false;
            foreach (var c in chars)
            {
                bool isHex = ((c >= '0' && c <= '9') ||
                             (c >= 'a' && c <= 'f') ||
                             (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return true;
        }
    }
}