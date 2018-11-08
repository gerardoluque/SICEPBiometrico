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
            ((System.ComponentModel.ISupportInitialize)(this.PreviewWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviewWindow
            // 
            this.PreviewWindow.BackColor = System.Drawing.SystemColors.Window;
            this.PreviewWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PreviewWindow.Location = new System.Drawing.Point(10, 54);
            this.PreviewWindow.Name = "PreviewWindow";
            this.PreviewWindow.Size = new System.Drawing.Size(404, 415);
            this.PreviewWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewWindow.TabIndex = 0;
            this.PreviewWindow.TabStop = false;
            // 
            // MsgPanel
            // 
            this.MsgPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgPanel.Location = new System.Drawing.Point(10, 13);
            this.MsgPanel.Name = "MsgPanel";
            this.MsgPanel.ReadOnly = true;
            this.MsgPanel.Size = new System.Drawing.Size(404, 35);
            this.MsgPanel.TabIndex = 1;
            this.MsgPanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TakeAuto
            // 
            this.TakeAuto.Enabled = false;
            this.TakeAuto.Location = new System.Drawing.Point(336, 488);
            this.TakeAuto.Name = "TakeAuto";
            this.TakeAuto.Size = new System.Drawing.Size(75, 23);
            this.TakeAuto.TabIndex = 2;
            this.TakeAuto.Text = "Capturar";
            this.TakeAuto.UseVisualStyleBackColor = true;
            this.TakeAuto.Click += new System.EventHandler(this.TakeAuto_Click);
            // 
            // DeviceList
            // 
            this.DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceList.FormattingEnabled = true;
            this.DeviceList.Location = new System.Drawing.Point(516, 73);
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.Size = new System.Drawing.Size(121, 21);
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
            this.clbDedo.Location = new System.Drawing.Point(10, 488);
            this.clbDedo.Name = "clbDedo";
            this.clbDedo.Size = new System.Drawing.Size(116, 64);
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
            this.clbPulgar.Location = new System.Drawing.Point(10, 488);
            this.clbPulgar.Name = "clbPulgar";
            this.clbPulgar.Size = new System.Drawing.Size(120, 64);
            this.clbPulgar.TabIndex = 5;
            this.clbPulgar.SelectedIndexChanged += new System.EventHandler(this.clbPulgar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dedos faltantes:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbPulgar);
            this.Controls.Add(this.clbDedo);
            this.Controls.Add(this.DeviceList);
            this.Controls.Add(this.TakeAuto);
            this.Controls.Add(this.MsgPanel);
            this.Controls.Add(this.PreviewWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

