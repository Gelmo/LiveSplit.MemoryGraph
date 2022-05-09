using LiveSplit.ComponentUtil;
using LiveSplit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        List<string> gamesOnTheList = new List<string>();
        static string componentsFolder = "Components";
        public static string listsFile = "LiveSplit.Roboquest.Games.xml";
        public static string ListsFilePath
        {
            get
            {
                var listsFilePath = Path.Combine(componentsFolder, listsFile);
                if (File.Exists(listsFilePath))
                {
                    return listsFilePath;
                }
                else
                {
                    // If the new file hasn't been downloaded, keep using the old one as a fallback.
                    return Path.Combine(componentsFolder, "LiveSplit.RoboquestList.xml");
                }
            }
        }

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

        public string ProcessName { get; set; }
        public string DescriptiveText { get; set; }

        public DeepPointer LastLevelPointer { get; set; }
        public DeepPointer GameLevelPointer { get; set; }
        public DeepPointer PlayerLevelPointer { get; set; }
        public DeepPointer GameTimePointer { get; set; }
        public DeepPointer GameTimeOnLevelStartPointer { get; set; }
        public DeepPointer TotalRunTimePointer { get; set; }
        public DeepPointer BGameTimePausedPointer { get; set; }
        public DeepPointer BIsDeadPointer { get; set; }
        public DeepPointer AnimSpeedPointer { get; set; }
        public DeepPointer BCurrentlyFightingBossPointer { get; set; }
        public bool ResetDeath { get; set; }
        public bool ResetGame { get; set; }

        public Settings()
        {
            InitializeComponent();

            if (File.Exists(ListsFilePath))
            {
                LoadXML();
            }
            else
            {
                ComboBox_ListOfGames.Enabled = false;
            }


            HandleDestroyed += UpdatePointer;

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
            ProcessName = "RoboQuest-Win64-Shipping";
            DescriptiveText = "Speed";
            DescriptiveTextFont = overrideControlDescriptiveText.OverridingFont;
            ValueTextFont = overrideControlValueText.OverridingFont;
            ResetDeath = false;
            ResetGame = true;

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

            txtProcessName.DataBindings.Add("Text", this, "ProcessName");
            txtDescriptiveText.DataBindings.Add("Text", this, "DescriptiveText");

            overrideControlDescriptiveText.DataBindings.Add("OverridingColor", this, "DescriptiveTextColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlDescriptiveText.DataBindings.Add("OverridingFont", this, "DescriptiveTextFont", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlDescriptiveText.DataBindings.Add("OverrideColor", this, "DescriptiveTextOverrideColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlDescriptiveText.DataBindings.Add("OverrideFont", this, "DescriptiveTextOverrideFont", false, DataSourceUpdateMode.OnPropertyChanged);

            overrideControlValueText.DataBindings.Add("OverridingColor", this, "ValueTextColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlValueText.DataBindings.Add("OverridingFont", this, "ValueTextFont", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlValueText.DataBindings.Add("OverrideColor", this, "ValueTextOverrideColor", false, DataSourceUpdateMode.OnPropertyChanged);
            overrideControlValueText.DataBindings.Add("OverrideFont", this, "ValueTextOverrideFont", false, DataSourceUpdateMode.OnPropertyChanged);

            cbResetDeath.DataBindings.Add("Checked", this, "ResetDeath", false, DataSourceUpdateMode.OnPropertyChanged);
            cbResetGame.DataBindings.Add("Checked", this, "ResetGame", false, DataSourceUpdateMode.OnPropertyChanged);

            AddComboboxDataSources();
        }

        private void UpdatePointer(object sender, EventArgs e)
        {
            int[] lastlevel_offsets;
            int[] gamelevel_offsets;
            int[] playerlevel_offsets;
            int[] gametime_offsets;
            int[] gametimeonlevelstart_offsets;
            int[] totalruntime_offsets;
            int[] bgametimepaused_offsets;
            int[] bisdead_offsets;
            int[] animspeed_offsets;
            int[] bcurrentlyfightingboss_offsets;

            if (TryParseHex(txtBase.Text, out int baseAddress))
            {
                if (!string.IsNullOrWhiteSpace(txtLastLevelOffsets.Text))
                {
                    string[] lastleveloffsetStrings = txtLastLevelOffsets.Text.Split(',');
                    lastlevel_offsets = new int[lastleveloffsetStrings.Length];
                    int j = 0;
                    foreach (string lastleveloffset in lastleveloffsetStrings)
                    {
                        TryParseHex(lastleveloffset.Trim(), out lastlevel_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    lastlevel_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtGameLevelOffsets.Text))
                {
                    string[] gameleveloffsetStrings = txtGameLevelOffsets.Text.Split(',');
                    gamelevel_offsets = new int[gameleveloffsetStrings.Length];
                    int j = 0;
                    foreach (string gameleveloffset in gameleveloffsetStrings)
                    {
                        TryParseHex(gameleveloffset.Trim(), out gamelevel_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    gamelevel_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtPlayerLevelOffsets.Text))
                {
                    string[] playerleveloffsetStrings = txtPlayerLevelOffsets.Text.Split(',');
                    playerlevel_offsets = new int[playerleveloffsetStrings.Length];
                    int j = 0;
                    foreach (string playerleveloffset in playerleveloffsetStrings)
                    {
                        TryParseHex(playerleveloffset.Trim(), out playerlevel_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    playerlevel_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtGameTimeOffsets.Text))
                {
                    string[] gametimeoffsetStrings = txtGameTimeOffsets.Text.Split(',');
                    gametime_offsets = new int[gametimeoffsetStrings.Length];
                    int j = 0;
                    foreach (string gametimeoffset in gametimeoffsetStrings)
                    {
                        TryParseHex(gametimeoffset.Trim(), out gametime_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    gametime_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtGameTimeOnLevelStartOffsets.Text))
                {
                    string[] gametimeonlevelstartoffsetStrings = txtGameTimeOnLevelStartOffsets.Text.Split(',');
                    gametimeonlevelstart_offsets = new int[gametimeonlevelstartoffsetStrings.Length];
                    int j = 0;
                    foreach (string gametimeonlevelstartoffset in gametimeonlevelstartoffsetStrings)
                    {
                        TryParseHex(gametimeonlevelstartoffset.Trim(), out gametimeonlevelstart_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    gametimeonlevelstart_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtTotalRunTimeOffsets.Text))
                {
                    string[] totalruntimeoffsetStrings = txtTotalRunTimeOffsets.Text.Split(',');
                    totalruntime_offsets = new int[totalruntimeoffsetStrings.Length];
                    int j = 0;
                    foreach (string totalruntimeoffset in totalruntimeoffsetStrings)
                    {
                        TryParseHex(totalruntimeoffset.Trim(), out totalruntime_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    totalruntime_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtBGameTimePausedOffsets.Text))
                {
                    string[] bgametimepausedoffsetStrings = txtBGameTimePausedOffsets.Text.Split(',');
                    bgametimepaused_offsets = new int[bgametimepausedoffsetStrings.Length];
                    int j = 0;
                    foreach (string bgametimepausedoffset in bgametimepausedoffsetStrings)
                    {
                        TryParseHex(bgametimepausedoffset.Trim(), out bgametimepaused_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    bgametimepaused_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtBIsDeadOffsets.Text))
                {
                    string[] bisdeadoffsetStrings = txtBIsDeadOffsets.Text.Split(',');
                    bisdead_offsets = new int[bisdeadoffsetStrings.Length];
                    int j = 0;
                    foreach (string bisdeadoffset in bisdeadoffsetStrings)
                    {
                        TryParseHex(bisdeadoffset.Trim(), out bisdead_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    bisdead_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtAnimSpeedOffsets.Text))
                {
                    string[] animspeedoffsetStrings = txtAnimSpeedOffsets.Text.Split(',');
                    animspeed_offsets = new int[animspeedoffsetStrings.Length];
                    int j = 0;
                    foreach (string animspeedoffset in animspeedoffsetStrings)
                    {
                        TryParseHex(animspeedoffset.Trim(), out animspeed_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    animspeed_offsets = new int[0];
                }

                if (!string.IsNullOrWhiteSpace(txtBCurrentlyFightingBossOffsets.Text))
                {
                    string[] bcurrentlyfightingbossoffsetStrings = txtBCurrentlyFightingBossOffsets.Text.Split(',');
                    bcurrentlyfightingboss_offsets = new int[bcurrentlyfightingbossoffsetStrings.Length];
                    int j = 0;
                    foreach (string bcurrentlyfightingbossoffset in bcurrentlyfightingbossoffsetStrings)
                    {
                        TryParseHex(bcurrentlyfightingbossoffset.Trim(), out bcurrentlyfightingboss_offsets[j]);
                        j += 1;
                    }
                }
                else
                {
                    bcurrentlyfightingboss_offsets = new int[0];
                }

                if (string.IsNullOrWhiteSpace(txtModule.Text))
                {
                    LastLevelPointer = new DeepPointer(baseAddress, lastlevel_offsets);
                    GameLevelPointer = new DeepPointer(baseAddress, gamelevel_offsets);
                    PlayerLevelPointer = new DeepPointer(baseAddress, playerlevel_offsets);
                    GameTimePointer = new DeepPointer(baseAddress, gametime_offsets);
                    GameTimeOnLevelStartPointer = new DeepPointer(baseAddress, gametimeonlevelstart_offsets);
                    TotalRunTimePointer = new DeepPointer(baseAddress, totalruntime_offsets);
                    BGameTimePausedPointer = new DeepPointer(baseAddress, bgametimepaused_offsets);
                    BIsDeadPointer = new DeepPointer(baseAddress, bisdead_offsets);
                    BCurrentlyFightingBossPointer = new DeepPointer(baseAddress, bcurrentlyfightingboss_offsets);
                    AnimSpeedPointer = new DeepPointer(baseAddress, animspeed_offsets);
                }
                else if (txtModule.Text == "[absolute_base]")
                {
                    LastLevelPointer = new DeepPointer(new IntPtr(baseAddress), lastlevel_offsets);
                    GameLevelPointer = new DeepPointer(new IntPtr(baseAddress), gamelevel_offsets);
                    PlayerLevelPointer = new DeepPointer(new IntPtr(baseAddress), playerlevel_offsets);
                    GameTimePointer = new DeepPointer(new IntPtr(baseAddress), gametime_offsets);
                    GameTimeOnLevelStartPointer = new DeepPointer(new IntPtr(baseAddress), gametimeonlevelstart_offsets);
                    TotalRunTimePointer = new DeepPointer(new IntPtr(baseAddress), totalruntime_offsets);
                    BGameTimePausedPointer = new DeepPointer(new IntPtr(baseAddress), bgametimepaused_offsets);
                    BIsDeadPointer = new DeepPointer(new IntPtr(baseAddress), bisdead_offsets);
                    BCurrentlyFightingBossPointer = new DeepPointer(new IntPtr(baseAddress), bcurrentlyfightingboss_offsets);
                    AnimSpeedPointer = new DeepPointer(new IntPtr(baseAddress), animspeed_offsets);
                }
                else
                {
                    LastLevelPointer = new DeepPointer(txtModule.Text, baseAddress, lastlevel_offsets);
                    GameLevelPointer = new DeepPointer(txtModule.Text, baseAddress, gamelevel_offsets);
                    PlayerLevelPointer = new DeepPointer(txtModule.Text, baseAddress, playerlevel_offsets);
                    GameTimePointer = new DeepPointer(txtModule.Text, baseAddress, gametime_offsets);
                    GameTimeOnLevelStartPointer = new DeepPointer(txtModule.Text, baseAddress, gametimeonlevelstart_offsets);
                    TotalRunTimePointer = new DeepPointer(txtModule.Text, baseAddress, totalruntime_offsets);
                    BGameTimePausedPointer = new DeepPointer(txtModule.Text, baseAddress, bgametimepaused_offsets);
                    BIsDeadPointer = new DeepPointer(txtModule.Text, baseAddress, bisdead_offsets);
                    BCurrentlyFightingBossPointer = new DeepPointer(txtModule.Text, baseAddress, bcurrentlyfightingboss_offsets);
                    AnimSpeedPointer = new DeepPointer(txtModule.Text, baseAddress, animspeed_offsets);
                }
            }
            else
            {
                LastLevelPointer = null;
                GameLevelPointer = null;
                PlayerLevelPointer = null;
                GameTimePointer = null;
                GameTimeOnLevelStartPointer = null;
                TotalRunTimePointer = null;
                BGameTimePausedPointer = null;
                BIsDeadPointer = null;
                AnimSpeedPointer = null;
                BCurrentlyFightingBossPointer = null;
            }
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
            ProcessName = SettingsHelper.ParseString(element["ProcessName"]);
            DescriptiveText = SettingsHelper.ParseString(element["DescriptiveText"]);

            var selectedGame = SettingsHelper.ParseString(element["SelectedGame"]);
            if (selectedGame != null)
            {
                if (ComboBox_ListOfGames.DataSource is List<string> games && games.Contains(selectedGame))
                {
                    ComboBox_ListOfGames.SelectedItem = selectedGame;
                }
            }

            txtModule.Text = SettingsHelper.ParseString(element["Module"]);
            txtBase.Text = SettingsHelper.ParseString(element["Base"]);
            txtLastLevelOffsets.Text = SettingsHelper.ParseString(element["LastLevelOffsets"]);
            txtGameLevelOffsets.Text = SettingsHelper.ParseString(element["GameLevelOffsets"]);
            txtPlayerLevelOffsets.Text = SettingsHelper.ParseString(element["PlayerLevelOffsets"]);
            txtGameTimeOffsets.Text = SettingsHelper.ParseString(element["GameTimeOffsets"]);
            txtGameTimeOnLevelStartOffsets.Text = SettingsHelper.ParseString(element["GameTimeOnLevelStartOffsets"]);
            txtTotalRunTimeOffsets.Text = SettingsHelper.ParseString(element["TotalRunTimeOffsets"]);
            txtBGameTimePausedOffsets.Text = SettingsHelper.ParseString(element["BGameTimePausedOffsets"]);
            txtBIsDeadOffsets.Text = SettingsHelper.ParseString(element["BIsDeadOffsets"]);
            txtAnimSpeedOffsets.Text = SettingsHelper.ParseString(element["AnimSpeedOffsets"]);
            txtBCurrentlyFightingBossOffsets.Text = SettingsHelper.ParseString(element["BCurrentlyFightingBossOffsets"]);

            DescriptiveTextColor = SettingsHelper.ParseColor(element["DescriptiveTextColor"]);
            DescriptiveTextFont = SettingsHelper.GetFontFromElement(element["DescriptiveTextFont"]);
            DescriptiveTextOverrideColor = SettingsHelper.ParseBool(element["DescriptiveTextOverrideColor"]);
            DescriptiveTextOverrideFont = SettingsHelper.ParseBool(element["DescriptiveTextOverrideFont"]);

            ValueTextColor = SettingsHelper.ParseColor(element["ValueTextColor"]);
            ValueTextFont = SettingsHelper.GetFontFromElement(element["ValueTextFont"]);
            ValueTextOverrideColor = SettingsHelper.ParseBool(element["ValueTextOverrideColor"]);
            ValueTextOverrideFont = SettingsHelper.ParseBool(element["ValueTextOverrideFont"]);
            ValueTextDecimals = SettingsHelper.ParseInt(element["ValueTextDecimals"]);

            ResetDeath = SettingsHelper.ParseBool(element["ResetDeath"]);
            ResetGame = SettingsHelper.ParseBool(element["ResetGame"]);

            UpdatePointer(null, null);
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
            SettingsHelper.CreateSetting(document, parent, "ProcessName", ProcessName) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveText", DescriptiveText) ^

            SettingsHelper.CreateSetting(document, parent, "SelectedGame", ComboBox_ListOfGames.SelectedValue) ^

            SettingsHelper.CreateSetting(document, parent, "Module", txtModule.Text) ^
            SettingsHelper.CreateSetting(document, parent, "Base", txtBase.Text) ^
            SettingsHelper.CreateSetting(document, parent, "LastLevelOffsets", txtLastLevelOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "GameLevelOffsets", txtGameLevelOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "PlayerLevelOffsets", txtPlayerLevelOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "GameTimeOffsets", txtGameTimeOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "GameTimeOnLevelStartOffsets", txtGameTimeOnLevelStartOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "TotalRunTimeOffsets", txtTotalRunTimeOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "BGameTimePausedOffsets", txtBGameTimePausedOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "BIsDeadOffsets", txtBIsDeadOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "AnimSpeedOffsets", txtAnimSpeedOffsets.Text) ^
            SettingsHelper.CreateSetting(document, parent, "BCurrentlyFightingBossOffsets", txtBCurrentlyFightingBossOffsets.Text) ^

            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextColor", DescriptiveTextColor) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextFont", DescriptiveTextFont) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextOverrideColor", DescriptiveTextOverrideColor) ^
            SettingsHelper.CreateSetting(document, parent, "DescriptiveTextOverrideFont", DescriptiveTextOverrideFont) ^

            SettingsHelper.CreateSetting(document, parent, "ValueTextColor", ValueTextColor) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextFont", ValueTextFont) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextOverrideColor", ValueTextOverrideColor) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextOverrideFont", ValueTextOverrideFont) ^
            SettingsHelper.CreateSetting(document, parent, "ValueTextDecimals", ValueTextDecimals) ^

            SettingsHelper.CreateSetting(document, parent, "ResetDeath", ResetDeath) ^
            SettingsHelper.CreateSetting(document, parent, "ResetGame", ResetGame);
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

        private void TxtBase_Validating(object sender, CancelEventArgs e)
        {
            if (!TryParseHex(txtBase.Text, out _))
            {
                MessageBox.Show("'Base' needs to be a hexadecimal number!", "Invalid value!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }

        private void LastLevelOffsets_Validating(object sender, CancelEventArgs e)
        {
            var lastlevel_offsets = txtLastLevelOffsets.Text.Split(',');
            if (lastlevel_offsets.Length == 1 && string.IsNullOrEmpty(lastlevel_offsets[0]))
            {
                return;
            }

            foreach (string lastleveloffset in lastlevel_offsets)
            {
                if (!TryParseHex(lastleveloffset, out _))
                {
                    MessageBox.Show("All lastlevel offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void GameLevelOffsets_Validating(object sender, CancelEventArgs e)
        {
            var gamelevel_offsets = txtGameLevelOffsets.Text.Split(',');
            if (gamelevel_offsets.Length == 1 && string.IsNullOrEmpty(gamelevel_offsets[0]))
            {
                return;
            }

            foreach (string gameleveloffset in gamelevel_offsets)
            {
                if (!TryParseHex(gameleveloffset, out _))
                {
                    MessageBox.Show("All gamelevel offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void PlayerLevelOffsets_Validating(object sender, CancelEventArgs e)
        {
            var playerlevel_offsets = txtPlayerLevelOffsets.Text.Split(',');
            if (playerlevel_offsets.Length == 1 && string.IsNullOrEmpty(playerlevel_offsets[0]))
            {
                return;
            }

            foreach (string playerleveloffset in playerlevel_offsets)
            {
                if (!TryParseHex(playerleveloffset, out _))
                {
                    MessageBox.Show("All playerlevel offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void GameTimeOffsets_Validating(object sender, CancelEventArgs e)
        {
            var gametime_offsets = txtGameTimeOffsets.Text.Split(',');
            if (gametime_offsets.Length == 1 && string.IsNullOrEmpty(gametime_offsets[0]))
            {
                return;
            }

            foreach (string gametimeoffset in gametime_offsets)
            {
                if (!TryParseHex(gametimeoffset, out _))
                {
                    MessageBox.Show("All gametime offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void GameTimeOnLevelStartOffsets_Validating(object sender, CancelEventArgs e)
        {
            var gametimeonlevelstart_offsets = txtGameTimeOnLevelStartOffsets.Text.Split(',');
            if (gametimeonlevelstart_offsets.Length == 1 && string.IsNullOrEmpty(gametimeonlevelstart_offsets[0]))
            {
                return;
            }

            foreach (string gametimeonlevelstartoffset in gametimeonlevelstart_offsets)
            {
                if (!TryParseHex(gametimeonlevelstartoffset, out _))
                {
                    MessageBox.Show("All gametimeonlevelstart offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void TotalRunTimeOffsets_Validating(object sender, CancelEventArgs e)
        {
            var totalruntime_offsets = txtTotalRunTimeOffsets.Text.Split(',');
            if (totalruntime_offsets.Length == 1 && string.IsNullOrEmpty(totalruntime_offsets[0]))
            {
                return;
            }

            foreach (string totalruntimeoffset in totalruntime_offsets)
            {
                if (!TryParseHex(totalruntimeoffset, out _))
                {
                    MessageBox.Show("All totalruntime offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BGameTimePausedOffsets_Validating(object sender, CancelEventArgs e)
        {
            var bgametimepaused_offsets = txtBGameTimePausedOffsets.Text.Split(',');
            if (bgametimepaused_offsets.Length == 1 && string.IsNullOrEmpty(bgametimepaused_offsets[0]))
            {
                return;
            }

            foreach (string bgametimepausedoffset in bgametimepaused_offsets)
            {
                if (!TryParseHex(bgametimepausedoffset, out _))
                {
                    MessageBox.Show("All bgametimepaused offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BIsDeadOffsets_Validating(object sender, CancelEventArgs e)
        {
            var bisdead_offsets = txtBIsDeadOffsets.Text.Split(',');
            if (bisdead_offsets.Length == 1 && string.IsNullOrEmpty(bisdead_offsets[0]))
            {
                return;
            }

            foreach (string bisdeadoffset in bisdead_offsets)
            {
                if (!TryParseHex(bisdeadoffset, out _))
                {
                    MessageBox.Show("All bisdead offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void AnimSpeedOffsets_Validating(object sender, CancelEventArgs e)
        {
            var animspeed_offsets = txtAnimSpeedOffsets.Text.Split(',');
            if (animspeed_offsets.Length == 1 && string.IsNullOrEmpty(animspeed_offsets[0]))
            {
                return;
            }

            foreach (string animspeedoffset in animspeed_offsets)
            {
                if (!TryParseHex(animspeedoffset, out _))
                {
                    MessageBox.Show("All speed offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BCurrentlyFightingBossOffsets_Validating(object sender, CancelEventArgs e)
        {
            var bcurrentlyfightingboss_offsets = txtBCurrentlyFightingBossOffsets.Text.Split(',');
            if (bcurrentlyfightingboss_offsets.Length == 1 && string.IsNullOrEmpty(bcurrentlyfightingboss_offsets[0]))
            {
                return;
            }

            foreach (string bcurrentlyfightingbossoffset in bcurrentlyfightingboss_offsets)
            {
                if (!TryParseHex(bcurrentlyfightingbossoffset, out _))
                {
                    MessageBox.Show("All bcurrentlyfightingboss offsets need to be hexadecimal numbers!", "Invalid value!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
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

        public static bool TryParseHex(string str, out int integer)
        {
            integer = 0;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            else
            {
                if (str.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase))
                {
                    str = str.Substring(2);
                }

                return int.TryParse(str, NumberStyles.HexNumber, null, out integer);
            }
        }

        #region XML database functions
        //////////////////////////////////////////
        /////Related to loading XML, list etc.////
        //////////////////////////////////////////

        private void LoadXML()
        {
            ComboBox_ListOfGames.DataSource = null;
            gamesOnTheList.Clear();
            XmlDocument XmlGames = new XmlDocument();
            XmlGames.Load(ListsFilePath);
            gamesOnTheList.Add("-None-");
            foreach (XmlNode gameNode in XmlGames.DocumentElement)
            {
                string name = gameNode.Attributes[0].Value;
                gamesOnTheList.Add(name);
            }

            ComboBox_ListOfGames.DataSource = gamesOnTheList;
            ComboBox_ListOfGames.Enabled = true;
        }

        private void ComboBox_ListOfGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)ComboBox_ListOfGames.SelectedValue == "-None-")
            {
            }
            else
            {
                XmlDocument XmlGames = new XmlDocument();
                XmlGames.Load(ListsFilePath);
                foreach (XmlNode gameNode in XmlGames.DocumentElement)
                {
                    string name = gameNode.Attributes[0].Value;
                    if (name == (string)ComboBox_ListOfGames.SelectedValue)
                    {
                        ProcessName = GetSafeStringValueFromXML(gameNode, "process");
                        txtProcessName.Text = ProcessName;

                        txtModule.Text = GetSafeStringValueFromXML(gameNode, "module");
                        txtBase.Text = GetSafeStringValueFromXML(gameNode, "base");
                        txtLastLevelOffsets.Text = GetSafeStringValueFromXML(gameNode, "lastlevel_offsets");
                        txtGameLevelOffsets.Text = GetSafeStringValueFromXML(gameNode, "gamelevel_offsets");
                        txtPlayerLevelOffsets.Text = GetSafeStringValueFromXML(gameNode, "playerlevel_offsets");
                        txtGameTimeOffsets.Text = GetSafeStringValueFromXML(gameNode, "gametime_offsets");
                        txtGameTimeOnLevelStartOffsets.Text = GetSafeStringValueFromXML(gameNode, "gametimeonlevelstart_offsets");
                        txtTotalRunTimeOffsets.Text = GetSafeStringValueFromXML(gameNode, "totalruntime_offsets");
                        txtBGameTimePausedOffsets.Text = GetSafeStringValueFromXML(gameNode, "bgametimepaused_offsets");
                        txtBIsDeadOffsets.Text = GetSafeStringValueFromXML(gameNode, "bisdead_offsets");
                        txtAnimSpeedOffsets.Text = GetSafeStringValueFromXML(gameNode, "animspeed_offsets");
                        txtBCurrentlyFightingBossOffsets.Text = GetSafeStringValueFromXML(gameNode, "bcurrentlyfightingboss_offsets");
                        txtMaximumValue.Text = GetSafeStringValueFromXML(gameNode, "maximumValue", txtMaximumValue.Text);
                        numValueTextDecimals.Value = GetSafeDecimalFromXML(gameNode, "decimals");

                        break;
                    }
                }
            }
        }
        private void B_UpdateXML_Click(object sender, EventArgs e)
        {
            MonkeyDownloadingXML _downloader = new MonkeyDownloadingXML();
            bool result = _downloader.DownloadNew();
            if (result)
            {
                LoadXML();
            }
        }

        #region GetSafeValuesFunctions
        private string GetSafeStringValueFromXML(XmlNode docNode, string nodeName, string defaultValue = "")
        {
            if (docNode.SelectSingleNode(nodeName) != null)
            {
                return docNode.SelectSingleNode(nodeName).InnerText;
            }
            else
                return defaultValue;
        }

        private decimal GetSafeDecimalFromXML(XmlNode docNode, string nodeName, decimal defaultValue = 0m)
        {
            if (docNode.SelectSingleNode(nodeName) != null)
            {
                string text = docNode.SelectSingleNode(nodeName).InnerText;
                return decimal.TryParse(text, out decimal value) ? value : defaultValue;
            }
            return defaultValue;
        }
        #endregion

        #endregion

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

        private void CBResetDeath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbResetDeath.Checked == true)
            {
                ResetDeath = true;
            }
            else
            {
                ResetDeath = false;
            }
        }

        private void CBResetGame_CheckedChanged(object sender, EventArgs e)
        {
            if (cbResetGame.Checked == true)
            {
                ResetGame = true;
            }
            else
            {
                ResetGame = false;
            }
        }
    }
}
