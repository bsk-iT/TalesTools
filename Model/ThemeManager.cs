using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _4RTools.Utils
{
    public static class ThemeManager
    {
        // ===== NOVA PALETA DE CORES =====
        public static readonly Color BlackBase = Color.FromArgb(28, 28, 28);
        public static readonly Color DarkGray = Color.FromArgb(28, 28, 28);
        public static readonly Color MediumGray = Color.FromArgb(28, 28, 28);
        public static readonly Color LightGray = Color.FromArgb(28, 28, 28);
        public static readonly Color WhiteBase = Color.FromArgb(244, 244, 246);

        // ===== CORES PARA DIFERENTES USOS =====
        public static readonly Color BackgroundDark = BlackBase;        // Fundo escuro principal
        public static readonly Color BackgroundMedium = DarkGray;       // Fundo médio para controles
        public static readonly Color BorderColor = MediumGray;          // Cor de bordas
        public static readonly Color TextPrimary = WhiteBase;           // Texto principal
        public static readonly Color TextSecondary = LightGray;         // Texto secundário

        // ===== APIs PARA BARRA DE TÍTULO ESCURA =====
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref bool attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;

        /// <summary>
        /// ÚNICA FUNCIONALIDADE: Aplica barra de título escura
        /// </summary>
        public static void ApplyDarkTitleBar(Form form)
        {
            try
            {
                if (form.Handle != IntPtr.Zero)
                {
                    bool useImmersiveDarkMode = true;

                    if (DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useImmersiveDarkMode, sizeof(bool)) != 0)
                    {
                        DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref useImmersiveDarkMode, sizeof(bool));
                    }

                    int captionColor = ColorToInt(DarkGray);  // Usando preto para barra de título
                    DwmSetWindowAttribute(form.Handle, DWMWA_CAPTION_COLOR, ref captionColor, sizeof(int));
                }
            }
            catch { }
        }

        /// <summary>
        /// NOVO: Aplica cor escura ao MdiClient (área de fundo do MDI Container)
        /// </summary>
        public static void ApplyDarkMdiClientBackground(Form mdiContainer)
        {
            try
            {
                foreach (Control control in mdiContainer.Controls)
                {
                    if (control is MdiClient mdiClient)
                    {
                        mdiClient.BackColor = BackgroundDark;  // Usando preto para fundo MDI
                        break; // Só existe um MdiClient por form
                    }
                }
            }
            catch { }
        }

        private static int ColorToInt(Color color)
        {
            return color.R | (color.G << 8) | (color.B << 16);
        }
    }
}