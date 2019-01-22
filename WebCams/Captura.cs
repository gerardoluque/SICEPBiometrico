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
using System.Threading.Tasks;

namespace WebCams
{
    public partial class Captura : Form
    {
        private bool existenDispositivosWebCams = false;
        private bool existenDispositivosWIA = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        private string rutaArchivoFoto;
        private bool capturo = false;
        private Bitmap Imagen;
        private bool capFoto;

        private DeviceManager wiaDeviceManager = null;

        public Captura(string[] args)
        {
            rutaArchivoFoto = "c:\\temp\\temp.jpg";
            capFoto = false;

            InitializeComponent();

            wiaDeviceManager = new DeviceManager();

            if (args.Count() > 0) 
                rutaArchivoFoto = args.First();

            existenDispositivosWebCams = BuscarDispositivos();

            if (btnIniciar.Text == "Activar")
            {
                if (existenDispositivosWebCams)
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
        }

        public bool BuscarDispositivos()
        {
            //Cargar WIAS
            cmbWiaDevices.Items.Clear();

            for (int i = 1; i <= wiaDeviceManager.DeviceInfos.Count; i++)
            {
                cmbWiaDevices.Items.Add(new Scanner(wiaDeviceManager.DeviceInfos[i]));
            }

            //Cargar webcams
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count > 0)
            {
                CargarDispositivos(DispositivoDeVideo);
            }

            existenDispositivosWebCams = DispositivoDeVideo.Count > 0;
            existenDispositivosWIA = cmbWiaDevices.Items.Count > 0; ;

            return existenDispositivosWebCams;
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
                if (existenDispositivosWebCams)
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
            if (FuenteDeVideo != null)
            {
                if (FuenteDeVideo.IsRunning)
                {
                    //foto.Image = Imagen;
                    capFoto = true;
                    capturo = true;
                }
            }
            else
            {
                MessageBox.Show("Favor de activar la camara");
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
                foto.Image.Save(rutaArchivoFoto, System.Drawing.Imaging.ImageFormat.Jpeg);
            else
            {
                try
                {
                    System.IO.File.Delete(rutaArchivoFoto);
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
            if (existenDispositivosWebCams == false && existenDispositivosWIA == false)
            {
                MessageBox.Show("No se encontraron dispositivos de video disponible");
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
                MessageBox.Show("Favor de seleccionar una camara de la lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ImageFile image = new ImageFile();

            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    image = device.ScanJPEG();
                }));

                if (image != null)
                {
                    var tempFile = System.IO.Path.GetTempFileName();

                    if (File.Exists(tempFile))
                    {
                        File.Delete(tempFile);
                    }

                    image.SaveFile(tempFile);

                    var wiaImgByte = File.ReadAllBytes(tempFile);

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
                MessageBox.Show("Ocurrio un error al intentar leer la imagen de la camara, intente de nuevo");
            }
        }

        private void btnWiaCapture_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(StartScanning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pbWiaFoto.Image != null)
            {
                pbWiaFoto.Image.Save(rutaArchivoFoto, System.Drawing.Imaging.ImageFormat.Jpeg);

                Close();
            }
            else
            {
                MessageBox.Show("No se encontro imagen, favor de tomar la foto");
            }
        }
    } 
}
