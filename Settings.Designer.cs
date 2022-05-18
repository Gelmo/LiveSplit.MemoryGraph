using LiveSplit.UI;
using System;
using System.ComponentModel;
using System.Linq;

namespace LiveSplit.Roboquest
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
            this.grpDescriptiveText = new System.Windows.Forms.GroupBox();
            this.overrideControlDescriptiveText = new LiveSplit.Roboquest.TextStyleOverrideControl();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDescriptiveText = new System.Windows.Forms.TextBox();
            this.lblDescriptiveTextPosition = new System.Windows.Forms.Label();
            this.cmbDescriptiveTextPosition = new System.Windows.Forms.ComboBox();
            this.grpRoboquest = new System.Windows.Forms.GroupBox();
            this.cmbRQVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpGraph = new System.Windows.Forms.GroupBox();
            this.btnDeleteColor = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.colorsCBSillyColors = new System.Windows.Forms.CheckBox();
            this.cmbGraphGradientType = new System.Windows.Forms.ComboBox();
            this.lblGraphStyle = new System.Windows.Forms.Label();
            this.grpValueText = new System.Windows.Forms.GroupBox();
            this.localMaxCB = new System.Windows.Forms.CheckBox();
            this.numValueTextDecimals = new System.Windows.Forms.NumericUpDown();
            this.lblDecimals = new System.Windows.Forms.Label();
            this.overrideControlValueText = new LiveSplit.Roboquest.TextStyleOverrideControl();
            this.cmbValueTextPosition = new System.Windows.Forms.ComboBox();
            this.lblValueTextPosition = new System.Windows.Forms.Label();
            this.cmbGraphStyle = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaximumValue = new System.Windows.Forms.Label();
            this.txtMaximumValue = new System.Windows.Forms.TextBox();
            this.lblMinimumValue = new System.Windows.Forms.Label();
            this.lblHorizontalMargins = new System.Windows.Forms.Label();
            this.txtMinimumValue = new System.Windows.Forms.TextBox();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.lblVerticalMargins = new System.Windows.Forms.Label();
            this.numVerticalMargins = new System.Windows.Forms.NumericUpDown();
            this.numHorizontalMargins = new System.Windows.Forms.NumericUpDown();
            this.lblGraphColor = new System.Windows.Forms.Label();
            this.lblBackgroundColor = new System.Windows.Forms.Label();
            this.btnBackgroundColor1 = new System.Windows.Forms.Button();
            this.btnBackgroundColor2 = new System.Windows.Forms.Button();
            this.cmbBackgroundGradientType = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpDescriptiveText.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grpRoboquest.SuspendLayout();
            this.grpGraph.SuspendLayout();
            this.grpValueText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValueTextDecimals)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticalMargins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizontalMargins)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDescriptiveText
            // 
            this.grpDescriptiveText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDescriptiveText.Controls.Add(this.overrideControlDescriptiveText);
            this.grpDescriptiveText.Controls.Add(this.tableLayoutPanel4);
            this.grpDescriptiveText.Location = new System.Drawing.Point(4, 265);
            this.grpDescriptiveText.Margin = new System.Windows.Forms.Padding(2);
            this.grpDescriptiveText.Name = "grpDescriptiveText";
            this.grpDescriptiveText.Padding = new System.Windows.Forms.Padding(2);
            this.grpDescriptiveText.Size = new System.Drawing.Size(428, 76);
            this.grpDescriptiveText.TabIndex = 6;
            this.grpDescriptiveText.TabStop = false;
            this.grpDescriptiveText.Text = "Descriptive Text";
            // 
            // overrideControlDescriptiveText
            // 
            this.overrideControlDescriptiveText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overrideControlDescriptiveText.Location = new System.Drawing.Point(4, 44);
            this.overrideControlDescriptiveText.Margin = new System.Windows.Forms.Padding(2);
            this.overrideControlDescriptiveText.Name = "overrideControlDescriptiveText";
            this.overrideControlDescriptiveText.OverrideColor = false;
            this.overrideControlDescriptiveText.OverrideFont = false;
            this.overrideControlDescriptiveText.OverridingColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.overrideControlDescriptiveText.OverridingFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.overrideControlDescriptiveText.Size = new System.Drawing.Size(420, 29);
            this.overrideControlDescriptiveText.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Controls.Add(this.txtDescriptiveText, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblDescriptiveTextPosition, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbDescriptiveTextPosition, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 15);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(420, 24);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // txtDescriptiveText
            // 
            this.txtDescriptiveText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescriptiveText.Location = new System.Drawing.Point(2, 2);
            this.txtDescriptiveText.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescriptiveText.Name = "txtDescriptiveText";
            this.txtDescriptiveText.Size = new System.Drawing.Size(206, 20);
            this.txtDescriptiveText.TabIndex = 2;
            // 
            // lblDescriptiveTextPosition
            // 
            this.lblDescriptiveTextPosition.AutoSize = true;
            this.lblDescriptiveTextPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescriptiveTextPosition.Location = new System.Drawing.Point(220, 0);
            this.lblDescriptiveTextPosition.Margin = new System.Windows.Forms.Padding(10, 0, 2, 0);
            this.lblDescriptiveTextPosition.Name = "lblDescriptiveTextPosition";
            this.lblDescriptiveTextPosition.Size = new System.Drawing.Size(58, 24);
            this.lblDescriptiveTextPosition.TabIndex = 0;
            this.lblDescriptiveTextPosition.Text = "Position:";
            this.lblDescriptiveTextPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDescriptiveTextPosition
            // 
            this.cmbDescriptiveTextPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDescriptiveTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescriptiveTextPosition.FormattingEnabled = true;
            this.cmbDescriptiveTextPosition.Location = new System.Drawing.Point(282, 2);
            this.cmbDescriptiveTextPosition.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDescriptiveTextPosition.Name = "cmbDescriptiveTextPosition";
            this.cmbDescriptiveTextPosition.Size = new System.Drawing.Size(136, 21);
            this.cmbDescriptiveTextPosition.TabIndex = 1;
            // 
            // grpRoboquest
            // 
            this.grpRoboquest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoboquest.Controls.Add(this.cmbRQVersion);
            this.grpRoboquest.Controls.Add(this.label1);
            this.grpRoboquest.Location = new System.Drawing.Point(11, 11);
            this.grpRoboquest.Margin = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Name = "grpRoboquest";
            this.grpRoboquest.Padding = new System.Windows.Forms.Padding(2);
            this.grpRoboquest.Size = new System.Drawing.Size(436, 46);
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
            // grpGraph
            // 
            this.grpGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGraph.Controls.Add(this.btnDeleteColor);
            this.grpGraph.Controls.Add(this.btnAddColor);
            this.grpGraph.Controls.Add(this.colorsCBSillyColors);
            this.grpGraph.Controls.Add(this.cmbGraphGradientType);
            this.grpGraph.Controls.Add(this.lblGraphStyle);
            this.grpGraph.Controls.Add(this.grpValueText);
            this.grpGraph.Controls.Add(this.grpDescriptiveText);
            this.grpGraph.Controls.Add(this.cmbGraphStyle);
            this.grpGraph.Controls.Add(this.tableLayoutPanel5);
            this.grpGraph.Controls.Add(this.lblGraphColor);
            this.grpGraph.Controls.Add(this.lblBackgroundColor);
            this.grpGraph.Controls.Add(this.btnBackgroundColor1);
            this.grpGraph.Controls.Add(this.btnBackgroundColor2);
            this.grpGraph.Controls.Add(this.cmbBackgroundGradientType);
            this.grpGraph.Location = new System.Drawing.Point(11, 59);
            this.grpGraph.Margin = new System.Windows.Forms.Padding(2);
            this.grpGraph.Name = "grpGraph";
            this.grpGraph.Padding = new System.Windows.Forms.Padding(2);
            this.grpGraph.Size = new System.Drawing.Size(436, 346);
            this.grpGraph.TabIndex = 1;
            this.grpGraph.TabStop = false;
            this.grpGraph.Text = "Speed Graph";
            // 
            // btnDeleteColor
            // 
            this.btnDeleteColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteColor.Location = new System.Drawing.Point(123, 167);
            this.btnDeleteColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteColor.Name = "btnDeleteColor";
            this.btnDeleteColor.Size = new System.Drawing.Size(18, 20);
            this.btnDeleteColor.TabIndex = 9;
            this.btnDeleteColor.Text = "-";
            this.btnDeleteColor.UseVisualStyleBackColor = false;
            this.btnDeleteColor.Click += new System.EventHandler(this.BtnDeleteColor_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColor.Location = new System.Drawing.Point(100, 167);
            this.btnAddColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(18, 20);
            this.btnAddColor.TabIndex = 8;
            this.btnAddColor.Text = "+";
            this.btnAddColor.UseVisualStyleBackColor = false;
            this.btnAddColor.Click += new System.EventHandler(this.BtnAddColor_Click);
            // 
            // colorsCBSillyColors
            // 
            this.colorsCBSillyColors.AutoSize = true;
            this.colorsCBSillyColors.Location = new System.Drawing.Point(7, 169);
            this.colorsCBSillyColors.Margin = new System.Windows.Forms.Padding(2);
            this.colorsCBSillyColors.Name = "colorsCBSillyColors";
            this.colorsCBSillyColors.Size = new System.Drawing.Size(76, 17);
            this.colorsCBSillyColors.TabIndex = 0;
            this.colorsCBSillyColors.Text = "Silly Colors";
            this.colorsCBSillyColors.UseVisualStyleBackColor = true;
            this.colorsCBSillyColors.MouseHover += new System.EventHandler(this.ColorsCBSillyColors_MouseHover);
            // 
            // cmbGraphGradientType
            // 
            this.cmbGraphGradientType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGraphGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraphGradientType.FormattingEnabled = true;
            this.cmbGraphGradientType.Location = new System.Drawing.Point(100, 143);
            this.cmbGraphGradientType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGraphGradientType.Name = "cmbGraphGradientType";
            this.cmbGraphGradientType.Size = new System.Drawing.Size(333, 21);
            this.cmbGraphGradientType.TabIndex = 4;
            this.cmbGraphGradientType.SelectedValueChanged += new System.EventHandler(this.CmbGraphGradientType_SelectedValueChanged);
            // 
            // lblGraphStyle
            // 
            this.lblGraphStyle.AutoSize = true;
            this.lblGraphStyle.Location = new System.Drawing.Point(4, 19);
            this.lblGraphStyle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGraphStyle.Name = "lblGraphStyle";
            this.lblGraphStyle.Size = new System.Drawing.Size(65, 13);
            this.lblGraphStyle.TabIndex = 5;
            this.lblGraphStyle.Text = "Graph Style:";
            this.lblGraphStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpValueText
            // 
            this.grpValueText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpValueText.Controls.Add(this.localMaxCB);
            this.grpValueText.Controls.Add(this.numValueTextDecimals);
            this.grpValueText.Controls.Add(this.lblDecimals);
            this.grpValueText.Controls.Add(this.overrideControlValueText);
            this.grpValueText.Controls.Add(this.cmbValueTextPosition);
            this.grpValueText.Controls.Add(this.lblValueTextPosition);
            this.grpValueText.Location = new System.Drawing.Point(4, 191);
            this.grpValueText.Margin = new System.Windows.Forms.Padding(2);
            this.grpValueText.Name = "grpValueText";
            this.grpValueText.Padding = new System.Windows.Forms.Padding(2);
            this.grpValueText.Size = new System.Drawing.Size(428, 74);
            this.grpValueText.TabIndex = 5;
            this.grpValueText.TabStop = false;
            this.grpValueText.Text = "Value as Text";
            // 
            // localMaxCB
            // 
            this.localMaxCB.AutoSize = true;
            this.localMaxCB.Location = new System.Drawing.Point(244, 19);
            this.localMaxCB.Margin = new System.Windows.Forms.Padding(2);
            this.localMaxCB.Name = "localMaxCB";
            this.localMaxCB.Size = new System.Drawing.Size(75, 17);
            this.localMaxCB.TabIndex = 8;
            this.localMaxCB.Text = "Local Max";
            this.localMaxCB.UseVisualStyleBackColor = true;
            this.localMaxCB.MouseHover += new System.EventHandler(this.LocalMaxCB_MouseHover);
            // 
            // numValueTextDecimals
            // 
            this.numValueTextDecimals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numValueTextDecimals.Location = new System.Drawing.Point(382, 18);
            this.numValueTextDecimals.Margin = new System.Windows.Forms.Padding(2);
            this.numValueTextDecimals.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numValueTextDecimals.Name = "numValueTextDecimals";
            this.numValueTextDecimals.Size = new System.Drawing.Size(40, 20);
            this.numValueTextDecimals.TabIndex = 3;
            // 
            // lblDecimals
            // 
            this.lblDecimals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDecimals.AutoSize = true;
            this.lblDecimals.Location = new System.Drawing.Point(326, 20);
            this.lblDecimals.Margin = new System.Windows.Forms.Padding(10, 0, 2, 0);
            this.lblDecimals.Name = "lblDecimals";
            this.lblDecimals.Size = new System.Drawing.Size(53, 13);
            this.lblDecimals.TabIndex = 2;
            this.lblDecimals.Text = "Decimals:";
            // 
            // overrideControlValueText
            // 
            this.overrideControlValueText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.overrideControlValueText.Location = new System.Drawing.Point(4, 42);
            this.overrideControlValueText.Margin = new System.Windows.Forms.Padding(2);
            this.overrideControlValueText.Name = "overrideControlValueText";
            this.overrideControlValueText.OverrideColor = false;
            this.overrideControlValueText.OverrideFont = false;
            this.overrideControlValueText.OverridingColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.overrideControlValueText.OverridingFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.overrideControlValueText.Size = new System.Drawing.Size(418, 27);
            this.overrideControlValueText.TabIndex = 2;
            // 
            // cmbValueTextPosition
            // 
            this.cmbValueTextPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValueTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValueTextPosition.FormattingEnabled = true;
            this.cmbValueTextPosition.Location = new System.Drawing.Point(56, 17);
            this.cmbValueTextPosition.Margin = new System.Windows.Forms.Padding(2);
            this.cmbValueTextPosition.Name = "cmbValueTextPosition";
            this.cmbValueTextPosition.Size = new System.Drawing.Size(184, 21);
            this.cmbValueTextPosition.TabIndex = 1;
            // 
            // lblValueTextPosition
            // 
            this.lblValueTextPosition.AutoSize = true;
            this.lblValueTextPosition.Location = new System.Drawing.Point(4, 20);
            this.lblValueTextPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValueTextPosition.Name = "lblValueTextPosition";
            this.lblValueTextPosition.Size = new System.Drawing.Size(47, 13);
            this.lblValueTextPosition.TabIndex = 0;
            this.lblValueTextPosition.Text = "Position:";
            // 
            // cmbGraphStyle
            // 
            this.cmbGraphStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGraphStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraphStyle.FormattingEnabled = true;
            this.cmbGraphStyle.Location = new System.Drawing.Point(74, 16);
            this.cmbGraphStyle.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGraphStyle.Name = "cmbGraphStyle";
            this.cmbGraphStyle.Size = new System.Drawing.Size(359, 21);
            this.cmbGraphStyle.TabIndex = 6;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblMaximumValue, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtMaximumValue, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblMinimumValue, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblHorizontalMargins, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtMinimumValue, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.numHeight, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblHeight, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblWidth, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.numWidth, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblVerticalMargins, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.numVerticalMargins, 4, 2);
            this.tableLayoutPanel5.Controls.Add(this.numHorizontalMargins, 1, 2);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 43);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 8, 2, 8);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(428, 70);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // lblMaximumValue
            // 
            this.lblMaximumValue.AutoSize = true;
            this.lblMaximumValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaximumValue.Location = new System.Drawing.Point(234, 0);
            this.lblMaximumValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaximumValue.Name = "lblMaximumValue";
            this.lblMaximumValue.Size = new System.Drawing.Size(94, 23);
            this.lblMaximumValue.TabIndex = 5;
            this.lblMaximumValue.Text = "Maximum Value:";
            this.lblMaximumValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaximumValue
            // 
            this.txtMaximumValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaximumValue.Location = new System.Drawing.Point(332, 2);
            this.txtMaximumValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaximumValue.Name = "txtMaximumValue";
            this.txtMaximumValue.Size = new System.Drawing.Size(94, 20);
            this.txtMaximumValue.TabIndex = 6;
            this.txtMaximumValue.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMaximumValue_Validating);
            // 
            // lblMinimumValue
            // 
            this.lblMinimumValue.AutoSize = true;
            this.lblMinimumValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinimumValue.Location = new System.Drawing.Point(2, 0);
            this.lblMinimumValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinimumValue.Name = "lblMinimumValue";
            this.lblMinimumValue.Size = new System.Drawing.Size(108, 23);
            this.lblMinimumValue.TabIndex = 5;
            this.lblMinimumValue.Text = "Minimum Value:";
            this.lblMinimumValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHorizontalMargins
            // 
            this.lblHorizontalMargins.AutoSize = true;
            this.lblHorizontalMargins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorizontalMargins.Location = new System.Drawing.Point(2, 46);
            this.lblHorizontalMargins.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHorizontalMargins.Name = "lblHorizontalMargins";
            this.lblHorizontalMargins.Size = new System.Drawing.Size(108, 24);
            this.lblHorizontalMargins.TabIndex = 5;
            this.lblHorizontalMargins.Text = "Horizontal Margins:";
            this.lblHorizontalMargins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMinimumValue
            // 
            this.txtMinimumValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMinimumValue.Location = new System.Drawing.Point(114, 2);
            this.txtMinimumValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtMinimumValue.Name = "txtMinimumValue";
            this.txtMinimumValue.Size = new System.Drawing.Size(94, 20);
            this.txtMinimumValue.TabIndex = 5;
            this.txtMinimumValue.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMinimumValue_Validating);
            // 
            // numHeight
            // 
            this.numHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numHeight.Location = new System.Drawing.Point(332, 25);
            this.numHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(94, 20);
            this.numHeight.TabIndex = 7;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeight.Location = new System.Drawing.Point(234, 23);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(94, 23);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "Height:";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWidth.Location = new System.Drawing.Point(2, 23);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(108, 23);
            this.lblWidth.TabIndex = 9;
            this.lblWidth.Text = "Width:";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numWidth
            // 
            this.numWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numWidth.Location = new System.Drawing.Point(114, 25);
            this.numWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(94, 20);
            this.numWidth.TabIndex = 10;
            // 
            // lblVerticalMargins
            // 
            this.lblVerticalMargins.AutoSize = true;
            this.lblVerticalMargins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVerticalMargins.Location = new System.Drawing.Point(234, 46);
            this.lblVerticalMargins.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVerticalMargins.Name = "lblVerticalMargins";
            this.lblVerticalMargins.Size = new System.Drawing.Size(94, 24);
            this.lblVerticalMargins.TabIndex = 11;
            this.lblVerticalMargins.Text = "Vertical Margins:";
            this.lblVerticalMargins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numVerticalMargins
            // 
            this.numVerticalMargins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numVerticalMargins.Location = new System.Drawing.Point(332, 48);
            this.numVerticalMargins.Margin = new System.Windows.Forms.Padding(2);
            this.numVerticalMargins.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numVerticalMargins.Name = "numVerticalMargins";
            this.numVerticalMargins.Size = new System.Drawing.Size(94, 20);
            this.numVerticalMargins.TabIndex = 12;
            // 
            // numHorizontalMargins
            // 
            this.numHorizontalMargins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numHorizontalMargins.Location = new System.Drawing.Point(114, 48);
            this.numHorizontalMargins.Margin = new System.Windows.Forms.Padding(2);
            this.numHorizontalMargins.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numHorizontalMargins.Name = "numHorizontalMargins";
            this.numHorizontalMargins.Size = new System.Drawing.Size(94, 20);
            this.numHorizontalMargins.TabIndex = 13;
            // 
            // lblGraphColor
            // 
            this.lblGraphColor.AutoSize = true;
            this.lblGraphColor.Location = new System.Drawing.Point(4, 145);
            this.lblGraphColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGraphColor.Name = "lblGraphColor";
            this.lblGraphColor.Size = new System.Drawing.Size(66, 13);
            this.lblGraphColor.TabIndex = 7;
            this.lblGraphColor.Text = "Graph Color:";
            this.lblGraphColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackgroundColor
            // 
            this.lblBackgroundColor.AutoSize = true;
            this.lblBackgroundColor.Location = new System.Drawing.Point(4, 122);
            this.lblBackgroundColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBackgroundColor.Name = "lblBackgroundColor";
            this.lblBackgroundColor.Size = new System.Drawing.Size(95, 13);
            this.lblBackgroundColor.TabIndex = 0;
            this.lblBackgroundColor.Text = "Background Color:";
            this.lblBackgroundColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBackgroundColor1
            // 
            this.btnBackgroundColor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackgroundColor1.Location = new System.Drawing.Point(100, 119);
            this.btnBackgroundColor1.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackgroundColor1.Name = "btnBackgroundColor1";
            this.btnBackgroundColor1.Size = new System.Drawing.Size(18, 20);
            this.btnBackgroundColor1.TabIndex = 2;
            this.btnBackgroundColor1.UseVisualStyleBackColor = false;
            this.btnBackgroundColor1.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // btnBackgroundColor2
            // 
            this.btnBackgroundColor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackgroundColor2.Location = new System.Drawing.Point(123, 119);
            this.btnBackgroundColor2.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackgroundColor2.Name = "btnBackgroundColor2";
            this.btnBackgroundColor2.Size = new System.Drawing.Size(18, 20);
            this.btnBackgroundColor2.TabIndex = 3;
            this.btnBackgroundColor2.UseVisualStyleBackColor = false;
            this.btnBackgroundColor2.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // cmbBackgroundGradientType
            // 
            this.cmbBackgroundGradientType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBackgroundGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackgroundGradientType.FormattingEnabled = true;
            this.cmbBackgroundGradientType.Location = new System.Drawing.Point(145, 119);
            this.cmbBackgroundGradientType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBackgroundGradientType.Name = "cmbBackgroundGradientType";
            this.cmbBackgroundGradientType.Size = new System.Drawing.Size(288, 21);
            this.cmbBackgroundGradientType.TabIndex = 1;
            this.cmbBackgroundGradientType.SelectedValueChanged += new System.EventHandler(this.CmbBackgroundGradientType_SelectedValueChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.grpRoboquest);
            this.Controls.Add(this.grpGraph);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Size = new System.Drawing.Size(459, 553);
            this.grpDescriptiveText.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.grpRoboquest.ResumeLayout(false);
            this.grpRoboquest.PerformLayout();
            this.grpGraph.ResumeLayout(false);
            this.grpGraph.PerformLayout();
            this.grpValueText.ResumeLayout(false);
            this.grpValueText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValueTextDecimals)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticalMargins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizontalMargins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void AddComboboxDataSources()
        {
            cmbGraphGradientType.DisplayMember = "Description";
            cmbGraphGradientType.ValueMember = "value";
            cmbGraphGradientType.DataSource = Enum.GetValues(typeof(GraphGradientType)).Cast<Enum>().Select(value =>
                new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                     typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                }).OrderBy(item => item.value).ToList();

            cmbBackgroundGradientType.DisplayMember = "Description";
            cmbBackgroundGradientType.ValueMember = "value";
            cmbBackgroundGradientType.DataSource = Enum.GetValues(typeof(GradientType)).Cast<Enum>().Select(value =>
                new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                     typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                }).OrderBy(item => item.value).ToList();

            cmbGraphStyle.DisplayMember = "Description";
            cmbGraphStyle.ValueMember = "value";
            cmbGraphStyle.DataSource = Enum.GetValues(typeof(GraphStyle)).Cast<Enum>().Select(value =>
                new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                     typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                }).OrderBy(item => item.value).ToList();

            cmbValueTextPosition.DisplayMember = "Description";
            cmbValueTextPosition.ValueMember = "value";
            cmbValueTextPosition.DataSource = Enum.GetValues(typeof(Position)).Cast<Enum>().Select(value =>
               new
               {
                   (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                   value
               }).OrderBy(item => item.value).ToList();

            cmbDescriptiveTextPosition.DisplayMember = "Description";
            cmbDescriptiveTextPosition.ValueMember = "value";
            cmbDescriptiveTextPosition.DataSource = Enum.GetValues(typeof(Position)).Cast<Enum>().Select(value =>
               new
               {
                   (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                   value
               }).OrderBy(item => item.value).ToList();
        }
        private System.Windows.Forms.GroupBox grpRoboquest;
        private System.Windows.Forms.GroupBox grpGraph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblMaximumValue;
        private System.Windows.Forms.TextBox txtMaximumValue;
        private System.Windows.Forms.Label lblMinimumValue;
        private System.Windows.Forms.ComboBox cmbGraphStyle;
        private System.Windows.Forms.Label lblGraphStyle;
        private System.Windows.Forms.TextBox txtMinimumValue;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label lblHorizontalMargins;
        private System.Windows.Forms.Label lblVerticalMargins;
        private System.Windows.Forms.NumericUpDown numVerticalMargins;
        private System.Windows.Forms.NumericUpDown numHorizontalMargins;
        private System.Windows.Forms.GroupBox grpValueText;
        private System.Windows.Forms.GroupBox grpDescriptiveText;
        private TextStyleOverrideControl overrideControlDescriptiveText;
        private TextStyleOverrideControl overrideControlValueText;
        private System.Windows.Forms.Label lblValueTextPosition;
        private System.Windows.Forms.ComboBox cmbValueTextPosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox cmbDescriptiveTextPosition;
        private System.Windows.Forms.TextBox txtDescriptiveText;
        private System.Windows.Forms.Label lblDescriptiveTextPosition;
        private System.Windows.Forms.Label lblDecimals;
        private System.Windows.Forms.NumericUpDown numValueTextDecimals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRQVersion;
        private System.Windows.Forms.Label lblGraphColor;
        private System.Windows.Forms.ComboBox cmbGraphGradientType;
        private System.Windows.Forms.Label lblBackgroundColor;
        private System.Windows.Forms.ComboBox cmbBackgroundGradientType;
        private System.Windows.Forms.Button btnBackgroundColor1;
        private System.Windows.Forms.Button btnBackgroundColor2;
        private System.Windows.Forms.CheckBox colorsCBSillyColors;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox localMaxCB;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Button btnDeleteColor;
    }
}
