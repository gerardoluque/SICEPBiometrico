using BTS.SiCEP.Biometria.Huellas.Entidades;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Gui;
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

namespace BTS.SiCEP.Biometria.Huellas
{
    public partial class MainForm : Form
    {
        #region Private fields
        private NDeviceManager _deviceManager;
        private NBiometricClient _biometricClient;
        private NSubject _subject;
        private NSubject _subjectFace;
        private NFinger _subjectFinger;
        private NIris _iris;
        private short ojo = 0;

        private string connStr = string.Empty;

        private string[] _args = new string[] { };

        private VerificarHuellaInfo _verificarHuellaInfo = null;
        private List<BusquedaResultadoInfo> _busquedaResultados = new List<BusquedaResultadoInfo>() { };
        private BiometriaBusquedaServicio.BiometriaServicioClient servicioBusqueda = new BiometriaBusquedaServicio.BiometriaServicioClient();
        #endregion

        public MainForm(string[] args)
        {
            InitializeComponent();

            if (args != null)
                _args = args;

            ((CheckBox)nViewZoomSlider2.Controls[0].Controls[0]).Text = "Zoom Ancho";
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (_args.Count() > 0)
            {
                EstablecerParametros();

                connStr = ObtenerConexion(_verificarHuellaInfo.Servicename);
            }
            else
            {
                MessageBox.Show("No se recibieron los parametros de busqueda");
            }

            _biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Face | NBiometricType.Finger | NBiometricType.Iris | NBiometricType.Voice, FacesCheckIcaoCompliance = false };

            await _biometricClient.InitializeAsync();

            Inicializar();
        }

        private void Inicializar()
        {
            #region Rostro
            _deviceManager = _biometricClient.DeviceManager;
            _deviceManager.Initialize();

            UpdateCameraList();
            #endregion

            #region Huella
            //Buscar UrU plugin con error y desactivarlo
            var pgins = Neurotec.Plugins.NPluginManager.GetInstances();

            if (pgins != null && pgins.Length > 0)
            {
                var pginUrU = pgins[0].Plugins["DigitalPersonaUareU"];
                if (pginUrU != null && pginUrU.State == Neurotec.Plugins.NPluginState.PluggingError)
                {
                    pginUrU.Disable();
                    pgins[0].Refresh();
                }
            }
            //

            UpdateScannerList();
            #endregion

            #region Iris
            UpdateIrisScannerList();
            #endregion
        }

        #region Metodos de ayuda
        private bool IsSubjectValid(NSubject subject)
        {
            return subject != null && (subject.Status == NBiometricStatus.Ok
                || subject.Status == NBiometricStatus.None && subject.GetTemplateBuffer() != null);
        }


        private void EstablecerParametros()
        {
            _verificarHuellaInfo = new VerificarHuellaInfo
            {
                PersonaIdentificar = new PersonaInfo
                {
                    id = Convert.ToInt32(_args[1]),
                    estado = Convert.ToInt16(_args[2]),
                    municipio = Convert.ToInt16(_args[3]),
                    cereso = _args[4],
                    ano = Convert.ToInt16(_args[5]),
                    folio = Convert.ToInt32(_args[6])
                },
                Dedo = _args[7],
                Completo = _args[8],
                Servicename = _args[9]
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
        #endregion

        #region Huella
        private void OnEnrollCompleted(NBiometricTask task)
        {
            EnableHuellaControls(false);
            NBiometricStatus status = task.Status;

            // Check if extraction was canceled
            if (status == NBiometricStatus.Canceled) return;

            if (status == NBiometricStatus.Ok)
            {
                lblQuality.Text = String.Format("Calidad: {0}", _subjectFinger.Objects[0].Quality);

                if (IsSubjectValid(_subject))
                    button1.Enabled = true;
                else
                    MessageBox.Show("La imagen de la huella no es valida");
            }
            else
            {
                MessageBox.Show("No fue posible realizar la lectura de la huella, intente de nuevo", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _subject = null;
                _subjectFinger = null;
                EnableHuellaControls(false);
            }
        }

        private void EnableHuellaControls(bool capturing)
        {
            scannersListBox.Enabled = !capturing;
            cancelScanningButton.Enabled = capturing;
            scanButton.Enabled = !capturing;
            refreshListButton.Enabled = !capturing;
            var fingerStatus = !capturing && _subjectFinger != null && _subjectFinger.Status == NBiometricStatus.Ok;
            chbShowBinarizedImage.Enabled = fingerStatus;
            chbScanAutomatically.Enabled = !capturing;
        }

        private void UpdateScannerList()
        {
            scannersListBox.BeginUpdate();
            try
            {
                scannersListBox.Items.Clear();
                if (_deviceManager != null)
                {
                    foreach (NDevice item in _deviceManager.Devices)
                    {
                        scannersListBox.Items.Add(item);
                    }
                }

                scanButton.Enabled = (scannersListBox.Items.Count > 0);
            }
            finally
            {
                scannersListBox.EndUpdate();
            }
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            UpdateScannerList();
        }

        private async void scanButton_Click(object sender, EventArgs e)
        {
            #region scan
            if (_biometricClient.FingerScanner == null)
            {
                MessageBox.Show(@"Seleccione un scanner de la lista por favor !");
            }
            else
            {
                EnableHuellaControls(true);
                lblQuality.Text = String.Empty;

                // Create a finger
                _subjectFinger = new NFinger();

                // Set Manual capturing mode if not automatic selected
                if (!chbScanAutomatically.Checked)
                {
                    _subjectFinger.CaptureOptions = NBiometricCaptureOptions.Manual;
                }

                // Add finger to the subject and fingerView
                _subject = new NSubject();
                _subject.Fingers.Add(_subjectFinger);
                _subjectFinger.PropertyChanged += OnAttributesPropertyChanged;
                fingerView.Finger = _subjectFinger;
                fingerView.ShownImage = ShownImage.Original;

                // Begin capturing
                _biometricClient.FingersReturnBinarizedImage = true;
                NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.CreateTemplate, _subject);
                var performedTask = await _biometricClient.PerformTaskAsync(task);
                OnEnrollCompleted(performedTask);
            }
            #endregion
        }

        private void OnAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Status")
            {
                BeginInvoke(new Action<NBiometricStatus>(status => lblQuality.Text = status.ToString()), _subjectFinger.Status);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            EnableHuellaControls(true);
            button1.Enabled = false;

            //identificado = await BuscarHuellaEnTemplates();

            try
            {
                var personaResult = await BuscarHuellaServicioWCF();

                if (personaResult.Identificado)
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("No se encontro coincidencias con la huella, intente otro dedo");
                }
            }
            catch (Exception)
            {
                Neurotec.Samples.Utils.ShowException(new Exception("Ocurrio un error al intentar utilizar el servicio web de biometria, favor de consultar el visor de eventos del servidor web"));
            }

            button1.Enabled = true;
            EnableHuellaControls(false);
        }

        private async Task<BiometriaBusquedaServicio.PersonaInfo> BuscarHuellaServicioWCF()
        {
            #region Buscar huella servicio WCF
            var template = Neurotec.Samples.Utils.ImageToByte(_subject.Fingers[0].BinarizedImage.ToBitmap());
            var templateBase64 = Convert.ToBase64String(template);

            var result = await servicioBusqueda.BuscarHuellaAsync(templateBase64, _verificarHuellaInfo.PersonaIdentificar.id);

            return result;
            #endregion
        }

        private void cancelScanningButton_Click(object sender, EventArgs e)
        {
            _biometricClient.Cancel();
            EnableHuellaControls(false);
        }

        private void chbShowBinarizedImage_CheckedChanged(object sender, EventArgs e)
        {
            fingerView.ShownImage = chbShowBinarizedImage.Checked ? ShownImage.Result : ShownImage.Original;
        }
        #endregion

        #region Rostro
        private void UpdateCameraList()
        {
            cbCameras.BeginUpdate();
            try
            {
                cbCameras.Items.Clear();
                foreach (NDevice device in _deviceManager.Devices)
                {
                    cbCameras.Items.Add(device);
                }

                if (_biometricClient.FaceCaptureDevice == null && cbCameras.Items.Count > 0)
                {
                    cbCameras.SelectedIndex = 0;
                    return;
                }

                if (_biometricClient.FaceCaptureDevice != null)
                {
                    cbCameras.SelectedIndex = cbCameras.Items.IndexOf(_biometricClient.FaceCaptureDevice);
                }
            }
            finally
            {
                cbCameras.EndUpdate();
            }
        }

        private void EnableFaceControls(bool capturing)
        {
            var hasTemplate = !capturing && _subjectFace != null && _subjectFace.Status == NBiometricStatus.Ok;
            //btnSaveImage.Enabled = hasTemplate;
            //btnSaveTemplate.Enabled = hasTemplate;
            btnVerificar.Enabled = !capturing;
            btnStart.Enabled = !capturing;
            btnRefreshList.Enabled = !capturing;
            btnStop.Enabled = capturing;
            cbCameras.Enabled = !capturing;
            btnStartExtraction.Enabled = capturing && !chbCaptureAutomatically.Checked;
            chbCaptureAutomatically.Enabled = !capturing;
            chbCheckLiveness.Enabled = !capturing;
        }

        private async System.Threading.Tasks.Task OnCapturingFaceCompletedAsync(NBiometricStatus status)
        {
            try
            {
                // If Stop button was pushed
                if (status == NBiometricStatus.Canceled) return;

                lblStatus.Text = status.ToString();
                if (status != NBiometricStatus.Ok)
                {
                    // Since capture failed start capturing again
                    _subjectFace.Faces[0].Image = null;
                    status = await _biometricClient.CaptureAsync(_subjectFace);
                    await OnCapturingFaceCompletedAsync(status);
                }
                else
                {
                    EnableFaceControls(false);
                }
            }
            catch (Exception ex)
            {
                //Utils.ShowException(ex);
                lblStatus.Text = string.Empty;
                //lblQuality.Text = string.Empty;
                EnableFaceControls(false);
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            UpdateCameraList();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            #region Iniciar captura de facial
            if (_biometricClient.FaceCaptureDevice == null)
            {
                MessageBox.Show(@"Seleccione una camara de la lista");
                return;
            }
            // Set face capture from stream
            var face = new NFace { CaptureOptions = NBiometricCaptureOptions.Stream };
            if (!chbCaptureAutomatically.Checked) face.CaptureOptions |= NBiometricCaptureOptions.Manual;
            _subjectFace = new NSubject();
            _subjectFace.Faces.Add(face);
            facesView.Face = face;

            // Begin capturing faces
            EnableFaceControls(true);
            lblStatus.Text = string.Empty;
            //lblQuality.Text = string.Empty;

            try
            {
                var status = await _biometricClient.CaptureAsync(_subjectFace);
                await OnCapturingFaceCompletedAsync(status);
            }
            catch (Exception ex)
            {
                Neurotec.Samples.Utils.ShowException(ex);
                lblStatus.Text = string.Empty;
                //lblQuality.Text = string.Empty;
                EnableFaceControls(false);
            }
            #endregion
        }

        private void btnStartExtraction_Click(object sender, EventArgs e)
        {
            lblStatus.Text = @"Extracting ...";
            // Begin extraction
            _biometricClient.ForceStart();
        }

        private void cbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            _biometricClient.FaceCaptureDevice = cbCameras.SelectedItem as NCamera;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            EnableFaceControls(true);
            btnVerificar.Enabled = false;

            var personaResult = await BuscarFacialServicioWCF();

            if (personaResult.Identificado)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("No se encontro coincidencias con la imagen, intente de nuevo");
            }

            btnVerificar.Enabled = true;
            EnableFaceControls(false);
        }

        private async Task<BiometriaBusquedaServicio.PersonaInfo> BuscarFacialServicioWCF()
        {
            var template = Neurotec.Samples.Utils.ImageToByte(_subjectFace.Faces[0].GetImage(false).ToBitmap());
            var templateBase64 = Convert.ToBase64String(template);

            var result = await servicioBusqueda.BuscarFacialAsync(templateBase64, _verificarHuellaInfo.PersonaIdentificar.id);

            return result;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _biometricClient.Cancel();
            EnableFaceControls(false);
        }
        #endregion

        #region Iris
        private void UpdateIrisScannerList()
        {
            lbScanners.BeginUpdate();
            try
            {
                lbScanners.Items.Clear();
                if (_deviceManager != null)
                {
                    foreach (NDevice item in _deviceManager.Devices)
                    {
                        lbScanners.Items.Add(item);
                    }
                }
            }
            finally
            {
                lbScanners.EndUpdate();
            }
        }

        private void EnableIrisControls(bool capturing)
        {
            btnVerificariris.Enabled = !capturing;
            btnCancel.Enabled = capturing;
            btnScan.Enabled = !capturing;
            btnRefresh.Enabled = !capturing;
            rbLeft.Enabled = !capturing;
            rbRight.Enabled = !capturing;
            //btnSaveImage.Enabled = !capturing && _iris != null && _iris.Status == NBiometricStatus.Ok;
            //btnSaveTemplate.Enabled = !capturing && _subject != null && _subject.Status == NBiometricStatus.Ok;
            chbScanAutomatically.Enabled = !capturing;
            btnForce.Enabled = capturing && !chbScanAutomatically.Checked;
        }

        private void OnIrisCaptureCompleted(NBiometricTask task)
        {
            EnableIrisControls(false);
            NBiometricStatus status = task.Status;
            lblStatus.Text = status.ToString();

            // Check if extraction was canceled
            if (status == NBiometricStatus.Canceled) return;
            if (status != NBiometricStatus.Ok)
            {
                MessageBox.Show(string.Format("No fue posible extrar el template: {0}.", status), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblQuality.Text = string.Empty;
                _subject = null;
                _iris = null;
                EnableIrisControls(false);
            }
            else
            {
                lblQuality.Text = string.Format("Calidad: {0}", _iris.Objects[0].Quality);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateIrisScannerList();
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            if (_biometricClient.IrisScanner == null)
            {
                MessageBox.Show(@"Seleccione un escaner, por favor");
            }
            else
            {
                EnableIrisControls(true);
                lblStatus.Text = String.Empty;

                // Create iris
                _iris = new NIris { Position = rbRight.Checked ? NEPosition.Right : NEPosition.Left };

                // Set Manual capturing mode if not automatic selected
                if (!chbScanAutomatically.Checked)
                {
                    _iris.CaptureOptions = NBiometricCaptureOptions.Manual;
                }

                // Add iris to the subject and irisView
                _subject = new NSubject();
                _subject.Irises.Add(_iris);
                irisView.Iris = _iris;

                // Begin capturing
                NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.CreateTemplate, _subject);
                var performedTask = await _biometricClient.PerformTaskAsync(task);
                OnIrisCaptureCompleted(performedTask);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelScaning();
        }

        public void CancelScaning()
        {
            irisView.Iris = null;
            _biometricClient.Cancel();
        }

        private async void btnVerificariris_Click(object sender, EventArgs e)
        {
            EnableIrisControls(true);


            try
            {
                var personaResult = await BuscarIrisServicioWCF();

                if (personaResult.Identificado)
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("No se encontro coincidencias con la huella, intente otro dedo");
                }
            }
            catch (Exception)
            {
                Neurotec.Samples.Utils.ShowException(new Exception("Ocurrio un error al intentar utilizar el servicio web de biometria, favor de consultar el visor de eventos del servidor web"));
            }

            EnableIrisControls(false);

        }

        private async Task<BiometriaBusquedaServicio.PersonaInfo> BuscarIrisServicioWCF()
        {
            #region Buscar huella servicio WCF
            var template = Neurotec.Samples.Utils.ImageToByte(_subject.Irises[0].GetImage(false).ToBitmap());
            var templateBase64 = Convert.ToBase64String(template);

            var result = await servicioBusqueda.BuscarIrisAsync(templateBase64, _verificarHuellaInfo.PersonaIdentificar.id, ojo);

            return result;
            #endregion
        }
        #endregion

        private void rbLeft_CheckedChanged(object sender, EventArgs e)
        {
            ojo = 0;
        }

        private void rbRight_CheckedChanged(object sender, EventArgs e)
        {
            ojo = 1;
        }
    }
}
