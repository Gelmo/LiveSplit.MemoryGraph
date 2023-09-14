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
            this.grpRoboquest.Controls.Add(this.cbResetDeath);
            this.grpRoboquest.Controls.Add(this.cbResetGame);
            this.grpRoboquest.Location = new System.Drawing.Point(11, 11);
            this.grpRoboquest.Margin = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Name = "grpRoboquest";
            this.grpRoboquest.Padding = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Size = new System.Drawing.Size(436, 44);
            this.grpRoboquest.TabIndex = 0;
            this.grpRoboquest.TabStop = false;
            this.grpRoboquest.Text = "Roboquest";
            this.grpRoboquest.Enter += new System.EventHandler(this.GrpRoboquest_Enter);
            // 
            // cbResetDeath
            // 
            this.cbResetDeath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbResetDeath.AutoSize = true;
            this.cbResetDeath.Location = new System.Drawing.Point(9, 19);
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
            this.cbResetGame.Location = new System.Drawing.Point(175, 19);
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
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbResetDeath;
        private System.Windows.Forms.CheckBox cbResetGame;
    }
}
