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
    public partial class StuffAutoBuffForm : Form, IObserver
    {
        private List<Buff> allBuffs = new List<Buff>();
        private List<StuffItem> selectedBuffs = new List<StuffItem>();
        private const int ITEM_HEIGHT = 60;
        private const int ITEM_MARGIN = 4;
        private Image deleteImage;

        public StuffAutoBuffForm(Subject subject)
        {
            InitializeComponent();

            InitializeStuffComboBox();
            LoadSelectedBuffs();

            subject.Attach(this);
        }

        private Image LoadDeleteImage()
        {
            if (deleteImage != null) return deleteImage;

            try
            {
                // Primeiro tenta carregar do Resources (embutido)
                try
                {
                    var resBmp = _4RTools.Properties.Resources.delete;
                    if (resBmp != null)
                    {
                        // Cria cópia para permitir dispose seguro
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

        private void InitializeStuffComboBox()
        {
            // Carregar todas as buffs/stuffs
            allBuffs.Clear();
            allBuffs.AddRange(Buff.GetPotionsBuffs());
            allBuffs.AddRange(Buff.GetElementalsBuffs());
            allBuffs.AddRange(Buff.GetBoxesBuffs());
            allBuffs.AddRange(Buff.GetFoodBuffs());
            allBuffs.AddRange(Buff.GetScrollBuffs());
            allBuffs.AddRange(Buff.GetETCBuffs());

            var comboItems = new List<ComboBoxItem>();

            comboItems.Add(new ComboBoxItem("═══ POTIONS ═══", null, true));
            foreach (var b in Buff.GetPotionsBuffs().OrderBy(x => x.name))
                comboItems.Add(new ComboBoxItem($"   {b.name}", b, false));

            comboItems.Add(new ComboBoxItem("═══ ELEMENTALS ═══", null, true));
            foreach (var b in Buff.GetElementalsBuffs().OrderBy(x => x.name))
                comboItems.Add(new ComboBoxItem($"   {b.name}", b, false));

            comboItems.Add(new ComboBoxItem("═══ BOXES / SPEED / STATUS ═══", null, true));
            foreach (var b in Buff.GetBoxesBuffs().OrderBy(x => x.name))
                comboItems.Add(new ComboBoxItem($"   {b.name}", b, false));

            comboItems.Add(new ComboBoxItem("═══ FOODS ═══", null, true));
            foreach (var b in Buff.GetFoodBuffs().OrderBy(x => x.name))
                comboItems.Add(new ComboBoxItem($"   {b.name}", b, false));

            comboItems.Add(new ComboBoxItem("═══ SCROLLS BUFFS ═══", null, true));
            foreach (var b in Buff.GetScrollBuffs().OrderBy(x => x.name))
                comboItems.Add(new ComboBoxItem($"   {b.name}", b, false));

            comboItems.Add(new ComboBoxItem("═══ ETC ═══", null, true));
            foreach (var b in Buff.GetETCBuffs().OrderBy(x => x.name))
                comboItems.Add(new ComboBoxItem($"   {b.name}", b, false));

            comboBoxStuff.DisplayMember = "DisplayText";
            comboBoxStuff.ValueMember = "Skill";
            comboBoxStuff.DataSource = comboItems;
        }

        private void LoadSelectedBuffs()
        {
            selectedBuffs.Clear();
            var buffMapping = ProfileSingleton.GetCurrent().AutobuffStuff.buffMapping;

            foreach (var mapping in buffMapping)
            {
                var buff = allBuffs.FirstOrDefault(s => s.effectStatusID == mapping.Key);
                if (buff != null)
                {
                    selectedBuffs.Add(new StuffItem
                    {
                        Buff = buff,
                        Key = mapping.Value
                    });
                }
            }

            RefreshBuffsDisplay();
        }

        private void RefreshBuffsDisplay()
        {
            panelStuffContainer.Controls.Clear();

            for (int i = 0; i < selectedBuffs.Count; i++)
            {
                var item = selectedBuffs[i];
                var panel = CreateStuffPanel(item, i);
                panelStuffContainer.Controls.Add(panel);
            }
        }

        private Panel CreateStuffPanel(StuffItem item, int index)
        {
            var panel = new Panel
            {
                Size = new Size(panelStuffContainer.Width - 25, ITEM_HEIGHT),
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
                Name = $"txtStuff_{item.Buff.effectStatusID}",
                Tag = item
            };
            textBox.KeyDown += FormUtils.OnKeyDown;
            textBox.KeyPress += FormUtils.OnKeyPress;
            textBox.TextChanged += StuffTextBox_TextChanged;

            // Nome do Stuff
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
            removeBox.Click += RemoveStuff_Click;

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

        private void comboBoxStuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxStuff.SelectedItem as ComboBoxItem;

            if (selectedItem?.Skill != null && !selectedItem.IsHeader)
            {
                if (!selectedBuffs.Any(s => s.Buff.effectStatusID == selectedItem.Skill.effectStatusID))
                {
                    selectedBuffs.Add(new StuffItem
                    {
                        Buff = selectedItem.Skill,
                        Key = Key.None
                    });

                    RefreshBuffsDisplay();
                }

                comboBoxStuff.SelectedIndex = -1;
            }
        }

        private void StuffTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var item = textBox.Tag as StuffItem;

            if (item != null)
            {
                try
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        item.Key = Key.None;
                    }
                    else
                    {
                        item.Key = (Key)Enum.Parse(typeof(Key), textBox.Text);
                    }

                    var autobuff = ProfileSingleton.GetCurrent().AutobuffStuff;
                    if (item.Key == Key.None)
                        autobuff.RemoveKeyFromBuff(item.Buff.effectStatusID);
                    else
                        autobuff.AddKeyToBuff(item.Buff.effectStatusID, item.Key);

                    ProfileSingleton.SetConfiguration(autobuff);
                }
                catch
                {
                    textBox.Text = "";
                    item.Key = Key.None;
                }
            }
        }

        private void RemoveStuff_Click(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            var item = ctrl?.Tag as StuffItem;

            if (item != null)
            {
                var autobuff = ProfileSingleton.GetCurrent().AutobuffStuff;
                autobuff.RemoveKeyFromBuff(item.Buff.effectStatusID);
                ProfileSingleton.SetConfiguration(autobuff);

                selectedBuffs.Remove(item);
                RefreshBuffsDisplay();
            }
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.numericDelay.Value = ProfileSingleton.GetCurrent().AutobuffStuff.delay;
                    LoadSelectedBuffs();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutobuffStuff.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutobuffStuff.Start();
                    break;
            }
        }

        private void btnResetAutobuff_Click(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutobuffStuff.ClearKeyMapping();
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffStuff);
            this.numericDelay.Value = 100;

            selectedBuffs.Clear();
            RefreshBuffsDisplay();
        }

        private void numericDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProfileSingleton.GetCurrent().AutobuffStuff.delay = Convert.ToInt16(this.numericDelay.Value);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffStuff);
                this.ActiveControl = null;
            }
            catch { }
        }
    }

    // Auxiliares
    internal class StuffItem
    {
        public Buff Buff { get; set; }
        public Key Key { get; set; }
    }
}