namespace WebCams
{
    partial class Captura
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Captura));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EspacioCamara = new System.Windows.Forms.PictureBox();
            this.cbxDispositivos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.foto = new System.Windows.Forms.PictureBox();
            this.btnCaptura = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProp = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlArgForce = new System.Windows.Forms.Panel();
            this.rbtnWias = new System.Windows.Forms.RadioButton();
            this.rbtnWebCams = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pnlWia = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWiaCapture = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbWiaFoto = new System.Windows.Forms.PictureBox();
            this.cmbWiaDevices = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioCamara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnlArgForce.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnlWia.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWiaFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EspacioCamara);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camara";
            // 
            // EspacioCamara
            // 
            this.EspacioCamara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EspacioCamara.Location = new System.Drawing.Point(3, 16);
            this.EspacioCamara.Name = "EspacioCamara";
            this.EspacioCamara.Size = new System.Drawing.Size(255, 236);
            this.EspacioCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EspacioCamara.TabIndex = 0;
            this.EspacioCamara.TabStop = false;
            // 
            // cbxDispositivos
            // 
            this.cbxDispositivos.FormattingEnabled = true;
            this.cbxDispositivos.Location = new System.Drawing.Point(130, 276);
            this.cbxDispositivos.Name = "cbxDispositivos";
            this.cbxDispositivos.Size = new System.Drawing.Size(321, 21);
            this.cbxDispositivos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar Camara ";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(466, 276);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "Activar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // foto
            // 
            this.foto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foto.Location = new System.Drawing.Point(3, 16);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(255, 236);
            this.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.foto.TabIndex = 5;
            this.foto.TabStop = false;
            // 
            // btnCaptura
            // 
            this.btnCaptura.Location = new System.Drawing.Point(376, 307);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(75, 23);
            this.btnCaptura.TabIndex = 6;
            this.btnCaptura.Text = "Captura";
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.tomafoto_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.foto);
            this.groupBox2.Location = new System.Drawing.Point(283, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 255);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Foto";
            // 
            // btnProp
            // 
            this.btnProp.Location = new System.Drawing.Point(21, 307);
            this.btnProp.Name = "btnProp";
            this.btnProp.Size = new System.Drawing.Size(75, 23);
            this.btnProp.TabIndex = 8;
            this.btnProp.Text = "Propiedades";
            this.btnProp.UseVisualStyleBackColor = true;
            this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(466, 307);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pnlArgForce
            // 
            this.pnlArgForce.Controls.Add(this.groupBox1);
            this.pnlArgForce.Controls.Add(this.btnAceptar);
            this.pnlArgForce.Controls.Add(this.cbxDispositivos);
            this.pnlArgForce.Controls.Add(this.btnProp);
            this.pnlArgForce.Controls.Add(this.label1);
            this.pnlArgForce.Controls.Add(this.groupBox2);
            this.pnlArgForce.Controls.Add(this.btnIniciar);
            this.pnlArgForce.Controls.Add(this.btnCaptura);
            this.pnlArgForce.Location = new System.Drawing.Point(6, 62);
            this.pnlArgForce.Name = "pnlArgForce";
            this.pnlArgForce.Size = new System.Drawing.Size(558, 362);
            this.pnlArgForce.TabIndex = 10;
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbtnWias);
            this.groupBox5.Controls.Add(this.rbtnWebCams);
            this.groupBox5.Location = new System.Drawing.Point(6, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(303, 49);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Tipo de Camara ";
            // 
            // pnlWia
            // 
            this.pnlWia.Controls.Add(this.button1);
            this.pnlWia.Controls.Add(this.btnWiaCapture);
            this.pnlWia.Controls.Add(this.groupBox4);
            this.pnlWia.Controls.Add(this.cmbWiaDevices);
            this.pnlWia.Controls.Add(this.label4);
            this.pnlWia.Location = new System.Drawing.Point(12, 71);
            this.pnlWia.Name = "pnlWia";
            this.pnlWia.Size = new System.Drawing.Size(540, 340);
            this.pnlWia.TabIndex = 21;
            this.pnlWia.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // Captura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 434);
            this.Controls.Add(this.pnlWia);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pnlArgForce);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(582, 378);
            this.Name = "Captura";
            this.Text = "Captura de fotografia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Captura_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EspacioCamara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pnlArgForce.ResumeLayout(false);
            this.pnlArgForce.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.pnlWia.ResumeLayout(false);
            this.pnlWia.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWiaFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox EspacioCamara;
        private System.Windows.Forms.ComboBox cbxDispositivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.PictureBox foto;
        private System.Windows.Forms.Button btnCaptura;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnProp;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlArgForce;
        private System.Windows.Forms.RadioButton rbtnWias;
        private System.Windows.Forms.RadioButton rbtnWebCams;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel pnlWia;
        private System.Windows.Forms.Button btnWiaCapture;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbWiaFoto;
        private System.Windows.Forms.ComboBox cmbWiaDevices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

