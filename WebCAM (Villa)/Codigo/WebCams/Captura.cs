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
            int i;
            for (i = 0; i < Dispositivos.Count; i++)
            {
                cbxDispositivos.Items.Add(Dispositivos[i].Name.ToString());
            }
                cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();
            
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
    } 
}
