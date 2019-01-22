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
            this.tbpRostroWebCam = new System.Windows.Forms.TabPage();
            this.pnlArgForce = new System.Windows.Forms.Panel();
            this.btnProp = new System.Windows.Forms.Button();
            this.btnCaptura = new System.Windows.Forms.Button();
            this.cbxDispositivos = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EspacioCamara = new System.Windows.Forms.PictureBox();
            this.pnlWia = new System.Windows.Forms.Panel();
            this.btnWiaVerificar = new System.Windows.Forms.Button();
            this.btnWiaCapture = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbWiaFoto = new System.Windows.Forms.PictureBox();
            this.cmbWiaDevices = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbtnWias = new System.Windows.Forms.RadioButton();
            this.rbtnWebCams = new System.Windows.Forms.RadioButton();
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
            this.saveVoiceFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabBio.SuspendLayout();
            this.tabPageHuella.SuspendLayout();
            this.tbpRostroWebCam.SuspendLayout();
            this.pnlArgForce.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioCamara)).BeginInit();
            this.pnlWia.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWiaFoto)).BeginInit();
            this.groupBox5.SuspendLayout();
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
            this.tabBio.Controls.Add(this.tbpRostroWebCam);
            this.tabBio.Controls.Add(this.tabPage1);
            this.tabBio.Controls.Add(this.tabPage2);
            this.tabBio.Location = new System.Drawing.Point(9, 11);
            this.tabBio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabBio.Name = "tabBio";
            this.tabBio.SelectedIndex = 0;
            this.tabBio.Size = new System.Drawing.Size(610, 458);
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
            this.scannersListBox.SelectedIndexChanged += new System.EventHandler(this.scannersListBox_SelectedIndexChanged);
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
            // tbpRostroWebCam
            // 
            this.tbpRostroWebCam.Controls.Add(this.pnlArgForce);
            this.tbpRostroWebCam.Controls.Add(this.pnlWia);
            this.tbpRostroWebCam.Controls.Add(this.groupBox5);
            this.tbpRostroWebCam.Location = new System.Drawing.Point(4, 22);
            this.tbpRostroWebCam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbpRostroWebCam.Name = "tbpRostroWebCam";
            this.tbpRostroWebCam.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbpRostroWebCam.Size = new System.Drawing.Size(602, 432);
            this.tbpRostroWebCam.TabIndex = 4;
            this.tbpRostroWebCam.Text = "Rostro";
            this.tbpRostroWebCam.UseVisualStyleBackColor = true;
            // 
            // pnlArgForce
            // 
            this.pnlArgForce.Controls.Add(this.btnProp);
            this.pnlArgForce.Controls.Add(this.btnCaptura);
            this.pnlArgForce.Controls.Add(this.cbxDispositivos);
            this.pnlArgForce.Controls.Add(this.btnAceptar);
            this.pnlArgForce.Controls.Add(this.label3);
            this.pnlArgForce.Controls.Add(this.btnIniciar);
            this.pnlArgForce.Controls.Add(this.groupBox2);
            this.pnlArgForce.Location = new System.Drawing.Point(16, 69);
            this.pnlArgForce.Name = "pnlArgForce";
            this.pnlArgForce.Size = new System.Drawing.Size(553, 333);
            this.pnlArgForce.TabIndex = 18;
            // 
            // btnProp
            // 
            this.btnProp.Location = new System.Drawing.Point(456, 33);
            this.btnProp.Name = "btnProp";
            this.btnProp.Size = new System.Drawing.Size(75, 23);
            this.btnProp.TabIndex = 16;
            this.btnProp.Text = "Propiedades";
            this.btnProp.UseVisualStyleBackColor = true;
            this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
            // 
            // btnCaptura
            // 
            this.btnCaptura.Location = new System.Drawing.Point(26, 299);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(75, 23);
            this.btnCaptura.TabIndex = 14;
            this.btnCaptura.Text = "Captura";
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.btnCaptura_Click);
            // 
            // cbxDispositivos
            // 
            this.cbxDispositivos.FormattingEnabled = true;
            this.cbxDispositivos.Location = new System.Drawing.Point(26, 33);
            this.cbxDispositivos.Name = "cbxDispositivos";
            this.cbxDispositivos.Size = new System.Drawing.Size(343, 21);
            this.cbxDispositivos.TabIndex = 11;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(180, 302);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Verificar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Camaras";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(375, 33);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 13;
            this.btnIniciar.Text = "Activar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EspacioCamara);
            this.groupBox2.Location = new System.Drawing.Point(23, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 230);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camara";
            // 
            // EspacioCamara
            // 
            this.EspacioCamara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EspacioCamara.Location = new System.Drawing.Point(3, 16);
            this.EspacioCamara.Name = "EspacioCamara";
            this.EspacioCamara.Size = new System.Drawing.Size(229, 211);
            this.EspacioCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EspacioCamara.TabIndex = 0;
            this.EspacioCamara.TabStop = false;
            // 
            // pnlWia
            // 
            this.pnlWia.Controls.Add(this.btnWiaVerificar);
            this.pnlWia.Controls.Add(this.btnWiaCapture);
            this.pnlWia.Controls.Add(this.groupBox4);
            this.pnlWia.Controls.Add(this.cmbWiaDevices);
            this.pnlWia.Controls.Add(this.label4);
            this.pnlWia.Location = new System.Drawing.Point(7, 62);
            this.pnlWia.Name = "pnlWia";
            this.pnlWia.Size = new System.Drawing.Size(540, 340);
            this.pnlWia.TabIndex = 19;
            this.pnlWia.Visible = false;
            // 
            // btnWiaVerificar
            // 
            this.btnWiaVerificar.Location = new System.Drawing.Point(101, 303);
            this.btnWiaVerificar.Name = "btnWiaVerificar";
            this.btnWiaVerificar.Size = new System.Drawing.Size(75, 23);
            this.btnWiaVerificar.TabIndex = 16;
            this.btnWiaVerificar.Text = "Verificar";
            this.btnWiaVerificar.UseVisualStyleBackColor = true;
            this.btnWiaVerificar.Click += new System.EventHandler(this.btnWiaVerificar_Click);
            // 
            // btnWiaCapture
            // 
            this.btnWiaCapture.Location = new System.Drawing.Point(20, 303);
            this.btnWiaCapture.Name = "btnWiaCapture";
            this.btnWiaCapture.Size = new System.Drawing.Size(75, 23);
            this.btnWiaCapture.TabIndex = 0;
            this.btnWiaCapture.Text = "Capturar";
            this.btnWiaCapture.UseVisualStyleBackColor = true;
            this.btnWiaCapture.Click += new System.EventHandler(this.btnWiaCapture_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbWiaFoto);
            this.groupBox4.Location = new System.Drawing.Point(20, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 246);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Foto ";
            // 
            // pbWiaFoto
            // 
            this.pbWiaFoto.Location = new System.Drawing.Point(7, 20);
            this.pbWiaFoto.Name = "pbWiaFoto";
            this.pbWiaFoto.Size = new System.Drawing.Size(263, 220);
            this.pbWiaFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWiaFoto.TabIndex = 0;
            this.pbWiaFoto.TabStop = false;
            // 
            // cmbWiaDevices
            // 
            this.cmbWiaDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWiaDevices.FormattingEnabled = true;
            this.cmbWiaDevices.Location = new System.Drawing.Point(19, 24);
            this.cmbWiaDevices.Name = "cmbWiaDevices";
            this.cmbWiaDevices.Size = new System.Drawing.Size(343, 21);
            this.cmbWiaDevices.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Camaras";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbtnWias);
            this.groupBox5.Controls.Add(this.rbtnWebCams);
            this.groupBox5.Location = new System.Drawing.Point(18, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(303, 49);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Tipo de Camara ";
            // 
            // rbtnWias
            // 
            this.rbtnWias.AutoSize = true;
            this.rbtnWias.Location = new System.Drawing.Point(120, 21);
            this.rbtnWias.Name = "rbtnWias";
            this.rbtnWias.Size = new System.Drawing.Size(177, 17);
            this.rbtnWias.TabIndex = 1;
            this.rbtnWias.TabStop = true;
            this.rbtnWias.Text = "Especificas (Nikon, Canon ..etc)";
            this.rbtnWias.UseVisualStyleBackColor = true;
            this.rbtnWias.CheckedChanged += new System.EventHandler(this.rbtnWias_CheckedChanged);
            // 
            // rbtnWebCams
            // 
            this.rbtnWebCams.AutoSize = true;
            this.rbtnWebCams.Checked = true;
            this.rbtnWebCams.Location = new System.Drawing.Point(16, 21);
            this.rbtnWebCams.Name = "rbtnWebCams";
            this.rbtnWebCams.Size = new System.Drawing.Size(73, 17);
            this.rbtnWebCams.TabIndex = 0;
            this.rbtnWebCams.TabStop = true;
            this.rbtnWebCams.Text = "Webcams";
            this.rbtnWebCams.UseVisualStyleBackColor = true;
            this.rbtnWebCams.CheckedChanged += new System.EventHandler(this.rbtnWebCams_CheckedChanged);
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
            this.scannersGroupBox.Location = new System.Drawing.Point(10, 23);
            this.scannersGroupBox.Name = "scannersGroupBox";
            this.scannersGroupBox.Size = new System.Drawing.Size(587, 124);
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
            this.btnForce.Text = "Forzar";
            this.btnForce.UseVisualStyleBackColor = true;
            this.btnForce.Visible = false;
            // 
            // rbRight
            // 
            this.rbRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(415, 54);
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
            this.rbLeft.Location = new System.Drawing.Point(414, 30);
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
            this.lbScanners.Size = new System.Drawing.Size(391, 56);
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
            this.tabPage2.Controls.Add(this.btnGuardarVoz);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btnVozVerificar);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.gbOptions);
            this.tabPage2.Controls.Add(this.voiceView);
            this.tabPage2.Controls.Add(this.gbMicrophones);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(602, 432);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Voz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGuardarVoz
            // 
            this.btnGuardarVoz.Enabled = false;
            this.btnGuardarVoz.Location = new System.Drawing.Point(117, 242);
            this.btnGuardarVoz.Name = "btnGuardarVoz";
            this.btnGuardarVoz.Size = new System.Drawing.Size(113, 22);
            this.btnGuardarVoz.TabIndex = 38;
            this.btnGuardarVoz.Text = "Guardar archivo";
            this.btnGuardarVoz.UseVisualStyleBackColor = true;
            this.btnGuardarVoz.Visible = false;
            this.btnGuardarVoz.Click += new System.EventHandler(this.btnGuardarVoz_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Verifica archivo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 13);
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
            this.gbOptions.Location = new System.Drawing.Point(425, 49);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(171, 110);
            this.gbOptions.TabIndex = 33;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Opciones";
            // 
            // extractFeatures
            // 
            this.extractFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extractFeatures.FormattingEnabled = true;
            this.extractFeatures.Location = new System.Drawing.Point(6, 46);
            this.extractFeatures.Name = "extractFeatures";
            this.extractFeatures.Size = new System.Drawing.Size(152, 21);
            this.extractFeatures.TabIndex = 23;
            this.extractFeatures.SelectedIndexChanged += new System.EventHandler(this.extractFeatures_SelectedIndexChanged);
            // 
            // chkBoxVozCapturarAut
            // 
            this.chkBoxVozCapturarAut.AutoSize = true;
            this.chkBoxVozCapturarAut.Checked = true;
            this.chkBoxVozCapturarAut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxVozCapturarAut.Location = new System.Drawing.Point(6, 84);
            this.chkBoxVozCapturarAut.Name = "chkBoxVozCapturarAut";
            this.chkBoxVozCapturarAut.Size = new System.Drawing.Size(150, 17);
            this.chkBoxVozCapturarAut.TabIndex = 22;
            this.chkBoxVozCapturarAut.Text = "Capturar automaticamente";
            this.chkBoxVozCapturarAut.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 15);
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
            this.voiceView.Location = new System.Drawing.Point(14, 163);
            this.voiceView.Name = "voiceView";
            this.voiceView.Size = new System.Drawing.Size(0, 54);
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
            this.gbMicrophones.Name = "gbMicrophones";
            this.gbMicrophones.Size = new System.Drawing.Size(409, 110);
            this.gbMicrophones.TabIndex = 32;
            this.gbMicrophones.TabStop = false;
            this.gbMicrophones.Text = "Lista de microfonos";
            // 
            // btnVozForsar
            // 
            this.btnVozForsar.Location = new System.Drawing.Point(249, 80);
            this.btnVozForsar.Name = "btnVozForsar";
            this.btnVozForsar.Size = new System.Drawing.Size(75, 23);
            this.btnVozForsar.TabIndex = 12;
            this.btnVozForsar.Text = "Forzar";
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
            this.lbMicrophones.Location = new System.Drawing.Point(7, 19);
            this.lbMicrophones.Name = "lbMicrophones";
            this.lbMicrophones.Size = new System.Drawing.Size(397, 56);
            this.lbMicrophones.TabIndex = 6;
            this.lbMicrophones.SelectedIndexChanged += new System.EventHandler(this.lbMicrophones_SelectedIndexChanged);
            // 
            // saveVoiceFileDialog
            // 
            this.saveVoiceFileDialog.Filter = "Wave audio files (*.wav;*.wave)|*.wav;*.wave";
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
            this.Text = "Busqueda biometrica 1.16";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabBio.ResumeLayout(false);
            this.tabPageHuella.ResumeLayout(false);
            this.tabPageHuella.PerformLayout();
            this.tbpRostroWebCam.ResumeLayout(false);
            this.pnlArgForce.ResumeLayout(false);
            this.pnlArgForce.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EspacioCamara)).EndInit();
            this.pnlWia.ResumeLayout(false);
            this.pnlWia.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWiaFoto)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button btnCaptura;
        private System.Windows.Forms.Panel pnlArgForce;
        private System.Windows.Forms.Panel pnlWia;
        private System.Windows.Forms.Button btnWiaCapture;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbWiaFoto;
        private System.Windows.Forms.ComboBox cmbWiaDevices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnWiaVerificar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtnWias;
        private System.Windows.Forms.RadioButton rbtnWebCams;
    }
}