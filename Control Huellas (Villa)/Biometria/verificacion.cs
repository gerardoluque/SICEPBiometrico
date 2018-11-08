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
using Oracle.DataAccess.Types;
using System.IO;
using DPUruNet;

namespace enrolamiento
{
    public partial class verificacion : UserControl, DPFP.Capture.EventHandler
    {
        #region variables
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        delegate void Function();
        private DPFP.Capture.Capture Capturer;
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Data dat;
        private string prueba;
        public bool capturado = false;
        public bool identificado = false;
        public string id;
        public string estado;
        public string municipio;
        public string cereso;
        public string ano;
        public string folio;
        public string dedo;
        public string completo;
        public string servicename;
        #endregion
        public verificacion()
        {
            InitializeComponent();
        }

        //se inicializa el componente
        protected virtual void Init()
        {
            #region init
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                {
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                    capturado = false;
                    identificado = false;
                    Verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
                    //SetStatus("Coloque su dedo en el lector para iniciar la Verificación");
                }
                else
                    SetStatus("No se pudo inicializar la operacion de captura!");
            }
            catch
            {
                SetStatus("No se pudo inicializar la operacion de captura!");
            }
            #endregion
        }

        //metodo para procesar
        protected virtual void Process(DPFP.Sample Sample)
        {
            #region process
            byte[] objeto;
            short consec = 1;
            DataSet ds = new DataSet();
            DPFP.Template Template2;
            try
            {
                // Draw fingerprint sample image.
                DrawPicture(ConvertSampleToBitmap(Sample));

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                //GENERA BMP DE LA HUELLA
                //Bitmap huella = ConvertSampleToBitmap(Sample);
                //huella.Save("c:\\temp\\huellas\\dedoIzq07UareU.bmp");
                
                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    ds = ObtenerTabla();
                    if (ds == null)
                    {
                        SetStatus("No se pudo optener información de las huellas registradas.");
                        return;
                    }


                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        objeto = (byte[])row["TEMPLATE"];
                        DPFP.Template comparar = new DPFP.Template();
                        comparar.DeSerialize(objeto);
                        Template = comparar;

                        #region CODIGO DE PRUEBAS
                        //FileStream fs = new FileStream("C:\\Temp\\huellas\\ansi.dat", FileMode.Open, FileAccess.Read);
                        //objeto = new byte[fs.Length];
                        //fs.Read(objeto, 0, System.Convert.ToInt32(fs.Length));
                        //fs.Close();
                        ////MemoryStream  a = new MemoryStream(objeto);
                        //DPFP.Template comparar = new DPFP.Template();
                        //comparar.DeSerialize(objeto);
                        //Template = comparar;
                        #endregion

                        // Compare the feature set with our template
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        

                        if (Template == null)
                            SetStatus("No se puedo crear el template");

                        Verificator.Verify(features, Template, ref result);
                        if (result.Verified)
                        {
                            SetStatus("Identidad Verificada.");
                            capturado = true;
                            identificado = true;

                            if (completo == "1")
                            {
                                estado = row["ESTADO"].ToString() ;
                                municipio = row["MUNICIPIO"].ToString();
                                cereso = row["CERESO"].ToString();
                                ano = row["ANO"].ToString();
                                folio = row["FOLIO"].ToString();
                            }

                            RegistrarDatos(consec);
                            consec++;
                            Stop();
                            
                            Application.Exit();
                        }
                        else
                        {
                            capturado = true;
                            identificado = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            Application.Exit();
            #endregion
        }

        #region funciones para el manejo de la interfaz

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            #region ConvertSampleToBitmap
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
            #endregion
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            #region ExtractFeatures
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
            #endregion
        }

        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate()
            {
                textBox1.AppendText(status + "\r\n");

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
            #region start
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetStatus("Coloque su dedo en el lector para iniciar la Verificación.");
                }
                catch
                {
                    SetStatus("No se pudo inicializar la operacion de captura!");
                }
            }
            #endregion
        }

        protected void Stop()
        {
            #region stop
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetStatus("Can't terminate capture!");
                }
            }
            #endregion
        }
        #endregion

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            SetStatus("La huella ha sido capturada.");
            SetStatus("Retire el dedo del lector.");
            Process(Sample);
            //Process2(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            SetStatus("Captura Finalizada...");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            SetStatus("Capturando Huella...");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetStatus("El lector de huella ha sido conectado.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetStatus("El lector de huella ha sido desconectado.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                SetStatus("The quality of the fingerprint sample is good.");
            else
                SetStatus("The quality of the fingerprint sample is poor.");
        }

        /*private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                if (Template != null)
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                else
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
            }));
        }*/
        #endregion

        #region Metodos
        public string TemplateString
        {
            set 
            {
                prueba = value;
            }
        }

        public bool CapturaTerminada()
        {
            return capturado;
        }

        public bool IdentidadComprobada()
        {
            return identificado;
        }

        public void Inicializar()
        {
            try
            {
                pbManoDer.Visible = false;
                pbIndiceDer.Visible = true;
                Init();
                Start();
            }
            catch (Exception ex)
            {
                SetStatus("No se pudo inicializar el lector de huella.");
            }
        }

        public void Finalizar()
        {
            Stop();
        }

        public void Inhabilitar()
        {
            Stop();
            SetStatus("No existe huella registrada para el Imputado");
        }

        public void Reiniciar()
        {
            Stop();
            Inicializar();
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

        public DataSet ObtenerTabla()
        {
            #region ObtenerTabla
            string select = null;
            DataSet ds = new DataSet();
            OracleConnection conn = null;
            
            bool existeRegistro = false;

            #region identifica el dedo que se marco para captura
            dedo = null;
            if (rbPulgarDer.Checked == true)
                dedo = "1";
            else
                if (rbIndiceDer.Checked == true)
                    dedo = "2";
                else
                    if (rbMedioDer.Checked == true)
                        dedo = "3";
                    else
                        if (rbAnularDer.Checked == true)
                            dedo = "4";
                        else
                            if (rbMeniqueDer.Checked == true)
                                dedo = "5";
                            else
                                if (rbPulgarIzq.Checked == true)
                                    dedo = "6";
                                else
                                    if (rbIndiceIzq.Checked == true)
                                        dedo = "7";
                                    else
                                        if (rbMedioIzq.Checked == true)
                                            dedo = "8";
                                        else
                                            if (rbAnularIzq.Checked == true)
                                                dedo = "9";
                                            else
                                                if (rbMeniqueIzq.Checked == true)
                                                    dedo = "10";
                                                else
                                                    SetStatus("Seleccione el dedo a capturar.");

            #endregion

            if (completo == "1")
            { 
                select = "SELECT ESTADO, MUNICIPIO, CERESO, ANO, FOLIO, DEDO, HUELLA,TEMPLATE FROM BTS.HUELLA WHERE DEDO = " + dedo; 
            }
            else
            {
                if (completo == "2")
                { 
                    select = "SELECT ESTADO, MUNICIPIO, CERESO, ANO, FOLIO, DEDO, HUELLA,TEMPLATE FROM BTS.HUELLA WHERE ESTADO = " + estado + "AND MUNICIPIO = " + municipio + "AND  CERESO =" + cereso + "AND ANO = " + ano + "AND FOLIO = " + folio; 
                }
                else
                {
                    if (completo == "3")
                        select = "SELECT ESTADO, MUNICIPIO, CERESO, ANO, FOLIO, DEDO, HUELLA,TEMPLATE FROM BTS.HUELLA";
                }
            }

            try
            {
                conn = new OracleConnection(Conexion(servicename));
                conn.Open();
                #region select
                OracleCommand cmdSelect = new OracleCommand(select, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmdSelect);
                oda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    SetStatus("select regreso resultado");
                    existeRegistro = true;
                }
                else
                {
                    SetStatus("select NO regreso resultado");
                    existeRegistro = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                SetStatus("Error " + ex.Message);
                ds = null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return ds;
            #endregion
        }

        public void RegistrarDatos(short consec)
        {
            #region RegistrarDatos
            OracleConnection conn = null;
            string insert = " INSERT INTO BTS.VALIDA_HUELLA(ID,CONSEC,ESTADO, MUNICIPIO, CERESO, ANO, FOLIO) VALUES (" + id.ToString() + "," + consec.ToString() + "," + estado.ToString() + "," + municipio.ToString() + ",'" + cereso + "'," + ano.ToString() + "," + folio.ToString() + " )";
            try
            {
                conn = new OracleConnection(Conexion(servicename));
                conn.Open();
                OracleCommand cmdInsert = new OracleCommand(insert, conn);
                //Open connection and execute insert query.
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SetStatus("Error " + ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }

        public void CargaComboDedos()
        {
            #region CargaComboDedos
            string select;
            DataSet ds = new DataSet();
            OracleConnection conn = null;
            bool existeRegistro = false;

            select = "SELECT ID_DEDO, DESCR FROM BTS.DEDO";
            
            try
            {
                conn = new OracleConnection(Conexion(servicename));
                conn.Open();
                OracleCommand cmdSelect = new OracleCommand(select, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmdSelect);
                oda.Fill(ds);
                cmbDedo.DisplayMember = "DESCR";
                cmbDedo.ValueMember = "ID_DEDO";
                cmbDedo.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                SetStatus("Error " + ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }

        public void OcultaImagenIzq()
        {
            pbManoIzq.Visible = false;
            pbPulgarIzq.Visible = false;
            pbindiceIzq.Visible = false;
            pbMedioIzq.Visible = false;
            pbAnularIzq.Visible = false;
            pbMeniqueIzq.Visible = false;
        }

        public void OcultaImagenDer()
        {
            pbManoDer.Visible = false;
            pbPulgarDer.Visible = false;
            pbIndiceDer.Visible = false;
            pbMedioDer.Visible = false;
            pbAnularDer.Visible = false;
            pbMeniqueDer.Visible = false;
        }

        private void rbPulgarIzq_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenIzq();
            OcultaImagenDer();
            pbPulgarIzq.Visible = true;
            pbManoDer.Visible = true;
        }

        private void rbIndiceIzq_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenIzq();
            OcultaImagenDer();
            pbindiceIzq.Visible = true;
            pbManoDer.Visible = true;
        }

        private void rbMedioIzq_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenIzq();
            OcultaImagenDer();
            pbMedioIzq.Visible = true;
            pbManoDer.Visible = true;
        }

        private void rbAnularIzq_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenIzq();
            OcultaImagenDer();
            pbAnularIzq.Visible = true;
            pbManoDer.Visible = true;
        }

        private void rbMeniqueIzq_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenIzq();
            OcultaImagenDer();
            pbMeniqueIzq.Visible = true;
            pbManoDer.Visible = true;
        }

        private void rbMeniqueDer_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenDer();
            OcultaImagenIzq();
            pbMeniqueDer.Visible = true;
            pbManoIzq.Visible = true;
        }

        private void rbAnularDer_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenDer();
            OcultaImagenIzq();
            pbAnularDer.Visible = true;
            pbManoIzq.Visible = true;
        }

        private void rbMedioDer_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenDer();
            OcultaImagenIzq();
            pbMedioDer.Visible = true;
            pbManoIzq.Visible = true;
        }

        private void rbIndiceDer_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenDer();
            OcultaImagenIzq();
            pbIndiceDer.Visible = true;
            pbManoIzq.Visible = true;
        }

        private void rbPulgarDer_CheckedChanged(object sender, EventArgs e)
        {
            OcultaImagenDer();
            OcultaImagenIzq();
            pbPulgarDer.Visible = true;
            pbManoIzq.Visible = true;
        }

        #endregion


        //metodo de prueba para procesar con el registro serializado
        protected virtual void Process2(DPFP.Sample Sample)
        {
            #region process
            byte[] objeto;
            short consec = 1;
            string huella;
            string huellaValidar;
            byte[] muestra = null;
            DataSet ds = new DataSet();
            DPFP.Template Template2;
            try
            {
                // Draw fingerprint sample image.
                DrawPicture(ConvertSampleToBitmap(Sample));

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    ds = ObtenerTabla();
                    if (ds == null)
                    {
                        SetStatus("No se pudo optener información de las huellas registradas.");
                        return;
                    }


                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        huella = (string)row["HUELLA"];

                        // Compare the feature set with our template
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        if (Template == null)
                            SetStatus("No se puedo crear el template");

                        features.Serialize(ref muestra);
                        huellaValidar = Convert.ToBase64String(muestra);

                        if (huellaValidar == huella)
                        {
                            SetStatus("Identidad Verificada.");
                            capturado = true;
                            identificado = true;

                            if (completo == "1")
                            {
                                estado = row["ESTADO"].ToString();
                                municipio = row["MUNICIPIO"].ToString();
                                cereso = row["CERESO"].ToString();
                                ano = row["ANO"].ToString();
                                folio = row["FOLIO"].ToString();
                            }

                            RegistrarDatos(consec);
                            consec++;
//                            Stop();

                        }

                        else
                        {
                            capturado = true;
                            identificado = false;
                        }
                        #region
                        //Verificator.Verify(features, Template, ref result);
                        //if (result.Verified)
                        //{
                        //    SetStatus("Identidad Verificada.");
                        //    capturado = true;
                        //    identificado = true;

                        //    if (completo == "1")
                        //    {
                        //        estado = row["ESTADO"].ToString();
                        //        municipio = row["MUNICIPIO"].ToString();
                        //        cereso = row["CERESO"].ToString();
                        //        ano = row["ANO"].ToString();
                        //        folio = row["FOLIO"].ToString();
                        //    }

                        //    RegistrarDatos();
                        //    Stop();

                        //    Application.Exit();
                        //}
                        //else
                        //{
                        //    capturado = true;
                        //    identificado = false;
                        //}
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            Application.Exit();
            #endregion
        }


    }
}
