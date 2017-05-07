using System;
using System.Reflection;
using System.Windows.Forms;
using Defectively.Compatibility;

namespace DefectivelyClient.Forms
{
    public partial class VersionConflictDialogue : Form
    {
        public VersionConflictDialogue() {
            InitializeComponent();
        }

        public void Initialize(Version clientVersion, Version serverVersion, string serverCoreVersion, string lsClientVersion, string details) {
            lblClientVersion.Text = VersionHelper.GetFullStringFromVersion(clientVersion);
            lblClientCoreVersion.Text = VersionHelper.GetFullStringFromCore();
            lblSupportedServerVersion.Text = VersionHelper.GetFullStringFromVersion(VersionHelper.GetLSVersionFromAssembly<LSServerVersionAttribute>(Assembly.GetExecutingAssembly()));

            lblServerVersion.Text = VersionHelper.GetFullStringFromVersion(serverVersion);
            lblServerCoreVersion.Text = serverCoreVersion;
            lblSupportedClientVersion.Text = lsClientVersion;

            rtbDetails.Text = details;
        }
    }
}
