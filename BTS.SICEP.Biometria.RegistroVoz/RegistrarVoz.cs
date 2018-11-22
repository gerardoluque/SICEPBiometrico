using BTS.SICEP.Biometria.Entidades;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using Neurotec.Samples;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTS.SICEP.Biometria.RegistroVoz
{
    public partial class RegistrarVoz : Form
    {
        #region Private fields

        private const string TextDependent = "Extract text dependent features";
        private const string TextIndependent = "Extract text independent features";

        private NDeviceManager _deviceManager;
        private NBiometricClient _biometricClient;
        private NSubject _subject;
        private NVoice _voice;
        private bool _defaultExtractFeatures;
        private PersonaInfo _persona;

        private string connStr = string.Empty;
        private string[] _args = new string[] { };
        private string pathArchivoTemp = string.Empty;
        private string nombreServicioBD = string.Empty;
        #endregion

        public RegistrarVoz(string[] args)
        {
            InitializeComponent();

            _args = args;

            _biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Voice };
            _biometricClient.InitializeAsync();
        }

        private void RegistrarVoz_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            extractFeatures.Items.Add(TextDependent);
            extractFeatures.Items.Add(TextIndependent);
            extractFeatures.SelectedIndex = 0;

            voiceView.Voice = null;

            _deviceManager = _biometricClient.DeviceManager;
            //_deviceManager.Initialize();

            UpdateDeviceList();

            if (_args.Count() > 0)
            {
                EstablecerParametros();

                connStr = ObtenerConexion(nombreServicioBD);
            }
            else
            {
                MessageBox.Show("No se recibieron los parametros de busqueda");
            }

            _defaultExtractFeatures = _biometricClient.VoicesExtractTextDependentFeatures;
            extractFeatures.SelectedItem = _defaultExtractFeatures ? TextDependent : TextIndependent;

            Inicializar();
        }

        private void Inicializar()
        {
            EnableControls(false);
            nudPhraseId.Value = 0;
            SetSettings();
        }

        private void EstablecerParametros()
        {
            pathArchivoTemp = _args[0];

            _persona = new PersonaInfo
            {
                id = Convert.ToInt32(_args[1]),
                estado = Convert.ToInt16(_args[2]),
                municipio = Convert.ToInt16(_args[3]),
                cereso = _args[4],
                ano = Convert.ToInt16(_args[5]),
                folio = Convert.ToInt32(_args[6]),
                num_ingreso = Convert.ToInt16(_args[7])
            };

            nombreServicioBD = _args[8];
        }

        public static string ObtenerConexion(string bd)
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

        public void StopCapturing()
        {
            _biometricClient.Cancel();
        }

        #region Private methods

        private void UpdateDeviceList()
        {
            lbMicrophones.BeginUpdate();
            try
            {
                lbMicrophones.Items.Clear();
                foreach (NDevice item in _deviceManager.Devices)
                {
                    lbMicrophones.Items.Add(item);
                }
            }
            finally
            {
                lbMicrophones.EndUpdate();
            }
        }

        private void EnableControls(bool capturing)
        {
            var hasTemplate = !capturing && _subject != null && _subject.Status == NBiometricStatus.Ok;
            //btnSaveTemplate.Enabled = hasTemplate;
            btnSaveVoice.Enabled = hasTemplate;
            btnStart.Enabled = !capturing;
            btnStop.Enabled = capturing;
            btnRefresh.Enabled = !capturing;
            gbOptions.Enabled = !capturing;
            lbMicrophones.Enabled = !capturing;
            chbCaptureAutomatically.Enabled = !capturing;
            btnForce.Enabled = !chbCaptureAutomatically.Checked && capturing;
        }

        private async System.Threading.Tasks.Task OnCapturingCompletedAsync(NBiometricTask task)
        {
            NBiometricStatus status = task.Status;
            // If Stop button was pushed
            if (status == NBiometricStatus.Canceled) return;

            if (status != NBiometricStatus.Ok && status != NBiometricStatus.SourceError && status != NBiometricStatus.TooFewSamples)
            {
                // Since capture failed start capturing again
                _voice.SoundBuffer = null;
                var performedTask = await _biometricClient.PerformTaskAsync(task);
                await OnCapturingCompletedAsync(performedTask);
            }
            else
            {
                EnableControls(false);
            }
        }

        private void SetSettings()
        {
            if ((string)extractFeatures.SelectedItem == TextDependent)
            {
                _biometricClient.VoicesExtractTextDependentFeatures = true;
                _biometricClient.VoicesExtractTextIndependentFeatures = true;
            }
            else if ((string)extractFeatures.SelectedItem == TextIndependent)
            {
                _biometricClient.VoicesExtractTextDependentFeatures = false;
                _biometricClient.VoicesExtractTextIndependentFeatures = true;
            }
        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_biometricClient.VoiceCaptureDevice == null)
            {
                MessageBox.Show(@"Seleccione un microfono, por favor !");
                return;
            }

            if (extractFeatures.SelectedIndex == -1)
            {
                MessageBox.Show(@"No se encontro la configuracion para extraccion de voz", @"Opciones invalidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set voice capture from stream
            _voice = new NVoice { CaptureOptions = NBiometricCaptureOptions.Stream };
            if (!chbCaptureAutomatically.Checked) _voice.CaptureOptions |= NBiometricCaptureOptions.Manual;
            _subject = new NSubject();
            _subject.Voices.Add(_voice);
            voiceView.Voice = _voice;

            NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.Segment, _subject);
            EnableControls(true);
            var performedTask = await _biometricClient.PerformTaskAsync(task);
            await OnCapturingCompletedAsync(performedTask);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCapturing();
            EnableControls(false);
        }

        private void btnForce_Click(object sender, EventArgs e)
        {
            _biometricClient.ForceStart();
            btnForce.Enabled = false;
        }

        private void extractFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSettings();
        }

        private void lbMicrophones_SelectedIndexChanged(object sender, EventArgs e)
        {
            _biometricClient.VoiceCaptureDevice = lbMicrophones.SelectedItem as NMicrophone;
        }

        private void btnSaveVoice_Click(object sender, EventArgs e)
        {
            var voice = _voice.Objects[0].Child as NVoice;
            if (voice == null) return;

            GuardarVoz(voice.SoundBuffer.Save().ToArray());

            this.Close();
        }

        private void GuardarVoz(byte[] voz)
        {
            var conn = new OracleConnection(connStr);

            try
            {
                conn.Open();

                File.WriteAllBytes(pathArchivoTemp, voz);

                string insert = string.Format("INSERT INTO BTS.VALIDA_HUELLA " +
                                              "(ID,CONSEC,ESTADO,MUNICIPIO,CERESO,ANO,FOLIO)" +
                                              " VALUES ({0},{1},{2},{3},'{4}',{5},{6})",
                    _persona.id,
                    1,
                    _persona.estado,
                    _persona.municipio,
                    _persona.cereso,
                    _persona.ano,
                    _persona.folio);

                OracleCommand cmdInsert = new OracleCommand(insert, conn);

                cmdInsert.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();

                //var select = $"SELECT 1 FROM BTS.FICHA_VOZ WHERE ESTADO = {_persona.estado} AND MUNICIPIO = {_persona.municipio} AND CERESO = '{_persona.cereso}' AND ANO = {_persona.ano} AND FOLIO = {_persona.folio} AND NUM_INGRESO = {_persona.num_ingreso}";
                //var insert = $"INSERT INTO BTS.FICHA_VOZ (ESTADO, MUNICIPIO, CERESO, ANO, FOLIO, NUM_INGRESO, VOZ) VALUES ({_persona.estado},{_persona.municipio},'{_persona.cereso}',{_persona.ano},{_persona.folio},{_persona.num_ingreso}," + ":BlobParameter"+ ")";
                //var conn = new OracleConnection(connStr);

                //try
                //{
                //    conn.Open();
                //    var cmdSelect = new OracleCommand(select, conn);

                //    var dr = await cmdSelect.ExecuteReaderAsync();
                //    var registroExiste = await dr.ReadAsync();

                //    if (!registroExiste)
                //    {
                //        #region insert
                //        OracleParameter blobParameter = new OracleParameter();

                //        blobParameter.OracleDbType = OracleDbType.Blob;
                //        blobParameter.ParameterName = "BlobParameter";
                //        blobParameter.Value = voz;

                //        OracleCommand cmdInsert = new OracleCommand(insert, conn);
                //        cmdInsert.Parameters.Add(blobParameter);
                //        await cmdInsert.ExecuteNonQueryAsync();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Ya cuenta con un registro de voz", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
            }
            catch (Exception ex)
            {
                Utils.ShowException(ex);
            }
        }
    }
}
