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

namespace LiveSplit.RoboquestTimer
{
    partial class Settings : UserControl
    {
        public bool ResetDeath { get; set; }
        public bool ResetGame { get; set; }

        public Settings()
        {
            InitializeComponent();

            ResetDeath = false;
            ResetGame = true;

            cbResetDeath.DataBindings.Add("Checked", this, "ResetDeath", false, DataSourceUpdateMode.OnPropertyChanged);
            cbResetGame.DataBindings.Add("Checked", this, "ResetGame", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void SetSettings(System.Xml.XmlNode node)
        {
            System.Xml.XmlElement element = (System.Xml.XmlElement)node;

            ResetDeath = SettingsHelper.ParseBool(element["ResetDeath"]);
            ResetGame = SettingsHelper.ParseBool(element["ResetGame"]);
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
            SettingsHelper.CreateSetting(document, parent, "ResetDeath", ResetDeath) ^
            SettingsHelper.CreateSetting(document, parent, "ResetGame", ResetGame);
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
