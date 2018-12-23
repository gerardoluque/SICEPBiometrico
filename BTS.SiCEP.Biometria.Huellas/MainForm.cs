using BTS.SiCEP.Biometria.Huellas.Entidades;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Gui;
using Neurotec.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace BTS.SiCEP.Biometria.Huellas
{
    public partial class MainForm : Form
    {
        #region Private fields
        private const string TextDependent = "Extract text dependent features";
        private const string TextIndependent = "Extract text independent features";

        private NDeviceManager _deviceManager;
        private NBiometricClient _biometricClient;
        private NSubject _subject;
        private NSubject _subjectFace;
        private NFinger _subjectFinger;
        private NIris _iris;
        private NVoice _voice;
        private short ojo = 0;
        private bool _defaultExtractFeatures;

        private string[] _args = new string[] { };

        private VerificarHuellaInfo _verificarHuellaInfo = null;
        private List<BusquedaResultadoInfo> _busquedaResultados = new List<BusquedaResultadoInfo>() { };
        private BiometriaBusquedaServicio.BiometriaServicioClient servicioBusqueda = new BiometriaBusquedaServicio.BiometriaServicioClient();

        #region Variables WebCam
        private bool existeDispositivo = false;
        private FilterInfoCollection dispositivoDeVideo;
        private VideoCaptureDevice fuenteDeVideo = null;
        private Bitmap Imagen;
        private bool capFoto;
        #endregion

        #endregion

        public MainForm(string[] args)
        {
            InitializeComponent();

            if (args != null)
                _args = args;

            _biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Face | NBiometricType.Finger | NBiometricType.Iris | NBiometricType.Voice, FacesCheckIcaoCompliance = false };
            _biometricClient.InitializeAsync();

            ((CheckBox)nViewZoomSlider2.Controls[0].Controls[0]).Text = "Zoom Ancho";
            ((CheckBox)nViewZoomSlider1.Controls[0].Controls[0]).Text = "Zoom Ancho";
            ((CheckBox)nViewZoomSlider3.Controls[0].Controls[0]).Text = "Zoom Ancho";

            #region WebCam
            appParam = "c:\\temp\\temp.jpg";
            capFoto = false;

            BuscarDispositivosDeVideo();
            if (btnIniciar.Text == "Activar")
            {
                if (existeDispositivo)
                {

                    fuenteDeVideo = new VideoCaptureDevice(dispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                    fuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    fuenteDeVideo.Start();

                    btnIniciar.Text = "Detener";
                    cbxDispositivos.Enabled = false;
                    groupBox1.Text = dispositivoDeVideo[cbxDispositivos.SelectedIndex].Name.ToString();
                }
            }
            #endregion
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_args.Count() > 0)
            {
                EstablecerParametros();
            }
            else
            {
                MessageBox.Show("No se recibieron los parametros de busqueda");
            }

            if (!DesignMode)
            {
                extractFeatures.Items.Add(TextDependent);
                extractFeatures.Items.Add(TextIndependent);
                extractFeatures.SelectedIndex = 0;

                voiceView.Voice = null;

                _deviceManager = _biometricClient.DeviceManager;
                _deviceManager.Initialize();

                UpdateVoiceDeviceList();
            }

            Inicializar();
        }

        private void Inicializar()
        {
            #region Rostro
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

            #region Voz
            _defaultExtractFeatures = _biometricClient.VoicesExtractTextDependentFeatures;
            extractFeatures.SelectedItem = _defaultExtractFeatures ? TextDependent : TextIndependent;

            EnableVoiceControls(false);
                       
            nudPhraseId.Value = 0;
            SetVoiceSettings();
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
        #endregion

        #region Huella
        private void scannersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _biometricClient.FingerScanner = scannersListBox.SelectedItem as NFScanner;
        }

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

                try
                {
                    var performedTask = await _biometricClient.PerformTaskAsync(task);
                    OnEnrollCompleted(performedTask);
                }
                catch (Exception ex)
                {
                    Neurotec.Samples.Utils.ShowException(ex);
                }
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
            lblStatus.Text = @"Extrayendo ...";
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

            var personaResult = await BuscarFacialServicioWCF(_subjectFace.Faces[0].GetImage(false).ToBitmap());

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

        private async Task<BiometriaBusquedaServicio.PersonaInfo> BuscarFacialServicioWCF(Image foto)
        {
            var template = Neurotec.Samples.Utils.ImageToByte(foto);
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
                    MessageBox.Show("No se encontro coincidencias con el iris, intente de nuevo");
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

        private void rbLeft_CheckedChanged(object sender, EventArgs e)
        {
            ojo = 0;
        }

        private void rbRight_CheckedChanged(object sender, EventArgs e)
        {
            ojo = 1;
        }
        #endregion

        #region Voz
        private void SetVoiceSettings()
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

        public void StopVoiceCapturing()
        {
            _biometricClient.Cancel();
        }

        private void EnableVoiceControls(bool capturing)
        {
            var hasTemplate = !capturing && _subject != null && _subject.Status == NBiometricStatus.Ok;
            btnVozVerificar.Enabled = hasTemplate;
            btnGuardarVoz.Enabled = hasTemplate;
            btnVozIniciar.Enabled = !capturing;
            btnVozDetener.Enabled = capturing;
            btnVozRefrescar.Enabled = !capturing;
            gbOptions.Enabled = !capturing;
            lbMicrophones.Enabled = !capturing;
            chkBoxVozCapturarAut.Enabled = !capturing;
            btnVozForsar.Enabled = !chbCaptureAutomatically.Checked && capturing;
        }

        private async System.Threading.Tasks.Task OnCapturingVoiceCompletedAsync(NBiometricTask task)
        {
            NBiometricStatus status = task.Status;
            // If Stop button was pushed
            if (status == NBiometricStatus.Canceled) return;

            if (status != NBiometricStatus.Ok && status != NBiometricStatus.SourceError && status != NBiometricStatus.TooFewSamples)
            {
                // Since capture failed start capturing again
                _biometricClient.ForceStart();

                _voice.SoundBuffer = null;
                var performedTask = await _biometricClient.PerformTaskAsync(task);
                await OnCapturingVoiceCompletedAsync(performedTask);
            }
            else
            {
                EnableVoiceControls(false);
            }
        }

        private void btnVozRefrescar_Click(object sender, EventArgs e)
        {
            UpdateVoiceDeviceList();
        }

        private async void btnVozIniciar_Click(object sender, EventArgs e)
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

            _biometricClient.ForceStart();

            // Set voice capture from stream
            _voice = new NVoice { CaptureOptions = NBiometricCaptureOptions.Stream };
            if (!chbCaptureAutomatically.Checked) _voice.CaptureOptions |= NBiometricCaptureOptions.Manual;
            _subject = new NSubject();
            _subject.Voices.Add(_voice);
            voiceView.Voice = _voice;

            EnableVoiceControls(true);

            NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.Segment, _subject);

            var performedTask = await _biometricClient.PerformTaskAsync(task);

            await OnCapturingVoiceCompletedAsync(performedTask);
        }

        private void btnVozDetener_Click(object sender, EventArgs e)
        {
            StopVoiceCapturing();
            EnableVoiceControls(false);
        }

        private void btnVozForsar_Click(object sender, EventArgs e)
        {
            _biometricClient.ForceStart();
            btnForce.Enabled = false;
        }

        private async void btnVozVerificar_Click(object sender, EventArgs e)
        {
            EnableVoiceControls(true);

            try
            {
                var personaResult = await BuscarVozServicioWCF();

                if (personaResult.Identificado)
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("No se encontro coincidencias con la voz, intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                Neurotec.Samples.Utils.ShowException(new Exception("Ocurrio un error al intentar utilizar el servicio web de biometria, favor de consultar el visor de eventos del servidor web"));
            }

            EnableVoiceControls(false);
        }

        private void extractFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVoiceSettings();
        }

        private void lbMicrophones_SelectedIndexChanged(object sender, EventArgs e)
        {
            _biometricClient.VoiceCaptureDevice = lbMicrophones.SelectedItem as NMicrophone;
        }

        private void UpdateVoiceDeviceList()
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

        private async Task<BiometriaBusquedaServicio.PersonaInfo> BuscarVozServicioWCF()
        {
            #region Buscar voz en servicio WCF
            var vozBase64 = Convert.ToBase64String(_subject.Voices.FirstOrDefault(x=>x.SoundBuffer != null).SoundBuffer.Save().ToArray());

            var result = await servicioBusqueda.BuscarVozAsync(vozBase64, _verificarHuellaInfo.PersonaIdentificar.id);

            return result;
            #endregion
        }

        private async Task<BiometriaBusquedaServicio.PersonaInfo> BuscarVozServicioWCFTEST(string pathArchivo)
        {
            #region Buscar voz en servicio WCF
            var voice = new NVoice();
            voice.SoundBuffer = Neurotec.Sound.NSoundBuffer.FromFile(pathArchivo);

            var vozBase64 = Convert.ToBase64String(voice.SoundBuffer.Save().ToArray());

            var result = await servicioBusqueda.BuscarVozAsync(vozBase64, _verificarHuellaInfo.PersonaIdentificar.id);

            return result;
            #endregion
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                await BuscarVozServicioWCFTEST(openFileDialog.FileName);
            }
        }

        private void btnGuardarVoz_Click(object sender, EventArgs e)
        {
            if (saveVoiceFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllBytes(saveVoiceFileDialog.FileName, _subject.Voices.FirstOrDefault(x => x.SoundBuffer != null).SoundBuffer.Save().ToArray());
                }
                catch (Exception ex)
                {
                    Neurotec.Samples.Utils.ShowException(ex);
                }
            }
        }
        #endregion

        #region Rostro WebCam
        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            int i;
            for (i = 0; i < Dispositivos.Count; i++)
            {
                cbxDispositivos.Items.Add(Dispositivos[i].Name.ToString());
            }
            cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();

        }

        public bool BuscarDispositivosDeVideo()
        {
            dispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (dispositivoDeVideo.Count == 0)
            {
                existeDispositivo = false;
            }

            else
            {
                existeDispositivo = true;
                CargarDispositivos(dispositivoDeVideo);

            }

            return existeDispositivo;
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(fuenteDeVideo == null))
                if (fuenteDeVideo.IsRunning)
                {
                    fuenteDeVideo.SignalToStop();
                    fuenteDeVideo = null;
                }

        }

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Imagen = (Bitmap)eventArgs.Frame.Clone();
            EspacioCamara.Image = Imagen;
            if (capFoto)
                foto.Image = Imagen;

            capFoto = false;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text == "Activar")

            {
                if (existeDispositivo)
                {

                    fuenteDeVideo = new VideoCaptureDevice(dispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                    fuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    fuenteDeVideo.Start();

                    btnIniciar.Text = "Detener";
                    cbxDispositivos.Enabled = false;
                    groupBox1.Text = dispositivoDeVideo[cbxDispositivos.SelectedIndex].Name.ToString();
                }
            }
            else
            {
                if (fuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    btnIniciar.Text = "Activar";
                    cbxDispositivos.Enabled = true;

                }
            }
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            if (fuenteDeVideo.IsRunning)
            {
                //foto.Image = Imagen;
                capFoto = true;
                capturo = true;
            }
        }

        private void btnProp_Click(object sender, EventArgs e)
        {
            if (!(fuenteDeVideo == null))
                fuenteDeVideo.DisplayPropertyPage(IntPtr.Zero);
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            var personaResult = await BuscarFacialServicioWCF(foto.Image);

            if (personaResult.Identificado)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("No se encontro coincidencias con la imagen, intente de nuevo");
            }
        }
        #endregion

        private void tabBio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabBio.SelectedIndex == 0)
            {
                UpdateScannerList();
            }
            else if (tabBio.SelectedIndex == 1)
            {
                UpdateCameraList();
            }
            else if (tabBio.SelectedIndex == 2)
            {
                UpdateIrisScannerList(); 
            }
            else if (tabBio.SelectedIndex == 3)
            {
                UpdateVoiceDeviceList();
            }
        }
    }
}
