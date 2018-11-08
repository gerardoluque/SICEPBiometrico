namespace ControlDeHuellas
{
    partial class validaHuella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(validaHuella));
            this.verifica = new enrolamiento.verificacion();
            this.SuspendLayout();
            // 
            // verifica
            // 
            this.verifica.BackColor = System.Drawing.SystemColors.Control;
            this.verifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.verifica.Location = new System.Drawing.Point(1, -2);
            this.verifica.Name = "verifica";
            this.verifica.Size = new System.Drawing.Size(605, 474);
            this.verifica.TabIndex = 0;
            // 
            // validaHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 449);
            this.Controls.Add(this.verifica);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "validaHuella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de interno por huella";
            this.Load += new System.EventHandler(this.validaHuella_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private enrolamiento.verificacion verifica;
    }
}