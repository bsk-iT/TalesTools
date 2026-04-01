using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using WinFormsCursors = System.Windows.Forms.Cursors;
using _4RTools.Properties;

namespace _4RTools.Forms
{
    public partial class AutoBuffStatusForm : Form, IObserver
    {
        private List<Buff> allDebuffs = new List<Buff>();
        private List<StatusItem> selectedDebuffs = new List<StatusItem>();
        private const int ITEM_HEIGHT = 60;
        private const int ITEM_MARGIN = 4;
        private Image deleteImage;

        public AutoBuffStatusForm(Subject subject)
        {
            InitializeComponent();

            InitializeDebuffComboBox();
            LoadSelectedDebuffs();

            // manter handlers para caixas fixas de status (grupo especial)
            this.txtStatusKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtStatusKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtStatusKey.TextChanged += new EventHandler(onStatusKeyChange);
            this.txtNewStatusKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtNewStatusKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtNewStatusKey.TextChanged += new EventHandler(on3RDStatusKeyChange);

            subject.Attach(this);
        }

        private Image LoadDeleteImage()
        {
            if (deleteImage != null) return deleteImage;

            try
            {
                // Tenta primeiro carregar do Resources fortemente tipado
                try
                {
                    var resBmp = _4RTools.Properties.Resources.delete;
                    if (resBmp != null)
                    {
                        // Cria uma cópia para não usar a instância interna do Resource diretamente
                        deleteImage = new Bitmap(resBmp);
                        return deleteImage;
                    }
                }
                catch
                {
                    // ignore - tentaremos o fallback por arquivo
                }

                // Fallback: carregar da pasta assets\etc se existir (compatibilidade)
                var path = Path.Combine(Application.StartupPath, "assets", "etc", "delete.png");
                if (File.Exists(path))
                {
                    using (var img = Image.FromFile(path))
                    {
                        deleteImage = new Bitmap(img);
                    }
                }
            }
            catch
            {
                deleteImage = null;
            }

            return deleteImage;
        }

        private void InitializeDebuffComboBox()
        {
            // Carregar todos os debuffs
            allDebuffs.Clear();
            allDebuffs.AddRange(Buff.GetDebuffs());

            var comboItems = new List<ComboBoxItem>();

            comboItems.Add(new ComboBoxItem("═══ DEBUFFS ═══", null, true));
            foreach (var d in Buff.GetDebuffs().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {d.name}", d, false));

            comboBoxDebuffs.DisplayMember = "DisplayText";
            comboBoxDebuffs.ValueMember = "Skill";
            comboBoxDebuffs.DataSource = comboItems;
        }

        private void LoadSelectedDebuffs()
        {
            selectedDebuffs.Clear();
            var buffMapping = ProfileSingleton.GetCurrent().DebuffsRecovery.buffMapping;

            foreach (var mapping in buffMapping)
            {
                var debuff = allDebuffs.FirstOrDefault(s => s.effectStatusID == mapping.Key);
                if (debuff != null)
                {
                    selectedDebuffs.Add(new StatusItem
                    {
                        Buff = debuff,
                        Key = mapping.Value
                    });
                }
            }

            RefreshDebuffsDisplay();
        }

        private void RefreshDebuffsDisplay()
        {
            // LIMPAR TODOS OS TOOLTIPS ANTES DE RECRIAR
            toolTip1.RemoveAll();

            panelDebuffsContainer.Controls.Clear();

            for (int i = 0; i < selectedDebuffs.Count; i++)
            {
                var item = selectedDebuffs[i];
                var panel = CreateDebuffPanel(item, i);
                panelDebuffsContainer.Controls.Add(panel);
            }
        }

        private Panel CreateDebuffPanel(StatusItem item, int index)
        {
            var panel = new Panel
            {
                Size = new Size(panelDebuffsContainer.Width - 25, ITEM_HEIGHT),
                Location = new Point(5, index * (ITEM_HEIGHT + ITEM_MARGIN)),
                BackColor = Color.FromArgb(28, 28, 28),
                BorderStyle = BorderStyle.None
            };

            var pictureBox = new PictureBox
            {
                Size = new Size(35, 35),
                Location = new Point(5, 12),
                Image = item.Buff.icon,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            toolTip1.SetToolTip(pictureBox, item.Buff.description);

            var textBox = new VerticallyCenteredTextBox
            {
                Size = new Size(35, 35),
                Location = new Point(50, 12),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("JetBrains Mono", 8.25F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Text = item.Key != Key.None ? item.Key.ToString() : "",
                Name = $"txtDebuff_{item.Buff.effectStatusID}",
                Tag = item
            };

            textBox.KeyDown += FormUtils.OnKeyDown;
            textBox.KeyPress += FormUtils.OnKeyPress;
            textBox.TextChanged += DebuffTextBox_TextChanged;

            var label = new Label
            {
                Text = item.Buff.name,
                Location = new Point(95, 22),
                Size = new Size(panel.Width - 200, 16),
                ForeColor = Color.White,
                Font = new Font("JetBrains Mono", 8.25F, FontStyle.Regular),
                AutoEllipsis = true
            };
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            var removeBox = new PictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(panel.Width - 25, 30),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = WinFormsCursors.Hand,
                Tag = item,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var img = LoadDeleteImage();
            if (img != null) removeBox.Image = img;
            else
            {
                var bmp = new Bitmap(20, 20);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    using (var pen = new Pen(Color.FromArgb(200, 50, 50), 2))
                    {
                        g.DrawLine(pen, 4, 4, 16, 16);
                        g.DrawLine(pen, 16, 4, 4, 16);
                    }
                }
                removeBox.Image = bmp;
            }
            removeBox.Click += RemoveDebuff_Click;

            var separator = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(200, 200, 200)
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(textBox);
            panel.Controls.Add(label);
            panel.Controls.Add(removeBox);
            panel.Controls.Add(separator);

            return panel;
        }

        private void comboBoxDebuffs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxDebuffs.SelectedItem as ComboBoxItem;

            if (selectedItem?.Skill != null && !selectedItem.IsHeader)
            {
                if (!selectedDebuffs.Any(s => s.Buff.effectStatusID == selectedItem.Skill.effectStatusID))
                {
                    selectedDebuffs.Add(new StatusItem
                    {
                        Buff = selectedItem.Skill,
                        Key = Key.None
                    });

                    RefreshDebuffsDisplay();
                }

                comboBoxDebuffs.SelectedIndex = -1;
            }
        }

        private void DebuffTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var item = textBox.Tag as StatusItem;

            if (item != null)
            {
                try
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        item.Key = Key.None;
                        ProfileSingleton.GetCurrent().DebuffsRecovery.RemoveKeyFromBuff(item.Buff.effectStatusID);
                    }
                    else
                    {
                        item.Key = (Key)Enum.Parse(typeof(Key), textBox.Text);
                        ProfileSingleton.GetCurrent().DebuffsRecovery.AddKeyToBuff(item.Buff.effectStatusID, item.Key);
                    }

                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().DebuffsRecovery);
                }
                catch
                {
                    textBox.Text = "";
                    item.Key = Key.None;
                }
            }
        }

        private void RemoveDebuff_Click(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            var item = ctrl?.Tag as StatusItem;

            if (item != null)
            {
                ProfileSingleton.GetCurrent().DebuffsRecovery.RemoveKeyFromBuff(item.Buff.effectStatusID);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().DebuffsRecovery);

                selectedDebuffs.Remove(item);
                RefreshDebuffsDisplay();
            }
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    // atualizar entradas fixas
                    this.txtStatusKey.Text = ProfileSingleton.GetCurrent().StatusRecovery.buffMapping.Keys.Contains(EffectStatusIDs.SILENCE) ? ProfileSingleton.GetCurrent().StatusRecovery.buffMapping[EffectStatusIDs.SILENCE].ToString() : "";
                    this.txtNewStatusKey.Text = ProfileSingleton.GetCurrent().StatusRecovery.buffMapping.Keys.Contains(EffectStatusIDs.CRITICALWOUND) ? ProfileSingleton.GetCurrent().StatusRecovery.buffMapping[EffectStatusIDs.CRITICALWOUND].ToString() : "";
                    LoadSelectedDebuffs();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().DebuffsRecovery.Stop();
                    ProfileSingleton.GetCurrent().StatusRecovery.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().DebuffsRecovery.Start();
                    ProfileSingleton.GetCurrent().StatusRecovery.Start();
                    break;
            }
        }

        public static void doUpdate(Control control)
        {
            // manter compatibilidade com chamadas externas
            var autobuffDict = ProfileSingleton.GetCurrent().DebuffsRecovery.buffMapping;
            var groupbox = control.Controls.OfType<GroupBox>().FirstOrDefault();
            foreach (VerticallyCenteredTextBox txt in groupbox.Controls.OfType<VerticallyCenteredTextBox>())
            {
                var buffid = int.Parse(txt.Name.Split('n')[1]);
                var existe = autobuffDict.FirstOrDefault(x => x.Key.Equals((EffectStatusIDs)buffid));
                if (!existe.Equals(default(KeyValuePair<EffectStatusIDs, Key>)))
                {
                    txt.Text = autobuffDict[(EffectStatusIDs)buffid] == Key.None ? "" : autobuffDict[(EffectStatusIDs)buffid].ToString();
                }
                else
                {
                    txt.Text = "";
                }
            }
        }

        private void onStatusKeyChange(object sender, EventArgs e)
        {
            try
            {
                // Se estiver vazio: remover as teclas associadas ao grupo de status e salvar
                if (string.IsNullOrEmpty(this.txtStatusKey.Text))
                {
                    var sr = ProfileSingleton.GetCurrent().StatusRecovery;
                    sr.buffMapping.Remove(EffectStatusIDs.POISON);
                    sr.buffMapping.Remove(EffectStatusIDs.SILENCE);
                    sr.buffMapping.Remove(EffectStatusIDs.BLIND);
                    sr.buffMapping.Remove(EffectStatusIDs.CONFUSION);
                    sr.buffMapping.Remove(EffectStatusIDs.HALLUCINATIONWALK);
                    sr.buffMapping.Remove(EffectStatusIDs.HALLUCINATION);
                    sr.buffMapping.Remove(EffectStatusIDs.CURSE);

                    ProfileSingleton.SetConfiguration(sr);
                    this.ActiveControl = null;
                    return;
                }

                Key k = (Key)Enum.Parse(typeof(Key), this.txtStatusKey.Text.ToString());

                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.POISON, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.SILENCE, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.BLIND, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.CONFUSION, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.HALLUCINATION, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.CURSE, k);

                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().StatusRecovery);
                this.ActiveControl = null;
            }
            catch { }
        }

        private void on3RDStatusKeyChange(object sender, EventArgs e)
        {
            try
            {
                // Se estiver vazio: remover as teclas associadas ao segundo grupo e salvar
                if (string.IsNullOrEmpty(this.txtNewStatusKey.Text))
                {
                    var sr = ProfileSingleton.GetCurrent().StatusRecovery;
                    sr.buffMapping.Remove(EffectStatusIDs.SLOW_CAST);
                    sr.buffMapping.Remove(EffectStatusIDs.CRITICALWOUND);
                    sr.buffMapping.Remove(EffectStatusIDs.FREEZING);
                    sr.buffMapping.Remove(EffectStatusIDs.MANDRAGORA);
                    sr.buffMapping.Remove(EffectStatusIDs.BURNING);
                    sr.buffMapping.Remove(EffectStatusIDs.DEEP_SLEEP);

                    ProfileSingleton.SetConfiguration(sr);
                    this.ActiveControl = null;
                    return;
                }

                Key k = (Key)Enum.Parse(typeof(Key), this.txtNewStatusKey.Text.ToString());

                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.SLOW_CAST, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.CRITICALWOUND, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.FREEZING, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.MANDRAGORA, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.BURNING, k);
                ProfileSingleton.GetCurrent().StatusRecovery.AddKeyToBuff(EffectStatusIDs.DEEP_SLEEP, k);

                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().StatusRecovery);
                this.ActiveControl = null;
            }
            catch { }
        }

        private void AutoBuffStatusForm_Load(object sender, EventArgs e)
        {

        }
    }

    internal class StatusItem
    {
        public Buff Buff { get; set; }
        public Key Key { get; set; }
    }
}