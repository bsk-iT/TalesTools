using _4RTools.Model;
using _4RTools.Properties;
using _4RTools.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace _4RTools.Forms
{
    public partial class ToggleApplicationStateForm : Form, IObserver
    {
        private Subject subject;
        private ContextMenu contextMenu;
        private MenuItem menuItem;

        //Store key used for last profile - necessarly to clean when change profile
        private Keys lastKey;
        private Keys healLastKey;

        // Imagens para os botões
        private Image onImage;
        private Image offImage;

        public ToggleApplicationStateForm() { }

        public ToggleApplicationStateForm(Subject subject)
        {
            InitializeComponent();

            // Carregar as imagens
            LoadButtonImages();

            // Configurar botões para usar imagens
            SetupImageButtons();

            subject.Attach(this);
            this.subject = subject;
            KeyboardHook.Enable();

            // Configurar texto inicial dos TextBox - deixar vazio se não há tecla configurada
            SetInitialTextBoxValue(this.txtStatusToggleKey, ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey);
            this.txtStatusToggleKey.KeyDown += new KeyEventHandler(FormUtils.OnKeyDown);
            this.txtStatusToggleKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtStatusToggleKey.TextChanged += new EventHandler(this.onStatusToggleKeyChange);

            SetInitialTextBoxValue(this.txtStatusHealToggleKey, ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey);
            this.txtStatusHealToggleKey.KeyDown += new KeyEventHandler(FormUtils.OnKeyDown);
            this.txtStatusHealToggleKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtStatusHealToggleKey.TextChanged += new EventHandler(this.onStatusHealToggleKeyChange);

            InitializeContextualMenu();
        }

        private void SetInitialTextBoxValue(TextBox textBox, string keyValue)
        {
            // Se a tecla for None, End, ou vazia, deixar o TextBox vazio
            if (string.IsNullOrEmpty(keyValue) || keyValue == "None" || keyValue == "End")
            {
                textBox.Text = "";
            }
            else
            {
                textBox.Text = keyValue;
            }
        }

        private void LoadButtonImages()
        {
            try
            {
                // Primeiro: tentar carregar diretamente dos Resources (embutidos)
                try
                {
                    // Nomes esperados no Resources.resx: on, off, delete (sem extensão)
                    // Se você nomeou diferente, ajuste aqui para Properties.Resources.<Nome>
                    var resOn = Properties.Resources.on;
                    var resOff = Properties.Resources.off;

                    if (resOn != null)
                    {
                        onImage = ResizeImage(resOn, 50, 50);
                    }

                    if (resOff != null)
                    {
                        offImage = ResizeImage(resOff, 50, 50);
                    }

                    // Se carregou pelo menos uma imagem via resources, retorna
                    if (onImage != null || offImage != null) return;
                }
                catch (Exception)
                {
                    // fallback para carregamento por arquivo se houver qualquer problema com Resources
                }

                // Fallback: carregar a partir da pasta assets\etc (mantido para compatibilidade)
                string onImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "etc", "on.png");
                string offImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "etc", "off.png");

                if (File.Exists(onImagePath))
                {
                    using (var img = Image.FromFile(onImagePath))
                    {
                        onImage = ResizeImage(img, 50, 50);
                    }
                }

                if (File.Exists(offImagePath))
                {
                    using (var img = Image.FromFile(offImagePath))
                    {
                        offImage = ResizeImage(img, 50, 50);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar imagens dos botões: {ex.Message}");
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void SetupImageButtons()
        {
            // Configurar btnStatusToggle
            if (this.btnStatusToggle != null)
            {
                // Se nenhuma imagem foi carregada, tentar usar imagens dos Resources diretamente (sem redimensionamento)
                if (offImage == null && Properties.Resources.off != null)
                    offImage = ResizeImage(Properties.Resources.off, this.btnStatusToggle.Width, this.btnStatusToggle.Height);

                if (onImage == null && Properties.Resources.on != null)
                    onImage = ResizeImage(Properties.Resources.on, this.btnStatusToggle.Width, this.btnStatusToggle.Height);

                SetupRoundButton(this.btnStatusToggle, offImage);
            }

            // Configurar btnStatusHealToggle
            if (this.btnStatusHealToggle != null)
            {
                if (offImage == null && Properties.Resources.off != null)
                    offImage = ResizeImage(Properties.Resources.off, this.btnStatusHealToggle.Width, this.btnStatusHealToggle.Height);

                if (onImage == null && Properties.Resources.on != null)
                    onImage = ResizeImage(Properties.Resources.on, this.btnStatusHealToggle.Width, this.btnStatusHealToggle.Height);

                SetupRoundButton(this.btnStatusHealToggle, offImage);
            }
        }

        private void SetupRoundButton(Button button, Image initialImage)
        {
            // Configurar propriedades básicas
            button.Text = "";
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Transparent;

            // Definir tamanho circular
            int size = Math.Min(button.Width, button.Height);
            button.Size = new Size(size, size);

            // Criar região circular
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, size, size);
            button.Region = new Region(path);

            // Definir imagem
            if (initialImage != null)
            {
                button.BackgroundImage = initialImage;
                button.BackgroundImageLayout = ImageLayout.Stretch;
            }

            // Adicionar evento de paint para garantir que fique circular
            button.Paint += (sender, e) =>
            {
                Button btn = sender as Button;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath buttonPath = new GraphicsPath())
                {
                    buttonPath.AddEllipse(0, 0, btn.Width - 1, btn.Height - 1);
                    btn.Region = new Region(buttonPath);
                }
            };
        }

        private void InitializeContextualMenu()
        {
            this.contextMenu = new ContextMenu();
            this.menuItem = new MenuItem();

            this.contextMenu.MenuItems.AddRange(
                    new MenuItem[] { this.menuItem });

            this.menuItem.Index = 0;
            this.menuItem.Text = "Close";
            this.menuItem.Click += new EventHandler(this.notifyShutdownApplication);

            this.notifyIconTray.ContextMenu = this.contextMenu;
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    Keys currentToggleKey = (Keys)Enum.Parse(typeof(Keys), ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey);
                    KeyboardHook.RemoveDown(lastKey); //Remove last key hook to prevent toggle with last profile key used.

                    // Usar o método para definir o valor inicial
                    SetInitialTextBoxValue(this.txtStatusToggleKey, ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey);
                    KeyboardHook.AddKeyDown(currentToggleKey, new KeyboardHook.KeyPressed(this.toggleStatus));
                    lastKey = currentToggleKey;

                    Keys currentHealToggleKey = (Keys)Enum.Parse(typeof(Keys), ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey);
                    KeyboardHook.RemoveUp(healLastKey); //Remove last key hook to prevent toggle with last profile key used.

                    // Usar o método para definir o valor inicial
                    SetInitialTextBoxValue(this.txtStatusHealToggleKey, ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey);
                    KeyboardHook.AddKeyUp(currentHealToggleKey, new KeyboardHook.KeyPressed(this.toggleStatusHeal));
                    healLastKey = currentHealToggleKey;
                    break;
            }
        }

        private void btnToggleStatusHandler(object sender, EventArgs e) { this.toggleStatus(); }

        private void onStatusToggleKeyChange(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)sender;

                if (string.IsNullOrEmpty(textBox.Text))
                {
                    // Se vazio, definir como None
                    KeyboardHook.RemoveDown(lastKey);
                    ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey = "None";
                    lastKey = Keys.None;
                }
                else
                {
                    // Se há texto, tentar converter para Keys
                    Keys currentToggleKey = (Keys)Enum.Parse(typeof(Keys), textBox.Text);
                    KeyboardHook.RemoveDown(lastKey);
                    KeyboardHook.AddKeyDown(currentToggleKey, new KeyboardHook.KeyPressed(this.toggleStatus));
                    ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey = currentToggleKey.ToString();
                    lastKey = currentToggleKey;
                }

                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                this.ActiveControl = null;
            }
            catch
            {
                // Em caso de erro, definir como None
                KeyboardHook.RemoveDown(lastKey);
                ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey = "None";
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                lastKey = Keys.None;
            }
        }

        private bool toggleStatus()
        {
            // Verificar o estado atual pela imagem de fundo
            bool isOn = this.btnStatusToggle.BackgroundImage == onImage;

            if (isOn)
            {
                // Mudar para OFF
                if (offImage != null)
                {
                    this.btnStatusToggle.BackgroundImage = offImage;
                }
                this.notifyIconTray.Icon = Resources._4RTools.ETCResource.TalesIcon_off;
                this.subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
                new SoundPlayer(Resources._4RTools.ETCResource.Speech_Off).Play();
            }
            else
            {
                Client client = ClientSingleton.GetClient();
                if (client != null)
                {
                    // Mudar para ON
                    if (onImage != null)
                    {
                        this.btnStatusToggle.BackgroundImage = onImage;
                    }
                    this.notifyIconTray.Icon = Resources._4RTools.ETCResource.TalesIcon_on;
                    this.subject.Notify(new Utils.Message(MessageCode.TURN_ON, null));
                    new SoundPlayer(Resources._4RTools.ETCResource.Speech_On).Play();
                }
            }

            return true;
        }

        public bool TurnOFF()
        {
            // Verificar o estado atual pela imagem de fundo
            bool isOn = this.btnStatusToggle.BackgroundImage == onImage;
            if (isOn)
            {
                if (offImage != null)
                {
                    this.btnStatusToggle.BackgroundImage = offImage;
                }
                this.subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
                new SoundPlayer(Resources._4RTools.ETCResource.Speech_Off).Play();
            }

            bool isOnheal = this.btnStatusHealToggle.BackgroundImage == onImage;
            if (isOnheal)
            {
                if (offImage != null)
                {
                    this.btnStatusHealToggle.BackgroundImage = offImage;
                }
                this.subject.Notify(new Utils.Message(MessageCode.TURN_HEAL_OFF, null));
                new SoundPlayer(Resources._4RTools.ETCResource.Healing_Off).Play();
            }
            return true;
        }

        private void btnToggleStatusHealHandler(object sender, EventArgs e) { this.toggleStatusHeal(); }

        private void onStatusHealToggleKeyChange(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)sender;

                if (string.IsNullOrEmpty(textBox.Text))
                {
                    // Se vazio, definir como None
                    KeyboardHook.RemoveUp(healLastKey);
                    ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey = "None";
                    healLastKey = Keys.None;
                }
                else
                {
                    // Se há texto, tentar converter para Keys
                    Keys currentHealToggleKey = (Keys)Enum.Parse(typeof(Keys), textBox.Text);
                    KeyboardHook.RemoveUp(healLastKey);
                    KeyboardHook.AddKeyUp(currentHealToggleKey, new KeyboardHook.KeyPressed(this.toggleStatusHeal));
                    ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey = currentHealToggleKey.ToString();
                    healLastKey = currentHealToggleKey;
                }

                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                this.ActiveControl = null;
            }
            catch
            {
                // Em caso de erro, definir como None
                KeyboardHook.RemoveUp(healLastKey);
                ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey = "None";
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                healLastKey = Keys.None;
            }
        }

        private bool toggleStatusHeal()
        {
            // Verificar o estado atual pela imagem de fundo
            bool isOn = this.btnStatusHealToggle.BackgroundImage == onImage;

            if (isOn)
            {
                // Mudar para OFF
                if (offImage != null)
                {
                    this.btnStatusHealToggle.BackgroundImage = offImage;
                }
                this.subject.Notify(new Utils.Message(MessageCode.TURN_HEAL_OFF, null));
                new SoundPlayer(Resources._4RTools.ETCResource.Healing_Off).Play();
            }
            else
            {
                Client client = ClientSingleton.GetClient();
                if (client != null)
                {
                    // Mudar para ON
                    if (onImage != null)
                    {
                        this.btnStatusHealToggle.BackgroundImage = onImage;
                    }
                    this.subject.Notify(new Utils.Message(MessageCode.TURN_HEAL_ON, null));
                    new SoundPlayer(Resources._4RTools.ETCResource.Healing_On).Play();
                }
            }

            return true;
        }

        private void notifyIconDoubleClick(object sender, MouseEventArgs e)
        {
            this.subject.Notify(new Utils.Message(MessageCode.CLICK_ICON_TRAY, null));
        }

        private void notifyShutdownApplication(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.subject.Notify(new Utils.Message(MessageCode.SHUTDOWN_APPLICATION, null));
        }

        private void lblStatusHealToggle_Click(object sender, EventArgs e)
        {

        }

        private void txtStatusHealToggleKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}