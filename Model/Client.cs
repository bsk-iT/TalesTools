using _4RTools.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace _4RTools.Model
{

    public class ClientDTO
    {
        public int index { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string hpAddress { get; set; }
        public string nameAddress { get; set; }
        public string mapAddress { get; set; }

        // Novos offsets para Debug e coordenadas precisas
        public string x_pos_offset { get; set; }
        public string entity_list_offset { get; set; }

        public int hpAddressPointer { get; set; }
        public int nameAddressPointer { get; set; }
        public int mapAddressPointer { get; set; }
        public int x_pos_offsetPointer { get; set; }
        public int entity_list_offsetPointer { get; set; }

        public ClientDTO() { }

        public ClientDTO(string name, string description, string hpAddress, string nameAddress, string mapAddress,
                        string x_pos_offset = null, string entity_list_offset = null)
        {
            this.name = name;
            this.description = description;
            this.hpAddress = hpAddress;
            this.nameAddress = nameAddress;
            this.mapAddress = mapAddress;
            this.x_pos_offset = x_pos_offset;
            this.entity_list_offset = entity_list_offset;

            this.hpAddressPointer = Convert.ToInt32(hpAddress, 16);
            this.nameAddressPointer = Convert.ToInt32(nameAddress, 16);
            this.mapAddressPointer = Convert.ToInt32(mapAddress, 16);

            // Converter novos offsets se disponíveis
            if (!string.IsNullOrEmpty(x_pos_offset))
                this.x_pos_offsetPointer = Convert.ToInt32(x_pos_offset, 16);
            if (!string.IsNullOrEmpty(entity_list_offset))
                this.entity_list_offsetPointer = Convert.ToInt32(entity_list_offset, 16);
        }
    }

    public sealed class ClientListSingleton
    {
        private static List<Client> clients = new List<Client>();

        public static void AddClient(Client c)
        {
            clients.Add(c);
        }

        public static void RemoveClient(Client c)
        {
            clients.Remove(c);
        }

        public static List<Client> GetAll()
        {
            return clients;
        }

        public static bool ExistsByProcessName(string processName)
        {
            return clients.Exists(client => client.processName == processName);
        }
    }

    public sealed class ClientSingleton
    {
        private static Client client;
        private ClientSingleton(Client client)
        {
            ClientSingleton.client = client;
        }

        public static ClientSingleton Instance(Client client)
        {
            return new ClientSingleton(client);
        }

        public static Client GetClient()
        {
            return client;
        }
    }

    public class Client
    {
        public Process process { get; }

        public string processName { get; private set; }
        private Utils.ProcessMemoryReader PMR { get; set; }
        public int currentNameAddress { get; set; }
        public int currentHPBaseAddress { get; set; }
        public int currentMapAddress { get; set; }
        private int statusBufferAddress { get; set; }
        private int currentOpenChatAddress { get; set; }
        private int _num = 0;

        // Novos endereços para coordenadas e entity list
        private int currentXPosAddress { get; set; }
        private int currentEntityListAddress { get; set; }

        // Propriedades para rastreamento de movimento e rédea automática
        private DateTime lastPositionCheck = DateTime.Now;
        private bool isMoving = false;
        private List<Tuple<uint, uint, DateTime>> positionHistory = new List<Tuple<uint, uint, DateTime>>();
        private uint lastX = 0;
        private uint lastY = 0;
        private int moveCounter = 0;
        private DateTime lastMoveTime = DateTime.Now;

        // ===== SISTEMA DE CACHE DE COORDENADAS =====
        private DateTime lastCoordinateRead = DateTime.MinValue;
        private uint cachedX = 0;
        private uint cachedY = 0;
        private const int COORDINATE_CACHE_DURATION_MS = 20; // Cache por 20ms para otimizar performance

        // ===== SISTEMA DE RÉDEA AUTOMÁTICA INTEGRADO =====
        private DateTime lastAutoReinCheck = DateTime.MinValue;
        private DateTime lastAutoReinUse = DateTime.MinValue;
        private bool autoReinInProgress = false;
        private const int AUTO_REIN_CHECK_INTERVAL_MS = 50; // Verificar a cada 50ms
        private const int AUTO_REIN_COOLDOWN_MS = 2000; // Cooldown de 1 segundos entre uses

        // ===== SISTEMA DE VALIDAÇÃO PARA DESMONTE MANUAL =====
        private bool wasMountedLastCheck = false;
        private bool manualDismountDetected = false;
        private DateTime manualDismountTime = DateTime.MinValue;
        private uint dismountPositionX = 0;
        private uint dismountPositionY = 0;
        private int cellsWalkedSinceDismount = 0;
        private bool autoReinTemporarilySuspended = false;

        // novo campo para contar passos adjacentes (evita contar teleporte)
        private uint lastStepPosX = 0;
        private uint lastStepPosY = 0;

        // Flag para debug - só executa uma vez
        private static bool debugExecuted = false;

        public Client(string processName, int currentHPBaseAddress, int currentNameAddress, int currentMapAddress)
        {
            this.currentNameAddress = currentNameAddress;
            this.currentHPBaseAddress = currentHPBaseAddress;
            this.currentMapAddress = currentMapAddress;
            this.processName = processName;
            this.statusBufferAddress = currentHPBaseAddress + 0x474;
            this.currentOpenChatAddress = 0x012A714C;
        }

        public Client(ClientDTO dto)
        {
            this.processName = dto.name;
            this.currentHPBaseAddress = Convert.ToInt32(dto.hpAddress, 16);
            this.currentNameAddress = Convert.ToInt32(dto.nameAddress, 16);
            this.currentMapAddress = Convert.ToInt32(dto.mapAddress, 16);
            this.statusBufferAddress = this.currentHPBaseAddress + 0x474;
            this.currentOpenChatAddress = 0x012A714C;

            // Debug apenas em modo debug (remover logs excessivos)
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"=== CONSTRUINDO CLIENT COM DTO ===");
            System.Diagnostics.Debug.WriteLine($"DTO Name: {dto.name}");
            System.Diagnostics.Debug.WriteLine($"DTO x_pos_offset string: '{dto.x_pos_offset}'");
            System.Diagnostics.Debug.WriteLine($"DTO x_pos_offset IsNull: {string.IsNullOrEmpty(dto.x_pos_offset)}");
#endif

            // Configurar novos offsets se disponíveis
            this.currentXPosAddress = !string.IsNullOrEmpty(dto.x_pos_offset) ?
                Convert.ToInt32(dto.x_pos_offset, 16) : 0;
            this.currentEntityListAddress = !string.IsNullOrEmpty(dto.entity_list_offset) ?
                Convert.ToInt32(dto.entity_list_offset, 16) : 0;

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Client construído - XPosAddress: 0x{this.currentXPosAddress:X8}");
            System.Diagnostics.Debug.WriteLine($"=== FIM CONSTRUÇÃO DTO ===");
#endif
        }

        public Client(string processName)
        {
            PMR = new Utils.ProcessMemoryReader();
            string rawProcessName = processName.Split(new string[] { ".exe - " }, StringSplitOptions.None)[0];
            int choosenPID = int.Parse(processName.Split(new string[] { ".exe - " }, StringSplitOptions.None)[1]);

            foreach (Process process in Process.GetProcessesByName(rawProcessName))
            {
                if (choosenPID == process.Id)
                {
                    this.process = process;
                    PMR.ReadProcess = process;
                    PMR.OpenProcess();

                    try
                    {
                        Client c = GetClientByProcess(rawProcessName);

                        if (c == null) throw new Exception();

                        this.currentHPBaseAddress = c.currentHPBaseAddress;
                        this.currentNameAddress = c.currentNameAddress;
                        this.currentMapAddress = c.currentMapAddress;
                        this.statusBufferAddress = c.statusBufferAddress;
                        this.currentOpenChatAddress = c.currentOpenChatAddress;

                        // Garantir que os novos offsets sejam copiados
                        this.currentXPosAddress = c.currentXPosAddress;
                        this.currentEntityListAddress = c.currentEntityListAddress;

#if DEBUG
                        System.Diagnostics.Debug.WriteLine($"Cliente encontrado - XPosAddress: 0x{this.currentXPosAddress:X8}");
#endif
                    }
                    catch
                    {
                        MessageBox.Show("This client is not supported. Only Spammers and macro will works.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.currentHPBaseAddress = 0;
                        this.currentNameAddress = 0;
                        this.currentMapAddress = 0;
                        this.statusBufferAddress = 0;
                        this.currentOpenChatAddress = 0;
                        this.currentXPosAddress = 0;
                        this.currentEntityListAddress = 0;

#if DEBUG
                        System.Diagnostics.Debug.WriteLine("Cliente não suportado - offsets zerados");
#endif
                    }

                    //Do not block spammer for non supported Versions
                }
            }
        }

        // Método para debug detalhado da configuração do cliente
        public void DebugClientConfiguration()
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("=== DEBUG CLIENT CONFIGURATION ===");
            System.Diagnostics.Debug.WriteLine($"ProcessName: {this.processName}");
            System.Diagnostics.Debug.WriteLine($"CurrentHPBaseAddress: 0x{this.currentHPBaseAddress:X8}");
            System.Diagnostics.Debug.WriteLine($"CurrentXPosAddress: 0x{this.currentXPosAddress:X8}");
            System.Diagnostics.Debug.WriteLine($"PMR Status: {(PMR != null ? "Configurado" : "Não configurado")}");
            System.Diagnostics.Debug.WriteLine($"Process Status: {(process != null ? $"PID: {process.Id}" : "Não configurado")}");

            // Verificar se existe cliente no singleton
            var clientsInSingleton = ClientListSingleton.GetAll();
            System.Diagnostics.Debug.WriteLine($"Clientes no singleton: {clientsInSingleton.Count}");

            foreach (var client in clientsInSingleton)
            {
                System.Diagnostics.Debug.WriteLine($"  Cliente: {client.processName}, XPos: 0x{client.currentXPosAddress:X8}");
            }
            System.Diagnostics.Debug.WriteLine("=== FIM DEBUG ===");
#endif
        }

        private string ReadMemoryAsString(int address)
        {
            if (address == 0 || PMR == null) return "";

            try
            {
                byte[] bytes = PMR.ReadProcessMemory((IntPtr)address, 40u, out _num);
                List<byte> buffer = new List<byte>(); //Need a list with dynamic size 
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] == 0) break; //Check Nullability based ON ASCII Table

                    buffer.Add(bytes[i]); //Add only bytes needed
                }

                return Encoding.Default.GetString(buffer.ToArray());
            }
            catch
            {
                return "";
            }
        }

        private uint ReadMemory(int address)
        {
            if (address == 0 || PMR == null) return 0;

            try
            {
                return BitConverter.ToUInt32(PMR.ReadProcessMemory((IntPtr)address, 4u, out _num), 0);
            }
            catch
            {
                return 0;
            }
        }

        public byte ReadMemoryAsByte(int address)
        {
            if (address == 0 || PMR == null) return 0;

            try
            {
                byte[] bytes = PMR.ReadProcessMemory((IntPtr)address, 1, out _num);
                return bytes[0];
            }
            catch
            {
                return 0;
            }
        }

        public void WriteMemory(int address, uint intToWrite)
        {
            if (address == 0 || PMR == null) return;

            try
            {
                PMR.WriteProcessMemory((IntPtr)address, BitConverter.GetBytes(intToWrite), out _num);
            }
            catch { }
        }

        public void WriteMemory(int address, byte[] bytesToWrite)
        {
            if (address == 0 || PMR == null) return;

            try
            {
                PMR.WriteProcessMemory((IntPtr)address, bytesToWrite, out _num);
            }
            catch { }
        }

        public bool IsHpBelow(int percent)
        {
            uint currentHp = ReadCurrentHp();
            uint maxHp = ReadMaxHp();
            if (maxHp == 0) return false;
            return currentHp * 100 < percent * maxHp;
        }

        public bool IsSpBelow(int percent)
        {
            uint currentSp = ReadCurrentSp();
            uint maxSp = ReadMaxSp();
            if (maxSp == 0) return false;
            return currentSp * 100 < percent * maxSp;
        }

        public bool IsHpAbove(int percent)
        {
            uint currentHp = ReadCurrentHp();
            uint maxHp = ReadMaxHp();
            if (maxHp == 0) return false;
            return currentHp * 100 > percent * maxHp;
        }

        public bool IsSpAbove(int percent)
        {
            uint currentSp = ReadCurrentSp();
            uint maxSp = ReadMaxSp();
            if (maxSp == 0) return false;
            return currentSp * 100 > percent * maxSp;
        }

        public uint ReadCurrentHp()
        {
            return ReadMemory(this.currentHPBaseAddress);
        }

        public uint ReadCurrentSp()
        {
            return ReadMemory(this.currentHPBaseAddress + 8);
        }

        public uint ReadMaxHp()
        {
            return ReadMemory(this.currentHPBaseAddress + 4);
        }

        public string ReadCharacterName()
        {
            return ReadMemoryAsString(this.currentNameAddress);
        }

        public string ReadCurrentMap()
        {
            return ReadMemoryAsString(this.currentMapAddress);
        }

        public bool ReadOpenChat()
        {
            try
            {
                return Convert.ToBoolean(ReadMemoryAsByte(this.currentOpenChatAddress));
            }
            catch
            {
                return false;
            }
        }

        public uint ReadMaxSp()
        {
            return ReadMemory(this.currentHPBaseAddress + 12);
        }

        public uint CurrentBuffStatusCode(int effectStatusIndex)
        {
            return ReadMemory(this.statusBufferAddress + effectStatusIndex * 4);
        }

        // ===== MÉTODOS DIRETOS PARA COORDENADAS (FALLBACK) =====
        private uint ReadCurrentXDirect()
        {
            try
            {
                // Usar diretamente o offset 0x0156FD4C
                int directAddress = 0x0156FD4C;
                return ReadMemory(directAddress);
            }
            catch
            {
                return 0;
            }
        }

        private uint ReadCurrentYDirect()
        {
            try
            {
                // Y seria X + 4
                int directAddress = 0x0156FD4C + 4;
                return ReadMemory(directAddress);
            }
            catch
            {
                return 0;
            }
        }

        // ===== MÉTODOS PRINCIPAIS COM CACHE DE COORDENADAS =====

        /// <summary>
        /// Lê as coordenadas X e Y com sistema de cache para otimizar performance
        /// </summary>
        private void UpdateCoordinateCache()
        {
            DateTime now = DateTime.Now;

            // Verificar se o cache ainda é válido
            if ((now - lastCoordinateRead).TotalMilliseconds < COORDINATE_CACHE_DURATION_MS)
                return;

            try
            {
                // Chamar debug apenas na primeira vez
                if (!debugExecuted)
                {
                    DebugClientConfiguration();
                    debugExecuted = true;
                }

                uint newX, newY;

                if (currentXPosAddress == 0)
                {
                    // Usar método direto se offset não configurado
                    newX = ReadCurrentXDirect();
                    newY = ReadCurrentYDirect();
                }
                else
                {
                    // Usar offset específico se disponível
                    newX = ReadMemory(currentXPosAddress);
                    newY = ReadMemory(currentXPosAddress + 4);
                }

                // Atualizar cache
                cachedX = newX;
                cachedY = newY;
                lastCoordinateRead = now;

#if DEBUG
                // Debug apenas se as coordenadas mudaram (reduzir spam no log)
                if (cachedX != lastX || cachedY != lastY)
                {
                    System.Diagnostics.Debug.WriteLine($"Coordenadas atualizadas: X={cachedX}, Y={cachedY}");
                }
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro ao atualizar cache de coordenadas: {ex.Message}");
#endif
                cachedX = 0;
                cachedY = 0;
            }
        }

        /// <summary>
        /// Lê a coordenada X atual com cache otimizado
        /// </summary>
        public uint ReadCurrentX()
        {
            UpdateCoordinateCache();
            return cachedX;
        }

        /// <summary>
        /// Lê a coordenada Y atual com cache otimizado
        /// </summary>
        public uint ReadCurrentY()
        {
            UpdateCoordinateCache();
            return cachedY;
        }

        /// <summary>
        /// Força a atualização do cache de coordenadas (útil para debug ou situações especiais)
        /// </summary>
        public void ForceUpdateCoordinates()
        {
            lastCoordinateRead = DateTime.MinValue;
            UpdateCoordinateCache();
        }

        /// <summary>
        /// Obtém as coordenadas X e Y em uma única chamada
        /// </summary>
        public (uint X, uint Y) GetCurrentPosition()
        {
            UpdateCoordinateCache();
            return (cachedX, cachedY);
        }

        // ===== MÉTODOS DE RASTREAMENTO DE MOVIMENTO OTIMIZADOS =====

        /// <summary>
        /// Método para rastreamento de movimento em células
        /// OBS: agora contabiliza apenas passos adjacentes (distância Chebyshev == 1).
        /// Saltos maiores são considerados teleporte e não incrementam contador.
        /// </summary>
        public bool HasPlayerMovedCells(int requiredCells)
        {
            try
            {
                // proteção nula
                if (ProfileSingleton.GetCurrent() == null || ProfileSingleton.GetCurrent().UserPreferences == null)
                    return false;

                var (currentX, currentY) = GetCurrentPosition();

                // Inicializa referência de passo se necessário
                if (lastStepPosX == 0 && lastStepPosY == 0)
                {
                    lastStepPosX = currentX;
                    lastStepPosY = currentY;
                }

                int dx = Math.Abs((int)currentX - (int)lastStepPosX);
                int dy = Math.Abs((int)currentY - (int)lastStepPosY);
                int cheb = Math.Max(dx, dy);

                if (cheb == 1)
                {
                    // passo válido -> conta 1 célula e atualiza referência
                    cellsWalkedSinceDismount++;
                    lastStepPosX = currentX;
                    lastStepPosY = currentY;
                }
                else if (cheb > 1)
                {
                    // teleporte / salto -> atualiza referência mas não conta
                    lastStepPosX = currentX;
                    lastStepPosY = currentY;
                }
                // cheb == 0 -> não houve movimento

                return cellsWalkedSinceDismount >= requiredCells;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica se o jogador se moveu desde a última verificação
        /// esta implementação incrementa moveCounter apenas para passos adjacentes
        /// </summary>
        public bool HasPlayerMoved()
        {
            try
            {
                var (currentX, currentY) = GetCurrentPosition();

                // Verificar se as coordenadas mudaram
                if (currentX != lastX || currentY != lastY)
                {
                    int dx = Math.Abs((int)currentX - (int)lastX);
                    int dy = Math.Abs((int)currentY - (int)lastY);
                    int cheb = Math.Max(dx, dy);

                    // Só contar como movimento “um passo” se for adjacente (cheb == 1)
                    if (cheb == 1)
                    {
                        lastX = currentX;
                        lastY = currentY;
                        lastMoveTime = DateTime.Now;
                        moveCounter++;
                        return true;
                    }
                    else
                    {
                        // salto/teleporte -> atualiza posição de referência, não conta
                        lastX = currentX;
                        lastY = currentY;
                        lastMoveTime = DateTime.Now;
                        return false;
                    }
                }

                // Reset counter se não se moveu por mais de 5 segundos
                if ((DateTime.Now - lastMoveTime).TotalSeconds > 5)
                {
                    moveCounter = 0;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public int GetMoveCounter()
        {
            return moveCounter;
        }

        public void ResetMoveCounter()
        {
            moveCounter = 0;
            positionHistory.Clear(); // Limpar histórico também
            // resetar contador de passos usados para rédea
            cellsWalkedSinceDismount = 0;
            lastStepPosX = 0;
            lastStepPosY = 0;
        }

        public bool HasMountStatus()
        {
            try
            {
                // ID 613 = status de montaria (RIDDING)
                for (int i = 0; i < 32; i++)
                {
                    uint statusCode = CurrentBuffStatusCode(i);
                    if (statusCode == 613)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // ===== SISTEMA DE VALIDAÇÃO PARA DESMONTE MANUAL =====

        /// <summary>
        /// Detecta se o usuário desmontou manualmente da rédea
        /// Verifica se o personagem estava montado e agora não está mais, sem ter sido por ação automática
        /// </summary>
        private void DetectManualDismount()
        {
            try
            {
                bool currentlyMounted = HasMountStatus();

                // Se estava montado na verificação anterior e agora não está mais
                if (wasMountedLastCheck && !currentlyMounted)
                {
                    // Verificar se não foi por ação automática (skill spammer, por exemplo)
                    // Se não há processo automático em andamento, assume que foi desmonte manual
                    if (!autoReinInProgress)
                    {
                        var (currentX, currentY) = GetCurrentPosition();

                        manualDismountDetected = true;
                        manualDismountTime = DateTime.Now;
                        dismountPositionX = currentX;
                        dismountPositionY = currentY;
                        cellsWalkedSinceDismount = 0;
                        autoReinTemporarilySuspended = true;

                        // inicializar referência de passo com a posição de desmonte
                        lastStepPosX = dismountPositionX;
                        lastStepPosY = dismountPositionY;

#if DEBUG
                        System.Diagnostics.Debug.WriteLine($"DESMONTE MANUAL DETECTADO! Posição: X={currentX}, Y={currentY}");
#endif
                    }
                }

                // Atualizar estado anterior
                wasMountedLastCheck = currentlyMounted;

                // Reset da flag se montou novamente (por qualquer meio)
                if (currentlyMounted)
                {
                    autoReinInProgress = false;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro na detecção de desmonte manual: {ex.Message}");
#endif
            }
        }

        /// <summary>
        /// Calcula quantas células o jogador andou desde o desmonte manual
        /// Implementação alterada: conta apenas passos adjacentes.
        /// </summary>
        private void UpdateCellsWalkedSinceDismount()
        {
            try
            {
                if (!manualDismountDetected)
                    return;

                var (currentX, currentY) = GetCurrentPosition();

                // Se ainda não inicializamos a referência de passos, use a posição de desmonte
                if (lastStepPosX == 0 && lastStepPosY == 0)
                {
                    lastStepPosX = dismountPositionX;
                    lastStepPosY = dismountPositionY;
                }

                int dx = Math.Abs((int)currentX - (int)lastStepPosX);
                int dy = Math.Abs((int)currentY - (int)lastStepPosY);
                int cheb = Math.Max(dx, dy);

                if (cheb == 1)
                {
                    // passo válido -> conta uma célula e atualiza referência
                    cellsWalkedSinceDismount++;
                    lastStepPosX = currentX;
                    lastStepPosY = currentY;

#if DEBUG
                    System.Diagnostics.Debug.WriteLine($"Células andadas desde desmonte: {cellsWalkedSinceDismount}");
#endif
                }
                else if (cheb > 1)
                {
                    // teleporte -> atualiza referência sem incrementar
                    lastStepPosX = currentX;
                    lastStepPosY = currentY;

#if DEBUG
                    System.Diagnostics.Debug.WriteLine($"Teleporte detectado (não conta): dx={dx}, dy={dy}");
#endif
                }
                // cheb == 0 -> nenhum movimento relevante
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro ao calcular células andadas: {ex.Message}");
#endif
            }
        }

        /// <summary>
        /// Verifica se deve reativar a rédea automática após desmonte manual
        /// </summary>
        private void CheckReactivateAutoRein()
        {
            try
            {
                if (!autoReinTemporarilySuspended || !manualDismountDetected)
                    return;

                var userPrefs = ProfileSingleton.GetCurrent()?.UserPreferences;
                if (userPrefs == null)
                    return;

                int requiredCells = userPrefs.autoReinCellCount;

                // Se andou as células necessárias, reativar a rédea automática
                if (cellsWalkedSinceDismount >= requiredCells)
                {
                    autoReinTemporarilySuspended = false;
                    manualDismountDetected = false;

                    // Resetar contadores
                    cellsWalkedSinceDismount = 0;
                    dismountPositionX = 0;
                    dismountPositionY = 0;
                    lastStepPosX = 0;
                    lastStepPosY = 0;

#if DEBUG
                    System.Diagnostics.Debug.WriteLine($"RÉDEA AUTOMÁTICA REATIVADA! Andou {requiredCells} células");
#endif
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro ao verificar reativação da rédea: {ex.Message}");
#endif
            }
        }

        /// <summary>
        /// Força a suspensão temporária da rédea automática (para integrar com skill spammers)
        /// Chame este método quando usar skill spammers que removem a montaria
        /// </summary>
        public void SuspendAutoReinTemporarily()
        {
            autoReinInProgress = true;

            // Não marcar como desmonte manual se foi ação automática
            if (HasMountStatus())
            {
                // Se estava montado, vai desmontar agora por ação automática
                var (currentX, currentY) = GetCurrentPosition();

                // Não é desmonte manual, então não suspender permanentemente
                manualDismountDetected = false;
                autoReinTemporarilySuspended = false;

                // reset referência de passos para evitar contagem indevida
                lastStepPosX = currentX;
                lastStepPosY = currentY;
                cellsWalkedSinceDismount = 0;
            }
        }

        // ===== SISTEMA DE RÉDEA AUTOMÁTICA INTEGRADO =====

        /// <summary>
        /// Verifica todas as condições para usar rédea automática
        /// </summary>
        private bool CanUseAutoRein()
        {
            try
            {
                // Verificar se está habilitado
                if (ProfileSingleton.GetCurrent()?.UserPreferences?.autoReinEnabled != true)
                    return false;

                // Verificar se está temporariamente suspenso por desmonte manual
                if (autoReinTemporarilySuspended)
                    return false;

                // Verificar se já está montado
                if (HasMountStatus())
                    return false;

                // Verificar antibot
                if (HasAntiBotBuff())
                    return false;

                // Verificar chat aberto
                bool hasOpenChat = ReadOpenChat();
                bool stopOpenChat = ProfileSingleton.GetCurrent().UserPreferences.stopWithChat;
                if (hasOpenChat && stopOpenChat)
                    return false;

                // Verificar cidade
                string currentMap = ReadCurrentMap();
                if (!string.IsNullOrEmpty(currentMap))
                {
                    bool stopBuffsCity = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity;
                    var cityList = LocalServerManager.GetListCities();
                    bool isInCityList = cityList?.Contains(currentMap) == true;
                    if (stopBuffsCity && isInCityList)
                        return false;
                }

                // Verificar cooldown
                DateTime now = DateTime.Now;
                if ((now - lastAutoReinUse).TotalMilliseconds < AUTO_REIN_COOLDOWN_MS)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica se tem o buff de antibot
        /// </summary>
        private bool HasAntiBotBuff()
        {
            try
            {
                for (int i = 1; i < Utils.Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
                {
                    uint currentStatus = CurrentBuffStatusCode(i);
                    if (currentStatus == (int)EffectStatusIDs.ANTI_BOT)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Método principal que deve ser chamado regularmente para verificar rédea automática
        /// Integrado ao AHK para máxima eficiência
        /// </summary>
        public void ProcessAutoRein()
        {
            try
            {
                DateTime now = DateTime.Now;

                // Detectar desmonte manual PRIMEIRO
                DetectManualDismount();

                // Atualizar células andadas desde desmonte
                UpdateCellsWalkedSinceDismount();

                // Verificar se deve reativar rédea automática
                CheckReactivateAutoRein();

                // Verificar se é hora de checar auto rein
                if ((now - lastAutoReinCheck).TotalMilliseconds < AUTO_REIN_CHECK_INTERVAL_MS)
                    return;

                lastAutoReinCheck = now;

                // Verificar se pode usar rédea automática
                if (!CanUseAutoRein())
                    return;

                // Verificar movimento
                if (ShouldUseAutoRein())
                {
                    UseMountSkill();
                    lastAutoReinUse = now;

#if DEBUG
                    System.Diagnostics.Debug.WriteLine("Rédea automática ativada!");
#endif
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro no ProcessAutoRein: {ex.Message}");
#endif
            }
        }

        /// <summary>
        /// Método para usar rédea automática
        /// </summary>
        public void UseMountSkill()
        {
            try
            {
                if (ProfileSingleton.GetCurrent() != null &&
                    ProfileSingleton.GetCurrent().UserPreferences != null &&
                    this.process != null)
                {
                    var reinKey = ProfileSingleton.GetCurrent().UserPreferences.autoReinKey;

                    // Converter Key para Keys
                    System.Windows.Forms.Keys key = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), reinKey.ToString());

                    // Enviar comando para usar rédea
                    Utils.Interop.PostMessage(this.process.MainWindowHandle, Utils.Constants.WM_KEYDOWN_MSG_ID, key, 0);

                    // Limpar histórico de posições após usar rédea
                    positionHistory.Clear();
                    moveCounter = 0;
                    autoReinInProgress = true;

                    // resetar contador de passos e referência
                    cellsWalkedSinceDismount = 0;
                    lastStepPosX = 0;
                    lastStepPosY = 0;

                    // Aguardar um pouco para a animação da montaria
                    System.Threading.Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro ao usar rédea: {ex.Message}");
#endif
            }
        }

        public void RemoveMountStatus()
        {
            try
            {
                if (HasMountStatus() && ProfileSingleton.GetCurrent() != null &&
                    ProfileSingleton.GetCurrent().UserPreferences != null &&
                    this.process != null)
                {
                    var reinKey = ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey;

                    // Converter Key para Keys
                    System.Windows.Forms.Keys key = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), reinKey.ToString());

                    // Marcar como ação automática para não detectar como desmonte manual
                    SuspendAutoReinTemporarily();

                    // Usar a mesma implementação do AHK/AutoBuffSkill para enviar a tecla
                    Utils.Interop.PostMessage(this.process.MainWindowHandle, Utils.Constants.WM_KEYDOWN_MSG_ID, key, 0);

                    // Reset das flags de auto rein
                    positionHistory.Clear();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro ao desmontar: {ex.Message}");
#endif
            }
        }

        /// <summary>
        /// Método para verificar se deve usar rédea automática
        /// </summary>
        public bool ShouldUseAutoRein()
        {
            try
            {
                if (ProfileSingleton.GetCurrent() == null ||
                    ProfileSingleton.GetCurrent().UserPreferences == null)
                    return false;

                var userPrefs = ProfileSingleton.GetCurrent().UserPreferences;

                // Verificar se a rédea automática está habilitada
                if (!userPrefs.autoReinEnabled)
                    return false;

                // Verificar se está temporariamente suspenso
                if (autoReinTemporarilySuspended)
                    return false;

                // Verificar se já está montado
                if (HasMountStatus())
                    return false;

                int requiredCells = userPrefs.autoReinCellCount;
                return HasPlayerMovedCells(requiredCells);
            }
            catch
            {
                return false;
            }
        }

        // Método para ler lista de entidades (para Debug)
        public List<string> ReadEntityList()
        {
            List<string> entities = new List<string>();
            try
            {
                if (currentEntityListAddress > 0)
                {
                    // Implementação básica para leitura da entity list
                    // Aqui você implementaria a lógica específica para ler a lista de entidades
                    for (int i = 0; i < 10; i++) // Exemplo: ler as primeiras 10 entidades
                    {
                        uint entityId = ReadMemory(currentEntityListAddress + (i * 4));
                        if (entityId > 0 && entityId != uint.MaxValue)
                        {
                            entities.Add($"Entity_{entityId}");
                        }
                    }
                }
                else
                {
                    entities.Add("Entity list offset não disponível para este cliente");
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Erro ao ler entity list: {ex.Message}");
#endif
                entities.Add($"Erro: {ex.Message}");
            }
            return entities;
        }

        // Método para obter informações de debug melhorado
        public Dictionary<string, object> GetDebugInfo()
        {
            var debugInfo = new Dictionary<string, object>();

            try
            {
                debugInfo["HP"] = $"{ReadCurrentHp()} / {ReadMaxHp()}";
                debugInfo["SP"] = $"{ReadCurrentSp()} / {ReadMaxSp()}";

                // Debug detalhado das posições
                var (currentX, currentY) = GetCurrentPosition();
                debugInfo["Position"] = $"X: {currentX}, Y: {currentY}";
                debugInfo["CurrentXPosAddress"] = $"0x{currentXPosAddress:X8}";
                debugInfo["XReadAddress"] = $"0x{(currentXPosAddress > 0 ? currentXPosAddress : 0x0156FD4C):X8}";
                debugInfo["YReadAddress"] = $"0x{(currentXPosAddress > 0 ? (currentXPosAddress + 4) : 0x0156FD4C):X8}";

                // Informações do cache
                debugInfo["CacheLastUpdate"] = lastCoordinateRead.ToString("HH:mm:ss.fff");
                debugInfo["CacheAge_ms"] = (DateTime.Now - lastCoordinateRead).TotalMilliseconds.ToString("F1");
                debugInfo["CachedX"] = cachedX;
                debugInfo["CachedY"] = cachedY;

                // Informações da rédea automática
                debugInfo["AutoRein_Enabled"] = ProfileSingleton.GetCurrent()?.UserPreferences?.autoReinEnabled ?? false;
                debugInfo["AutoRein_CellCount"] = ProfileSingleton.GetCurrent()?.UserPreferences?.autoReinCellCount ?? 0;
                debugInfo["AutoRein_Key"] = ProfileSingleton.GetCurrent()?.UserPreferences?.autoReinKey.ToString() ?? "None";
                debugInfo["AutoRein_LastCheck"] = lastAutoReinCheck.ToString("HH:mm:ss.fff");
                debugInfo["AutoRein_LastUse"] = lastAutoReinUse.ToString("HH:mm:ss.fff");
                debugInfo["AutoRein_CanUse"] = CanUseAutoRein();
                debugInfo["AutoRein_ShouldUse"] = ShouldUseAutoRein();
                debugInfo["AutoRein_InProgress"] = autoReinInProgress;

                // === NOVAS INFORMAÇÕES DE DEBUG PARA VALIDAÇÃO DE DESMONTE MANUAL ===
                debugInfo["ManualDismount_Detected"] = manualDismountDetected;
                debugInfo["ManualDismount_Time"] = manualDismountTime.ToString("HH:mm:ss.fff");
                debugInfo["ManualDismount_Position"] = $"X: {dismountPositionX}, Y: {dismountPositionY}";
                debugInfo["ManualDismount_CellsWalked"] = cellsWalkedSinceDismount;
                debugInfo["AutoRein_TemporarilySuspended"] = autoReinTemporarilySuspended;
                debugInfo["WasMountedLastCheck"] = wasMountedLastCheck;

                debugInfo["Map"] = ReadCurrentMap() ?? "N/A";
                debugInfo["MoveCounter"] = GetMoveCounter();
                debugInfo["HasMount"] = HasMountStatus();
                debugInfo["EntityListAddress"] = $"0x{currentEntityListAddress:X8}";
                debugInfo["PositionHistoryCount"] = positionHistory.Count;

                // Lista de buffs ativos
                List<string> buffs = new List<string>();
                for (int i = 0; i < 32; i++)
                {
                    uint buffId = CurrentBuffStatusCode(i);
                    if (buffId > 0 && buffId != uint.MaxValue)
                    {
                        buffs.Add(buffId.ToString());
                    }
                }
                debugInfo["ActiveBuffs"] = buffs;

                // Entity list
                debugInfo["EntityList"] = ReadEntityList();

                // Debug adicional - verificar se PMR está configurado
                debugInfo["PMR_Status"] = PMR != null ? "Configurado" : "Não configurado";
                debugInfo["Process_Status"] = process != null ? $"PID: {process.Id}" : "Não configurado";

            }
            catch (Exception ex)
            {
                debugInfo["Error"] = ex.Message;
            }

            return debugInfo;
        }

        public Client GetClientByProcess(string processName)
        {
            foreach (Client c in ClientListSingleton.GetAll())
            {
                if (c.processName == processName)
                {
                    uint hpBaseValue = ReadMemory(c.currentHPBaseAddress);
                    if (hpBaseValue > 0) return c;
                }
            }
            return null;
        }

        public static Client FromDTO(ClientDTO dto)
        {
            return ClientListSingleton.GetAll()
                .Where(c => c.processName == dto.name)
                .Where(c => c.currentHPBaseAddress == dto.hpAddressPointer)
                .Where(c => c.currentNameAddress == dto.nameAddressPointer).FirstOrDefault();
        }
    }
}