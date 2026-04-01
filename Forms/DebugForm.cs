using System;
using System.Drawing;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Utils;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace _4RTools.Forms
{
    public partial class DebugForm : Form, IObserver
    {
        private Timer debugTimer;
        private Subject subject;

        // GroupBoxes principais
        private GroupBox groupRealTimeValues;
        private GroupBox groupEntityList;

        // Labels para valores em tempo real
        private Label lblHPValue;
        private Label lblSPValue;
        private Label lblPositionValue;
        private Label lblMapValue;
        private Label lblBuffsValue;

        // ListBox para entity list
        private ListBox lstEntityList;
        private Label lblEntityCount;

        // Labels para informações adicionais
        private Label lblAutoReinStatus;

        public DebugForm(Subject subject)
        {
            this.subject = subject;
            subject.Attach(this);
            InitializeComponent();
            InitializeDebugControls();
            InitializeDebugTimer();
        }

        private void InitializeDebugControls()
        {
            // Configurações do form - ajustar para caber na tab
            this.Size = new Size(780, 280);
            this.BackColor = ThemeManager.BackgroundDark;
            this.ForeColor = ThemeManager.TextPrimary;
            this.FormBorderStyle = FormBorderStyle.None;

            // ===== GROUPBOX ESQUERDO - VALORES EM TEMPO REAL =====
            groupRealTimeValues = new GroupBox();
            groupRealTimeValues.Text = "VALORES EM TEMPO REAL";
            groupRealTimeValues.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            groupRealTimeValues.ForeColor = ThemeManager.TextPrimary;
            groupRealTimeValues.Location = new Point(20, 20);
            groupRealTimeValues.Size = new Size(450, 350);
            this.Controls.Add(groupRealTimeValues);

            // HP
            Label lblHP = new Label();
            lblHP.Text = "HP:";
            lblHP.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            lblHP.ForeColor = ThemeManager.TextPrimary;
            lblHP.Location = new Point(15, 25);
            lblHP.Size = new Size(60, 18);
            groupRealTimeValues.Controls.Add(lblHP);

            lblHPValue = new Label();
            lblHPValue.Text = "0 / 0 (0%)";
            lblHPValue.Font = new Font("JetBrains Mono", 8.25F);
            lblHPValue.ForeColor = Color.Lime;
            lblHPValue.Location = new Point(85, 25);
            lblHPValue.Size = new Size(280, 18);
            groupRealTimeValues.Controls.Add(lblHPValue);

            // SP
            Label lblSP = new Label();
            lblSP.Text = "SP:";
            lblSP.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            lblSP.ForeColor = ThemeManager.TextPrimary;
            lblSP.Location = new Point(15, 48);
            lblSP.Size = new Size(60, 18);
            groupRealTimeValues.Controls.Add(lblSP);

            lblSPValue = new Label();
            lblSPValue.Text = "0 / 0 (0%)";
            lblSPValue.Font = new Font("JetBrains Mono", 8.25F);
            lblSPValue.ForeColor = Color.Cyan;
            lblSPValue.Location = new Point(85, 48);
            lblSPValue.Size = new Size(280, 18);
            groupRealTimeValues.Controls.Add(lblSPValue);

            // POSITION
            Label lblPosition = new Label();
            lblPosition.Text = "POSITION:";
            lblPosition.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            lblPosition.ForeColor = ThemeManager.TextPrimary;
            lblPosition.Location = new Point(15, 71);
            lblPosition.Size = new Size(70, 18);
            groupRealTimeValues.Controls.Add(lblPosition);

            lblPositionValue = new Label();
            lblPositionValue.Text = "X: 0, Y: 0";
            lblPositionValue.Font = new Font("JetBrains Mono", 8.25F);
            lblPositionValue.ForeColor = Color.Yellow;
            lblPositionValue.Location = new Point(85, 71);
            lblPositionValue.Size = new Size(280, 18);
            groupRealTimeValues.Controls.Add(lblPositionValue);

            // MAP
            Label lblMap = new Label();
            lblMap.Text = "MAP:";
            lblMap.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            lblMap.ForeColor = ThemeManager.TextPrimary;
            lblMap.Location = new Point(15, 94);
            lblMap.Size = new Size(60, 18);
            groupRealTimeValues.Controls.Add(lblMap);

            lblMapValue = new Label();
            lblMapValue.Text = "N/A";
            lblMapValue.Font = new Font("JetBrains Mono", 8.25F);
            lblMapValue.ForeColor = Color.Yellow;
            lblMapValue.Location = new Point(85, 94);
            lblMapValue.Size = new Size(280, 18);
            groupRealTimeValues.Controls.Add(lblMapValue);

            // AUTO REIN STATUS
            Label lblAutoReinLabel = new Label();
            lblAutoReinLabel.Text = "RÉDEA:";
            lblAutoReinLabel.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            lblAutoReinLabel.ForeColor = ThemeManager.TextPrimary;
            lblAutoReinLabel.Location = new Point(15, 117);
            lblAutoReinLabel.Size = new Size(60, 18);
            groupRealTimeValues.Controls.Add(lblAutoReinLabel);

            lblAutoReinStatus = new Label();
            lblAutoReinStatus.Text = "Desabilitado";
            lblAutoReinStatus.Font = new Font("JetBrains Mono", 8.25F);
            lblAutoReinStatus.ForeColor = Color.Yellow;
            lblAutoReinStatus.Location = new Point(85, 117);
            lblAutoReinStatus.Size = new Size(280, 18);
            groupRealTimeValues.Controls.Add(lblAutoReinStatus);

            // BUFFS
            Label lblBuffs = new Label();
            lblBuffs.Text = "BUFFS ATIVOS:";
            lblBuffs.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            lblBuffs.ForeColor = ThemeManager.TextPrimary;
            lblBuffs.Location = new Point(15, 145);
            lblBuffs.Size = new Size(420, 18);
            groupRealTimeValues.Controls.Add(lblBuffs);

            lblBuffsValue = new Label();
            lblBuffsValue.Text = "Carregando...";
            lblBuffsValue.Font = new Font("JetBrains Mono", 7.75F);
            lblBuffsValue.ForeColor = ThemeManager.TextPrimary;
            lblBuffsValue.Location = new Point(15, 168);
            lblBuffsValue.Size = new Size(420, 160);
            lblBuffsValue.AutoSize = false;
            lblBuffsValue.BorderStyle = BorderStyle.FixedSingle;
            lblBuffsValue.BackColor = ThemeManager.BackgroundMedium;
            lblBuffsValue.TextAlign = ContentAlignment.TopLeft;
            groupRealTimeValues.Controls.Add(lblBuffsValue);

            // ===== GROUPBOX DIREITO - ENTITY LIST =====
            groupEntityList = new GroupBox();
            groupEntityList.Text = "ENTITY-LIST";
            groupEntityList.Font = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);
            groupEntityList.ForeColor = ThemeManager.TextPrimary;
            groupEntityList.Location = new Point(495, 20);
            groupEntityList.Size = new Size(450, 350);
            this.Controls.Add(groupEntityList);

            // Entity Count
            lblEntityCount = new Label();
            lblEntityCount.Text = "Entidades encontradas: 0";
            lblEntityCount.Font = new Font("JetBrains Mono", 8.25F);
            lblEntityCount.ForeColor = Color.Yellow;
            lblEntityCount.Location = new Point(15, 25);
            lblEntityCount.Size = new Size(420, 18);
            groupEntityList.Controls.Add(lblEntityCount);

            // ListBox para Entity List
            lstEntityList = new ListBox();
            lstEntityList.Font = new Font("JetBrains Mono", 8F);
            lstEntityList.BackColor = ThemeManager.BackgroundMedium;
            lstEntityList.ForeColor = ThemeManager.TextPrimary;
            lstEntityList.BorderStyle = BorderStyle.FixedSingle;
            lstEntityList.Location = new Point(15, 48);
            lstEntityList.Size = new Size(420, 290);
            groupEntityList.Controls.Add(lstEntityList);
        }

        private void InitializeDebugTimer()
        {
            debugTimer = new Timer();
            debugTimer.Interval = 500; // Atualizar a cada 500ms
            debugTimer.Tick += UpdateDebugInfo;
            debugTimer.Start();
        }

        private void UpdateDebugInfo(object sender, EventArgs e)
        {
            try
            {
                Client client = ClientSingleton.GetClient();
                if (client == null)
                {
                    SetDisconnectedState();
                    return;
                }

                // Obter informações completas de debug
                var debugInfo = client.GetDebugInfo();

                // Atualizar HP
                uint currentHP = client.ReadCurrentHp();
                uint maxHP = client.ReadMaxHp();
                int hpPercent = maxHP > 0 ? (int)((currentHP * 100) / maxHP) : 0;
                lblHPValue.Text = $"{currentHP} / {maxHP} ({hpPercent}%)";
                lblHPValue.ForeColor = hpPercent < 30 ? Color.Red : hpPercent < 70 ? Color.Yellow : Color.Lime;

                // Atualizar SP
                uint currentSP = client.ReadCurrentSp();
                uint maxSP = client.ReadMaxSp();
                int spPercent = maxSP > 0 ? (int)((currentSP * 100) / maxSP) : 0;
                lblSPValue.Text = $"{currentSP} / {maxSP} ({spPercent}%)";
                lblSPValue.ForeColor = spPercent < 30 ? Color.Red : spPercent < 70 ? Color.Yellow : Color.Cyan;

                // Atualizar Position
                var (posX, posY) = client.GetCurrentPosition();
                lblPositionValue.Text = $"X: {posX}, Y: {posY}";

                // Atualizar Map
                string currentMap = client.ReadCurrentMap();
                lblMapValue.Text = string.IsNullOrEmpty(currentMap) ? "N/A" : currentMap;

                // Atualizar Auto Rein Status
                UpdateAutoReinStatus(debugInfo);

                // Atualizar Buffs
                UpdateBuffsList(debugInfo);

                // Atualizar Entity List
                UpdateEntityList(debugInfo);
            }
            catch (Exception ex)
            {
                lblHPValue.Text = $"Erro: {ex.Message}";
            }
        }

        private void SetDisconnectedState()
        {
            lblHPValue.Text = "Cliente não conectado";
            lblSPValue.Text = "Cliente não conectado";
            lblPositionValue.Text = "X: 0, Y: 0";
            lblMapValue.Text = "N/A";
            lblAutoReinStatus.Text = "Cliente não conectado";
            lblBuffsValue.Text = "Cliente não conectado";
            lblEntityCount.Text = "Entidades encontradas: 0";
            lstEntityList.Items.Clear();
        }

        private void UpdateAutoReinStatus(Dictionary<string, object> debugInfo)
        {
            try
            {
                bool enabled = (bool)(debugInfo["AutoRein_Enabled"] ?? false);
                bool canUse = (bool)(debugInfo["AutoRein_CanUse"] ?? false);
                bool shouldUse = (bool)(debugInfo["AutoRein_ShouldUse"] ?? false);
                int cellCount = (int)(debugInfo["AutoRein_CellCount"] ?? 0);
                string key = debugInfo["AutoRein_Key"]?.ToString() ?? "None";
                bool hasMount = (bool)(debugInfo["HasMount"] ?? false);

                if (!enabled)
                {
                    lblAutoReinStatus.Text = "Desabilitado";
                    lblAutoReinStatus.ForeColor = ThemeManager.TextPrimary;
                }
                else if (hasMount)
                {
                    lblAutoReinStatus.Text = "Montado";
                    lblAutoReinStatus.ForeColor = Color.Green;
                }
                else if (shouldUse)
                {
                    lblAutoReinStatus.Text = $"Pronto! ({cellCount} células, {key})";
                    lblAutoReinStatus.ForeColor = Color.Lime;
                }
                else if (canUse)
                {
                    lblAutoReinStatus.Text = $"Aguardando ({cellCount} células, {key})";
                    lblAutoReinStatus.ForeColor = Color.Yellow;
                }
                else
                {
                    lblAutoReinStatus.Text = "Bloqueado (antibot/chat/cidade)";
                    lblAutoReinStatus.ForeColor = Color.Orange;
                }
            }
            catch
            {
                lblAutoReinStatus.Text = "Erro ao ler status";
                lblAutoReinStatus.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Converte um ID de buff para seu nome amigável usando o enum EffectStatusIDs
        /// </summary>
        /// <param name="buffId">ID do buff como string</param>
        /// <returns>Nome do buff ou o ID se não houver mapeamento</returns>
        private string GetBuffName(string buffId)
        {
            try
            {
                // Tentar converter o ID para uint
                if (uint.TryParse(buffId, out uint id))
                {
                    // Verificar se existe um valor correspondente no enum
                    if (Enum.IsDefined(typeof(EffectStatusIDs), id))
                    {
                        EffectStatusIDs effectStatus = (EffectStatusIDs)id;

                        // Buscar pelo atributo Description
                        var field = typeof(EffectStatusIDs).GetField(effectStatus.ToString());
                        if (field != null)
                        {
                            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
                            if (descriptionAttribute != null)
                            {
                                return descriptionAttribute.Description;
                            }
                        }

                        // Se não houver Description, usar o nome do enum
                        return effectStatus.ToString();
                    }
                }

                // Se não conseguir mapear, retorna o ID original
                return $"ID:{buffId}";
            }
            catch
            {
                // Em caso de erro, retorna o ID original
                return $"ID:{buffId}";
            }
        }

        private void UpdateBuffsList(Dictionary<string, object> debugInfo)
        {
            try
            {
                if (debugInfo["ActiveBuffs"] is List<string> activeBuffs && activeBuffs.Count > 0)
                {
                    // Converter IDs para nomes
                    List<string> buffNames = activeBuffs.Select(buffId => GetBuffName(buffId)).ToList();

                    // Organizar buffs em linhas (ajustar para caber melhor)
                    List<string> buffLines = new List<string>();
                    for (int i = 0; i < buffNames.Count; i += 3) // Reduzindo para 3 buffs por linha para acomodar nomes mais longos
                    {
                        var lineBuffs = buffNames.Skip(i).Take(3);
                        buffLines.Add(string.Join(", ", lineBuffs));
                    }

                    lblBuffsValue.Text = string.Join("\n", buffLines);
                }
                else
                {
                    lblBuffsValue.Text = "Nenhum buff ativo";
                }
            }
            catch (Exception ex)
            {
                lblBuffsValue.Text = $"Erro ao ler buffs: {ex.Message}";
            }
        }

        private void UpdateEntityList(Dictionary<string, object> debugInfo)
        {
            try
            {
                if (debugInfo["EntityList"] is List<string> entities)
                {
                    lblEntityCount.Text = $"Entidades encontradas: {entities.Count}";

                    lstEntityList.Items.Clear();
                    foreach (string entity in entities)
                    {
                        lstEntityList.Items.Add(entity);
                    }

                    if (entities.Count == 0)
                    {
                        lstEntityList.Items.Add("Nenhuma entidade encontrada");
                    }
                }
                else
                {
                    lblEntityCount.Text = "Entidades encontradas: 0";
                    lstEntityList.Items.Clear();
                    lstEntityList.Items.Add("Erro ao carregar entity list");
                }
            }
            catch (Exception ex)
            {
                lblEntityCount.Text = "Erro ao ler entities";
                lstEntityList.Items.Clear();
                lstEntityList.Items.Add($"Erro: {ex.Message}");
            }
        }

        public void Update(ISubject subject)
        {
            try
            {
                switch ((subject as Subject).Message.code)
                {
                    case MessageCode.PROFILE_CHANGED:
                    case MessageCode.PROCESS_CHANGED:
                        // Atualizar informações quando processo ou perfil mudar
                        if (debugTimer != null)
                        {
                            UpdateDebugInfo(this, EventArgs.Empty);
                        }
                        break;
                }
            }
            catch { }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DisposeDebugTimer();
            DetachFromSubject();
            base.OnFormClosed(e);
        }

        private void DisposeDebugTimer()
        {
            if (debugTimer != null)
            {
                debugTimer.Stop();
                debugTimer.Dispose();
                debugTimer = null;
            }
        }

        private void DetachFromSubject()
        {
            if (subject != null)
            {
                subject.Detach(this);
                subject = null;
            }
        }
    }
}