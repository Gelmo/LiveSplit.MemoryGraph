using LiveSplit.ComponentUtil;
using LiveSplit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Roboquest
{

    enum GraphStyle
    {
        [Description("Single Bar")]
        SingleBar,
        [Description("Filled Graph")]
        FilledGraph,
        [Description("Polygonal Graph")]
        Polygonal,
        [Description("Polygonal Overflowing Graph")]
        PolygonalOverflow
    }

    enum GradientType
    {
        [Description("Plain")]
        Plain,
        [Description("Vertical")]
        Vertical,
        [Description("Horizontal")]
        Horizontal
    }

    enum GraphGradientType
    {
        [Description("Plain")]
        Plain,
        [Description("Vertical")]
        Vertical,
        [Description("Horizontal")]
        Horizontal,
        [Description("By Value")]
        ByValue
    }

    enum Position
    {
        [Description("None")]
        None,
        [Description("Left")]
        Left,
        [Description("Right")]
        Right,
        [Description("Center in Graph")]
        CenterInGraph,
        [Description("Left in Graph")]
        LeftInGraph,
        [Description("Right in Graph")]
        RightInGraph
    }

    partial class Settings : UserControl
    {
        public Color BackgroundColor { get; set; }
        public Color BackgroundColor2 { get; set; }
        public List<Color> GraphColors { get; set; } = new List<Color>();
        /// <summary>
        /// Yields the GraphColors. If there are no GraphColors, yields Color.Red.
        /// </summary>
        public IEnumerable<Color> GraphColorsEnumeration => GraphColors.Any() ? GraphColors : new List<Color> { Color.Red };

        public float MinimumValue { get; set; }
        public float MaximumValue { get; set; }
        public int GraphWidth { get; set; }
        public int GraphHeight { get; set; }
        public int HorizontalMargins { get; set; }
        public int VerticalMargins { get; set; }

        public GraphStyle GraphStyle { get; set; }
        public GradientType BackgroundGradient { get; set; }
        public GraphGradientType GraphGradient { get; set; }
        public bool GraphSillyColors { get; set; }
        public Position ValueTextPosition { get; set; }
        public Position DescriptiveTextPosition { get; set; }
        public bool LocalMax { get; set; }

        public Color DescriptiveTextColor { get; set; }
        public Font DescriptiveTextFont { get; set; }
        public bool DescriptiveTextOverrideColor { get; set; }
        public bool DescriptiveTextOverrideFont { get; set; }

        public Color ValueTextColor { get; set; }
        public Font ValueTextFont { get; set; }
        public bool ValueTextOverrideColor { get; set; }
        public bool ValueTextOverrideFont { get; set; }
        public int ValueTextDecimals { get; set; }

        public string DescriptiveText { get; set; }

        public Settings()
        {
            InitializeComponent();

            BackgroundColor = Color.Transparent;
            BackgroundColor2 = Color.Transparent;
            MinimumValue = 0;
            MaximumValue = 3500;
            GraphWidth = 110;
            GraphHeight = 30;
            HorizontalMargins = 0;
            VerticalMargins = 0;
            GraphStyle = GraphStyle.FilledGraph;
            BackgroundGradient = GradientType.Plain;
            GraphGradient = GraphGradientType.Plain;
            GraphSillyColors = false;
            ValueTextPosition = Position.Right;
            DescriptiveTextPosition = Position.Left;
            LocalMax = false;
            ValueTextDecimals = 2;
            DescriptiveText = "Speed";
            DescriptiveTextFont = overrideControlDescriptiveText.OverridingFont;
            ValueTextFont = overrideControlValueText.OverridingFont;

            btnBackgroundColor1.DataBindings.Add("BackColor", this, "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            btnBackgroundColor2.DataBindings.Add("BackColor", this, "BackgroundColor2", false, DataSourceUpdateMode.OnPropertyChanged);

            txtMinimumValue.DataBindings.Add("Text", this, "MinimumValue", false, DataSourceUpdateMode.OnPropertyChanged);
            txtMaximumValue.DataBindings.Add("Text", this, "MaximumValue", false, DataSourceUpdateMode.OnPropertyChanged);
            numWidth.DataBindings.Add("Value", this, "GraphWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            numHeight.DataBindings.Add("Value", this, "GraphHeight", false, DataSourceUpdateMode.OnPropertyChanged);
            numHorizontalMargins.DataBindings.Add("Value", this, "HorizontalMargins", false, DataSourceUpdateMode.OnPropertyChanged);
            numVerticalMargins.DataBindings.Add("Value", this, "VerticalMargins", false, DataSourceUpdateMode.OnPropertyChanged);
            numValueTextDecimals.DataBindings.Add("Value", this, "ValueTextDecimals", false, DataSourceUpdateMode.OnPropertyChanged);

            cmbGraphStyle.DataBindings.Add("SelectedValue", this, "GraphStyle", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBackgroundGradientType.DataBindings.Add("SelectedValue", this, "BackgroundGradient", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbGraphGradientType.DataBindings.Add("SelectedValue", this, "GraphGradient", false, DataSourceUpdateMode.OnPropertyChanged);
            colorsCBSillyColors.DataBindings.Add("Checked", this, "GraphSillyColors", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbValueTextPosition.DataBindings.Add("SelectedValue", this, "ValueTextPosition", false, DataSourceUpdateMode.OnPropertyChanged);

            cmbDescriptiveTextPosition.DataBindings.Add("SelectedValue", this, "DescriptiveTextPosition", false, DataSourceUpdateMode.OnPropertyChanged);
            localMaxCB.DataBindings.Add("Checked", this, "LocalMax", false, DataSourceUpdateMode.OnPropertyChanged);

            txtDescriptiveText.DataBindings.Add("Text", this, "DescriptiveText");

            overrideControlDescriptiveText.DataBindings.Add("OverridingColor", this, "DescriptiveTextColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlDescriptiveText.DataBindings.Add("OverridingFont", this, "DescriptiveTextFont", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlDescriptiveText.DataBindings.Add("OverrideColor", this, "DescriptiveTextOverrideColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlDescriptiveText.DataBindings.Add("OverrideFont", this, "DescriptiveTextOverrideFont", false, DataSourceUpdateMode.OnPropertyChanged);

            overrideControlValueText.DataBindings.Add("OverridingColor", this, "ValueTextColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlValueText.DataBindings.Add("OverridingFont", this, "ValueTextFont", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlValueText.DataBindings.Add("OverrideColor", this, "ValueTextOverrideColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlValueText.DataBindings.Add("OverrideFont", this, "ValueTextOverrideFont", false, DataSourceUpdateMode.OnPropertyChanged);

            AddComboboxDataSources();
        }

        private void ColorButtonClick(object sender, EventArgs e)
        {
            SettingsHelper.ColorButtonClick((Button)sender, this);
        }

        private List<Button> GraphColorButtons = new List<Button>();

        private void BtnAddColor_Click(object sender, EventArgs e)
        {
            SettingsHelper.ColorButtonClick(AddColorButton(), this);
        }

        private Button AddColorButton()
        {
            var newButton = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Location = new Point(btnAddColor.Location.X, btnAddColor.Location.Y),
                Margin = btnAddColor.Margin,
                Size = btnAddColor.Size,
                BackColor = GraphColors.Skip(GraphColorButtons.Count).FirstOrDefault(),
                UseVisualStyleBackColor = false
            };
            newButton.Click += new EventHandler(ColorButtonClick);
            newButton.BackColorChanged += new EventHandler(BackColorChangedEvent);

            var delta = btnDeleteColor.Location.X - btnAddColor.Location.X;
            btnAddColor.Location = new Point(btnAddColor.Location.X + delta, btnAddColor.Location.Y);
            btnDeleteColor.Location = new Point(btnDeleteColor.Location.X + delta, btnDeleteColor.Location.Y);

            grpGraph.Controls.Add(newButton);
            GraphColorButtons.Add(newButton);
            btnAddColor.Visible = !GraphColorButtons.Skip(12).Any();
            btnDeleteColor.Visible = GraphColorButtons.Skip(2).Any();

            return newButton;
        }

        private void BtnDeleteColor_Click(object sender, EventArgs e)
        {
            DeleteColorButton(true);
        }

        private void DeleteColorButton(bool fromButton)
        {
            var delta = btnDeleteColor.Location.X - btnAddColor.Location.X;
            btnAddColor.Location = new Point(btnAddColor.Location.X - delta, btnAddColor.Location.Y);
            btnDeleteColor.Location = new Point(btnDeleteColor.Location.X - delta, btnDeleteColor.Location.Y);

            grpGraph.Controls.Remove(GraphColorButtons.Last());
            GraphColorButtons.RemoveAt(GraphColorButtons.Count - 1);
            if (fromButton)
            {
                GraphColors.RemoveAt(GraphColors.Count - 1);
            }
            btnAddColor.Visible = !GraphColorButtons.Skip(12).Any();
            btnDeleteColor.Visible = GraphColorButtons.Skip(2).Any();
        }

        private void BackColorChangedEvent(object sender, EventArgs e)
        {
            GraphColors.Clear();
            GraphColors.AddRange(GraphColorButtons.Select(b => b.BackColor));
        }

        public void SetSettings(System.Xml.XmlNode node)
        {
            System.Xml.XmlElement element = (System.Xml.XmlElement)node;

            BackgroundColor = SettingsHelper.ParseColor(element["BackgroundColor"]);
            BackgroundColor2 = SettingsHelper.ParseColor(element["BackgroundColor2"]);
            GraphColors.Clear();

            // Regular parsing of GraphColors. We can't use a default Parser since it's a list and needs to be comma seperated.
            if (element[nameof(GraphColors)] != null)
            {
                var colorString = element[nameof(GraphColors)].InnerText;
                if (!string.IsNullOrWhiteSpace(colorString))
                {
                    GraphColors.AddRange(colorString.Split(',').Select(x => Color.FromArgb(int.Parse(x, NumberStyles.HexNumber))));
                }
            }
            // The trigger that occurs when GraphGradientType is Plain fires too early. Redo it!
            CmbGraphGradientType_SelectedValueChanged(null, null);
            MinimumValue = SettingsHelper.ParseFloat(element["MinimumValue"]);
            MaximumValue = SettingsHelper.ParseFloat(element["MaximumValue"]);
            GraphWidth = SettingsHelper.ParseInt(element["GraphWidth"]);
            GraphHeight = SettingsHelper.ParseInt(element["GraphHeight"]); ;
            HorizontalMargins = SettingsHelper.ParseInt(element["HorizontalMargins"]); ;
            VerticalMargins = SettingsHelper.ParseInt(element["VerticalMargins"]); ;
            GraphStyle = SettingsHelper.ParseEnum<GraphStyle>(element["GraphStyle"]);
            BackgroundGradient = SettingsHelper.ParseEnum<GradientType>(element["BackgroundGradient"]);
            GraphGradient = SettingsHelper.ParseEnum<GraphGradientType>(element["GraphGradient"]);
            GraphSillyColors = SettingsHelper.ParseBool(element["GraphSillyColors"]);
            ValueTextPosition = SettingsHelper.ParseEnum<Position>(element["ValueTextPosition"]);
            DescriptiveTextPosition = SettingsHelper.ParseEnum<Position>(element["DescriptiveTextPosition"]);
            LocalMax = SettingsHelper.ParseBool(element["LocalMax"]);
            DescriptiveText = SettingsHelper.ParseString(element["DescriptiveText"]);

            DescriptiveTextColor = SettingsHelper.ParseColor(element["DescriptiveTextColor"]);
            DescriptiveTextFont = SettingsHelper.GetFontFromElement(element["DescriptiveTextFont"]);
            DescriptiveTextOverrideColor = SettingsHelper.ParseBool(element["DescriptiveTextOverrideColor"]);
            DescriptiveTextOverrideFont = SettingsHelper.ParseBool(element["DescriptiveTextOverrideFont"]);

            ValueTextColor = SettingsHelper.ParseColor(element["ValueTextColor"]);
            ValueTextFont = SettingsHelper.GetFontFromElement(element["ValueTextFont"]);
            ValueTextOverrideColor = SettingsHelper.ParseBool(element["ValueTextOverrideColor"]);
            ValueTextOverrideFont = SettingsHelper.ParseBool(element["ValueTextOverrideFont"]);
            ValueTextDecimals = SettingsHelper.ParseInt(element["ValueTextDecimals"]);
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            System.Xml.XmlElement parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        public static int CreateSetting(XmlDocument document, XmlElement parent, string name, IEnumerable<Color> colors)
        {
            if (document != null)
            {
                var element = document.CreateElement(name);
                element.InnerText = String.Join(",", colors.Select(c => c.ToArgb().ToString("X8")));
                parent.AppendChild(element);
            }
            return colors.GetHashCode();
        }

        private int CreateSettingsNode(System.Xml.XmlDocument document, System.Xml.XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundColor", BackgroundColor) ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundColor2", BackgroundColor2) ^
            CreateSetting(document, parent, nameof(GraphColors), GraphColors) ^
            SettingsHelper.CreateSetting(document, parent, "MinimumValue", MinimumValue) ^
            SettingsHelper.CreateSetting(document, parent, "MaximumValue", MaximumValue) ^
            SettingsHelper.CreateSetting(document, parent, "GraphWidth", GraphWidth) ^
            SettingsHelper.CreateSetting(document, parent, "GraphHeight", GraphHeight) ^
            SettingsHelper.CreateSetting(document, parent, "HorizontalMargins", HorizontalMargins) ^
            SettingsHelper.CreateSetting(document, parent, "VerticalMargins", VerticalMargins) ^
            SettingsHelper.CreateSetting(document, parent, "GraphStyle", GraphStyle) ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundGradient", BackgroundGradient) ^
            SettingsHelper.CreateSetting(document, parent, "GraphGradient", GraphGradient) ^
            SettingsHelper.CreateSetting(document, parent, "GraphSillyColors", GraphSillyColors) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextPosition", ValueTextPosition) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextPosition", DescriptiveTextPosition) ^
            SettingsHelper.CreateSetting(document, parent, "LocalMax", LocalMax) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveText", DescriptiveText) ^

            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextColor", DescriptiveTextColor) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextFont", DescriptiveTextFont) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextOverrideColor", DescriptiveTextOverrideColor) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextOverrideFont", DescriptiveTextOverrideFont) ^

            SettingsHelper.CreateSetting(document, parent, "ValueTextColor", ValueTextColor) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextFont", ValueTextFont) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextOverrideColor", ValueTextOverrideColor) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextOverrideFont", ValueTextOverrideFont) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextDecimals", ValueTextDecimals);
        }

        private void CmbBackgroundGradientType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbBackgroundGradientType.SelectedValue == null)
            {
                return;
            }

            btnBackgroundColor1.Visible = ((GradientType)cmbBackgroundGradientType.SelectedValue != GradientType.Plain);
            btnBackgroundColor2.DataBindings.Clear();
            btnBackgroundColor2.DataBindings.Add("BackColor", this, btnBackgroundColor1.Visible ? "BackgroundColor2" : "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CmbGraphGradientType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbGraphGradientType.SelectedValue == null)
            {
                return;
            }
            else if ((GraphGradientType)cmbGraphGradientType.SelectedValue == GraphGradientType.Horizontal &&
                     GraphStyle == GraphStyle.FilledGraph)
            {
                MessageBox.Show("Horizontal Gradient for Filled Graph is not supported", "Invalid value!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGraphGradientType.SelectedValue = GraphGradientType.Plain;
                return;
            }

            while (GraphColorButtons.Any())
            {
                DeleteColorButton(false);
            }
            var ggt = (GraphGradientType)cmbGraphGradientType.SelectedValue;
            switch (ggt)
            {
                default:
                case GraphGradientType.Plain:
                    AddColorButton();

                    btnAddColor.Visible = false;
                    btnDeleteColor.Visible = false;
                    break;

                case GraphGradientType.Vertical:
                case GraphGradientType.Horizontal:
                case GraphGradientType.ByValue:
                    foreach (var color in GraphColors)
                    {
                        AddColorButton();
                    }

                    btnAddColor.Visible = !GraphColorButtons.Skip(12).Any();
                    btnDeleteColor.Visible = GraphColorButtons.Skip(2).Any();
                    break;
            }
        }

        private void TxtMinimumValue_Validating(object sender, CancelEventArgs e)
        {
            if (!float.TryParse(txtMinimumValue.Text, out _))
            {
                MessageBox.Show("Minimum Value needs to be a number!", "Invalid value!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }

        private void TxtMaximumValue_Validating(object sender, CancelEventArgs e)
        {
            if (!float.TryParse(txtMaximumValue.Text, out _))
            {
                MessageBox.Show("Maximum Value needs to be a number!", "Invalid value!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }

        private void ColorsCBSillyColors_MouseHover(object sender, EventArgs e)
        {
            //Displays tooltip
            toolTip.Show("This options allows the multiplier to exceed '1.0', meaning that if using color grading, the maximum color can be brighter than specified.", colorsCBSillyColors);
        }

        private void LocalMaxCB_MouseHover(object sender, EventArgs e)
        {
            // Displays tooltip
            toolTip.Show("Shows the largest value which is visible on the graph.", localMaxCB);
        }

        private void GrpRoboquest_Enter(object sender, EventArgs e)
        {

        }
    }
}
