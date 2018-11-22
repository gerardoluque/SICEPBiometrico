namespace BTS.SICEP.Biometria.RegistroVoz
{
    partial class RegistrarVoz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarVoz));
            this.label5 = new System.Windows.Forms.Label();
            this.btnForce = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbMicrophones = new System.Windows.Forms.ListBox();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.extractFeatures = new System.Windows.Forms.ComboBox();
            this.chbCaptureAutomatically = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPhraseId = new System.Windows.Forms.NumericUpDown();
            this.gbMicrophones = new System.Windows.Forms.GroupBox();
            this.voiceView = new Neurotec.Biometrics.Gui.NVoiceView();
            this.btnSaveVoice = new System.Windows.Forms.Button();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhraseId)).BeginInit();
            this.gbMicrophones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Seleccione un microfono, presione Iniciar y diga una frase";
            // 
            // btnForce
            // 
            this.btnForce.Location = new System.Drawing.Point(249, 80);
            this.btnForce.Name = "btnForce";
            this.btnForce.Size = new System.Drawing.Size(75, 23);
            this.btnForce.TabIndex = 12;
            this.btnForce.Text = "Forsar";
            this.btnForce.UseVisualStyleBackColor = true;
            this.btnForce.Click += new System.EventHandler(this.btnForce_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(168, 80);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(87, 80);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbMicrophones
            // 
            this.lbMicrophones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMicrophones.Location = new System.Drawing.Point(4, 19);
            this.lbMicrophones.Name = "lbMicrophones";
            this.lbMicrophones.Size = new System.Drawing.Size(320, 56);
            this.lbMicrophones.TabIndex = 6;
            this.lbMicrophones.SelectedIndexChanged += new System.EventHandler(this.lbMicrophones_SelectedIndexChanged);
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.extractFeatures);
            this.gbOptions.Controls.Add(this.chbCaptureAutomatically);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Controls.Add(this.nudPhraseId);
            this.gbOptions.Location = new System.Drawing.Point(367, 42);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(189, 110);
            this.gbOptions.TabIndex = 24;
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
            this.extractFeatures.SelectedIndexChanged += new System.EventHandler(this.extractFeatures_SelectedIndexChanged);
            // 
            // chbCaptureAutomatically
            // 
            this.chbCaptureAutomatically.AutoSize = true;
            this.chbCaptureAutomatically.Checked = true;
            this.chbCaptureAutomatically.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCaptureAutomatically.Location = new System.Drawing.Point(6, 86);
            this.chbCaptureAutomatically.Name = "chbCaptureAutomatically";
            this.chbCaptureAutomatically.Size = new System.Drawing.Size(150, 17);
            this.chbCaptureAutomatically.TabIndex = 22;
            this.chbCaptureAutomatically.Text = "Capturar automaticamente";
            this.chbCaptureAutomatically.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Frase:";
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
            // gbMicrophones
            // 
            this.gbMicrophones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMicrophones.Controls.Add(this.btnForce);
            this.gbMicrophones.Controls.Add(this.btnStop);
            this.gbMicrophones.Controls.Add(this.btnRefresh);
            this.gbMicrophones.Controls.Add(this.btnStart);
            this.gbMicrophones.Controls.Add(this.lbMicrophones);
            this.gbMicrophones.Location = new System.Drawing.Point(15, 42);
            this.gbMicrophones.Name = "gbMicrophones";
            this.gbMicrophones.Size = new System.Drawing.Size(330, 110);
            this.gbMicrophones.TabIndex = 23;
            this.gbMicrophones.TabStop = false;
            this.gbMicrophones.Text = "Microphones list";
            // 
            // voiceView
            // 
            this.voiceView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceView.BackColor = System.Drawing.Color.Transparent;
            this.voiceView.Location = new System.Drawing.Point(15, 158);
            this.voiceView.Name = "voiceView";
            this.voiceView.Size = new System.Drawing.Size(541, 54);
            this.voiceView.TabIndex = 30;
            this.voiceView.Text = "voiceView";
            this.voiceView.Voice = null;
            // 
            // btnSaveVoice
            // 
            this.btnSaveVoice.Enabled = false;
            this.btnSaveVoice.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveVoice.Image")));
            this.btnSaveVoice.Location = new System.Drawing.Point(409, 237);
            this.btnSaveVoice.Name = "btnSaveVoice";
            this.btnSaveVoice.Size = new System.Drawing.Size(140, 34);
            this.btnSaveVoice.TabIndex = 31;
            this.btnSaveVoice.Text = "Guardar audio de voz";
            this.btnSaveVoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveVoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveVoice.UseVisualStyleBackColor = true;
            this.btnSaveVoice.Click += new System.EventHandler(this.btnSaveVoice_Click);
            // 
            // RegistrarVoz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 283);
            this.Controls.Add(this.btnSaveVoice);
            this.Controls.Add(this.voiceView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbMicrophones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarVoz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Voz";
            this.Load += new System.EventHandler(this.RegistrarVoz_Load);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhraseId)).EndInit();
            this.gbMicrophones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnForce;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbMicrophones;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.ComboBox extractFeatures;
        private System.Windows.Forms.CheckBox chbCaptureAutomatically;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPhraseId;
        private System.Windows.Forms.GroupBox gbMicrophones;
        private Neurotec.Biometrics.Gui.NVoiceView voiceView;
        private System.Windows.Forms.Button btnSaveVoice;
    }
}