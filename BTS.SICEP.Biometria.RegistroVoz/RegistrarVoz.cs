﻿using BTS.SICEP.Biometria.Entidades;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        #endregion

        public RegistrarVoz()
        {
            InitializeComponent();
        }

        private async void RegistrarVoz_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            extractFeatures.Items.Add(TextDependent);
            extractFeatures.Items.Add(TextIndependent);
            extractFeatures.SelectedIndex = 0;

            voiceView.Voice = null;

            if (_args.Count() > 0)
            {
                EstablecerParametros();

                connStr = ObtenerConexion(_args[9]);
            }
            else
            {
                MessageBox.Show("No se recibieron los parametros de busqueda");
            }

            _biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Voice };

            await _biometricClient.InitializeAsync();

            _defaultExtractFeatures = _biometricClient.VoicesExtractTextDependentFeatures;
            extractFeatures.SelectedItem = _defaultExtractFeatures ? TextDependent : TextIndependent;

            Inicializar();
        }

        private void Inicializar()
        {
            _deviceManager = _biometricClient.DeviceManager;
            _deviceManager.Initialize();

            EnableControls(false);
            nudPhraseId.Value = 0;
            SetSettings();
        }

        private void EstablecerParametros()
        {
            _persona = new PersonaInfo
            {
                id = Convert.ToInt32(_args[1]),
                estado = Convert.ToInt16(_args[2]),
                municipio = Convert.ToInt16(_args[3]),
                cereso = _args[4],
                ano = Convert.ToInt16(_args[5]),
                folio = Convert.ToInt32(_args[6])
            };
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
                MessageBox.Show(@"Please select a microphone");
                return;
            }

            if (extractFeatures.SelectedIndex == -1)
            {
                MessageBox.Show(@"No features configured to extract", @"Invalid options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            //if (saveVoiceFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        // Voice buffer is saved in Child attribute after segmentation
            //        var voice = _voice.Objects[0].Child as NVoice;
            //        if (voice == null) return;
            //        File.WriteAllBytes(saveVoiceFileDialog.FileName, voice.SoundBuffer.Save().ToArray());
            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.ShowException(ex);
            //    }
            //}
        }
    }
}