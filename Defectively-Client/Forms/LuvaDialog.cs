using System.Drawing;
using System.Windows.Forms;
using Defectively;

namespace DefectivelyClient.Forms
{
    public partial class LuvaDialog : Form
    {
        public string LuvaValue { get; set; }
        public Severity Severity { get; set; }

        public LuvaDialog() {
            InitializeComponent();
        }

        public new DialogResult ShowDialog() {
            lblLuvaValue.Text = LuvaValue;
            lblSeverity.Text = Severity.Description;
            lblSeverity.ForeColor = ColorTranslator.FromHtml(Severity.Color);
            return base.ShowDialog();
        }
    }
}
