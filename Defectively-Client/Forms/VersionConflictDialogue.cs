using System.Windows.Forms;

namespace DefectivelyClient.Forms
{
    public partial class VersionConflictDialogue : Form
    {
        public VersionConflictDialogue() {
            InitializeComponent();
        }

        public void Initialize(Defectively.Compatibility.Version clientVersion, Defectively.Compatibility.Version serverVersion, string serverCoreVersion, string details) {
            lblClientVersion.Text = $"{clientVersion.ToMediumString()}";
            lblClientCoreVersion.Text = $"{new Defectively.Compatibility.Version().ToMediumString()}";
            lblSupportedServerVersion.Text = $"{clientVersion.SupportedVersion}";

            lblServerVersion.Text = $"{serverVersion.ToMediumString()}";
            lblServerCoreVersion.Text = $"{serverCoreVersion}";
            lblSupportedClientVersion.Text = $"{serverVersion.SupportedVersion}";

            rtbDetails.Text = details;
        }
    }
}
