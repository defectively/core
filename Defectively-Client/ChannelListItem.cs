using System;
using System.Drawing;
using System.Windows.Forms;

namespace DefectivelyClient
{
    public partial class ChannelListItem : UserControl
    {
        public delegate void DSelectionChanged(ChannelListItem sender, bool selected);

        public event DSelectionChanged SelectionChanged;

        public string ChannelName { get; set; }
        public string ChannelId { get; set; }
        public string ChannelCreator { get; set; }
        public string ChannelProtection { get; set; }
        public int MemberCount { get; set; }
        public int MemberCapacity { get; set; }

        private SelectionMode _Mode = SelectionMode.None;

        public SelectionMode Mode {
            get { return _Mode; }
            set { _Mode = value;
                this.BackColor = Palettes[(int)value].DarkShade;
                lblProtection.BackColor = Palettes[(int) value].MediumShade;
                lblMemberCount.BackColor = Palettes[(int) value].LightShade;
            }
        }

        public ChannelListItem() {
            InitializeComponent();
            this.Click += OnClicked;
            lblChannelName.Click += OnClicked;
            lblCreator.Click += OnClicked;
            lblProtection.Click += OnClicked;
            lblMemberCount.Click += OnClicked;
            this.MouseEnter += OnEntered;
            lblChannelName.MouseEnter += OnEntered;
            lblCreator.MouseEnter += OnEntered;
            lblProtection.MouseEnter += OnEntered;
            lblMemberCount.MouseEnter += OnEntered;
            this.MouseLeave += OnLeaved;
            lblChannelName.MouseLeave += OnLeaved;
            lblCreator.MouseLeave += OnLeaved;
            lblProtection.MouseLeave += OnLeaved;
            lblMemberCount.MouseLeave += OnLeaved;
        }

        private void OnLeaved(object sender, EventArgs e) {
            if (Mode != SelectionMode.Selected) {
                Mode = SelectionMode.None;
            }
        }

        private void OnEntered(object sender, EventArgs e) {
            if (Mode != SelectionMode.Selected) {
                Mode = SelectionMode.Hovered;
            }
        }

        private void OnClicked(object sender, EventArgs e) {
            Mode = Mode == SelectionMode.Selected ? SelectionMode.Hovered : SelectionMode.Selected;
            SelectionChanged?.Invoke(this, Mode == SelectionMode.Selected);
        }

        public void RefreshItem() {
            lblChannelName.Text = $"{ChannelName} (#{ChannelId})";
            lblCreator.Text = $"Created by {ChannelCreator}";
            lblProtection.Text = ChannelProtection;
            lblMemberCount.Text = $"{MemberCount}/{(MemberCapacity != -1 ? MemberCapacity.ToString() : "∞")}";
        }

        private ColorShadePalette[] Palettes = {
            new ColorShadePalette {DarkShade = Color.FromArgb(255, 51, 51, 51), MediumShade = Color.FromArgb(255, 56, 56, 56), LightShade = Color.FromArgb(255, 61, 61, 61)},
            new ColorShadePalette {DarkShade = Color.FromArgb(255, 68, 68, 68), MediumShade = Color.FromArgb(255, 73, 73, 73), LightShade = Color.FromArgb(255, 78, 78, 78)},
            new ColorShadePalette {DarkShade = Color.FromArgb(255, 0, 102, 204), MediumShade = Color.FromArgb(255, 5, 107, 209), LightShade = Color.FromArgb(255, 10, 112, 214)}
        };

        public struct ColorShadePalette
        {
            public Color DarkShade { get; set; }
            public Color MediumShade { get; set; }
            public Color LightShade { get; set; }
        }

        public enum SelectionMode
        {
            None,
            Hovered,
            Selected
        }
    }
}
