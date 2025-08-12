using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _4RTools.Utils
{
    public enum AppTheme
    {
        Dark,
        LightGray,
        Light
    }

    public static class ThemeManager
    {
        public static AppTheme CurrentTheme { get; private set; } = AppTheme.Dark;
        public static Font MainFont { get; private set; }

        // Tailwind Neutral Palette
        private static readonly Dictionary<AppTheme, Color> BackgroundColors = new Dictionary<AppTheme, Color>
        {
            { AppTheme.Dark, ColorTranslator.FromHtml("#0a0a0a") },        // 950
            { AppTheme.LightGray, ColorTranslator.FromHtml("#404040") },   // 700
            { AppTheme.Light, ColorTranslator.FromHtml("#f5f5f5") }        // 100
        };

        private static readonly Dictionary<AppTheme, Color> ForegroundColors = new Dictionary<AppTheme, Color>
        {
            { AppTheme.Dark, Color.White },
            { AppTheme.LightGray, Color.White },
            { AppTheme.Light, Color.Black }
        };

        // Cores para painéis - contrastantes com o fundo
        private static readonly Dictionary<AppTheme, Color> PanelColors = new Dictionary<AppTheme, Color>
        {
            { AppTheme.Dark, Color.White },           // Painel branco no tema escuro
            { AppTheme.LightGray, Color.LightGray },  // Painel cinza claro no tema cinza
            { AppTheme.Light, Color.DarkGray }        // Painel cinza escuro no tema claro
        };

        static ThemeManager()
        {
            LoadFont();
        }

        private static void LoadFont()
        {
            try
            {
                // Caminho relativo ao executável
                string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Fonts", "JetBrainsMono-Regular.ttf");
                if (File.Exists(fontPath))
                {
                    var pfc = new System.Drawing.Text.PrivateFontCollection();
                    pfc.AddFontFile(fontPath);
                    MainFont = new Font(pfc.Families[0], 10f, FontStyle.Regular);
                }
                else
                {
                    MainFont = new Font("Consolas", 10f, FontStyle.Regular); // fallback
                }
            }
            catch
            {
                MainFont = new Font("Consolas", 10f, FontStyle.Regular); // fallback
            }
        }

        public static Color GetBackgroundColor() => BackgroundColors[CurrentTheme];
        public static Color GetForegroundColor() => ForegroundColors[CurrentTheme];
        public static Color GetPanelColor() => PanelColors[CurrentTheme];

        public static void ApplyThemeToForm(Form form)
        {
            ApplyThemeToControl(form);
            foreach (Form owned in form.OwnedForms)
            {
                ApplyThemeToControl(owned);
            }
        }

        private static void ApplyThemeToControl(Control control)
        {
            // Não aplicar tema aos botões de status que devem manter cores específicas
            if (ShouldPreserveButtonColors(control))
            {
                // Aplica apenas a fonte, preserva as cores do botão
                control.Font = MainFont;
            }
            else if (control is Panel panel)
            {
                // Aplica cor específica para painéis para ficarem visíveis
                ApplyPanelTheme(panel);
            }
            else
            {
                // Aplica tema normal para outros controles
                control.BackColor = GetBackgroundColor();
                control.ForeColor = GetForegroundColor();
                control.Font = MainFont;
            }

            // Recursivamente aplica tema aos controles filhos
            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }

            if (control is TabControl tc)
            {
                foreach (TabPage page in tc.TabPages)
                {
                    ApplyThemeToControl(page);
                }
            }
        }

        private static bool ShouldPreserveButtonColors(Control control)
        {
            // Preserva cores dos botões de status (ON/OFF) que devem ficar vermelho/verde
            if (control is Button button)
            {
                return button.Name == "btnStatusToggle" ||
                       button.Name == "btnStatusHealToggle" ||
                       button.Text == "ON" ||
                       button.Text == "OFF";
            }
            return false;
        }

        private static void ApplyPanelTheme(Panel panel)
        {
            // Aplica cor contrastante para painéis ficarem visíveis
            panel.BackColor = GetPanelColor();
            panel.Font = MainFont;

            // Para painéis que são separadores (como panel4), aplica cor mais sutil
            if (panel.Name == "panel4" || panel.Height <= 2 || panel.Width <= 2)
            {
                panel.BackColor = GetPanelColor();
            }
            else
            {
                // Para painéis normais, aplica a cor do tema
                panel.BackColor = GetPanelColor();
                // Se o painel tem imagem de fundo, não altera a cor
                if (panel.BackgroundImage != null)
                {
                    panel.BackColor = Color.Transparent;
                }
            }
        }

        public static void ChangeTheme(AppTheme theme)
        {
            CurrentTheme = theme;
            // Salvar preferência do tema, se desejar
        }

        // Método para forçar atualização das cores dos botões de status
        // Usando Form genérico para evitar conflito de tipos
        public static void UpdateStatusButtonColors(Form containerForm)
        {
            // Busca os botões por nome nos controles do formulário
            Button btnStatusToggle = FindControlByName<Button>(containerForm, "btnStatusToggle");
            Button btnStatusHealToggle = FindControlByName<Button>(containerForm, "btnStatusHealToggle");

            // Atualiza o botão de status principal
            if (btnStatusToggle != null)
            {
                btnStatusToggle.BackColor = btnStatusToggle.Text == "ON" ? Color.Green : Color.Red;
                btnStatusToggle.FlatStyle = FlatStyle.Flat;
                btnStatusToggle.FlatAppearance.BorderSize = 0;
            }

            // Atualiza o botão de status de cura
            if (btnStatusHealToggle != null)
            {
                btnStatusHealToggle.BackColor = btnStatusHealToggle.Text == "ON" ? Color.Green : Color.Red;
                btnStatusHealToggle.FlatStyle = FlatStyle.Flat;
                btnStatusHealToggle.FlatAppearance.BorderSize = 0;
            }
        }

        // Método auxiliar para encontrar controles por nome recursivamente
        private static T FindControlByName<T>(Control parent, string name) where T : Control
        {
            if (parent.Name == name && parent is T)
                return parent as T;

            foreach (Control child in parent.Controls)
            {
                T result = FindControlByName<T>(child, name);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}