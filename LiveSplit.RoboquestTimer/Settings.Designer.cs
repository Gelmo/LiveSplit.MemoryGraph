using LiveSplit.UI;
using System;
using System.ComponentModel;
using System.Linq;

namespace LiveSplit.RoboquestTimer
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpRoboquest = new System.Windows.Forms.GroupBox();
            this.cmbRQVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbResetDeath = new System.Windows.Forms.CheckBox();
            this.cbResetGame = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpRoboquest.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoboquest
            // 
            this.grpRoboquest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoboquest.Controls.Add(this.cmbRQVersion);
            this.grpRoboquest.Controls.Add(this.label1);
            this.grpRoboquest.Controls.Add(this.cbResetDeath);
            this.grpRoboquest.Controls.Add(this.cbResetGame);
            this.grpRoboquest.Location = new System.Drawing.Point(11, 11);
            this.grpRoboquest.Margin = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Name = "grpRoboquest";
            this.grpRoboquest.Padding = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Size = new System.Drawing.Size(436, 71);
            this.grpRoboquest.TabIndex = 0;
            this.grpRoboquest.TabStop = false;
            this.grpRoboquest.Text = "Roboquest";
            this.grpRoboquest.Enter += new System.EventHandler(this.GrpRoboquest_Enter);
            // 
            // cmbRQVersion
            // 
            this.cmbRQVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRQVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRQVersion.FormattingEnabled = true;
            this.cmbRQVersion.Items.AddRange(new object[] {
            "-None-",
            "Steam"});
            this.cmbRQVersion.Location = new System.Drawing.Point(51, 15);
            this.cmbRQVersion.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRQVersion.Name = "cmbRQVersion";
            this.cmbRQVersion.Size = new System.Drawing.Size(375, 21);
            this.cmbRQVersion.TabIndex = 9;
            this.cmbRQVersion.SelectedValueChanged += new System.EventHandler(this.CmbRQVersion_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Version:";
            // 
            // cbResetDeath
            // 
            this.cbResetDeath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbResetDeath.AutoSize = true;
            this.cbResetDeath.Location = new System.Drawing.Point(9, 46);
            this.cbResetDeath.Name = "cbResetDeath";
            this.cbResetDeath.Size = new System.Drawing.Size(136, 17);
            this.cbResetDeath.TabIndex = 2;
            this.cbResetDeath.Text = "Reset timer upon death";
            this.cbResetDeath.UseVisualStyleBackColor = true;
            this.cbResetDeath.CheckedChanged += new System.EventHandler(this.CBResetDeath_CheckedChanged);
            // 
            // cbResetGame
            // 
            this.cbResetGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResetGame.AutoSize = true;
            this.cbResetGame.Checked = true;
            this.cbResetGame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbResetGame.Location = new System.Drawing.Point(175, 46);
            this.cbResetGame.Name = "cbResetGame";
            this.cbResetGame.Size = new System.Drawing.Size(260, 17);
            this.cbResetGame.TabIndex = 3;
            this.cbResetGame.Text = "Reset timer when restarting or going to Basecamp";
            this.cbResetGame.UseVisualStyleBackColor = true;
            this.cbResetGame.CheckedChanged += new System.EventHandler(this.CBResetGame_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.grpRoboquest);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Size = new System.Drawing.Size(459, 553);
            this.grpRoboquest.ResumeLayout(false);
            this.grpRoboquest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoboquest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRQVersion;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbResetDeath;
        private System.Windows.Forms.CheckBox cbResetGame;
    }
}
