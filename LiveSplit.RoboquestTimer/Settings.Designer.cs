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
            this.grpGame = new System.Windows.Forms.GroupBox();
            this.cbResetGame = new System.Windows.Forms.CheckBox();
            this.cbGameSave = new System.Windows.Forms.CheckBox();
            this.grpDeath = new System.Windows.Forms.GroupBox();
            this.cbResetDeath = new System.Windows.Forms.CheckBox();
            this.cbDeathSave = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpRoboquest.SuspendLayout();
            this.grpGame.SuspendLayout();
            this.grpDeath.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoboquest
            // 
            this.grpRoboquest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoboquest.Controls.Add(this.grpGame);
            this.grpRoboquest.Controls.Add(this.grpDeath);
            this.grpRoboquest.Location = new System.Drawing.Point(11, 11);
            this.grpRoboquest.Margin = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Name = "grpRoboquest";
            this.grpRoboquest.Padding = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Size = new System.Drawing.Size(308, 164);
            this.grpRoboquest.TabIndex = 0;
            this.grpRoboquest.TabStop = false;
            this.grpRoboquest.Text = "Roboquest";
            // 
            // grpGame
            // 
            this.grpGame.Controls.Add(this.cbResetGame);
            this.grpGame.Controls.Add(this.cbGameSave);
            this.grpGame.Location = new System.Drawing.Point(17, 91);
            this.grpGame.Name = "grpGame";
            this.grpGame.Size = new System.Drawing.Size(267, 50);
            this.grpGame.TabIndex = 4;
            this.grpGame.TabStop = false;
            this.grpGame.Text = "Reset timer when restarting or going to Basecamp";
            // 
            // cbResetGame
            // 
            this.cbResetGame.AutoSize = true;
            this.cbResetGame.Checked = true;
            this.cbResetGame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbResetGame.Location = new System.Drawing.Point(16, 21);
            this.cbResetGame.Name = "cbResetGame";
            this.cbResetGame.Size = new System.Drawing.Size(54, 17);
            this.cbResetGame.TabIndex = 5;
            this.cbResetGame.Text = "Reset";
            this.cbResetGame.UseVisualStyleBackColor = true;
            this.cbResetGame.CheckedChanged += new System.EventHandler(this.CBResetGame_CheckedChanged);
            // 
            // cbGameSave
            // 
            this.cbGameSave.AutoSize = true;
            this.cbGameSave.Enabled = this.cbResetGame.Checked;
            this.cbGameSave.Location = new System.Drawing.Point(78, 21);
            this.cbGameSave.Name = "cbGameSave";
            this.cbGameSave.Size = new System.Drawing.Size(77, 17);
            this.cbGameSave.TabIndex = 6;
            this.cbGameSave.Text = "Save splits";
            this.cbGameSave.UseVisualStyleBackColor = true;
            this.cbGameSave.CheckedChanged += new System.EventHandler(this.CBGameSave_CheckedChanged);
            // 
            // grpDeath
            // 
            this.grpDeath.Controls.Add(this.cbResetDeath);
            this.grpDeath.Controls.Add(this.cbDeathSave);
            this.grpDeath.Location = new System.Drawing.Point(17, 24);
            this.grpDeath.Name = "grpDeath";
            this.grpDeath.Size = new System.Drawing.Size(165, 50);
            this.grpDeath.TabIndex = 1;
            this.grpDeath.TabStop = false;
            this.grpDeath.Text = "Reset timer upon death";
            // 
            // cbResetDeath
            // 
            this.cbResetDeath.AutoSize = true;
            this.cbResetDeath.Checked = false;
            this.cbResetDeath.Location = new System.Drawing.Point(16, 21);
            this.cbResetDeath.Name = "cbResetDeath";
            this.cbResetDeath.Size = new System.Drawing.Size(54, 17);
            this.cbResetDeath.TabIndex = 2;
            this.cbResetDeath.Text = "Reset";
            this.cbResetDeath.UseVisualStyleBackColor = true;
            this.cbResetDeath.CheckedChanged += new System.EventHandler(this.CBResetDeath_CheckedChanged);
            // 
            // cbDeathSave
            // 
            this.cbDeathSave.AutoSize = true;
            this.cbDeathSave.Enabled = this.cbResetDeath.Checked;
            this.cbDeathSave.Location = new System.Drawing.Point(78, 21);
            this.cbDeathSave.Name = "cbDeathSave";
            this.cbDeathSave.Size = new System.Drawing.Size(77, 17);
            this.cbDeathSave.TabIndex = 3;
            this.cbDeathSave.Text = "Save splits";
            this.cbDeathSave.UseVisualStyleBackColor = true;
            this.cbDeathSave.CheckedChanged += new System.EventHandler(this.CBDeathSave_CheckedChanged);
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
            this.grpGame.ResumeLayout(false);
            this.grpGame.PerformLayout();
            this.grpDeath.ResumeLayout(false);
            this.grpDeath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoboquest;
        private System.Windows.Forms.GroupBox grpGame;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbResetGame;
        private System.Windows.Forms.CheckBox cbGameSave;
        private System.Windows.Forms.GroupBox grpDeath;
        private System.Windows.Forms.CheckBox cbResetDeath;
        private System.Windows.Forms.CheckBox cbDeathSave;
    }
}
