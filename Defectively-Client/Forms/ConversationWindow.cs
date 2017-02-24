using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace DefectivelyClient.Forms
{
    public partial class ConversationWindow : Form
    {
        public ConversationWindow() {
            InitializeComponent();

            panel1.Paint += Panel1_Paint;
            this.ResizeEnd += (sender, args) => panel1.Invalidate();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            var Online = true;

            var TextRectangle = new Rectangle(9, 0, panel1.Width - 83, 50);
            e.Graphics.DrawString("Väinämö Łūmikērø", new Font("Segoe UI Semibold", 18F), new SolidBrush(Color.WhiteSmoke), TextRectangle, new StringFormat { LineAlignment = StringAlignment.Center });
            e.Graphics.FillEllipse(new SolidBrush(ColorTranslator.FromHtml(Online ? "#19E68C" : "#FC3539")), new Rectangle(panel1.Width - 24, 20, 10, 10));
            GC.Collect();
        }
    }
}
