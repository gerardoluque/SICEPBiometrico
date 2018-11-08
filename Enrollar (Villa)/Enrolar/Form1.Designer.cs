namespace Enrolar
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
            this.PreviewWindow = new System.Windows.Forms.PictureBox();
            this.MsgPanel = new System.Windows.Forms.TextBox();
            this.TakeAuto = new System.Windows.Forms.Button();
            this.DeviceList = new System.Windows.Forms.ComboBox();
            this.clbDedo = new System.Windows.Forms.CheckedListBox();
            this.clbPulgar = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviewWindow
            // 
            this.PreviewWindow.BackColor = System.Drawing.SystemColors.Window;
            this.PreviewWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PreviewWindow.Location = new System.Drawing.Point(13, 66);
            this.PreviewWindow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PreviewWindow.Name = "PreviewWindow";
            this.PreviewWindow.Size = new System.Drawing.Size(537, 510);
            this.PreviewWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewWindow.TabIndex = 0;
            this.PreviewWindow.TabStop = false;
            // 
            // MsgPanel
            // 
            this.MsgPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgPanel.Location = new System.Drawing.Point(13, 16);
            this.MsgPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MsgPanel.Name = "MsgPanel";
            this.MsgPanel.ReadOnly = true;
            this.MsgPanel.Size = new System.Drawing.Size(537, 41);
            this.MsgPanel.TabIndex = 1;
            this.MsgPanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TakeAuto
            // 
            this.TakeAuto.Enabled = false;
            this.TakeAuto.Location = new System.Drawing.Point(448, 601);
            this.TakeAuto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TakeAuto.Name = "TakeAuto";
            this.TakeAuto.Size = new System.Drawing.Size(100, 28);
            this.TakeAuto.TabIndex = 2;
            this.TakeAuto.Text = "Capturar";
            this.TakeAuto.UseVisualStyleBackColor = true;
            this.TakeAuto.Click += new System.EventHandler(this.TakeAuto_Click);
            // 
            // DeviceList
            // 
            this.DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceList.FormattingEnabled = true;
            this.DeviceList.Location = new System.Drawing.Point(688, 90);
            this.DeviceList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.Size = new System.Drawing.Size(160, 24);
            this.DeviceList.TabIndex = 3;
            // 
            // clbDedo
            // 
            this.clbDedo.CheckOnClick = true;
            this.clbDedo.FormattingEnabled = true;
            this.clbDedo.Items.AddRange(new object[] {
            "Meñique",
            "Anular",
            "Medio",
            "Indice"});
            this.clbDedo.Location = new System.Drawing.Point(13, 601);
            this.clbDedo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbDedo.Name = "clbDedo";
            this.clbDedo.Size = new System.Drawing.Size(153, 72);
            this.clbDedo.TabIndex = 4;
            this.clbDedo.SelectedIndexChanged += new System.EventHandler(this.clbDedo_SelectedIndexChanged);
            // 
            // clbPulgar
            // 
            this.clbPulgar.CheckOnClick = true;
            this.clbPulgar.FormattingEnabled = true;
            this.clbPulgar.Items.AddRange(new object[] {
            "Pulgar Izquierdo",
            "Pulgar Derecho"});
            this.clbPulgar.Location = new System.Drawing.Point(13, 601);
            this.clbPulgar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbPulgar.Name = "clbPulgar";
            this.clbPulgar.Size = new System.Drawing.Size(159, 72);
            this.clbPulgar.TabIndex = 5;
            this.clbPulgar.SelectedIndexChanged += new System.EventHandler(this.clbPulgar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 582);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dedos faltantes:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 623);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 682);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbPulgar);
            this.Controls.Add(this.clbDedo);
            this.Controls.Add(this.DeviceList);
            this.Controls.Add(this.TakeAuto);
            this.Controls.Add(this.MsgPanel);
            this.Controls.Add(this.PreviewWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Captura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PreviewWindow;
        private System.Windows.Forms.TextBox MsgPanel;
        private System.Windows.Forms.Button TakeAuto;
        private System.Windows.Forms.ComboBox DeviceList;
        private System.Windows.Forms.CheckedListBox clbDedo;
        private System.Windows.Forms.CheckedListBox clbPulgar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

