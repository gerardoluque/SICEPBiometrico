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
            this.btnGuardarVoz = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnVozVerificar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.extractFeatures = new System.Windows.Forms.ComboBox();
            this.chkBoxVozCapturarAut = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPhraseId = new System.Windows.Forms.NumericUpDown();
            this.voiceView = new Neurotec.Biometrics.Gui.NVoiceView();
            this.gbMicrophones = new System.Windows.Forms.GroupBox();
            this.btnVozForsar = new System.Windows.Forms.Button();
            this.btnVozDetener = new System.Windows.Forms.Button();
            this.btnVozRefrescar = new System.Windows.Forms.Button();
            this.btnVozIniciar = new System.Windows.Forms.Button();
            this.lbMicrophones = new System.Windows.Forms.ListBox();
            this.tbpRostroWebCam = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EspacioCamara = new System.Windows.Forms.PictureBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDispositivos = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnProp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.foto = new System.Windows.Forms.PictureBox();
            this.btnCaptura = new System.Windows.Forms.Button();
            this.saveVoiceFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
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
            this.tbpRostroWebCam.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioCamara)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBio
            // 
            this.tabBio.Controls.Add(this.tabPageHuella);
            this.tabBio.Controls.Add(this.tabRostro);
            this.tabBio.Controls.Add(this.tabPage1);
            this.tabBio.Controls.Add(this.tabPage2);
            this.tabBio.Controls.Add(this.tbpRostroWebCam);
            this.tabBio.Location = new System.Drawing.Point(12, 14);
            this.tabBio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabBio.Name = "tabBio";
            this.tabBio.SelectedIndex = 0;
            this.tabBio.Size = new System.Drawing.Size(813, 564);
            this.tabBio.TabIndex = 0;
            this.tabBio.SelectedIndexChanged += new System.EventHandler(this.tabBio_SelectedIndexChanged);
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
            this.tabPageHuella.Location = new System.Drawing.Point(4, 25);
            this.tabPageHuella.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageHuella.Name = "tabPageHuella";
            this.tabPageHuella.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageHuella.Size = new System.Drawing.Size(805, 535);
            this.tabPageHuella.TabIndex = 0;
            this.tabPageHuella.Text = "Huella";
            this.tabPageHuella.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Lista de scanners";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(208, 436);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 27);
            this.button1.TabIndex = 38;
            this.button1.Text = "Verificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblQuality
            // 
            this.lblQuality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQuality.Location = new System.Drawing.Point(335, 434);
            this.lblQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(253, 25);
            this.lblQuality.TabIndex = 37;
            // 
            // chbScanAutomatically
            // 
            this.chbScanAutomatically.AutoSize = true;
            this.chbScanAutomatically.Checked = true;
            this.chbScanAutomatically.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbScanAutomatically.Location = new System.Drawing.Point(391, 34);
            this.chbScanAutomatically.Margin = new System.Windows.Forms.Padding(4);
            this.chbScanAutomatically.Name = "chbScanAutomatically";
            this.chbScanAutomatically.Size = new System.Drawing.Size(197, 21);
            this.chbScanAutomatically.TabIndex = 36;
            this.chbScanAutomatically.Text = "Capturar automaticamente";
            this.chbScanAutomatically.UseVisualStyleBackColor = true;
            this.chbScanAutomatically.Visible = false;
            // 
            // cancelScanningButton
            // 
            this.cancelScanningButton.Enabled = false;
            this.cancelScanningButton.Location = new System.Drawing.Point(441, 134);
            this.cancelScanningButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelScanningButton.Name = "cancelScanningButton";
            this.cancelScanningButton.Size = new System.Drawing.Size(120, 27);
            this.cancelScanningButton.TabIndex = 35;
            this.cancelScanningButton.Text = "Cancelar";
            this.cancelScanningButton.UseVisualStyleBackColor = true;
            this.cancelScanningButton.Click += new System.EventHandler(this.cancelScanningButton_Click);
            // 
            // scanButton
            // 
            this.scanButton.Enabled = false;
            this.scanButton.Location = new System.Drawing.Point(317, 134);
            this.scanButton.Margin = new System.Windows.Forms.Padding(4);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(120, 27);
            this.scanButton.TabIndex = 34;
            this.scanButton.Text = "Capturar";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // refreshListButton
            // 
            this.refreshListButton.Location = new System.Drawing.Point(173, 134);
            this.refreshListButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshListButton.Name = "refreshListButton";
            this.refreshListButton.Size = new System.Drawing.Size(120, 27);
            this.refreshListButton.TabIndex = 31;
            this.refreshListButton.Text = "Refrescar";
            this.refreshListButton.UseVisualStyleBackColor = true;
            this.refreshListButton.Click += new System.EventHandler(this.refreshListButton_Click);
            // 
            // scannersListBox
            // 
            this.scannersListBox.ItemHeight = 16;
            this.scannersListBox.Location = new System.Drawing.Point(172, 58);
            this.scannersListBox.Margin = new System.Windows.Forms.Padding(4);
            this.scannersListBox.Name = "scannersListBox";
            this.scannersListBox.Size = new System.Drawing.Size(461, 68);
            this.scannersListBox.TabIndex = 30;
            this.scannersListBox.SelectedIndexChanged += new System.EventHandler(this.scannersListBox_SelectedIndexChanged);
            // 
            // fingerView
            // 
            this.fingerView.BackColor = System.Drawing.Color.White;
            this.fingerView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fingerView.BoundingRectColor = System.Drawing.Color.Red;
            this.fingerView.Location = new System.Drawing.Point(207, 199);
            this.fingerView.Margin = new System.Windows.Forms.Padding(4);
            this.fingerView.MinutiaColor = System.Drawing.Color.Red;
            this.fingerView.Name = "fingerView";
            this.fingerView.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.fingerView.ResultImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.fingerView.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.fingerView.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.fingerView.ShownImage = Neurotec.Biometrics.Gui.ShownImage.Result;
            this.fingerView.SingularPointColor = System.Drawing.Color.Red;
            this.fingerView.Size = new System.Drawing.Size(380, 228);
            this.fingerView.TabIndex = 29;
            this.fingerView.TreeColor = System.Drawing.Color.Crimson;
            this.fingerView.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.fingerView.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.fingerView.TreeWidth = 2D;
            // 
            // nViewZoomSlider1
            // 
            this.nViewZoomSlider1.BackColor = System.Drawing.SystemColors.Window;
            this.nViewZoomSlider1.Location = new System.Drawing.Point(211, 469);
            this.nViewZoomSlider1.Margin = new System.Windows.Forms.Padding(4);
            this.nViewZoomSlider1.Name = "nViewZoomSlider1";
            this.nViewZoomSlider1.Size = new System.Drawing.Size(377, 28);
            this.nViewZoomSlider1.TabIndex = 33;
            this.nViewZoomSlider1.Text = "nViewHuellaZoomSlider";
            this.nViewZoomSlider1.View = this.fingerView;
            // 
            // chbShowBinarizedImage
            // 
            this.chbShowBinarizedImage.AutoSize = true;
            this.chbShowBinarizedImage.Enabled = false;
            this.chbShowBinarizedImage.Location = new System.Drawing.Point(449, 178);
            this.chbShowBinarizedImage.Margin = new System.Windows.Forms.Padding(4);
            this.chbShowBinarizedImage.Name = "chbShowBinarizedImage";
            this.chbShowBinarizedImage.Size = new System.Drawing.Size(143, 21);
            this.chbShowBinarizedImage.TabIndex = 32;
            this.chbShowBinarizedImage.Text = "Imagen en binario\r\n";
            this.chbShowBinarizedImage.UseVisualStyleBackColor = true;
            this.chbShowBinarizedImage.CheckedChanged += new System.EventHandler(this.chbShowBinarizedImage_CheckedChanged);
            // 
            // tabRostro
            // 
            this.tabRostro.Controls.Add(this.groupBox);
            this.tabRostro.Controls.Add(this.gpbFacial);
            this.tabRostro.Location = new System.Drawing.Point(4, 25);
            this.tabRostro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRostro.Name = "tabRostro";
            this.tabRostro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRostro.Size = new System.Drawing.Size(805, 535);
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
            this.groupBox.Location = new System.Drawing.Point(20, 18);
            this.groupBox.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox.Size = new System.Drawing.Size(759, 106);
            this.groupBox.TabIndex = 26;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Camaras";
            // 
            // btnStartExtraction
            // 
            this.btnStartExtraction.Enabled = false;
            this.btnStartExtraction.Location = new System.Drawing.Point(269, 60);
            this.btnStartExtraction.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartExtraction.Name = "btnStartExtraction";
            this.btnStartExtraction.Size = new System.Drawing.Size(120, 27);
            this.btnStartExtraction.TabIndex = 27;
            this.btnStartExtraction.Text = "Capturar rostro";
            this.btnStartExtraction.UseVisualStyleBackColor = true;
            this.btnStartExtraction.Click += new System.EventHandler(this.btnStartExtraction_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(393, 60);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 27);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chbCheckLiveness
            // 
            this.chbCheckLiveness.AutoSize = true;
            this.chbCheckLiveness.Location = new System.Drawing.Point(597, 58);
            this.chbCheckLiveness.Margin = new System.Windows.Forms.Padding(4);
            this.chbCheckLiveness.Name = "chbCheckLiveness";
            this.chbCheckLiveness.Size = new System.Drawing.Size(124, 21);
            this.chbCheckLiveness.TabIndex = 21;
            this.chbCheckLiveness.Text = "Check liveness";
            this.chbCheckLiveness.UseVisualStyleBackColor = true;
            this.chbCheckLiveness.Visible = false;
            // 
            // chbCaptureAutomatically
            // 
            this.chbCaptureAutomatically.AutoSize = true;
            this.chbCaptureAutomatically.Location = new System.Drawing.Point(424, 58);
            this.chbCaptureAutomatically.Margin = new System.Windows.Forms.Padding(4);
            this.chbCaptureAutomatically.Name = "chbCaptureAutomatically";
            this.chbCaptureAutomatically.Size = new System.Drawing.Size(166, 21);
            this.chbCaptureAutomatically.TabIndex = 20;
            this.chbCaptureAutomatically.Text = "Capture automatically";
            this.chbCaptureAutomatically.UseVisualStyleBackColor = true;
            this.chbCaptureAutomatically.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(145, 60);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 27);
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
            this.cbCameras.Location = new System.Drawing.Point(11, 25);
            this.cbCameras.Margin = new System.Windows.Forms.Padding(4);
            this.cbCameras.Name = "cbCameras";
            this.cbCameras.Size = new System.Drawing.Size(591, 24);
            this.cbCameras.TabIndex = 15;
            this.cbCameras.SelectedIndexChanged += new System.EventHandler(this.cbCameras_SelectedIndexChanged);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(11, 60);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(120, 27);
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
            this.gpbFacial.Location = new System.Drawing.Point(20, 139);
            this.gpbFacial.Margin = new System.Windows.Forms.Padding(4);
            this.gpbFacial.Name = "gpbFacial";
            this.gpbFacial.Padding = new System.Windows.Forms.Padding(4);
            this.gpbFacial.Size = new System.Drawing.Size(759, 380);
            this.gpbFacial.TabIndex = 34;
            this.gpbFacial.TabStop = false;
            this.gpbFacial.Text = " Facial ";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(65, 338);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(537, 25);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVerificar
            // 
            this.btnVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerificar.Enabled = false;
            this.btnVerificar.Location = new System.Drawing.Point(69, 302);
            this.btnVerificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(120, 27);
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
            this.facesView.Location = new System.Drawing.Point(69, 23);
            this.facesView.Margin = new System.Windows.Forms.Padding(4);
            this.facesView.Name = "facesView";
            this.facesView.ShowIcaoArrows = true;
            this.facesView.ShowTokenImageRectangle = true;
            this.facesView.Size = new System.Drawing.Size(524, 273);
            this.facesView.TabIndex = 33;
            this.facesView.TokenImageRectangleColor = System.Drawing.Color.White;
            // 
            // nViewZoomSlider2
            // 
            this.nViewZoomSlider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nViewZoomSlider2.Location = new System.Drawing.Point(197, 304);
            this.nViewZoomSlider2.Margin = new System.Windows.Forms.Padding(4);
            this.nViewZoomSlider2.Name = "nViewZoomSlider2";
            this.nViewZoomSlider2.Size = new System.Drawing.Size(376, 28);
            this.nViewZoomSlider2.TabIndex = 32;
            this.nViewZoomSlider2.Text = "nViewZoomSlider2";
            this.nViewZoomSlider2.View = this.facesView;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scannersGroupBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(805, 535);
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
            this.scannersGroupBox.Location = new System.Drawing.Point(24, 16);
            this.scannersGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.scannersGroupBox.Name = "scannersGroupBox";
            this.scannersGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.scannersGroupBox.Size = new System.Drawing.Size(757, 165);
            this.scannersGroupBox.TabIndex = 13;
            this.scannersGroupBox.TabStop = false;
            this.scannersGroupBox.Text = "Escaners";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(611, 107);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 21);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Scan automatically";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // btnForce
            // 
            this.btnForce.Enabled = false;
            this.btnForce.Location = new System.Drawing.Point(409, 100);
            this.btnForce.Margin = new System.Windows.Forms.Padding(4);
            this.btnForce.Name = "btnForce";
            this.btnForce.Size = new System.Drawing.Size(120, 27);
            this.btnForce.TabIndex = 14;
            this.btnForce.Text = "Forzar";
            this.btnForce.UseVisualStyleBackColor = true;
            this.btnForce.Visible = false;
            // 
            // rbRight
            // 
            this.rbRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(586, 60);
            this.rbRight.Margin = new System.Windows.Forms.Padding(4);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(105, 21);
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
            this.rbLeft.Location = new System.Drawing.Point(583, 31);
            this.rbLeft.Margin = new System.Windows.Forms.Padding(4);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(109, 21);
            this.rbLeft.TabIndex = 12;
            this.rbLeft.TabStop = true;
            this.rbLeft.Text = "Iris Izquierdo";
            this.rbLeft.UseVisualStyleBackColor = true;
            this.rbLeft.CheckedChanged += new System.EventHandler(this.rbLeft_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(261, 100);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 100);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 27);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(140, 100);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(120, 27);
            this.btnScan.TabIndex = 9;
            this.btnScan.Text = "Capturar";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lbScanners
            // 
            this.lbScanners.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScanners.ItemHeight = 16;
            this.lbScanners.Location = new System.Drawing.Point(8, 23);
            this.lbScanners.Margin = new System.Windows.Forms.Padding(4);
            this.lbScanners.Name = "lbScanners";
            this.lbScanners.Size = new System.Drawing.Size(521, 68);
            this.lbScanners.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.irisView);
            this.groupBox1.Controls.Add(this.nViewZoomSlider3);
            this.groupBox1.Controls.Add(this.btnVerificariris);
            this.groupBox1.Location = new System.Drawing.Point(13, 188);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(783, 260);
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
            this.irisView.Location = new System.Drawing.Point(13, 23);
            this.irisView.Margin = new System.Windows.Forms.Padding(4);
            this.irisView.Name = "irisView";
            this.irisView.OuterBoundaryColor = System.Drawing.Color.GreenYellow;
            this.irisView.OuterBoundaryWidth = 2;
            this.irisView.Size = new System.Drawing.Size(755, 175);
            this.irisView.TabIndex = 14;
            // 
            // nViewZoomSlider3
            // 
            this.nViewZoomSlider3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nViewZoomSlider3.BackColor = System.Drawing.SystemColors.Window;
            this.nViewZoomSlider3.Location = new System.Drawing.Point(305, 208);
            this.nViewZoomSlider3.Margin = new System.Windows.Forms.Padding(4);
            this.nViewZoomSlider3.Name = "nViewZoomSlider3";
            this.nViewZoomSlider3.Size = new System.Drawing.Size(455, 28);
            this.nViewZoomSlider3.TabIndex = 18;
            this.nViewZoomSlider3.Text = "nIrisViewZoomSlider";
            this.nViewZoomSlider3.View = this.irisView;
            // 
            // btnVerificariris
            // 
            this.btnVerificariris.Enabled = false;
            this.btnVerificariris.Location = new System.Drawing.Point(11, 208);
            this.btnVerificariris.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerificariris.Name = "btnVerificariris";
            this.btnVerificariris.Size = new System.Drawing.Size(120, 27);
            this.btnVerificariris.TabIndex = 16;
            this.btnVerificariris.Text = "Verificar";
            this.btnVerificariris.UseVisualStyleBackColor = true;
            this.btnVerificariris.Click += new System.EventHandler(this.btnVerificariris_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGuardarVoz);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btnVozVerificar);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.gbOptions);
            this.tabPage2.Controls.Add(this.voiceView);
            this.tabPage2.Controls.Add(this.gbMicrophones);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(805, 535);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Voz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGuardarVoz
            // 
            this.btnGuardarVoz.Enabled = false;
            this.btnGuardarVoz.Location = new System.Drawing.Point(156, 298);
            this.btnGuardarVoz.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarVoz.Name = "btnGuardarVoz";
            this.btnGuardarVoz.Size = new System.Drawing.Size(151, 27);
            this.btnGuardarVoz.TabIndex = 38;
            this.btnGuardarVoz.Text = "Guardar archivo";
            this.btnGuardarVoz.UseVisualStyleBackColor = true;
            this.btnGuardarVoz.Visible = false;
            this.btnGuardarVoz.Click += new System.EventHandler(this.btnGuardarVoz_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 345);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 28);
            this.button2.TabIndex = 37;
            this.button2.Text = "Verifica archivo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnVozVerificar
            // 
            this.btnVozVerificar.Enabled = false;
            this.btnVozVerificar.Location = new System.Drawing.Point(28, 298);
            this.btnVozVerificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVozVerificar.Name = "btnVozVerificar";
            this.btnVozVerificar.Size = new System.Drawing.Size(120, 27);
            this.btnVozVerificar.TabIndex = 36;
            this.btnVozVerificar.Text = "Verificar";
            this.btnVozVerificar.UseVisualStyleBackColor = true;
            this.btnVozVerificar.Click += new System.EventHandler(this.btnVozVerificar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Seleccione un microfono, presione Iniciar y diga una frase";
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.extractFeatures);
            this.gbOptions.Controls.Add(this.chkBoxVozCapturarAut);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.Add(this.nudPhraseId);
            this.gbOptions.Location = new System.Drawing.Point(559, 49);
            this.gbOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Padding = new System.Windows.Forms.Padding(4);
            this.gbOptions.Size = new System.Drawing.Size(238, 135);
            this.gbOptions.TabIndex = 33;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Opciones";
            // 
            // extractFeatures
            // 
            this.extractFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extractFeatures.FormattingEnabled = true;
            this.extractFeatures.Location = new System.Drawing.Point(8, 53);
            this.extractFeatures.Margin = new System.Windows.Forms.Padding(4);
            this.extractFeatures.Name = "extractFeatures";
            this.extractFeatures.Size = new System.Drawing.Size(201, 24);
            this.extractFeatures.TabIndex = 23;
            this.extractFeatures.SelectedIndexChanged += new System.EventHandler(this.extractFeatures_SelectedIndexChanged);
            // 
            // chkBoxVozCapturarAut
            // 
            this.chkBoxVozCapturarAut.AutoSize = true;
            this.chkBoxVozCapturarAut.Checked = true;
            this.chkBoxVozCapturarAut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxVozCapturarAut.Location = new System.Drawing.Point(8, 106);
            this.chkBoxVozCapturarAut.Margin = new System.Windows.Forms.Padding(4);
            this.chkBoxVozCapturarAut.Name = "chkBoxVozCapturarAut";
            this.chkBoxVozCapturarAut.Size = new System.Drawing.Size(197, 21);
            this.chkBoxVozCapturarAut.TabIndex = 22;
            this.chkBoxVozCapturarAut.Text = "Capturar automaticamente";
            this.chkBoxVozCapturarAut.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Frase:";
            // 
            // nudPhraseId
            // 
            this.nudPhraseId.Location = new System.Drawing.Point(85, 21);
            this.nudPhraseId.Margin = new System.Windows.Forms.Padding(4);
            this.nudPhraseId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudPhraseId.Name = "nudPhraseId";
            this.nudPhraseId.Size = new System.Drawing.Size(124, 22);
            this.nudPhraseId.TabIndex = 18;
            // 
            // voiceView
            // 
            this.voiceView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceView.BackColor = System.Drawing.Color.Transparent;
            this.voiceView.Location = new System.Drawing.Point(31, 201);
            this.voiceView.Margin = new System.Windows.Forms.Padding(4);
            this.voiceView.Name = "voiceView";
            this.voiceView.Size = new System.Drawing.Size(737, 66);
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
            this.gbMicrophones.Location = new System.Drawing.Point(10, 49);
            this.gbMicrophones.Margin = new System.Windows.Forms.Padding(4);
            this.gbMicrophones.Name = "gbMicrophones";
            this.gbMicrophones.Padding = new System.Windows.Forms.Padding(4);
            this.gbMicrophones.Size = new System.Drawing.Size(520, 135);
            this.gbMicrophones.TabIndex = 32;
            this.gbMicrophones.TabStop = false;
            this.gbMicrophones.Text = "Microphones list";
            // 
            // btnVozForsar
            // 
            this.btnVozForsar.Location = new System.Drawing.Point(332, 98);
            this.btnVozForsar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVozForsar.Name = "btnVozForsar";
            this.btnVozForsar.Size = new System.Drawing.Size(100, 28);
            this.btnVozForsar.TabIndex = 12;
            this.btnVozForsar.Text = "Forzar";
            this.btnVozForsar.UseVisualStyleBackColor = true;
            this.btnVozForsar.Click += new System.EventHandler(this.btnVozForsar_Click);
            // 
            // btnVozDetener
            // 
            this.btnVozDetener.Enabled = false;
            this.btnVozDetener.Location = new System.Drawing.Point(224, 98);
            this.btnVozDetener.Margin = new System.Windows.Forms.Padding(4);
            this.btnVozDetener.Name = "btnVozDetener";
            this.btnVozDetener.Size = new System.Drawing.Size(100, 28);
            this.btnVozDetener.TabIndex = 11;
            this.btnVozDetener.Text = "Detener";
            this.btnVozDetener.UseVisualStyleBackColor = true;
            this.btnVozDetener.Click += new System.EventHandler(this.btnVozDetener_Click);
            // 
            // btnVozRefrescar
            // 
            this.btnVozRefrescar.Location = new System.Drawing.Point(8, 98);
            this.btnVozRefrescar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVozRefrescar.Name = "btnVozRefrescar";
            this.btnVozRefrescar.Size = new System.Drawing.Size(100, 28);
            this.btnVozRefrescar.TabIndex = 10;
            this.btnVozRefrescar.Text = "Refrescar";
            this.btnVozRefrescar.UseVisualStyleBackColor = true;
            this.btnVozRefrescar.Click += new System.EventHandler(this.btnVozRefrescar_Click);
            // 
            // btnVozIniciar
            // 
            this.btnVozIniciar.Location = new System.Drawing.Point(116, 98);
            this.btnVozIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVozIniciar.Name = "btnVozIniciar";
            this.btnVozIniciar.Size = new System.Drawing.Size(100, 28);
            this.btnVozIniciar.TabIndex = 9;
            this.btnVozIniciar.Text = "Iniciar";
            this.btnVozIniciar.UseVisualStyleBackColor = true;
            this.btnVozIniciar.Click += new System.EventHandler(this.btnVozIniciar_Click);
            // 
            // lbMicrophones
            // 
            this.lbMicrophones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMicrophones.ItemHeight = 16;
            this.lbMicrophones.Location = new System.Drawing.Point(13, 23);
            this.lbMicrophones.Margin = new System.Windows.Forms.Padding(4);
            this.lbMicrophones.Name = "lbMicrophones";
            this.lbMicrophones.Size = new System.Drawing.Size(499, 68);
            this.lbMicrophones.TabIndex = 6;
            this.lbMicrophones.SelectedIndexChanged += new System.EventHandler(this.lbMicrophones_SelectedIndexChanged);
            // 
            // tbpRostroWebCam
            // 
            this.tbpRostroWebCam.Controls.Add(this.groupBox2);
            this.tbpRostroWebCam.Controls.Add(this.btnIniciar);
            this.tbpRostroWebCam.Controls.Add(this.label3);
            this.tbpRostroWebCam.Controls.Add(this.cbxDispositivos);
            this.tbpRostroWebCam.Controls.Add(this.btnAceptar);
            this.tbpRostroWebCam.Controls.Add(this.btnProp);
            this.tbpRostroWebCam.Controls.Add(this.groupBox3);
            this.tbpRostroWebCam.Controls.Add(this.btnCaptura);
            this.tbpRostroWebCam.Location = new System.Drawing.Point(4, 25);
            this.tbpRostroWebCam.Name = "tbpRostroWebCam";
            this.tbpRostroWebCam.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRostroWebCam.Size = new System.Drawing.Size(805, 535);
            this.tbpRostroWebCam.TabIndex = 4;
            this.tbpRostroWebCam.Text = "Rostro";
            this.tbpRostroWebCam.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EspacioCamara);
            this.groupBox2.Location = new System.Drawing.Point(31, 97);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(348, 314);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camara";
            // 
            // EspacioCamara
            // 
            this.EspacioCamara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EspacioCamara.Location = new System.Drawing.Point(4, 19);
            this.EspacioCamara.Margin = new System.Windows.Forms.Padding(4);
            this.EspacioCamara.Name = "EspacioCamara";
            this.EspacioCamara.Size = new System.Drawing.Size(340, 291);
            this.EspacioCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EspacioCamara.TabIndex = 0;
            this.EspacioCamara.TabStop = false;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(500, 56);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(100, 28);
            this.btnIniciar.TabIndex = 13;
            this.btnIniciar.Text = "Activar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Camaras";
            // 
            // cbxDispositivos
            // 
            this.cbxDispositivos.FormattingEnabled = true;
            this.cbxDispositivos.Location = new System.Drawing.Point(35, 56);
            this.cbxDispositivos.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDispositivos.Name = "cbxDispositivos";
            this.cbxDispositivos.Size = new System.Drawing.Size(456, 24);
            this.cbxDispositivos.TabIndex = 11;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(391, 415);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Verificar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnProp
            // 
            this.btnProp.Location = new System.Drawing.Point(608, 56);
            this.btnProp.Margin = new System.Windows.Forms.Padding(4);
            this.btnProp.Name = "btnProp";
            this.btnProp.Size = new System.Drawing.Size(100, 28);
            this.btnProp.TabIndex = 16;
            this.btnProp.Text = "Propiedades";
            this.btnProp.UseVisualStyleBackColor = true;
            this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.foto);
            this.groupBox3.Location = new System.Drawing.Point(387, 97);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(348, 314);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Foto";
            // 
            // foto
            // 
            this.foto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foto.Location = new System.Drawing.Point(4, 19);
            this.foto.Margin = new System.Windows.Forms.Padding(4);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(340, 291);
            this.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.foto.TabIndex = 5;
            this.foto.TabStop = false;
            // 
            // btnCaptura
            // 
            this.btnCaptura.Location = new System.Drawing.Point(31, 415);
            this.btnCaptura.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(100, 28);
            this.btnCaptura.TabIndex = 14;
            this.btnCaptura.Text = "Captura";
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.btnCaptura_Click);
            // 
            // saveVoiceFileDialog
            // 
            this.saveVoiceFileDialog.Filter = "Wave audio files (*.wav;*.wave)|*.wav;*.wave";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 607);
            this.Controls.Add(this.tabBio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda biometrica 1.6";
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
            this.tbpRostroWebCam.ResumeLayout(false);
            this.tbpRostroWebCam.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EspacioCamara)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.foto)).EndInit();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGuardarVoz;
        private System.Windows.Forms.SaveFileDialog saveVoiceFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tbpRostroWebCam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox EspacioCamara;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDispositivos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnProp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox foto;
        private System.Windows.Forms.Button btnCaptura;
    }
}