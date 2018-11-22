namespace BTS.SiCEP.Biometria.Huellas
{
    partial class MainForm
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
            this.tabBio = new System.Windows.Forms.TabControl();
            this.tabPageHuella = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblQuality = new System.Windows.Forms.Label();
            this.chbScanAutomatically = new System.Windows.Forms.CheckBox();
            this.cancelScanningButton = new System.Windows.Forms.Button();
            this.scanButton = new System.Windows.Forms.Button();
            this.refreshListButton = new System.Windows.Forms.Button();
            this.scannersListBox = new System.Windows.Forms.ListBox();
            this.fingerView = new Neurotec.Biometrics.Gui.NFingerView();
            this.nViewZoomSlider1 = new Neurotec.Gui.NViewZoomSlider();
            this.chbShowBinarizedImage = new System.Windows.Forms.CheckBox();
            this.tabRostro = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStartExtraction = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chbCheckLiveness = new System.Windows.Forms.CheckBox();
            this.chbCaptureAutomatically = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbCameras = new System.Windows.Forms.ComboBox();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.gpbFacial = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.facesView = new Neurotec.Biometrics.Gui.NFaceView();
            this.nViewZoomSlider2 = new Neurotec.Gui.NViewZoomSlider();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.scannersGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnForce = new System.Windows.Forms.Button();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lbScanners = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.irisView = new Neurotec.Biometrics.Gui.NIrisView();
            this.nViewZoomSlider3 = new Neurotec.Gui.NViewZoomSlider();
            this.btnVerificariris = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVozForsar = new System.Windows.Forms.Button();
            this.btnVozDetener = new System.Windows.Forms.Button();
            this.btnVozRefrescar = new System.Windows.Forms.Button();
            this.btnVozIniciar = new System.Windows.Forms.Button();
            this.lbMicrophones = new System.Windows.Forms.ListBox();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.extractFeatures = new System.Windows.Forms.ComboBox();
            this.chkBoxVozCapturarAut = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPhraseId = new System.Windows.Forms.NumericUpDown();
            this.voiceView = new Neurotec.Biometrics.Gui.NVoiceView();
            this.gbMicrophones = new System.Windows.Forms.GroupBox();
            this.btnVozVerificar = new System.Windows.Forms.Button();
            this.tabBio.SuspendLayout();
            this.tabPageHuella.SuspendLayout();
            this.tabRostro.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.gpbFacial.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.scannersGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhraseId)).BeginInit();
            this.gbMicrophones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBio
            // 
            this.tabBio.Controls.Add(this.tabPageHuella);
            this.tabBio.Controls.Add(this.tabRostro);
            this.tabBio.Controls.Add(this.tabPage1);
            this.tabBio.Controls.Add(this.tabPage2);
            this.tabBio.Location = new System.Drawing.Point(9, 11);
            this.tabBio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabBio.Name = "tabBio";
            this.tabBio.SelectedIndex = 0;
            this.tabBio.Size = new System.Drawing.Size(610, 458);
            this.tabBio.TabIndex = 0;
            // 
            // tabPageHuella
            // 
            this.tabPageHuella.Controls.Add(this.label1);
            this.tabPageHuella.Controls.Add(this.button1);
            this.tabPageHuella.Controls.Add(this.lblQuality);
            this.tabPageHuella.Controls.Add(this.chbScanAutomatically);
            this.tabPageHuella.Controls.Add(this.cancelScanningButton);
            this.tabPageHuella.Controls.Add(this.scanButton);
            this.tabPageHuella.Controls.Add(this.refreshListButton);
            this.tabPageHuella.Controls.Add(this.scannersListBox);
            this.tabPageHuella.Controls.Add(this.fingerView);
            this.tabPageHuella.Controls.Add(this.nViewZoomSlider1);
            this.tabPageHuella.Controls.Add(this.chbShowBinarizedImage);
            this.tabPageHuella.Location = new System.Drawing.Point(4, 22);
            this.tabPageHuella.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageHuella.Name = "tabPageHuella";
            this.tabPageHuella.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageHuella.Size = new System.Drawing.Size(602, 432);
            this.tabPageHuella.TabIndex = 0;
            this.tabPageHuella.Text = "Huella";
            this.tabPageHuella.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Lista de scanners";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(156, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 22);
            this.button1.TabIndex = 38;
            this.button1.Text = "Verificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblQuality
            // 
            this.lblQuality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQuality.Location = new System.Drawing.Point(251, 353);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(190, 20);
            this.lblQuality.TabIndex = 37;
            // 
            // chbScanAutomatically
            // 
            this.chbScanAutomatically.AutoSize = true;
            this.chbScanAutomatically.Checked = true;
            this.chbScanAutomatically.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbScanAutomatically.Location = new System.Drawing.Point(293, 28);
            this.chbScanAutomatically.Name = "chbScanAutomatically";
            this.chbScanAutomatically.Size = new System.Drawing.Size(150, 17);
            this.chbScanAutomatically.TabIndex = 36;
            this.chbScanAutomatically.Text = "Capturar automaticamente";
            this.chbScanAutomatically.UseVisualStyleBackColor = true;
            this.chbScanAutomatically.Visible = false;
            // 
            // cancelScanningButton
            // 
            this.cancelScanningButton.Enabled = false;
            this.cancelScanningButton.Location = new System.Drawing.Point(331, 109);
            this.cancelScanningButton.Name = "cancelScanningButton";
            this.cancelScanningButton.Size = new System.Drawing.Size(90, 22);
            this.cancelScanningButton.TabIndex = 35;
            this.cancelScanningButton.Text = "Cancelar";
            this.cancelScanningButton.UseVisualStyleBackColor = true;
            this.cancelScanningButton.Click += new System.EventHandler(this.cancelScanningButton_Click);
            // 
            // scanButton
            // 
            this.scanButton.Enabled = false;
            this.scanButton.Location = new System.Drawing.Point(238, 109);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(90, 22);
            this.scanButton.TabIndex = 34;
            this.scanButton.Text = "Capturar";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // refreshListButton
            // 
            this.refreshListButton.Location = new System.Drawing.Point(130, 109);
            this.refreshListButton.Name = "refreshListButton";
            this.refreshListButton.Size = new System.Drawing.Size(90, 22);
            this.refreshListButton.TabIndex = 31;
            this.refreshListButton.Text = "Refrescar";
            this.refreshListButton.UseVisualStyleBackColor = true;
            this.refreshListButton.Click += new System.EventHandler(this.refreshListButton_Click);
            // 
            // scannersListBox
            // 
            this.scannersListBox.Location = new System.Drawing.Point(129, 47);
            this.scannersListBox.Name = "scannersListBox";
            this.scannersListBox.Size = new System.Drawing.Size(347, 56);
            this.scannersListBox.TabIndex = 30;
            // 
            // fingerView
            // 
            this.fingerView.BackColor = System.Drawing.Color.White;
            this.fingerView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fingerView.BoundingRectColor = System.Drawing.Color.Red;
            this.fingerView.Location = new System.Drawing.Point(155, 162);
            this.fingerView.MinutiaColor = System.Drawing.Color.Red;
            this.fingerView.Name = "fingerView";
            this.fingerView.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.fingerView.ResultImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.fingerView.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.fingerView.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.fingerView.ShownImage = Neurotec.Biometrics.Gui.ShownImage.Result;
            this.fingerView.SingularPointColor = System.Drawing.Color.Red;
            this.fingerView.Size = new System.Drawing.Size(286, 186);
            this.fingerView.TabIndex = 29;
            this.fingerView.TreeColor = System.Drawing.Color.Crimson;
            this.fingerView.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.fingerView.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.fingerView.TreeWidth = 2D;
            // 
            // nViewZoomSlider1
            // 
            this.nViewZoomSlider1.BackColor = System.Drawing.SystemColors.Window;
            this.nViewZoomSlider1.Location = new System.Drawing.Point(158, 381);
            this.nViewZoomSlider1.Name = "nViewZoomSlider1";
            this.nViewZoomSlider1.Size = new System.Drawing.Size(283, 23);
            this.nViewZoomSlider1.TabIndex = 33;
            this.nViewZoomSlider1.Text = "nViewHuellaZoomSlider";
            this.nViewZoomSlider1.View = this.fingerView;
            // 
            // chbShowBinarizedImage
            // 
            this.chbShowBinarizedImage.AutoSize = true;
            this.chbShowBinarizedImage.Enabled = false;
            this.chbShowBinarizedImage.Location = new System.Drawing.Point(337, 145);
            this.chbShowBinarizedImage.Name = "chbShowBinarizedImage";
            this.chbShowBinarizedImage.Size = new System.Drawing.Size(110, 17);
            this.chbShowBinarizedImage.TabIndex = 32;
            this.chbShowBinarizedImage.Text = "Imagen en binario\r\n";
            this.chbShowBinarizedImage.UseVisualStyleBackColor = true;
            this.chbShowBinarizedImage.CheckedChanged += new System.EventHandler(this.chbShowBinarizedImage_CheckedChanged);
            // 
            // tabRostro
            // 
            this.tabRostro.Controls.Add(this.groupBox);
            this.tabRostro.Controls.Add(this.gpbFacial);
            this.tabRostro.Location = new System.Drawing.Point(4, 22);
            this.tabRostro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRostro.Name = "tabRostro";
            this.tabRostro.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRostro.Size = new System.Drawing.Size(602, 432);
            this.tabRostro.TabIndex = 1;
            this.tabRostro.Text = "Rostro";
            this.tabRostro.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.btnStartExtraction);
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.chbCheckLiveness);
            this.groupBox.Controls.Add(this.chbCaptureAutomatically);
            this.groupBox.Controls.Add(this.btnStart);
            this.groupBox.Controls.Add(this.cbCameras);
            this.groupBox.Controls.Add(this.btnRefreshList);
            this.groupBox.Location = new System.Drawing.Point(15, 15);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(110, 86);
            this.groupBox.TabIndex = 26;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Camaras";
            // 
            // btnStartExtraction
            // 
            this.btnStartExtraction.Enabled = false;
            this.btnStartExtraction.Location = new System.Drawing.Point(202, 44);
            this.btnStartExtraction.Name = "btnStartExtraction";
            this.btnStartExtraction.Size = new System.Drawing.Size(90, 22);
            this.btnStartExtraction.TabIndex = 27;
            this.btnStartExtraction.Text = "Capturar rostro";
            this.btnStartExtraction.UseVisualStyleBackColor = true;
            this.btnStartExtraction.Click += new System.EventHandler(this.btnStartExtraction_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(295, 44);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 22);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chbCheckLiveness
            // 
            this.chbCheckLiveness.AutoSize = true;
            this.chbCheckLiveness.Location = new System.Drawing.Point(448, 47);
            this.chbCheckLiveness.Name = "chbCheckLiveness";
            this.chbCheckLiveness.Size = new System.Drawing.Size(98, 17);
            this.chbCheckLiveness.TabIndex = 21;
            this.chbCheckLiveness.Text = "Check liveness";
            this.chbCheckLiveness.UseVisualStyleBackColor = true;
            this.chbCheckLiveness.Visible = false;
            // 
            // chbCaptureAutomatically
            // 
            this.chbCaptureAutomatically.AutoSize = true;
            this.chbCaptureAutomatically.Location = new System.Drawing.Point(318, 47);
            this.chbCaptureAutomatically.Name = "chbCaptureAutomatically";
            this.chbCaptureAutomatically.Size = new System.Drawing.Size(127, 17);
            this.chbCaptureAutomatically.TabIndex = 20;
            this.chbCaptureAutomatically.Text = "Capture automatically";
            this.chbCaptureAutomatically.UseVisualStyleBackColor = true;
            this.chbCaptureAutomatically.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(109, 44);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 22);
            this.btnStart.TabIndex = 18;
            this.btnStart.Text = "Iniciar captura";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbCameras
            // 
            this.cbCameras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameras.FormattingEnabled = true;
            this.cbCameras.Location = new System.Drawing.Point(8, 20);
            this.cbCameras.Name = "cbCameras";
            this.cbCameras.Size = new System.Drawing.Size(82, 21);
            this.cbCameras.TabIndex = 15;
            this.cbCameras.SelectedIndexChanged += new System.EventHandler(this.cbCameras_SelectedIndexChanged);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(8, 44);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(90, 22);
            this.btnRefreshList.TabIndex = 17;
            this.btnRefreshList.Text = "Refrescar";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // gpbFacial
            // 
            this.gpbFacial.Controls.Add(this.lblStatus);
            this.gpbFacial.Controls.Add(this.btnVerificar);
            this.gpbFacial.Controls.Add(this.facesView);
            this.gpbFacial.Controls.Add(this.nViewZoomSlider2);
            this.gpbFacial.Location = new System.Drawing.Point(15, 113);
            this.gpbFacial.Name = "gpbFacial";
            this.gpbFacial.Size = new System.Drawing.Size(569, 309);
            this.gpbFacial.TabIndex = 34;
            this.gpbFacial.TabStop = false;
            this.gpbFacial.Text = " Facial ";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(49, 275);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(403, 20);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVerificar
            // 
            this.btnVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerificar.Enabled = false;
            this.btnVerificar.Location = new System.Drawing.Point(52, 245);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(90, 22);
            this.btnVerificar.TabIndex = 31;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.button1_Click);
            // 
            // facesView
            // 
            this.facesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.facesView.Face = null;
            this.facesView.FaceIds = null;
            this.facesView.IcaoArrowsColor = System.Drawing.Color.Red;
            this.facesView.Location = new System.Drawing.Point(52, 19);
            this.facesView.Name = "facesView";
            this.facesView.ShowIcaoArrows = true;
            this.facesView.ShowTokenImageRectangle = true;
            this.facesView.Size = new System.Drawing.Size(393, 222);
            this.facesView.TabIndex = 33;
            this.facesView.TokenImageRectangleColor = System.Drawing.Color.White;
            // 
            // nViewZoomSlider2
            // 
            this.nViewZoomSlider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nViewZoomSlider2.Location = new System.Drawing.Point(148, 247);
            this.nViewZoomSlider2.Name = "nViewZoomSlider2";
            this.nViewZoomSlider2.Size = new System.Drawing.Size(282, 23);
            this.nViewZoomSlider2.TabIndex = 32;
            this.nViewZoomSlider2.Text = "nViewZoomSlider2";
            this.nViewZoomSlider2.View = this.facesView;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scannersGroupBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(602, 432);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Iris";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // scannersGroupBox
            // 
            this.scannersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scannersGroupBox.Controls.Add(this.checkBox1);
            this.scannersGroupBox.Controls.Add(this.btnForce);
            this.scannersGroupBox.Controls.Add(this.rbRight);
            this.scannersGroupBox.Controls.Add(this.rbLeft);
            this.scannersGroupBox.Controls.Add(this.btnCancel);
            this.scannersGroupBox.Controls.Add(this.btnRefresh);
            this.scannersGroupBox.Controls.Add(this.btnScan);
            this.scannersGroupBox.Controls.Add(this.lbScanners);
            this.scannersGroupBox.Location = new System.Drawing.Point(7, 13);
            this.scannersGroupBox.Name = "scannersGroupBox";
            this.scannersGroupBox.Size = new System.Drawing.Size(590, 134);
            this.scannersGroupBox.TabIndex = 13;
            this.scannersGroupBox.TabStop = false;
            this.scannersGroupBox.Text = "Escaners";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(458, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Scan automatically";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // btnForce
            // 
            this.btnForce.Enabled = false;
            this.btnForce.Location = new System.Drawing.Point(307, 81);
            this.btnForce.Name = "btnForce";
            this.btnForce.Size = new System.Drawing.Size(90, 22);
            this.btnForce.TabIndex = 14;
            this.btnForce.Text = "Force";
            this.btnForce.UseVisualStyleBackColor = true;
            this.btnForce.Visible = false;
            // 
            // rbRight
            // 
            this.rbRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(499, 53);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(82, 17);
            this.rbRight.TabIndex = 13;
            this.rbRight.Text = "Iris Derecho";
            this.rbRight.UseVisualStyleBackColor = true;
            this.rbRight.CheckedChanged += new System.EventHandler(this.rbRight_CheckedChanged);
            // 
            // rbLeft
            // 
            this.rbLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbLeft.AutoSize = true;
            this.rbLeft.Checked = true;
            this.rbLeft.Location = new System.Drawing.Point(498, 29);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(84, 17);
            this.rbLeft.TabIndex = 12;
            this.rbLeft.TabStop = true;
            this.rbLeft.Text = "Iris Izquierdo";
            this.rbLeft.UseVisualStyleBackColor = true;
            this.rbLeft.CheckedChanged += new System.EventHandler(this.rbLeft_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(196, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 22);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 81);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 22);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(105, 81);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(90, 22);
            this.btnScan.TabIndex = 9;
            this.btnScan.Text = "Capturar";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lbScanners
            // 
            this.lbScanners.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScanners.Location = new System.Drawing.Point(6, 19);
            this.lbScanners.Name = "lbScanners";
            this.lbScanners.Size = new System.Drawing.Size(486, 56);
            this.lbScanners.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.irisView);
            this.groupBox1.Controls.Add(this.nViewZoomSlider3);
            this.groupBox1.Controls.Add(this.btnVerificariris);
            this.groupBox1.Location = new System.Drawing.Point(10, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 211);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Iris ";
            // 
            // irisView
            // 
            this.irisView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.irisView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.irisView.InnerBoundaryColor = System.Drawing.Color.Red;
            this.irisView.InnerBoundaryWidth = 2;
            this.irisView.Iris = null;
            this.irisView.Location = new System.Drawing.Point(10, 19);
            this.irisView.Name = "irisView";
            this.irisView.OuterBoundaryColor = System.Drawing.Color.GreenYellow;
            this.irisView.OuterBoundaryWidth = 2;
            this.irisView.Size = new System.Drawing.Size(567, 143);
            this.irisView.TabIndex = 14;
            // 
            // nViewZoomSlider3
            // 
            this.nViewZoomSlider3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nViewZoomSlider3.BackColor = System.Drawing.SystemColors.Window;
            this.nViewZoomSlider3.Location = new System.Drawing.Point(229, 169);
            this.nViewZoomSlider3.Name = "nViewZoomSlider3";
            this.nViewZoomSlider3.Size = new System.Drawing.Size(341, 23);
            this.nViewZoomSlider3.TabIndex = 18;
            this.nViewZoomSlider3.Text = "nIrisViewZoomSlider";
            this.nViewZoomSlider3.View = this.irisView;
            // 
            // btnVerificariris
            // 
            this.btnVerificariris.Enabled = false;
            this.btnVerificariris.Location = new System.Drawing.Point(8, 169);
            this.btnVerificariris.Name = "btnVerificariris";
            this.btnVerificariris.Size = new System.Drawing.Size(90, 22);
            this.btnVerificariris.TabIndex = 16;
            this.btnVerificariris.Text = "Verificar";
            this.btnVerificariris.UseVisualStyleBackColor = true;
            this.btnVerificariris.Click += new System.EventHandler(this.btnVerificariris_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnVozVerificar);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.gbOptions);
            this.tabPage2.Controls.Add(this.voiceView);
            this.tabPage2.Controls.Add(this.gbMicrophones);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 432);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Voz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Seleccione un microfono, presione Iniciar y diga una frase";
            // 
            // btnVozForsar
            // 
            this.btnVozForsar.Location = new System.Drawing.Point(249, 80);
            this.btnVozForsar.Name = "btnVozForsar";
            this.btnVozForsar.Size = new System.Drawing.Size(75, 23);
            this.btnVozForsar.TabIndex = 12;
            this.btnVozForsar.Text = "Forsar";
            this.btnVozForsar.UseVisualStyleBackColor = true;
            this.btnVozForsar.Click += new System.EventHandler(this.btnVozForsar_Click);
            // 
            // btnVozDetener
            // 
            this.btnVozDetener.Enabled = false;
            this.btnVozDetener.Location = new System.Drawing.Point(168, 80);
            this.btnVozDetener.Name = "btnVozDetener";
            this.btnVozDetener.Size = new System.Drawing.Size(75, 23);
            this.btnVozDetener.TabIndex = 11;
            this.btnVozDetener.Text = "Detener";
            this.btnVozDetener.UseVisualStyleBackColor = true;
            this.btnVozDetener.Click += new System.EventHandler(this.btnVozDetener_Click);
            // 
            // btnVozRefrescar
            // 
            this.btnVozRefrescar.Location = new System.Drawing.Point(6, 80);
            this.btnVozRefrescar.Name = "btnVozRefrescar";
            this.btnVozRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnVozRefrescar.TabIndex = 10;
            this.btnVozRefrescar.Text = "Refrescar";
            this.btnVozRefrescar.UseVisualStyleBackColor = true;
            this.btnVozRefrescar.Click += new System.EventHandler(this.btnVozRefrescar_Click);
            // 
            // btnVozIniciar
            // 
            this.btnVozIniciar.Location = new System.Drawing.Point(87, 80);
            this.btnVozIniciar.Name = "btnVozIniciar";
            this.btnVozIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnVozIniciar.TabIndex = 9;
            this.btnVozIniciar.Text = "Iniciar";
            this.btnVozIniciar.UseVisualStyleBackColor = true;
            this.btnVozIniciar.Click += new System.EventHandler(this.btnVozIniciar_Click);
            // 
            // lbMicrophones
            // 
            this.lbMicrophones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMicrophones.Location = new System.Drawing.Point(4, 19);
            this.lbMicrophones.Name = "lbMicrophones";
            this.lbMicrophones.Size = new System.Drawing.Size(320, 56);
            this.lbMicrophones.TabIndex = 6;
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.extractFeatures);
            this.gbOptions.Controls.Add(this.chkBoxVozCapturarAut);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.Add(this.nudPhraseId);
            this.gbOptions.Location = new System.Drawing.Point(375, 47);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(189, 110);
            this.gbOptions.TabIndex = 33;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Opciones";
            // 
            // extractFeatures
            // 
            this.extractFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extractFeatures.FormattingEnabled = true;
            this.extractFeatures.Location = new System.Drawing.Point(6, 43);
            this.extractFeatures.Name = "extractFeatures";
            this.extractFeatures.Size = new System.Drawing.Size(176, 21);
            this.extractFeatures.TabIndex = 23;
            // 
            // chkBoxVozCapturarAut
            // 
            this.chkBoxVozCapturarAut.AutoSize = true;
            this.chkBoxVozCapturarAut.Checked = true;
            this.chkBoxVozCapturarAut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxVozCapturarAut.Location = new System.Drawing.Point(6, 86);
            this.chkBoxVozCapturarAut.Name = "chkBoxVozCapturarAut";
            this.chkBoxVozCapturarAut.Size = new System.Drawing.Size(150, 17);
            this.chkBoxVozCapturarAut.TabIndex = 22;
            this.chkBoxVozCapturarAut.Text = "Capturar automaticamente";
            this.chkBoxVozCapturarAut.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Frase:";
            // 
            // nudPhraseId
            // 
            this.nudPhraseId.Location = new System.Drawing.Point(64, 17);
            this.nudPhraseId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudPhraseId.Name = "nudPhraseId";
            this.nudPhraseId.Size = new System.Drawing.Size(93, 20);
            this.nudPhraseId.TabIndex = 18;
            // 
            // voiceView
            // 
            this.voiceView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceView.BackColor = System.Drawing.Color.Transparent;
            this.voiceView.Location = new System.Drawing.Point(23, 163);
            this.voiceView.Name = "voiceView";
            this.voiceView.Size = new System.Drawing.Size(541, 54);
            this.voiceView.TabIndex = 35;
            this.voiceView.Text = "voiceView";
            this.voiceView.Voice = null;
            // 
            // gbMicrophones
            // 
            this.gbMicrophones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMicrophones.Controls.Add(this.btnVozForsar);
            this.gbMicrophones.Controls.Add(this.btnVozDetener);
            this.gbMicrophones.Controls.Add(this.btnVozRefrescar);
            this.gbMicrophones.Controls.Add(this.btnVozIniciar);
            this.gbMicrophones.Controls.Add(this.lbMicrophones);
            this.gbMicrophones.Location = new System.Drawing.Point(23, 47);
            this.gbMicrophones.Name = "gbMicrophones";
            this.gbMicrophones.Size = new System.Drawing.Size(330, 110);
            this.gbMicrophones.TabIndex = 32;
            this.gbMicrophones.TabStop = false;
            this.gbMicrophones.Text = "Microphones list";
            // 
            // btnVozVerificar
            // 
            this.btnVozVerificar.Enabled = false;
            this.btnVozVerificar.Location = new System.Drawing.Point(21, 242);
            this.btnVozVerificar.Name = "btnVozVerificar";
            this.btnVozVerificar.Size = new System.Drawing.Size(90, 22);
            this.btnVozVerificar.TabIndex = 36;
            this.btnVozVerificar.Text = "Verificar";
            this.btnVozVerificar.UseVisualStyleBackColor = true;
            this.btnVozVerificar.Click += new System.EventHandler(this.btnVozVerificar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 493);
            this.Controls.Add(this.tabBio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda biometrica";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabBio.ResumeLayout(false);
            this.tabPageHuella.ResumeLayout(false);
            this.tabPageHuella.PerformLayout();
            this.tabRostro.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.gpbFacial.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.scannersGroupBox.ResumeLayout(false);
            this.scannersGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhraseId)).EndInit();
            this.gbMicrophones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBio;
        private System.Windows.Forms.TabPage tabPageHuella;
        private System.Windows.Forms.TabPage tabRostro;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox chbCheckLiveness;
        private System.Windows.Forms.CheckBox chbCaptureAutomatically;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox cbCameras;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartExtraction;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.CheckBox chbScanAutomatically;
        private System.Windows.Forms.Button cancelScanningButton;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button refreshListButton;
        private System.Windows.Forms.ListBox scannersListBox;
        private Neurotec.Biometrics.Gui.NFingerView fingerView;
        private Neurotec.Gui.NViewZoomSlider nViewZoomSlider1;
        private System.Windows.Forms.CheckBox chbShowBinarizedImage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox scannersGroupBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnForce;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox lbScanners;
        private Neurotec.Biometrics.Gui.NIrisView irisView;
        private Neurotec.Gui.NViewZoomSlider nViewZoomSlider3;
        private System.Windows.Forms.Button btnVerificariris;
        private Neurotec.Gui.NViewZoomSlider nViewZoomSlider2;
        private Neurotec.Biometrics.Gui.NFaceView facesView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gpbFacial;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnVozVerificar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.ComboBox extractFeatures;
        private System.Windows.Forms.CheckBox chkBoxVozCapturarAut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPhraseId;
        private Neurotec.Biometrics.Gui.NVoiceView voiceView;
        private System.Windows.Forms.GroupBox gbMicrophones;
        private System.Windows.Forms.Button btnVozForsar;
        private System.Windows.Forms.Button btnVozDetener;
        private System.Windows.Forms.Button btnVozRefrescar;
        private System.Windows.Forms.Button btnVozIniciar;
        private System.Windows.Forms.ListBox lbMicrophones;
    }
}