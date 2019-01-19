using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using WIA;
using ScannerDemo;
using System.IO;

namespace WebCams
{
    public partial class Captura : Form
    {
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        private string appParam;
        private bool capturo = false;
        private Bitmap Imagen;
        private bool capFoto;

        private byte[] wiaImgByte = null;
        private DeviceManager wiaDeviceManager = null;

        public Captura(string[] args)
        {
            appParam = "c:\\temp\\temp.jpg";
            capFoto = false;
            InitializeComponent();
            if (args.Count() > 0) 
                appParam = args.First();

            BuscarDispositivos();
            if (btnIniciar.Text == "Activar")
            {
                if (ExisteDispositivo)
                {

                    FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    FuenteDeVideo.Start();

                    btnIniciar.Text = "Detener";
                    cbxDispositivos.Enabled = false;
                    groupBox1.Text = DispositivoDeVideo[cbxDispositivos.SelectedIndex].Name.ToString();
                }
            }
        }

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {            
            for (int i = 0; i < Dispositivos.Count; i++)
            {
                cbxDispositivos.Items.Add(Dispositivos[i].Name.ToString());
            }
                cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();

            //Cargar WIAS
            cmbWiaDevices.Items.Clear();

            // Loop through the list of devices and add the name to the listbox
            for (int i = 1; i <= wiaDeviceManager.DeviceInfos.Count; i++)
            {
                cmbWiaDevices.Items.Add(new Scanner(wiaDeviceManager.DeviceInfos[i]));
            }
        }

        public bool BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
            {
                ExisteDispositivo = false;
            }

            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);

            }

            return ExisteDispositivo;
        }

        public void TerminarFuenteDeVideo()
        { 
        if (!(FuenteDeVideo==null))
            if(FuenteDeVideo.IsRunning)
            {
            FuenteDeVideo.SignalToStop();
            FuenteDeVideo= null;
            }

        }

       public  void Video_NuevoFrame( object sender, NewFrameEventArgs eventArgs)
        {
           Imagen = (Bitmap)eventArgs.Frame.Clone();
           EspacioCamara.Image = Imagen;
           if (capFoto )
               foto.Image = Imagen;

           capFoto = false;
        }



        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text == "Activar")
                
            {
                if (ExisteDispositivo)
                {
                    
                    FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    FuenteDeVideo.Start();

                    btnIniciar.Text = "Detener";
                    cbxDispositivos.Enabled = false;
                    groupBox1.Text = DispositivoDeVideo[cbxDispositivos.SelectedIndex].Name.ToString();
                }


            }
            else
            {
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    btnIniciar.Text = "Activar";
                    cbxDispositivos.Enabled = true;

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnIniciar.Text == "Detener")
                btnIniciar_Click(sender, e);
        }


        private void tomafoto_Click(object sender, EventArgs e)
        {
            if (FuenteDeVideo.IsRunning)
            {
                //foto.Image = Imagen;
                capFoto = true;
                capturo = true;
            }
        }

        private void btnProp_Click(object sender, EventArgs e)
        {
            if (!(FuenteDeVideo==null))
                FuenteDeVideo.DisplayPropertyPage(IntPtr.Zero);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (capturo)
                foto.Image.Save(appParam, System.Drawing.Imaging.ImageFormat.Jpeg);
            else
            {
                try
                {
                    System.IO.File.Delete(appParam);
                }
                catch (System.IO.IOException ex)
                {
                    TerminarFuenteDeVideo();
                }
            }
                
             Close();
            
        }

        private void Captura_Load(object sender, EventArgs e)
        {
            if (ExisteDispositivo == false)
            {
                Close();
            }
        }

        private void rbtnWebCams_CheckedChanged(object sender, EventArgs e)
        {
            pnlArgForce.Visible = true;
            pnlWia.Visible = false;
        }

        private void rbtnWias_CheckedChanged(object sender, EventArgs e)
        {
            pnlArgForce.Visible = false;
            pnlWia.Visible = true;
        }

        public void StartScanning()
        {
            Scanner device = null;

            this.Invoke(new MethodInvoker(delegate ()
            {
                device = cmbWiaDevices.SelectedItem as Scanner;
            }));

            if (device == null)
            {
                MessageBox.Show("Favor de seleccionar una camara de la lista",
                                "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ImageFile image = new ImageFile();
            string imageExtension = "";

            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    image = device.ScanJPEG();
                    imageExtension = ".jpeg";

                    //switch (cmbWiaDevices.SelectedIndex)
                    //{
                    //    case 0:
                    //        image = device.ScanPNG();
                    //        imageExtension = ".png";
                    //        break;
                    //    case 1:
                    //        image = device.ScanJPEG();
                    //        imageExtension = ".jpeg";
                    //        break;
                    //    case 2:
                    //        image = device.ScanTIFF();
                    //        imageExtension = ".tiff";
                    //        break;
                    //}
                }));


                if (image != null)
                {
                    string tempFile = System.IO.Path.GetTempFileName();

                    if (File.Exists(tempFile))
                    {
                        File.Delete(tempFile);
                    }

                    image.SaveFile(tempFile);

                    wiaImgByte = File.ReadAllBytes(tempFile);

                    using (MemoryStream stream = new MemoryStream(wiaImgByte))
                    {
                        var tamanoImagen = new Size(640, 360);
                        var imagenOriginal = new Bitmap(stream);
                        var imagen = new Bitmap(imagenOriginal, tamanoImagen);
                        pbWiaFoto.Image = imagen;
                    }

                    if (File.Exists(tempFile))
                    {
                        File.Delete(tempFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Neurotec.Samples.Utils.ShowException(new Exception("Ocurrio un error al intentar leer la imagen de la camara, intente de nuevo", ex));
            }
        }

        private void btnWiaCapture_Click(object sender, EventArgs e)
        {

        }
    } 
}
