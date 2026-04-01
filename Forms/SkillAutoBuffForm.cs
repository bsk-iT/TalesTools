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
    public partial class SkillAutoBuffForm : Form, IObserver
    {
        private List<Buff> allSkills = new List<Buff>();
        private List<SkillItem> selectedSkills = new List<SkillItem>();
        private const int SKILL_ITEM_HEIGHT = 60;
        private const int SKILL_ITEM_MARGIN = 4;
        private Image deleteImage;

        public SkillAutoBuffForm(Subject subject)
        {
            this.KeyPreview = true;
            InitializeComponent();

            // Configurar nova aba (apenas nova implementação)
            InitializeSkillComboBox();
            LoadSelectedSkills();

            subject.Attach(this);
        }

        private Image LoadDeleteImage()
        {
            if (deleteImage != null) return deleteImage;

            try
            {
                // Tentar carregar do Resources (embutido)
                try
                {
                    var resBmp = _4RTools.Properties.Resources.delete;
                    if (resBmp != null)
                    {
                        // Criar uma cópia para permitir dispose seguro se necessário
                        deleteImage = new Bitmap(resBmp);
                        return deleteImage;
                    }
                }
                catch
                {
                    // se falhar, tenta o fallback por arquivo
                }

                // Fallback: carregar a partir da pasta assets\etc (mantido para compatibilidade)
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

        private void InitializeSkillComboBox()
        {
            // Carregar todas as skills
            allSkills.Clear();
            allSkills.AddRange(Buff.GetArcherSkills());
            allSkills.AddRange(Buff.GetSwordmanSkill());
            allSkills.AddRange(Buff.GetMageSkills());
            allSkills.AddRange(Buff.GetMerchantSkills());
            allSkills.AddRange(Buff.GetThiefSkills());
            allSkills.AddRange(Buff.GetAcolyteSkills());
            allSkills.AddRange(Buff.GetTaekwonSkills());
            allSkills.AddRange(Buff.GetNinjaSkills());
            allSkills.AddRange(Buff.GetGunsSkills());

            // Criar itens do ComboBox organizados por classe
            var comboItems = new List<ComboBoxItem>();

            // Separadores de classes
            comboItems.Add(new ComboBoxItem("═══ ARCHER SKILLS ═══", null, true));
            foreach (var skill in Buff.GetArcherSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ SWORDMAN SKILLS ═══", null, true));
            foreach (var skill in Buff.GetSwordmanSkill().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ MAGE SKILLS ═══", null, true));
            foreach (var skill in Buff.GetMageSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ MERCHANT SKILLS ═══", null, true));
            foreach (var skill in Buff.GetMerchantSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ THIEF SKILLS ═══", null, true));
            foreach (var skill in Buff.GetThiefSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ ACOLYTE SKILLS ═══", null, true));
            foreach (var skill in Buff.GetAcolyteSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ TAEKWON SKILLS ═══", null, true));
            foreach (var skill in Buff.GetTaekwonSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ NINJA SKILLS ═══", null, true));
            foreach (var skill in Buff.GetNinjaSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboItems.Add(new ComboBoxItem("═══ GUNSLINGER SKILLS ═══", null, true));
            foreach (var skill in Buff.GetGunsSkills().OrderBy(s => s.name))
                comboItems.Add(new ComboBoxItem($"   {skill.name}", skill, false));

            comboBoxSkills.DisplayMember = "DisplayText";
            comboBoxSkills.ValueMember = "Skill";
            comboBoxSkills.DataSource = comboItems;
        }

        private void LoadSelectedSkills()
        {
            selectedSkills.Clear();
            var buffMapping = ProfileSingleton.GetCurrent().AutobuffSkill.buffMapping;

            foreach (var mapping in buffMapping)
            {
                var skill = allSkills.FirstOrDefault(s => s.effectStatusID == mapping.Key);
                if (skill != null)
                {
                    selectedSkills.Add(new SkillItem
                    {
                        Skill = skill,
                        Key = mapping.Value
                    });
                }
            }

            RefreshSkillsDisplay();
        }

        private void RefreshSkillsDisplay()
        {
            panelSkillsContainer.Controls.Clear();

            for (int i = 0; i < selectedSkills.Count; i++)
            {
                var skillItem = selectedSkills[i];
                var panel = CreateSkillPanel(skillItem, i);
                panelSkillsContainer.Controls.Add(panel);
            }
        }

        private Panel CreateSkillPanel(SkillItem skillItem, int index)
        {
            var panel = new Panel
            {
                Size = new Size(panelSkillsContainer.Width - 25, SKILL_ITEM_HEIGHT),
                Location = new Point(5, index * (SKILL_ITEM_HEIGHT + SKILL_ITEM_MARGIN)),
                BackColor = Color.FromArgb(28, 28, 28),
                BorderStyle = BorderStyle.None
            };

            // Ícone da skill (menor)
            var pictureBox = new PictureBox
            {
                Size = new Size(35, 35),
                Location = new Point(5, 12),
                Image = skillItem.Skill.icon,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            toolTip1.SetToolTip(pictureBox, skillItem.Skill.name);

            // TextBox para a tecla
            var textBox = new VerticallyCenteredTextBox
            {
                Size = new Size(35, 35),
                Location = new Point(50, 12),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("JetBrains Mono", 8.25F, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Text = skillItem.Key != Key.None ? skillItem.Key.ToString() : "",
                Name = $"txtSkill_{skillItem.Skill.effectStatusID}",
                Tag = skillItem
            };

            textBox.KeyDown += FormUtils.OnKeyDown;
            textBox.KeyPress += FormUtils.OnKeyPress;
            textBox.TextChanged += SkillTextBox_TextChanged;

            // Label com nome da skill
            var label = new Label
            {
                Text = skillItem.Skill.name,
                Location = new Point(95, 22),
                Size = new Size(panel.Width - 200, 16),
                ForeColor = Color.White,
                Font = new Font("JetBrains Mono", 8.25F, FontStyle.Regular),
                AutoEllipsis = true
            };
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // PictureBox remover (imagem delete)
            var removeBox = new PictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(panel.Width - 25, 30),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = WinFormsCursors.Hand,
                Tag = skillItem,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var img = LoadDeleteImage();
            if (img != null) removeBox.Image = img;
            else
            {
                // fallback: desenhar um X se a imagem não for encontrada
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
            removeBox.Click += RemoveButton_Click;

            // Linha separadora
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

        private void comboBoxSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxSkills.SelectedItem as ComboBoxItem;

            if (selectedItem?.Skill != null && !selectedItem.IsHeader)
            {
                // Verificar se a skill já foi adicionada
                if (!selectedSkills.Any(s => s.Skill.effectStatusID == selectedItem.Skill.effectStatusID))
                {
                    selectedSkills.Add(new SkillItem
                    {
                        Skill = selectedItem.Skill,
                        Key = Key.None
                    });

                    RefreshSkillsDisplay();
                }

                // Reset ComboBox selection
                comboBoxSkills.SelectedIndex = -1;
            }
        }

        private void SkillTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var skillItem = textBox.Tag as SkillItem;

            if (skillItem != null)
            {
                try
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        skillItem.Key = Key.None;
                    }
                    else
                    {
                        skillItem.Key = (Key)Enum.Parse(typeof(Key), textBox.Text);
                    }

                    // Atualizar configuração
                    var autobuffSkill = ProfileSingleton.GetCurrent().AutobuffSkill;
                    if (skillItem.Key == Key.None)
                    {
                        autobuffSkill.RemoveKeyFromBuff(skillItem.Skill.effectStatusID);
                    }
                    else
                    {
                        autobuffSkill.AddKeyToBuff(skillItem.Skill.effectStatusID, skillItem.Key);
                    }

                    ProfileSingleton.SetConfiguration(autobuffSkill);
                }
                catch
                {
                    // Em caso de erro, limpar o campo
                    textBox.Text = "";
                    skillItem.Key = Key.None;
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            var skillItem = ctrl?.Tag as SkillItem;

            if (skillItem != null)
            {
                // Remover da configuração
                var autobuffSkill = ProfileSingleton.GetCurrent().AutobuffSkill;
                autobuffSkill.RemoveKeyFromBuff(skillItem.Skill.effectStatusID);
                ProfileSingleton.SetConfiguration(autobuffSkill);

                // Remover da lista e atualizar display
                selectedSkills.Remove(skillItem);
                RefreshSkillsDisplay();
            }
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.numericDelay.Value = ProfileSingleton.GetCurrent().AutobuffSkill.delay;
                    LoadSelectedSkills(); // Atualizar nova aba também
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutobuffSkill.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutobuffSkill.Start();
                    break;
            }
        }

        private void btnResetAutobuff_Click(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutobuffSkill.ClearKeyMapping();
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffSkill);
            this.numericDelay.Value = 100;

            // Limpar nova aba também
            selectedSkills.Clear();
            RefreshSkillsDisplay();
        }

        private void numericDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProfileSingleton.GetCurrent().AutobuffSkill.delay = Convert.ToInt16(this.numericDelay.Value);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffSkill);
                this.ActiveControl = null;
            }
            catch { }
        }
    }

    // Classes auxiliares

    internal class SkillItem
    {
        public Buff Skill { get; set; }
        public Key Key { get; set; }
    }
}