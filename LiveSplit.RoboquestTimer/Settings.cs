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
        public bool DeathSave { get; set; }
        public bool ResetGame { get; set; }
        public bool GameSave { get; set; }

        public Settings()
        {
            InitializeComponent();

            ResetDeath = false;
            DeathSave = false;
            ResetGame = true;
            GameSave = false;

            cbResetDeath.DataBindings.Add("Checked", this, "ResetDeath", false, DataSourceUpdateMode.OnPropertyChanged);
            cbDeathSave.DataBindings.Add("Checked", this, "DeathSave", false, DataSourceUpdateMode.OnPropertyChanged);
            cbResetGame.DataBindings.Add("Checked", this, "ResetGame", false, DataSourceUpdateMode.OnPropertyChanged);
            cbGameSave.DataBindings.Add("Checked", this, "GameSave", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void SetSettings(System.Xml.XmlNode node)
        {
            System.Xml.XmlElement element = (System.Xml.XmlElement)node;

            ResetDeath = SettingsHelper.ParseBool(element["ResetDeath"]);
            DeathSave = SettingsHelper.ParseBool(element["DeathSave"]);
            ResetGame = SettingsHelper.ParseBool(element["ResetGame"]);
            GameSave = SettingsHelper.ParseBool(element["GameSave"]);
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
            SettingsHelper.CreateSetting(document, parent, "DeathSave", DeathSave) ^
            SettingsHelper.CreateSetting(document, parent, "ResetGame", ResetGame) ^
            SettingsHelper.CreateSetting(document, parent, "GameSave", GameSave);
        }

        private void CBResetDeath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbResetDeath.Checked == true)
            {
                ResetDeath = true;
                cbDeathSave.Enabled = cbResetDeath.Checked;
            }
            else
            {
                ResetDeath = false;
                cbDeathSave.Enabled = cbResetDeath.Checked;
            }
        }

        private void CBDeathSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeathSave.Checked == true)
            {
                DeathSave = true;
            }
            else
            {
                DeathSave = false;
            }
        }

        private void CBResetGame_CheckedChanged(object sender, EventArgs e)
        {
            if (cbResetGame.Checked == true)
            {
                ResetGame = true;
                cbGameSave.Enabled = cbResetGame.Checked;
            }
            else
            {
                ResetGame = false;
                cbGameSave.Enabled = cbResetGame.Checked;
            }
        }

        private void CBGameSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGameSave.Checked == true)
            {
                GameSave = true;
            }
            else
            {
                GameSave = false;
            }
        }
    }
}
