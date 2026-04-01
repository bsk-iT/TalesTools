using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace _4RTools.Forms
{
    internal class VerticallyCenteredTextBox : TextBox
    {
        private const int EM_SETRECT = 0xB3;
        private const int WM_WINDOWPOSCHANGED = 0x0047;
        private const int HORIZONTAL_PADDING = 2; // evita que o texto fique colado às bordas

        // ajuste fino: se o texto ainda ficar um pixel acima/abaixo, mude para 1 ou -1
        private const int VerticalAdjustment = 1;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam);

        public VerticallyCenteredTextBox()
        {
            this.Multiline = true; // requerido para EM_SETRECT funcionar corretamente
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateFormattingRect();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateFormattingRect();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            UpdateFormattingRect();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            UpdateFormattingRect(); // recalcula quando o texto muda em runtime
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_WINDOWPOSCHANGED)
            {
                UpdateFormattingRect();
            }
        }

        private void UpdateFormattingRect()
        {
            if (!this.IsHandleCreated) return;

            // Use o texto atual para medir — quando vazio usamos fallback "Wy"
            string sample = string.IsNullOrEmpty(this.Text) ? "Wy" : this.Text;

            // Medição mais precisa usando Graphics + GenericTypographic
            int textHeight;
            try
            {
                using (var g = this.CreateGraphics())
                {
                    var sf = StringFormat.GenericTypographic;
                    sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                    var sizeF = g.MeasureString(sample, this.Font, PointF.Empty, sf);
                    textHeight = (int)Math.Ceiling(sizeF.Height);
                }
            }
            catch
            {
                // fallback para TextRenderer se algo falhar
                var flags = TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;
                Size textSize = TextRenderer.MeasureText(sample, this.Font, new Size(int.MaxValue, int.MaxValue), flags);
                textHeight = textSize.Height;
            }

            int clientH = this.ClientSize.Height;

            // Compensação pela borda do TextBox (FixedSingle adiciona ~2px)
            int borderComp = (this.BorderStyle == BorderStyle.FixedSingle) ? 2 : 0;

            // Calcular top padding de forma equilibrada e aplicar ajuste fino
            int topPadding = Math.Max(0, (clientH - textHeight) / 2 - (borderComp / 2) + VerticalAdjustment);
            int bottomPadding = Math.Max(0, clientH - textHeight - topPadding);

            RECT r = new RECT
            {
                Left = HORIZONTAL_PADDING,
                Top = topPadding,
                Right = Math.Max(0, this.ClientSize.Width - HORIZONTAL_PADDING),
                Bottom = Math.Max(0, clientH - bottomPadding)
            };

            try
            {
                SendMessage(this.Handle, EM_SETRECT, IntPtr.Zero, ref r);
                this.Invalidate();
            }
            catch
            {
                // ignore
            }
        }
    }
}