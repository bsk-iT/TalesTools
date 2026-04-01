using _4RTools.Forms;
using _4RTools.Properties;
using _4RTools.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static _4RTools.Model.AutoSwitch;

namespace _4RTools.Model
{
    internal class AutoSwitchContainer
    {
        public GroupBox container { get; set; }
        public List<Buff> skills { get; set; }

        public AutoSwitchContainer() { }

        public AutoSwitchContainer(GroupBox p, List<Buff> skills)
        {
            this.skills = skills;
            this.container = p;
        }
    }

    internal class AutoSwitchRenderer
    {

        private readonly int BUFFS_PER_ROW = 1;
        private readonly int DISTANCE_BETWEEN_CONTAINERS = 10;
        // Aumentado para dar mais espaço vertical entre cada skill (ícone + gap)
        private readonly int DISTANCE_BETWEEN_ROWS = 48;

        private AutoSwitchContainer _container;
        private ToolTip _toolTip;
        private Subject _subject;
        private Form _forms;
        string OldText = string.Empty;

        public AutoSwitchRenderer(AutoSwitchContainer container, ToolTip toolTip, Subject subject, Form forms)
        {
            this._container = container;
            this._toolTip = toolTip;
            this._subject = subject;
            this._forms = forms;
        }

        public void doRender()
        {
            GroupBox group = (GroupBox)this._forms.Controls.Find("AutoSwitchGP", true)[0];
            group.Controls.Clear();
            AutoSwitchContainer bk = _container;

            // Constantes de layout ajustadas para ícone 35x35 e TextBox 35x35
            int pbWidth = 35;
            int itemSpacing = 8;              // espaço entre PictureBox e primeiro TextBox
            int textBoxWidth = 35;
            int textBoxHeight = 35;
            int arrowWidthApprox = 19;        // largura aproximada da seta (utilizada para cálculo)
            int arrowSpacing = 8;             // espaço entre textbox e seta
            int betweenArrowAndText = 12;     // espaço entre a seta e o próximo TextBox
            int removeBtnSpacing = 12;        // espaço entre nextItem textbox e botão remover
            int removeBtnWidth = 20;
            int rightPadding = 12;

            // Calcule largura relativa da linha usando os offsets exatos
            int pbX_rel = 0;
            int itemX_rel = pbX_rel + pbWidth + itemSpacing;
            int seta1X_rel = itemX_rel + textBoxWidth + arrowSpacing;
            int skillX_rel = seta1X_rel + arrowWidthApprox + betweenArrowAndText;
            int seta2X_rel = skillX_rel + textBoxWidth + arrowSpacing;
            int nextItemX_rel = seta2X_rel + arrowWidthApprox + betweenArrowAndText;
            int removeX_rel = nextItemX_rel + textBoxWidth + removeBtnSpacing;
            int rightMost_rel = removeX_rel + removeBtnWidth;
            int totalRowWidthRel = rightMost_rel + rightPadding;

            int groupBoxWidth = Math.Max(200, group.ClientSize.Width); // fallback mínimo
            int startX = Math.Max(8, (groupBoxWidth - totalRowWidthRel) / 2); // centraliza

            // Pos inicial para primeiro ítem
            Point lastLocation = new Point(startX, 30);

            // desenha cabeçalhos usando o startX calculado
            headerLabels(bk, startX);

            // Fonte dos TextBoxes
            Font textBoxFont = new Font("JetBrains Mono", 8.25F, FontStyle.Regular);

            foreach (Buff skill in bk.skills)
            {
                AutoSwitchConfig config = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping.Find(cfg => cfg.skillId == skill.effectStatusID);

                // Calcular posições usando startX (mesma lógica, agora utilizando tamanhos reais)
                int pbX = startX;
                int pbY = lastLocation.Y;
                int itemX = pbX + pbWidth + itemSpacing;
                // centraliza verticalmente os TextBoxes em relação ao PictureBox
                int itemY = pbY + (pbWidth - textBoxHeight) / 2;
                int seta1X = itemX + textBoxWidth + arrowSpacing;
                int seta1Y = itemY + (textBoxHeight - 11) / 2; // 11 = altura aproximada da seta
                int skillX = seta1X + arrowWidthApprox + betweenArrowAndText;
                int skillY = itemY;
                int seta2X = skillX + textBoxWidth + arrowSpacing;
                int seta2Y = seta1Y;
                int nextItemX = seta2X + arrowWidthApprox + betweenArrowAndText;
                int nextItemY = itemY;
                int removeX = nextItemX + textBoxWidth + removeBtnSpacing;
                int removeY = nextItemY + (textBoxHeight - removeBtnWidth) / 2;

                PictureBox pb = new PictureBox();
                pb.Image = skill.icon;
                pb.SizeMode = PictureBoxSizeMode.Zoom; // FORÇA 35x35 ocupando todo o PictureBox
                pb.Location = new Point(pbX, pbY);
                pb.Name = "pbox" + ((int)skill.effectStatusID);
                pb.Size = new Size(pbWidth, pbWidth);
                _toolTip.SetToolTip(pb, skill.name);

                VerticallyCenteredTextBox itemtb = new VerticallyCenteredTextBox();
                itemtb.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                itemtb.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                itemtb.GotFocus += new EventHandler(textBox_GotFocus);
                itemtb.TextChanged += new EventHandler(onTextChange);
                itemtb.Size = new Size(textBoxWidth, textBoxHeight);
                itemtb.Tag = "ITEMin" + ((int)skill.effectStatusID);
                itemtb.Name = "ITEMin" + ((int)skill.effectStatusID);
                itemtb.Location = new Point(itemX, itemY);
                itemtb.BackColor = Color.FromArgb(50, 50, 50);
                itemtb.ForeColor = Color.White;
                itemtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                itemtb.Font = textBoxFont;
                itemtb.TextAlign = HorizontalAlignment.Center;
                itemtb.Text = (config != null && config.itemKey != Key.None) ? config.itemKey.ToString() : "";

                PictureBox seta1pb = new PictureBox();
                seta1pb.Image = Resources._4RTools.ETCResource.arrowright;
                seta1pb.Location = new Point(seta1X, seta1Y);
                seta1pb.Name = "item" + ((int)skill.effectStatusID);
                seta1pb.Size = new System.Drawing.Size(arrowWidthApprox, 11);
                seta1pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                seta1pb.TabStop = false;

                VerticallyCenteredTextBox skilltb = new VerticallyCenteredTextBox();
                skilltb.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                skilltb.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                skilltb.GotFocus += new EventHandler(textBox_GotFocus);
                skilltb.TextChanged += new EventHandler(onTextChange);
                skilltb.Size = new Size(textBoxWidth, textBoxHeight);
                skilltb.Tag = "SKILLin" + ((int)skill.effectStatusID);
                skilltb.Name = "SKILLin" + ((int)skill.effectStatusID);
                skilltb.Location = new Point(skillX, skillY);
                skilltb.BackColor = Color.FromArgb(50, 50, 50);
                skilltb.ForeColor = Color.White;
                skilltb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                skilltb.Font = textBoxFont;
                skilltb.TextAlign = HorizontalAlignment.Center;
                skilltb.Text = (config != null && config.skillKey != Key.None) ? config.skillKey.ToString() : "";

                PictureBox seta2pb = new PictureBox();
                seta2pb.Image = Resources._4RTools.ETCResource.arrowright;
                seta2pb.Location = new Point(seta2X, seta2Y);
                seta2pb.Name = "pboxSeta2" + ((int)skill.effectStatusID);
                seta2pb.Size = new System.Drawing.Size(arrowWidthApprox, 11);
                seta2pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                seta2pb.TabStop = false;

                VerticallyCenteredTextBox nextItemtb = new VerticallyCenteredTextBox();
                nextItemtb.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                nextItemtb.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                nextItemtb.GotFocus += new EventHandler(textBox_GotFocus);
                nextItemtb.TextChanged += new EventHandler(onTextChange);
                nextItemtb.Size = new Size(textBoxWidth, textBoxHeight);
                nextItemtb.Tag = "NEXTITEMin" + ((int)skill.effectStatusID);
                nextItemtb.Name = "NEXTITEMin" + ((int)skill.effectStatusID);
                nextItemtb.Location = new Point(nextItemX, nextItemY);
                nextItemtb.BackColor = Color.FromArgb(50, 50, 50);
                nextItemtb.ForeColor = Color.White;
                nextItemtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                nextItemtb.Font = textBoxFont;
                nextItemtb.TextAlign = HorizontalAlignment.Center;
                nextItemtb.Text = (config != null && config.nextItemKey != Key.None) ? config.nextItemKey.ToString() : "";

                PictureBox removepb = new PictureBox();
                removepb.Image = Resources._4RTools.ETCResource.remove;
                removepb.Location = new Point(removeX, removeY);
                removepb.Name = "remove" + ((int)skill.effectStatusID);
                removepb.Size = new System.Drawing.Size(removeBtnWidth, removeBtnWidth);
                removepb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                removepb.Click += new EventHandler(removeSkill);

                bk.container.Controls.Add(pb);
                bk.container.Controls.Add(itemtb);
                bk.container.Controls.Add(seta1pb);
                bk.container.Controls.Add(skilltb);
                bk.container.Controls.Add(seta2pb);
                bk.container.Controls.Add(nextItemtb);
                bk.container.Controls.Add(removepb);

                // próxima linha
                lastLocation = new Point(startX, lastLocation.Y + DISTANCE_BETWEEN_ROWS);
            }
        }

        private static void headerLabels(AutoSwitchContainer bk, int startX)
        {
            Label itemLB = new Label();
            Label skillLB = new Label();
            Label proxItemLB = new Label();

            Font headerFont = new Font("JetBrains Mono", 8.25F, FontStyle.Bold);

            // Mesma lógica de offsets usada em doRender
            int pbWidth = 35;
            int itemSpacing = 8;
            int textBoxWidth = 35;
            int arrowWidthApprox = 19;
            int arrowSpacing = 8;
            int betweenArrowAndText = 12;
            int removeBtnSpacing = 12;

            int pbX = startX;
            int itemX = pbX + pbWidth + itemSpacing;
            int seta1X = itemX + textBoxWidth + arrowSpacing;
            int skillX = seta1X + arrowWidthApprox + betweenArrowAndText;
            int seta2X = skillX + textBoxWidth + arrowSpacing;
            int nextItemX = seta2X + arrowWidthApprox + betweenArrowAndText;

            // item label: largura igual ao textbox (centraliza facilmente)
            itemLB.AutoSize = false;
            itemLB.Location = new Point(itemX, 12);
            itemLB.Size = new System.Drawing.Size(textBoxWidth, 16);
            itemLB.Text = "Item";
            itemLB.Font = headerFont;
            itemLB.ForeColor = ThemeManager.TextPrimary;
            itemLB.TextAlign = ContentAlignment.MiddleCenter;
            bk.container.Controls.Add(itemLB);

            // skill label
            skillLB.AutoSize = false;
            skillLB.Location = new Point(skillX, 12);
            skillLB.Size = new System.Drawing.Size(textBoxWidth, 16);
            skillLB.Text = "Skill";
            skillLB.Font = headerFont;
            skillLB.ForeColor = ThemeManager.TextPrimary;
            skillLB.TextAlign = ContentAlignment.MiddleCenter;
            bk.container.Controls.Add(skillLB);

            // Próximo Item: precisa de largura maior. meça string e ajuste
            proxItemLB.AutoSize = false;
            proxItemLB.Font = headerFont;
            proxItemLB.Text = "Próximo Item";
            // medir texto para garantir espaço
            using (var g = bk.container.CreateGraphics())
            {
                var textSize = g.MeasureString(proxItemLB.Text, headerFont);
                int width = Math.Max(textBoxWidth, (int)Math.Ceiling(textSize.Width) + 8);
                proxItemLB.Size = new System.Drawing.Size(width, 16);
            }
            // centralize o label sobre o nextItem textbox
            proxItemLB.Location = new Point(nextItemX + (textBoxWidth - proxItemLB.Width) / 2, 12);
            proxItemLB.ForeColor = ThemeManager.TextPrimary;
            proxItemLB.TextAlign = ContentAlignment.MiddleCenter;
            bk.container.Controls.Add(proxItemLB);
        }

        private void onTextChange(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                EffectStatusIDs statusID = (EffectStatusIDs)Int16.Parse(txtBox.Name.Split(new[] { "in" }, StringSplitOptions.None)[1]);
                string type = txtBox.Name.Split(new[] { "in" }, StringSplitOptions.None)[0];

                Key key;
                // Se o texto estiver vazio, define como Key.None
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    key = Key.None;
                }
                else
                {
                    key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                }

                AutoSwitchConfig config = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping.Find(cfg => cfg.skillId == statusID);
                if (config != null)
                {
                    config.skillId = statusID;

                    switch (type)
                    {
                        case item:
                            config.itemKey = key;
                            break;

                        case skill:
                            config.skillKey = key;
                            break;

                        case nextItem:
                            config.nextItemKey = key;
                            break;
                    }
                }
                else
                {
                    ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping.Add(new AutoSwitchConfig(statusID, key, type));
                }

                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
            }
            catch { }
        }

        private void removeSkill(object sender, EventArgs e)
        {
            PictureBox removepb = (PictureBox)sender;
            int skillIdInt = short.Parse(removepb.Name.Split(new[] { "remove" }, StringSplitOptions.None)[1]);
            EffectStatusIDs skillID = (EffectStatusIDs)skillIdInt;

            var config = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping.FirstOrDefault(x => x.skillId == skillID);
            if (config != null)
            {
                ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping.Remove(config);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
                this._subject.Notify(new Utils.Message(Utils.MessageCode.CHANGED_AUTOSWITCH_SKILL, ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping));
            }
        }

        public static void doUpdate(Dictionary<EffectStatusIDs, Key> autobuffDict, Control control)
        {
            FormUtils.ResetForm(control);
            foreach (EffectStatusIDs effect in autobuffDict.Keys)
            {
                Control[] c = control.Controls.Find("in" + (int)effect, true);
                if (c.Length > 0)
                {
                    TextBox textBox = (TextBox)c[0];
                    textBox.Text = autobuffDict[effect].ToString();
                }
            }
        }


        private void textBox_GotFocus(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            this.OldText = txtBox.Text.ToString();
        }
    }
}