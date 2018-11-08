namespace BioBaseDotNetDemo
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonAcquire = new System.Windows.Forms.Button();
            this.buttonForce = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDevices = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.comboBoxBiometricPosition = new System.Windows.Forms.ComboBox();
            this.checkBoxAutoCapture = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxDeviceCategory = new System.Windows.Forms.ListBox();
            this.labelDeviceCategory = new System.Windows.Forms.Label();
            this.comboBoxImpressionType = new System.Windows.Forms.ComboBox();
            this.checkBoxSaveDataAvailable = new System.Windows.Forms.CheckBox();
            this.labelDeviceCount = new System.Windows.Forms.Label();
            this.buttonCloseCategory = new System.Windows.Forms.Button();
            this.buttonOpenCategory = new System.Windows.Forms.Button();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.Brightness = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxBrightness = new System.Windows.Forms.CheckBox();
            this.labelContrast = new System.Windows.Forms.Label();
            this.Contrast = new System.Windows.Forms.NumericUpDown();
            this.checkBoxContrast = new System.Windows.Forms.CheckBox();
            this.labelGain = new System.Windows.Forms.Label();
            this.Gain = new System.Windows.Forms.NumericUpDown();
            this.checkBoxGain = new System.Windows.Forms.CheckBox();
            this.labelLeftBank1 = new System.Windows.Forms.Label();
            this.LeftBank1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxLeftBank1 = new System.Windows.Forms.CheckBox();
            this.labelLeftBank2 = new System.Windows.Forms.Label();
            this.LeftBank2 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxLeftBank2 = new System.Windows.Forms.CheckBox();
            this.labelLeftBank3 = new System.Windows.Forms.Label();
            this.LeftBank3 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxLeftBank3 = new System.Windows.Forms.CheckBox();
            this.labelRightBank1 = new System.Windows.Forms.Label();
            this.RightBank1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRightBank1 = new System.Windows.Forms.CheckBox();
            this.labelRightBank2 = new System.Windows.Forms.Label();
            this.RightBank2 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRightBank2 = new System.Windows.Forms.CheckBox();
            this.labelRightBank3 = new System.Windows.Forms.Label();
            this.RightBank3 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRightBank3 = new System.Windows.Forms.CheckBox();
            this.groupBoxLatentControls = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).BeginInit();
            this.Brightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast)).BeginInit();
            this.Contrast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gain)).BeginInit();
            this.Gain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBank1)).BeginInit();
            this.LeftBank1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBank2)).BeginInit();
            this.LeftBank2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBank3)).BeginInit();
            this.LeftBank3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBank1)).BeginInit();
            this.RightBank1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBank2)).BeginInit();
            this.RightBank2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBank3)).BeginInit();
            this.RightBank3.SuspendLayout();
            this.groupBoxLatentControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(1026, 39);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(344, 166);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.Visible = false;
            // 
            // buttonAcquire
            // 
            this.buttonAcquire.Location = new System.Drawing.Point(12, 42);
            this.buttonAcquire.Name = "buttonAcquire";
            this.buttonAcquire.Size = new System.Drawing.Size(75, 23);
            this.buttonAcquire.TabIndex = 14;
            this.buttonAcquire.Text = "Captura";
            this.buttonAcquire.UseVisualStyleBackColor = true;
            this.buttonAcquire.Click += new System.EventHandler(this.buttonAcquire_Click);
            // 
            // buttonForce
            // 
            this.buttonForce.Location = new System.Drawing.Point(91, 42);
            this.buttonForce.Name = "buttonForce";
            this.buttonForce.Size = new System.Drawing.Size(75, 23);
            this.buttonForce.TabIndex = 15;
            this.buttonForce.Text = "Forzar";
            this.buttonForce.UseVisualStyleBackColor = true;
            this.buttonForce.Click += new System.EventHandler(this.buttonForce_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(873, 189);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(91, 23);
            this.buttonOpen.TabIndex = 9;
            this.buttonOpen.Text = "Open Device";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Visible = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpenDevice_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(971, 189);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(91, 23);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close Device";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonCloseDevice_Click);
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.Location = new System.Drawing.Point(1017, 58);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.Size = new System.Drawing.Size(169, 108);
            this.listBoxDevices.TabIndex = 8;
            this.listBoxDevices.Visible = false;
            this.listBoxDevices.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(170, 42);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Detener";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDevices
            // 
            this.labelDevices.AutoSize = true;
            this.labelDevices.Location = new System.Drawing.Point(1014, 42);
            this.labelDevices.Name = "labelDevices";
            this.labelDevices.Size = new System.Drawing.Size(46, 13);
            this.labelDevices.TabIndex = 6;
            this.labelDevices.Text = "Devices";
            this.labelDevices.Visible = false;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(798, 178);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(25, 13);
            this.labelLog.TabIndex = 2;
            this.labelLog.Text = "Log";
            this.labelLog.Visible = false;
            // 
            // comboBoxBiometricPosition
            // 
            this.comboBoxBiometricPosition.FormattingEnabled = true;
            this.comboBoxBiometricPosition.Location = new System.Drawing.Point(12, 12);
            this.comboBoxBiometricPosition.Name = "comboBoxBiometricPosition";
            this.comboBoxBiometricPosition.Size = new System.Drawing.Size(154, 21);
            this.comboBoxBiometricPosition.TabIndex = 12;
            // 
            // checkBoxAutoCapture
            // 
            this.checkBoxAutoCapture.AutoSize = true;
            this.checkBoxAutoCapture.Location = new System.Drawing.Point(876, 220);
            this.checkBoxAutoCapture.Name = "checkBoxAutoCapture";
            this.checkBoxAutoCapture.Size = new System.Drawing.Size(88, 17);
            this.checkBoxAutoCapture.TabIndex = 11;
            this.checkBoxAutoCapture.Text = "Auto Capture";
            this.checkBoxAutoCapture.UseVisualStyleBackColor = true;
            this.checkBoxAutoCapture.Visible = false;
            this.checkBoxAutoCapture.CheckedChanged += new System.EventHandler(this.checkBoxAutoCapture_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 263);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // listBoxDeviceCategory
            // 
            this.listBoxDeviceCategory.FormattingEnabled = true;
            this.listBoxDeviceCategory.Location = new System.Drawing.Point(798, 58);
            this.listBoxDeviceCategory.Name = "listBoxDeviceCategory";
            this.listBoxDeviceCategory.Size = new System.Drawing.Size(120, 108);
            this.listBoxDeviceCategory.TabIndex = 4;
            this.listBoxDeviceCategory.Visible = false;
            this.listBoxDeviceCategory.SelectedIndexChanged += new System.EventHandler(this.listBoxDeviceCategory_SelectedIndexChanged);
            // 
            // labelDeviceCategory
            // 
            this.labelDeviceCategory.AutoSize = true;
            this.labelDeviceCategory.Location = new System.Drawing.Point(797, 42);
            this.labelDeviceCategory.Name = "labelDeviceCategory";
            this.labelDeviceCategory.Size = new System.Drawing.Size(86, 13);
            this.labelDeviceCategory.TabIndex = 3;
            this.labelDeviceCategory.Text = "Device Category";
            this.labelDeviceCategory.Visible = false;
            // 
            // comboBoxImpressionType
            // 
            this.comboBoxImpressionType.FormattingEnabled = true;
            this.comboBoxImpressionType.Location = new System.Drawing.Point(172, 12);
            this.comboBoxImpressionType.Name = "comboBoxImpressionType";
            this.comboBoxImpressionType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxImpressionType.TabIndex = 13;
            this.comboBoxImpressionType.Visible = false;
            // 
            // checkBoxSaveDataAvailable
            // 
            this.checkBoxSaveDataAvailable.AutoSize = true;
            this.checkBoxSaveDataAvailable.Location = new System.Drawing.Point(857, 243);
            this.checkBoxSaveDataAvailable.Name = "checkBoxSaveDataAvailable";
            this.checkBoxSaveDataAvailable.Size = new System.Drawing.Size(205, 17);
            this.checkBoxSaveDataAvailable.TabIndex = 18;
            this.checkBoxSaveDataAvailable.Text = "Save Data from DataAvailable Events";
            this.checkBoxSaveDataAvailable.UseVisualStyleBackColor = true;
            this.checkBoxSaveDataAvailable.Visible = false;
            // 
            // labelDeviceCount
            // 
            this.labelDeviceCount.AutoSize = true;
            this.labelDeviceCount.Location = new System.Drawing.Point(1066, 42);
            this.labelDeviceCount.Name = "labelDeviceCount";
            this.labelDeviceCount.Size = new System.Drawing.Size(13, 13);
            this.labelDeviceCount.TabIndex = 7;
            this.labelDeviceCount.Text = "0";
            this.labelDeviceCount.Visible = false;
            // 
            // buttonCloseCategory
            // 
            this.buttonCloseCategory.Location = new System.Drawing.Point(924, 83);
            this.buttonCloseCategory.Name = "buttonCloseCategory";
            this.buttonCloseCategory.Size = new System.Drawing.Size(91, 23);
            this.buttonCloseCategory.TabIndex = 6;
            this.buttonCloseCategory.Text = "Close Category";
            this.buttonCloseCategory.UseVisualStyleBackColor = true;
            this.buttonCloseCategory.Visible = false;
            this.buttonCloseCategory.Click += new System.EventHandler(this.buttonCloseCategory_Click);
            // 
            // buttonOpenCategory
            // 
            this.buttonOpenCategory.Location = new System.Drawing.Point(924, 58);
            this.buttonOpenCategory.Name = "buttonOpenCategory";
            this.buttonOpenCategory.Size = new System.Drawing.Size(91, 23);
            this.buttonOpenCategory.TabIndex = 5;
            this.buttonOpenCategory.Text = "Open Category";
            this.buttonOpenCategory.UseVisualStyleBackColor = true;
            this.buttonOpenCategory.Visible = false;
            this.buttonOpenCategory.Click += new System.EventHandler(this.buttonOpenCategory_Click);
            // 
            // labelBrightness
            // 
            this.labelBrightness.Location = new System.Drawing.Point(6, 21);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(80, 20);
            this.labelBrightness.TabIndex = 41;
            this.labelBrightness.Text = "Brightness";
            this.labelBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelBrightness.Visible = false;
            // 
            // Brightness
            // 
            this.Brightness.Controls.Add(this.CheckBoxBrightness);
            this.Brightness.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Brightness.Location = new System.Drawing.Point(92, 23);
            this.Brightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Brightness.Name = "Brightness";
            this.Brightness.Size = new System.Drawing.Size(52, 20);
            this.Brightness.TabIndex = 42;
            this.Brightness.Visible = false;
            this.Brightness.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // CheckBoxBrightness
            // 
            this.CheckBoxBrightness.Location = new System.Drawing.Point(552, 222);
            this.CheckBoxBrightness.Name = "CheckBoxBrightness";
            this.CheckBoxBrightness.Size = new System.Drawing.Size(91, 20);
            this.CheckBoxBrightness.TabIndex = 2;
            this.CheckBoxBrightness.Visible = false;
            // 
            // labelContrast
            // 
            this.labelContrast.Location = new System.Drawing.Point(6, 48);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Size = new System.Drawing.Size(80, 20);
            this.labelContrast.TabIndex = 43;
            this.labelContrast.Text = "Contrast";
            this.labelContrast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelContrast.Visible = false;
            // 
            // Contrast
            // 
            this.Contrast.Controls.Add(this.checkBoxContrast);
            this.Contrast.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Contrast.Location = new System.Drawing.Point(92, 48);
            this.Contrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Contrast.Name = "Contrast";
            this.Contrast.Size = new System.Drawing.Size(52, 20);
            this.Contrast.TabIndex = 44;
            this.Contrast.Visible = false;
            this.Contrast.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxContrast
            // 
            this.checkBoxContrast.Location = new System.Drawing.Point(552, 222);
            this.checkBoxContrast.Name = "checkBoxContrast";
            this.checkBoxContrast.Size = new System.Drawing.Size(91, 20);
            this.checkBoxContrast.TabIndex = 2;
            this.checkBoxContrast.Visible = false;
            // 
            // labelGain
            // 
            this.labelGain.Location = new System.Drawing.Point(6, 71);
            this.labelGain.Name = "labelGain";
            this.labelGain.Size = new System.Drawing.Size(80, 20);
            this.labelGain.TabIndex = 45;
            this.labelGain.Text = "Gain";
            this.labelGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelGain.Visible = false;
            // 
            // Gain
            // 
            this.Gain.Controls.Add(this.checkBoxGain);
            this.Gain.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Gain.Location = new System.Drawing.Point(92, 73);
            this.Gain.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Gain.Name = "Gain";
            this.Gain.Size = new System.Drawing.Size(52, 20);
            this.Gain.TabIndex = 46;
            this.Gain.Visible = false;
            this.Gain.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxGain
            // 
            this.checkBoxGain.Location = new System.Drawing.Point(552, 222);
            this.checkBoxGain.Name = "checkBoxGain";
            this.checkBoxGain.Size = new System.Drawing.Size(91, 20);
            this.checkBoxGain.TabIndex = 2;
            this.checkBoxGain.Visible = false;
            // 
            // labelLeftBank1
            // 
            this.labelLeftBank1.Location = new System.Drawing.Point(6, 102);
            this.labelLeftBank1.Name = "labelLeftBank1";
            this.labelLeftBank1.Size = new System.Drawing.Size(80, 20);
            this.labelLeftBank1.TabIndex = 47;
            this.labelLeftBank1.Text = "Left Bank 1";
            this.labelLeftBank1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelLeftBank1.Visible = false;
            // 
            // LeftBank1
            // 
            this.LeftBank1.Controls.Add(this.checkBoxLeftBank1);
            this.LeftBank1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LeftBank1.Location = new System.Drawing.Point(92, 102);
            this.LeftBank1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LeftBank1.Name = "LeftBank1";
            this.LeftBank1.Size = new System.Drawing.Size(52, 20);
            this.LeftBank1.TabIndex = 48;
            this.LeftBank1.Visible = false;
            this.LeftBank1.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxLeftBank1
            // 
            this.checkBoxLeftBank1.Location = new System.Drawing.Point(552, 222);
            this.checkBoxLeftBank1.Name = "checkBoxLeftBank1";
            this.checkBoxLeftBank1.Size = new System.Drawing.Size(91, 20);
            this.checkBoxLeftBank1.TabIndex = 2;
            this.checkBoxLeftBank1.Visible = false;
            // 
            // labelLeftBank2
            // 
            this.labelLeftBank2.Location = new System.Drawing.Point(6, 127);
            this.labelLeftBank2.Name = "labelLeftBank2";
            this.labelLeftBank2.Size = new System.Drawing.Size(80, 20);
            this.labelLeftBank2.TabIndex = 49;
            this.labelLeftBank2.Text = "Left Bank 2";
            this.labelLeftBank2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelLeftBank2.Visible = false;
            // 
            // LeftBank2
            // 
            this.LeftBank2.Controls.Add(this.checkBoxLeftBank2);
            this.LeftBank2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LeftBank2.Location = new System.Drawing.Point(92, 127);
            this.LeftBank2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LeftBank2.Name = "LeftBank2";
            this.LeftBank2.Size = new System.Drawing.Size(52, 20);
            this.LeftBank2.TabIndex = 50;
            this.LeftBank2.Visible = false;
            this.LeftBank2.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxLeftBank2
            // 
            this.checkBoxLeftBank2.Location = new System.Drawing.Point(552, 222);
            this.checkBoxLeftBank2.Name = "checkBoxLeftBank2";
            this.checkBoxLeftBank2.Size = new System.Drawing.Size(91, 20);
            this.checkBoxLeftBank2.TabIndex = 2;
            this.checkBoxLeftBank2.Visible = false;
            // 
            // labelLeftBank3
            // 
            this.labelLeftBank3.Location = new System.Drawing.Point(6, 150);
            this.labelLeftBank3.Name = "labelLeftBank3";
            this.labelLeftBank3.Size = new System.Drawing.Size(80, 20);
            this.labelLeftBank3.TabIndex = 51;
            this.labelLeftBank3.Text = "Left Bank 3";
            this.labelLeftBank3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelLeftBank3.Visible = false;
            // 
            // LeftBank3
            // 
            this.LeftBank3.Controls.Add(this.checkBoxLeftBank3);
            this.LeftBank3.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LeftBank3.Location = new System.Drawing.Point(92, 152);
            this.LeftBank3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LeftBank3.Name = "LeftBank3";
            this.LeftBank3.Size = new System.Drawing.Size(52, 20);
            this.LeftBank3.TabIndex = 52;
            this.LeftBank3.Visible = false;
            this.LeftBank3.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxLeftBank3
            // 
            this.checkBoxLeftBank3.Location = new System.Drawing.Point(552, 222);
            this.checkBoxLeftBank3.Name = "checkBoxLeftBank3";
            this.checkBoxLeftBank3.Size = new System.Drawing.Size(91, 20);
            this.checkBoxLeftBank3.TabIndex = 2;
            this.checkBoxLeftBank3.Visible = false;
            // 
            // labelRightBank1
            // 
            this.labelRightBank1.Location = new System.Drawing.Point(6, 183);
            this.labelRightBank1.Name = "labelRightBank1";
            this.labelRightBank1.Size = new System.Drawing.Size(80, 20);
            this.labelRightBank1.TabIndex = 53;
            this.labelRightBank1.Text = "Right Bank 1";
            this.labelRightBank1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelRightBank1.Visible = false;
            // 
            // RightBank1
            // 
            this.RightBank1.Controls.Add(this.checkBoxRightBank1);
            this.RightBank1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RightBank1.Location = new System.Drawing.Point(92, 183);
            this.RightBank1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RightBank1.Name = "RightBank1";
            this.RightBank1.Size = new System.Drawing.Size(52, 20);
            this.RightBank1.TabIndex = 54;
            this.RightBank1.Visible = false;
            this.RightBank1.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxRightBank1
            // 
            this.checkBoxRightBank1.Location = new System.Drawing.Point(552, 222);
            this.checkBoxRightBank1.Name = "checkBoxRightBank1";
            this.checkBoxRightBank1.Size = new System.Drawing.Size(91, 20);
            this.checkBoxRightBank1.TabIndex = 2;
            this.checkBoxRightBank1.Visible = false;
            // 
            // labelRightBank2
            // 
            this.labelRightBank2.Location = new System.Drawing.Point(6, 208);
            this.labelRightBank2.Name = "labelRightBank2";
            this.labelRightBank2.Size = new System.Drawing.Size(80, 20);
            this.labelRightBank2.TabIndex = 55;
            this.labelRightBank2.Text = "Right Bank 2";
            this.labelRightBank2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelRightBank2.Visible = false;
            // 
            // RightBank2
            // 
            this.RightBank2.Controls.Add(this.checkBoxRightBank2);
            this.RightBank2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RightBank2.Location = new System.Drawing.Point(92, 208);
            this.RightBank2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RightBank2.Name = "RightBank2";
            this.RightBank2.Size = new System.Drawing.Size(52, 20);
            this.RightBank2.TabIndex = 56;
            this.RightBank2.Visible = false;
            this.RightBank2.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxRightBank2
            // 
            this.checkBoxRightBank2.Location = new System.Drawing.Point(552, 222);
            this.checkBoxRightBank2.Name = "checkBoxRightBank2";
            this.checkBoxRightBank2.Size = new System.Drawing.Size(91, 20);
            this.checkBoxRightBank2.TabIndex = 2;
            this.checkBoxRightBank2.Visible = false;
            // 
            // labelRightBank3
            // 
            this.labelRightBank3.Location = new System.Drawing.Point(6, 233);
            this.labelRightBank3.Name = "labelRightBank3";
            this.labelRightBank3.Size = new System.Drawing.Size(80, 20);
            this.labelRightBank3.TabIndex = 57;
            this.labelRightBank3.Text = "Right Bank 3";
            this.labelRightBank3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelRightBank3.Visible = false;
            // 
            // RightBank3
            // 
            this.RightBank3.Controls.Add(this.checkBoxRightBank3);
            this.RightBank3.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RightBank3.Location = new System.Drawing.Point(92, 233);
            this.RightBank3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RightBank3.Name = "RightBank3";
            this.RightBank3.Size = new System.Drawing.Size(52, 20);
            this.RightBank3.TabIndex = 58;
            this.RightBank3.Visible = false;
            this.RightBank3.ValueChanged += new System.EventHandler(this.LatentSettings_Changed);
            // 
            // checkBoxRightBank3
            // 
            this.checkBoxRightBank3.Location = new System.Drawing.Point(552, 222);
            this.checkBoxRightBank3.Name = "checkBoxRightBank3";
            this.checkBoxRightBank3.Size = new System.Drawing.Size(91, 20);
            this.checkBoxRightBank3.TabIndex = 2;
            this.checkBoxRightBank3.Visible = false;
            // 
            // groupBoxLatentControls
            // 
            this.groupBoxLatentControls.Controls.Add(this.labelBrightness);
            this.groupBoxLatentControls.Controls.Add(this.Brightness);
            this.groupBoxLatentControls.Controls.Add(this.labelContrast);
            this.groupBoxLatentControls.Controls.Add(this.Contrast);
            this.groupBoxLatentControls.Controls.Add(this.labelGain);
            this.groupBoxLatentControls.Controls.Add(this.Gain);
            this.groupBoxLatentControls.Controls.Add(this.labelLeftBank1);
            this.groupBoxLatentControls.Controls.Add(this.LeftBank1);
            this.groupBoxLatentControls.Controls.Add(this.labelLeftBank2);
            this.groupBoxLatentControls.Controls.Add(this.LeftBank2);
            this.groupBoxLatentControls.Controls.Add(this.labelLeftBank3);
            this.groupBoxLatentControls.Controls.Add(this.LeftBank3);
            this.groupBoxLatentControls.Controls.Add(this.labelRightBank1);
            this.groupBoxLatentControls.Controls.Add(this.RightBank1);
            this.groupBoxLatentControls.Controls.Add(this.labelRightBank2);
            this.groupBoxLatentControls.Controls.Add(this.RightBank2);
            this.groupBoxLatentControls.Controls.Add(this.labelRightBank3);
            this.groupBoxLatentControls.Controls.Add(this.RightBank3);
            this.groupBoxLatentControls.Location = new System.Drawing.Point(1017, 243);
            this.groupBoxLatentControls.Name = "groupBoxLatentControls";
            this.groupBoxLatentControls.Size = new System.Drawing.Size(154, 265);
            this.groupBoxLatentControls.TabIndex = 40;
            this.groupBoxLatentControls.TabStop = false;
            this.groupBoxLatentControls.Text = "Latent Controls";
            this.groupBoxLatentControls.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(601, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 377);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonOpenCategory);
            this.Controls.Add(this.buttonCloseCategory);
            this.Controls.Add(this.labelDeviceCount);
            this.Controls.Add(this.checkBoxSaveDataAvailable);
            this.Controls.Add(this.comboBoxImpressionType);
            this.Controls.Add(this.labelDeviceCategory);
            this.Controls.Add(this.listBoxDeviceCategory);
            this.Controls.Add(this.checkBoxAutoCapture);
            this.Controls.Add(this.comboBoxBiometricPosition);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.labelDevices);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonForce);
            this.Controls.Add(this.buttonAcquire);
            this.Controls.Add(this.groupBoxLatentControls);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Captura Iris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).EndInit();
            this.Brightness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Contrast)).EndInit();
            this.Contrast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gain)).EndInit();
            this.Gain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBank1)).EndInit();
            this.LeftBank1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBank2)).EndInit();
            this.LeftBank2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBank3)).EndInit();
            this.LeftBank3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightBank1)).EndInit();
            this.RightBank1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightBank2)).EndInit();
            this.RightBank2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightBank3)).EndInit();
            this.RightBank3.ResumeLayout(false);
            this.groupBoxLatentControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonAcquire;
        private System.Windows.Forms.Button buttonForce;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDevices;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.ComboBox comboBoxBiometricPosition;
        private System.Windows.Forms.CheckBox checkBoxAutoCapture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxDeviceCategory;
        private System.Windows.Forms.Label labelDeviceCategory;
        private System.Windows.Forms.ComboBox comboBoxImpressionType;
        private System.Windows.Forms.CheckBox checkBoxSaveDataAvailable;
        private System.Windows.Forms.Label labelDeviceCount;
        private System.Windows.Forms.Button buttonCloseCategory;
        private System.Windows.Forms.Button buttonOpenCategory;
        public System.Windows.Forms.GroupBox groupBoxLatentControls;
        public System.Windows.Forms.Label labelBrightness;
        public System.Windows.Forms.NumericUpDown Brightness;
        public System.Windows.Forms.CheckBox CheckBoxBrightness;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.NumericUpDown Contrast;
        private System.Windows.Forms.CheckBox checkBoxContrast;
        private System.Windows.Forms.NumericUpDown Gain;
        private System.Windows.Forms.CheckBox checkBoxGain;
        private System.Windows.Forms.Label labelGain;
        private System.Windows.Forms.Label labelLeftBank1;
        private System.Windows.Forms.NumericUpDown LeftBank1;
        private System.Windows.Forms.CheckBox checkBoxLeftBank1;
        private System.Windows.Forms.Label labelLeftBank2;
        private System.Windows.Forms.NumericUpDown LeftBank2;
        private System.Windows.Forms.CheckBox checkBoxLeftBank2;
        private System.Windows.Forms.Label labelLeftBank3;
        private System.Windows.Forms.NumericUpDown LeftBank3;
        private System.Windows.Forms.CheckBox checkBoxLeftBank3;
        private System.Windows.Forms.Label labelRightBank1;
        private System.Windows.Forms.NumericUpDown RightBank1;
        private System.Windows.Forms.CheckBox checkBoxRightBank1;
        private System.Windows.Forms.Label labelRightBank2;
        private System.Windows.Forms.NumericUpDown RightBank2;
        private System.Windows.Forms.CheckBox checkBoxRightBank2;
        private System.Windows.Forms.Label labelRightBank3;
        private System.Windows.Forms.NumericUpDown RightBank3;
        private System.Windows.Forms.CheckBox checkBoxRightBank3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

