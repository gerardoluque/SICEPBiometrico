using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.IO;
using DPFP;

namespace enrolamiento
{
    public partial class enrolamiento : UserControl, DPFP.Capture.EventHandler
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        delegate void Function();
        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Template Template;
        public bool enrolado = false;
        public bool fallo = false;
        public bool Cerrado = false;
        public string id;
        public string estado;
        public string municipio;
        public string cereso;
        public string ano;
        public string folio;
        public string dedo;
        public string completo;
        public string servicename;


        public enrolamiento()
        {
            InitializeComponent();
        }

        //se inicializa el componente
        protected virtual void Init(bool nuevo)
        {
            try
            {

                Capturer = new DPFP.Capture.Capture(DPFP.Capture.Priority.High);				// Create a capture operation.

                if (null != Capturer)
                {
                    enrolado = false;
                    Capturer.EventHandler = this;					// Subscribe for capturing events.

                    Enroller = new DPFP.Processing.Enrollment();

                    if (nuevo)
                    {
                        SetStatus("Coloque su dedo en el lector para iniciar enrolamiento");
                    }
                    else
                    {
                        SetStatus("La huella procesada no es valida, repita el proceso de registro.");
                    }

                    Huella1.Image = Properties.Resources.icon16Wait;
                    lbHuella1.Text = "Muestra 1 por capturar";
                    Huella2.Image = Properties.Resources.icon16Wait;
                    lbHuella2.Text = "Muestra 2 por capturar";
                    Huella3.Image = Properties.Resources.icon16Wait;
                    lbHuella3.Text = "Muestra 3 por capturar";
                    Huella4.Image = Properties.Resources.icon16Wait;
                    lbHuella4.Text = "Muestra 4 por capturar";
                }
                else
                    SetStatus("No se pudo inicializar la operacion de captura!");
            }
            catch
            {
                SetStatus("No se pudo inicializar la operacion de captura!");
            }
        }

        //metodo para procesar
        protected virtual void Process(DPFP.Sample Sample)
        {
            try
            {
                // Draw fingerprint sample image.
                DrawPicture(ConvertSampleToBitmap(Sample));
                SalvarAArchivo(Sample);


                #region CODIGO DE PRUEBA
                /*
                DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
                //Byte[] ansi = null;
                //Convertor.ConvertToANSI381(Sample, ref ansi);
                Bitmap ma = null;
                Convertor.ConvertToPicture(Sample, ref ma);
                ma.Save("c:\\temp\\huellas\\prueba.bmp");
                
                //using (FileStream fs = File.Create("c:\\temp\\huellas\\ansi.dat"))
                //{
                //    fs.Write(ansi, 0, ansi.Length);
                //    fs.Close();
                //}
               */
                #endregion

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification); //DPFP.Processing.DataPurpose.Enrollment

                // Check quality of the sample and add to enroller if it's good
                if (features != null) try
                    {
                        MakeReport("El patron de la huella ha sido creado");
                        SetStatus("Retire su dedo del lector.");
                        switch (Enroller.FeaturesNeeded)
                        {
                            case 4:
                                Huella1.Image = Properties.Resources.icon16Ok;
                                SetHuella("Muestra 1 capturada correctamente",1);
                                break;
                            case 3:
                                Huella2.Image = Properties.Resources.icon16Ok;
                                SetHuella("Muestra 2 capturada correctamente", 2);
                                break;
                            case 2:
                                Huella3.Image = Properties.Resources.icon16Ok;
                                SetHuella("Muestra 3 capturada correctamente", 3);
                                break;
                            case 1:
                                Huella4.Image = Properties.Resources.icon16Ok;
                                SetHuella("Muestra 4 capturada correctamente", 4);
                                break;
                        }

                        Enroller.AddFeatures(features);		// Add feature set to template.
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        //UpdateStatus();

                        // Check if template has been created.
                        switch (Enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:	// report success and stop capturing
                                OnTemplate(Enroller.Template);
                                MakeReport("Huella Procesada");
                                Stop();
                                break;

                            case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing
                                Enroller.Clear();
                                Stop();
                                //UpdateStatus();
                                OnTemplate(null);
                                Start();
                                break;
                        }
                    }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SalvarAArchivo(Sample sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.


            var huellaCompresa = DPUruNet.Compression.CompressRaw(10, 10, 100, 55, sample.Bytes, DPUruNet.CompressionAlgorithm.COMPRESSION_WSQ_AWARE);
            File.WriteAllBytes(@"c:\temp\huellaCompresaWSQ", huellaCompresa);

            var huella = new byte[] { };
            Convertor.ConvertToANSI381(sample, ref huella);		
            File.WriteAllBytes(@"c:\temp\huellaAnsi", huella);
        }

        #region funciones para el manejo de la interfaz

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            bitmap.Save("C:\\TEMP\\HUELLA.BMP");

            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate()
            {
                StatusLine.Text = status;
            }));
        }


        protected void SetHuella(string texto,int label)
        {
            this.Invoke(new Function(delegate()
            {
                switch (label)
                {
                    case 1:
                        lbHuella1.Text = texto;
                        break;
                    case 2:
                        lbHuella2.Text = texto;
                        break;
                    case 3:
                        lbHuella3.Text = texto;
                        break;
                    case 4:
                        lbHuella4.Text = texto;
                        break;
                }
            }));
        }




        protected void MakeReport(string message)
        {
            this.Invoke(new Function(delegate()
            {
                StatusText.AppendText(message + "\r\n");
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate()
            {
                Picture.Image = new Bitmap(bitmap, Picture.Size);	// fit the image into the picture box
            }));
        }
        #endregion

        #region Metodos de captura del control
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    Cerrado = true;
                    SetStatus("Inicie el registro colocando su dedo en el lector");
                }
                catch
                {
                    if (fallo == false)
                    {
                        Init(true);
                        //Start();
                    }
                    else
                    {
                        MakeReport("No se puede iniciar la captura.");
                    }
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                    Cerrado = true;
                }
                catch
                {
                    MakeReport("No se puede iniciar la captura.");
                }
            }
        }
        #endregion

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport("La muestra de la huella fue capturada...");
            SetStatus("Coloque el dedo en el lector nuevamente");
            Process(Sample);
        }

        public bool isClosed()
        {
            return Cerrado;
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            SetStatus("Coloque el dedo en el lector nuevamente");
            MakeReport("Continuar...");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("Capturando Huella...");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huella ha sido conectado");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huella ha sido desconectado");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("La calidad de la muestra de huella digital es correcta.");
            else
                MakeReport("La calidad de la muestra de huella digital es incorrecta.");
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                if (Template != null)
                {
                    SetStatus("De clic en Aceptar para Finalizar el proceso.");
                    enrolado = true;
                }
                else
                {
                    Stop();
                    enrolado = false;
                    Init(false);
                }
            }));
        }
        #endregion

        #region Metodos para su llamada desde Web
        public string ObtenerTemplate()
        {
            string template = "";
            byte[] muestra = null;
            
            Template.Serialize(ref muestra);
            File.WriteAllBytes(@"c:\temp\MuestraTemplate", muestra);
            template = Convert.ToBase64String(muestra);
            return template;
        }

        public bool EnrolamientoCompletado()
        {
            return enrolado;
        }

        public void Inicializar()
        {
            Init(true);
            Start();
        }

        public void Finalizar()
        {
            Stop();
            Dispose(true);
        }

        public void Reiniciar()
        {
            Finalizar(); Init(true);
            Start();
        }

        public void Mensaje(string msg)
        {
            MakeReport(msg);
        }

        #endregion

        private void enrolamiento_Load(object sender, EventArgs e)
        {

        }

        public static string Conexion(string bd)
        {
            #region Conexion
            string connectionString;

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = bd;
            sqlBuilder.Password = "BTS";

            if (sqlBuilder.Password.Length > 30)
                sqlBuilder.Password = sqlBuilder.Password.Substring(0, 30);

            sqlBuilder.UserID = "BTS";
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.Pooling = false;
            connectionString = sqlBuilder.ToString();

            return connectionString;
            #endregion
        }

        public void RegistraHuella()
        {
            #region RegistraHuella

            DPFP.Template comparar = new DPFP.Template();

            OracleConnection conn = null;
            bool existeRegistro = false;
            string huellastr = ObtenerTemplate();
            byte[] muestra = null;
            Template.Serialize(ref muestra);

            string select = " SELECT 1 FROM BTS.HUELLA WHERE ESTADO = " + estado.ToString() + " AND MUNICIPIO = " + municipio.ToString() + " AND CERESO = '" + cereso + "' AND ANO = " + ano.ToString() + " AND FOLIO = " + folio.ToString() + " AND DEDO = " + dedo.ToString();
            string insert = " INSERT INTO BTS.HUELLA(ESTADO, MUNICIPIO, CERESO, ANO, FOLIO, DEDO, TEMPLATE,HUELLA) VALUES (" + estado.ToString() + "," + municipio.ToString() + ",'" + cereso + "'," + ano.ToString() + "," + folio.ToString() + "," + dedo.ToString() + ", :BlobParameter ,'" + huellastr + "' )";
            //string update = " select docto from bts.ingreso_docto_pdf where pdf = ";

            try
            {
                conn = new OracleConnection(Conexion(servicename));
                conn.Open();
                #region select
                OracleCommand cmdSelect = new OracleCommand(select, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Mensaje("select regreso resultado");
                    existeRegistro = true;
                }
                else
                {
                    Mensaje("select NO regreso resultado");
                    existeRegistro = false;
                }
                #endregion

                if (existeRegistro == false)
                {
                    #region insert
                    OracleParameter blobParameter = new OracleParameter();

                    blobParameter.OracleDbType = OracleDbType.Blob;
                    blobParameter.ParameterName = "BlobParameter";
                    blobParameter.Value = muestra;

                    OracleCommand cmdInsert = new OracleCommand(insert, conn);

                    //We are passing Name and Blob byte data as Oracle parameters.  CARGAR TEMPLATE
                    cmdInsert.Parameters.Add(blobParameter);
                    //cmdInsert.Parameters.Add(blobParameter2);

                    //Open connection and execute insert query.
                    cmdInsert.ExecuteNonQuery();
                    #endregion
                }

            }
            catch (Exception ex)
            {
                Mensaje("Error " + ex.Message);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }



    }
}
