using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Enrolar;
using RealScanExtend;
using Oracle.DataAccess.Client;
using System.Threading;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.IO;

namespace Enrolar
{
    public partial class Form1 : Form
    {
        #region Variables
        string[] param;
        OracleConnection conn = null;

        int m_result = 0;
        int m_errorcode = 0;
        string m_errorMsg = " ";
        int deviceHandle = 0;
        int capturedImageWidth;
        int capturedImageHeight;
        IntPtr capturedImageData;
        bool m_prevStopped = true;
        int m_captureMode = 0;
        int m_slapType = 0;
        int m_fingerCount = 0;
        byte[][] m_pSeqCheckTargetImages = new byte[5][];
        int[] m_nSeqCheckTargetWidths = new int[5];
        int[] m_nSeqCheckTargetHeights = new int[5];
        int[] m_nSeqCheckTargetSlapTypes = new int[5];
        int m_numOfTargerFingers = 0;
        int m_numOfTargets;
        int m_nCustomCaptX;
        int m_nCustomCaptY;
        int m_nCustomCaptW;
        int m_nCustomCaptH;
        bool m_bCaptureModeSelected = false;
        int m_captureDir = 0;
        int m_minCount = 0;

        enum PrevMode
        {
            directDraw,
            callbackDraw,
            advCallbackDraw
        }

        enum callbackMode
        {
            none,
            save,
            segment,
            enlarge,
            saveNseg,
            seqCheck
        }



        private PrevMode _selectedPrevMode;
        private Thread autoCaptureThread = null;
        delegate void afterAutoCaptureCallback(int captureResult);
        #endregion

        public Form1(string[] args)
        {
            InitializeComponent();
            param = args;
        }

        private bool Init_SDK()
        {
            #region Init_SDK
            int numOfDevice = 0;
            RSSDKInfo sdkInfo = new RSSDKInfo();

            m_result = RS_SDK.RS_InitSDK(null, 0, ref numOfDevice);
            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                //MsgPanel.Text = m_errorMsg;
                MsgPanel.Text = "Error al inicializar SDK";
                return false;
            }

            m_result = RS_SDK.RS_GetSDKInfo(ref sdkInfo);
            DeviceList.Items.Clear();

            MsgPanel.Text = "Se inicializo SDK";

            for (int i = 0; i < numOfDevice; i++)
            {
                String deviceName = "Device ";
                deviceName += i;
                DeviceList.Items.Add(deviceName);
            }

            if (numOfDevice > 0)
            {
                DeviceList.SelectedIndex = 0;
            }
            return true;
            #endregion
        }

        private bool initDevice()
        {
            #region initDevice
            RSDeviceInfo deviceInfo = new RSDeviceInfo();

            m_result = RS_SDK.RS_InitDevice(DeviceList.SelectedIndex, ref deviceHandle);
            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                //MsgPanel.Text = m_errorMsg;
                MsgPanel.Text = "No se encontro lector";
                return false;
            }

            //AutoCalibrate.Checked = true;
            if (!m_prevStopped)
            {
                if (_selectedPrevMode == PrevMode.directDraw) RS_SDK.RS_StopViewWindow(deviceHandle);
            }
            m_prevStopped = true;

            //TimeoutTextBox.Text = Convert.ToString(0);
            //ReductionLevel.Text = Convert.ToString(100);

            //m_result = RS_SDK.RS_GetDeviceInfo(deviceHandle, ref deviceInfo);
            //if (m_result != RS_SDK.RS_SUCCESS)
            //{
            //    RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
            //    MsgPanel.Text = m_errorMsg;
            //    return false;
            //}

            //DeviceInfo.Text = System.Text.Encoding.ASCII.GetString(deviceInfo.productName);
            //DeviceID.Text = System.Text.Encoding.ASCII.GetString(deviceInfo.deviceID);
            //FirmwareInfo.Text = System.Text.Encoding.ASCII.GetString(deviceInfo.firmwareVersion);
            //FirmwareInfo.Text = System.Text.Encoding.ASCII.GetString(deviceInfo.firmwareVersion);
            //Hardwareinfo.Text = System.Text.Encoding.ASCII.GetString(deviceInfo.HardwareVersion);

            //InitDevice.Enabled = false;
            //ExitDevice.Enabled = true;

            //if (deviceInfo.deviceType != RS_SDK.RS_DEVICE_REALSCAN_F)
            //{
            //    ResetLCD.Enabled = false;
            //    DisplayLCD.Enabled = false;
            //}

            MsgPanel.Text = "El dispositivo se encuentra inicializado";
            return true;
            #endregion
        }

        private void exit_Device()
        {
            #region exit_Device
            if (!m_prevStopped)
            {
                if (_selectedPrevMode == PrevMode.directDraw)
                {
                    m_result = RS_SDK.RS_StopViewWindow(deviceHandle);
                    if (m_result != RS_SDK.RS_SUCCESS)
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                        return;
                    }
                }

                m_prevStopped = true;
            }

            m_result = RS_SDK.RS_ExitDevice(deviceHandle);

            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                MsgPanel.Text = m_errorMsg;
                return;
            }
            //CaptureMode.SelectedIndex = 0;
            //Callback.SelectedIndex = 0;

            //DeviceInfo.Text = "";
            //FirmwareInfo.Text = "";
            //DeviceID.Text = "";
            //FirmwareInfo.Text = "";
            //Hardwareinfo.Text = "";
            //ImageSize.Text = "";

            //InitSDK.Enabled = true;
            //InitDevice.Enabled = false;
            //ExitDevice.Enabled = false;
            //StartCapture.Enabled = false;
            //StopCapture.Enabled = false;
            //TakeManual.Enabled = false;
            //TakeAuto.Enabled = false;
            //ResetLCD.Enabled = false;
            //DisplayLCD.Enabled = false;

            //ResetLCD.Enabled = true;
            //DisplayLCD.Enabled = true;

            //MsgPanel.Text = "The device is disconnected successfully";
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Form1_Load
                //RSESDKInfo sdkInfo = new RSESDKInfo();
                switch (param[0])
                {
                    case "3":
                        this.Text = "Captura: Pulgares";
                        label1.Text = "Pulgares faltantes:";
                        clbPulgar.Visible = true;
                        clbDedo.Visible = false;
                        break;
                    case "4":
                        this.Text = "Captura: dedos mano izquierda";
                        label1.Text = "Dedos faltantes:";
                        clbPulgar.Visible = false;
                        clbDedo.Visible = true;
                        break;
                    case "5":
                        this.Text = "Captura: dedos mano derecha";
                        label1.Text = "Dedos faltantes:";
                        clbPulgar.Visible = false;
                        clbDedo.Visible = true;
                        break;
                    default:
                        this.Text = "Captura";
                        break;
                }


                if (Init_SDK() == false)
                    return;

                if (initDevice() == false)
                    return;


                //RealScanExtendSDK.RSE_InitSDK();
                //m_result = RealScanExtendSDK.RS_GetSDKInfo(ref sdkInfo);
                //RealScanExtendSDK.RSE_CompressWSQ("C:\\TEMP\\HUELLA\\INTERNO_7.BMP", null, 0.75, "C:\\TEMP\\HUELLA\\INTERNO_7.WSQ");

                _selectedPrevMode = PrevMode.directDraw;
                SetPreview();

                Take_Auto();
            #endregion
        }


        private void Take_Auto()
        {
            #region Take_Auto
            TakeAuto.Enabled = false;
            CaptureMode_SelectedIndexChanged(null, null);
            MsgPanel.Text = "Coloque los dedos sobre el lector";

            this.autoCaptureThread = new Thread(new ThreadStart(this.DoautoCapture));
            this.autoCaptureThread.Start();
            #endregion
        }

        private void CaptureMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region CaptureMode_SelectedIndexChanged
            int[] tmpCaptureModes = new int[15] {RS_SDK.RS_CAPTURE_DISABLED,RS_SDK.RS_CAPTURE_ROLL_FINGER,RS_SDK.RS_CAPTURE_FLAT_SINGLE_FINGER,
                                                RS_SDK.RS_CAPTURE_FLAT_TWO_FINGERS, RS_SDK.RS_CAPTURE_FLAT_LEFT_FOUR_FINGERS, RS_SDK.RS_CAPTURE_FLAT_RIGHT_FOUR_FINGERS,
                                                RS_SDK.RS_CAPTURE_FLAT_LEFT_PALM, RS_SDK.RS_CAPTURE_FLAT_RIGHT_PALM, RS_SDK.RS_CAPTURE_FLAT_SINGLE_FINGER_EX,
                                                RS_SDK.RS_CAPTURE_FLAT_TWO_FINGERS_EX, RS_SDK.RS_CAPTURE_FLAT_LEFT_SIDE_PALM, RS_SDK.RS_CAPTURE_FLAT_RIGHT_SIDE_PALM,
                                                RS_SDK.RS_CAPTURE_FLAT_LEFT_WRITERS_PALM, RS_SDK.RS_CAPTURE_FLAT_RIGHT_WRITERS_PALM, RS_SDK.RS_CAPTURE_FLAT_MANUAL};


            m_captureMode = Convert.ToInt16(param[0]);

            switch (m_captureMode)
            {
                case RS_SDK.RS_CAPTURE_FLAT_SINGLE_FINGER:
                case RS_SDK.RS_CAPTURE_FLAT_SINGLE_FINGER_EX:
                    m_slapType = RS_SDK.RS_SLAP_ONE_FINGER;
                    m_fingerCount = 1;
                    m_minCount = 1;
                    break;

                case RS_SDK.RS_CAPTURE_FLAT_TWO_FINGERS:
                case RS_SDK.RS_CAPTURE_FLAT_TWO_FINGERS_EX:
                    m_slapType = RS_SDK.RS_SLAP_TWO_THUMB;
                    m_fingerCount = 2;
                    m_minCount = 2;
                    break;

                case RS_SDK.RS_CAPTURE_FLAT_LEFT_FOUR_FINGERS:
                    m_slapType = RS_SDK.RS_SLAP_LEFT_FOUR;
                    m_fingerCount = 4;
                    m_minCount = 4;
                    break;

                case RS_SDK.RS_CAPTURE_FLAT_RIGHT_FOUR_FINGERS:
                    m_slapType = RS_SDK.RS_SLAP_RIGHT_FOUR;
                    m_fingerCount = 4;
                    m_minCount = 4;
                    break;

                default:
                    break;
            }

            int[] nCaptDir = new int[3] { RS_SDK.RS_CAPTURE_DIRECTION_DEFAULT, RS_SDK.RS_CAPTURE_DIRECTION_LEFT, RS_SDK.RS_CAPTURE_DIRECTION_RIGHT };

            m_result = RS_SDK.RS_SetCaptureModeWithDir(deviceHandle, m_captureMode, nCaptDir[m_captureDir], 0, true);
            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                MsgPanel.Text = m_errorMsg;
                //CaptureMode.SelectedIndex = 0;
                m_bCaptureModeSelected = false;
                return;
            }
            #endregion
        }

        private void DoautoCapture()
        {
            #region DoautoCapture
            int n;
            try
            {
                m_result = RS_SDK.RS_RemoveAllOverlay(deviceHandle);
                if (m_result != RS_SDK.RS_SUCCESS)
                {
                    if (MsgPanel.InvokeRequired)
                    {
                        afterAutoCaptureCallback callback = new afterAutoCaptureCallback(captureProcess);
                        try
                        {
                            this.Invoke(callback, m_result);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                    }
                    return;
                }

                if (clbDedo.Visible)
                {
                    n = 0;

                    for (int i = 0; i < 4; i++)
                        if (clbDedo.GetItemChecked(i))
                            n++;

                    m_minCount = m_minCount - n;

                    m_result = RS_SDK.RS_SetMinimumFinger(deviceHandle, m_minCount);
                    if (m_result != RS_SDK.RS_SUCCESS)
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                    }
                }
                else
                {
                    n = 0;

                    for (int i = 0; i < 2; i++)
                        if (clbPulgar.GetItemChecked(i))
                            n++;

                    m_minCount = m_minCount - n;

                    m_result = RS_SDK.RS_SetMinimumFinger(deviceHandle, m_minCount);
                    if (m_result != RS_SDK.RS_SUCCESS)
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                    }
                }

                m_result = RS_SDK.RS_TakeImageData(deviceHandle, 10000, ref capturedImageData, ref capturedImageWidth, ref capturedImageHeight);

                if (m_result != RS_SDK.RS_SUCCESS)
                {
                    if (capturedImageData != (IntPtr)0)
                    {
                        RS_SDK.RS_FreeImageData(capturedImageData);
                    }
                }

                if (MsgPanel.InvokeRequired)
                {
                    afterAutoCaptureCallback callback = new afterAutoCaptureCallback(captureProcess);
                    try
                    {
                        this.Invoke(callback, m_result);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                    MsgPanel.Text = m_errorMsg;
                }
            }
            catch (Exception ex)
            {
                return;
            }
            #endregion
        }

        private void captureProcess(int captureResult)
        {
            #region captureProcess
            if (captureResult == RS_SDK.RS_SUCCESS)
            {
                MsgPanel.Text = "Captura terminada";
                SaveSeqCheckTargetProcess(capturedImageData, capturedImageWidth, capturedImageHeight);
                TakeAuto.Enabled = true;
            }
            else
            {
                RS_SDK.RS_GetErrString(captureResult, ref m_errorMsg);
                //MsgPanel.Text = m_errorMsg;
                MsgPanel.Text = "Huellas no detectadas";
                MessageBox.Show("Baja calidad o dedo faltante, capture de nuevo.","Aviso");
                TakeAuto.Enabled = true;
                return;
            }


            int numOfFingers = 0;
            IntPtr[] ImageBuffer = new IntPtr[4];
            int[] ImageWidth = new int[4];
            int[] ImageHeight = new int[4];
            RSSlapInfoArray slapInfoA = new RSSlapInfoArray();

            if (SegmentCaptureProcess(capturedImageData, capturedImageWidth, capturedImageHeight, deviceHandle, ref slapInfoA, ref numOfFingers, ref ImageBuffer, ref ImageWidth, ref ImageHeight) == false)
            {
                if (capturedImageData != (IntPtr)0)
                {
                    RS_SDK.RS_FreeImageData(capturedImageData);
                }
                return;
            }
           
            SegmentSaveImageCaptureProcess(capturedImageData, capturedImageWidth, capturedImageHeight, numOfFingers, slapInfoA, ImageBuffer, ImageWidth, ImageHeight);

            for (int i = 0; i < 4; i++)
            {
                if (ImageBuffer[i] != (IntPtr)0)
                {
                    RS_SDK.RS_FreeImageData(ImageBuffer[i]);
                }
            }

            if (capturedImageData != (IntPtr)0)
            {
                RS_SDK.RS_FreeImageData(capturedImageData);
            }

            Close();
            #endregion
        }

        private void SaveSeqCheckTargetProcess(IntPtr imageData, int imageWidth, int imageHeight)
        {
            #region SaveSeqCheckTargetProcess
            if (m_slapType < RS_SDK.RS_SLAP_ONE_FINGER)
            {
                bool bIsOverlapped = false;
                int nOverlappedIndex = m_numOfTargets;
                //for (int i = 0; i < m_numOfTargets; i++)
                //{
                //    if (m_nSeqCheckTargetSlapTypes[i] == m_slapType)
                //    {
                //        bIsOverlapped = true;
                //        nOverlappedIndex = i;
                //        break;
                //    }
                //}

                if (bIsOverlapped == true)
                {
                    //Marshal.Copy(imageData, m_pSeqCheckTargetImages[nOverlappedIndex], 0, imageWidth * imageHeight);
                    //m_nSeqCheckTargetWidths[nOverlappedIndex] = imageWidth;
                    //m_nSeqCheckTargetHeights[nOverlappedIndex] = imageHeight;
                }
                else
                {
                    m_pSeqCheckTargetImages[m_numOfTargets] = new byte[imageWidth * imageHeight];
                    Marshal.Copy(imageData, m_pSeqCheckTargetImages[m_numOfTargets], 0, imageWidth * imageHeight);
                    m_nSeqCheckTargetWidths[m_numOfTargets] = imageWidth;
                    m_nSeqCheckTargetHeights[m_numOfTargets] = imageHeight;
                    m_nSeqCheckTargetSlapTypes[m_numOfTargets] = m_slapType;
                    m_numOfTargets++;
                    m_numOfTargerFingers += m_fingerCount;

                    //switch (m_slapType)
                    //{
                    //    case RS_SDK.RS_SLAP_TWO_THUMB:
                    //        seqTargetList.Items.Add("TWO THUMBS");
                    //        break;
                    //    case RS_SDK.RS_SLAP_LEFT_FOUR:
                    //        seqTargetList.Items.Add("LEFT FOUR FINGERS");
                    //        break;
                    //    case RS_SDK.RS_SLAP_RIGHT_FOUR:
                    //        seqTargetList.Items.Add("RIGHT FOUR FINGERS");
                    //        break;
                    //}
                }
            }
            #endregion
        }

        private bool SegmentCaptureProcess(IntPtr imageData, int imageWidth, int imageHeight, int deviceHandle, ref RSSlapInfoArray slapInfo,
                                           ref int numOfFingers, ref IntPtr[] ImageBuffer, ref int[] ImageWidth, ref int[] ImageHeight)
        {
            #region SegmentCaptureProcess
            RSSlapInfoArray slapInfoA = new RSSlapInfoArray();
            IntPtr slapInfoArray;

            int captureMode = 0;
            int captureOption = 0;
            int slapType = 1;

            for (int i = 0; i < 4; i++)
            {
                ImageBuffer[i] = (IntPtr)0;
                ImageWidth[i] = 0;
                ImageHeight[i] = 0;
            }

            int _size = Marshal.SizeOf(typeof(RSSlapInfoArray));
            slapInfoArray = Marshal.AllocHGlobal(_size);
            Marshal.StructureToPtr(slapInfoA, slapInfoArray, true);

            int fingerType = 0;
            int[] missingFingerArray = new int[] { 0, 0, 0, 0 };

            int n = 0;
            //if (m_captureDir != RS_SDK.RS_CAPTURE_DIRECTION_DEFAULT)
            //{
            //    int captureDir = RS_SDK.RS_CAPTURE_DIRECTION_DEFAULT;
            //    m_result = RS_SDK.RS_GetCaptureModeWithDir(deviceHandle, ref captureMode, ref captureDir, ref captureOption);
            //}
            //else
                m_result = RS_SDK.RS_GetCaptureMode(deviceHandle, ref captureMode, ref captureOption);

            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                MsgPanel.Text = m_errorMsg;
            }

            switch (captureMode)
            {
                case RS_SDK.RS_CAPTURE_FLAT_TWO_FINGERS:
                case RS_SDK.RS_CAPTURE_FLAT_TWO_FINGERS_EX:
                    slapType = RS_SDK.RS_SLAP_TWO_FINGER;
                    break;
                case RS_SDK.RS_CAPTURE_FLAT_SINGLE_FINGER:
                case RS_SDK.RS_CAPTURE_FLAT_SINGLE_FINGER_EX:
                    slapType = RS_SDK.RS_SLAP_ONE_FINGER;
                    break;
                case RS_SDK.RS_CAPTURE_FLAT_LEFT_FOUR_FINGERS:
                    slapType = RS_SDK.RS_SLAP_LEFT_FOUR;
                    for (int i = 0; i < 4; i++)
                    {
                        if (clbDedo.GetItemChecked(i))
                            missingFingerArray[n++] = RS_SDK.RS_FGP_LEFT_LITTLE - i;
                    }
                    fingerType = RS_SDK.RS_FGP_LEFT_LITTLE;
                    break;
                case RS_SDK.RS_CAPTURE_FLAT_RIGHT_FOUR_FINGERS:
                    slapType = RS_SDK.RS_SLAP_RIGHT_FOUR;
                    for (int i = 0; i < 4; i++)
                    {
                        if (clbDedo.GetItemChecked(i))
                            missingFingerArray[n++] = i + RS_SDK.RS_FGP_RIGHT_INDEX;
                    }
                    fingerType = RS_SDK.RS_FGP_RIGHT_INDEX;
                    break;
                default:
                    MsgPanel.Text = "Cannot segment in this mode";
                    return false;
            }

            m_result = RS_SDK.RS_Segment4(imageData, imageWidth, imageHeight, slapType, ref numOfFingers, ref slapInfoArray, ref ImageBuffer[0], ref ImageWidth[0],
                                                ref ImageHeight[0], ref ImageBuffer[1], ref ImageWidth[1], ref ImageHeight[1], ref ImageBuffer[2], ref ImageWidth[2],
                                                ref ImageHeight[2], ref ImageBuffer[3], ref ImageWidth[3], ref ImageHeight[3]);

            if (m_result != RS_SDK.RS_SUCCESS)
            {
                if (m_result == RS_SDK.RS_ERR_SEGMENT_FEWER_FINGER)
                {
                    if (m_minCount != numOfFingers)
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                        return false;
                    }
                }
                else
                {
                    RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                    MsgPanel.Text = m_errorMsg;
                    return false;
                }
            }

            MsgPanel.Text = "Calidad:";

            slapInfoA = (RSSlapInfoArray)Marshal.PtrToStructure(slapInfoArray, typeof(RSSlapInfoArray));
            if (slapInfoArray != (IntPtr)0)
            {
                RS_SDK.RS_FreeImageData(slapInfoArray);
            }

            int overlayHandle = -1;
            int j = 0;
            for (int i = 0; i < numOfFingers; i++)
            {
                if (slapInfoA.RSSlapInfoA[i].fingerType == RS_SDK.RS_FGP_UNKNOWN)
                {
                    if (slapType == RS_SDK.RS_SLAP_LEFT_FOUR)
                    {
                        while (fingerType == missingFingerArray[j])
                        {
                            fingerType--;
                            j++;
                        }

                        slapInfoA.RSSlapInfoA[i].fingerType = fingerType--;
                    }
                    else if (slapType == RS_SDK.RS_SLAP_RIGHT_FOUR)
                    {
                        while (fingerType == missingFingerArray[j])
                        {
                            fingerType++;
                            j++;
                        }

                        slapInfoA.RSSlapInfoA[i].fingerType = fingerType++;
                    }
                }

                slapInfo = slapInfoA;
                Enrolar.
                RSOverlayQuadrangle quad = new RSOverlayQuadrangle();
                quad.pos = new RSPoint[4];
                quad.color = 0x00ff0000;

                RSRect rect = new RSRect();
                RS_SDK.GetClientRect(PreviewWindow.Handle, ref rect);

                quad.pos[0].x = slapInfoA.RSSlapInfoA[i].fingerPosition[0].x * rect.right / imageWidth;
                quad.pos[0].y = slapInfoA.RSSlapInfoA[i].fingerPosition[0].y * rect.bottom / imageHeight;
                quad.pos[1].x = slapInfoA.RSSlapInfoA[i].fingerPosition[1].x * rect.right / imageWidth;
                quad.pos[1].y = slapInfoA.RSSlapInfoA[i].fingerPosition[1].y * rect.bottom / imageHeight;
                quad.pos[2].x = slapInfoA.RSSlapInfoA[i].fingerPosition[3].x * rect.right / imageWidth;
                quad.pos[2].y = slapInfoA.RSSlapInfoA[i].fingerPosition[3].y * rect.bottom / imageHeight;
                quad.pos[3].x = slapInfoA.RSSlapInfoA[i].fingerPosition[2].x * rect.right / imageWidth;
                quad.pos[3].y = slapInfoA.RSSlapInfoA[i].fingerPosition[2].y * rect.bottom / imageHeight;

                m_result = RS_SDK.RS_AddOverlayQuadrangle(deviceHandle, ref quad, ref overlayHandle);
                m_result = RS_SDK.RS_ShowOverlay(overlayHandle, true);
                if (m_result != RS_SDK.RS_SUCCESS)
                {
                    MsgPanel.Text = "Cannot overlay for quadrangle" + m_result;
                    return false;
                }
            }

            for (int i = 0; i < numOfFingers; i++)
            {
                MsgPanel.Text += "[" + slapInfoA.RSSlapInfoA[i].fingerType + ":" + slapInfoA.RSSlapInfoA[i].imageQuality + "] ";
            }
            return true;
            #endregion
        }

        private void SegmentSaveImageCaptureProcess(IntPtr imageData, int imageWidth, int imageHeight, int numOfFingers, RSSlapInfoArray slapInfo, IntPtr[] ImageBuffer, int[] ImageWidth, int[] ImageHeight)
        {
            #region SegmentSaveImageCaptureProcess
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = ".:\\";
            saveDialog.FilterIndex = 1;
            string bmp;
            string wsq;
            int result;
            byte[] huella = null;
            byte[] wsqBuffer = null;
            int dedo = 0;
            int tamano = 0;
            byte[] template = null;
            int[] dedoPerdido = new int[] { 0, 0, 0, 0 };
            int[] pulgarPerdido = new int[] { 0, 0 };
            int n = 0;
            try
            {
                #region genera arreglo para identificar dedo sin huella
                switch (param[0])
                    {
                        case "3": //PULGARES
                            for (int i = 0; i < 2; i++)
                            {
                                if (clbPulgar.GetItemChecked(i))
                                    switch (i)
                                    {
                                        case 0:
                                            dedoPerdido[0] = 0;
                                            break;
                                        case 1:
                                            dedoPerdido[1] = 0;
                                            break;
                                            break;
                                    }
                                else
                                    switch (i)
                                    {
                                        case 0:
                                            dedoPerdido[0] = 6;
                                            break;
                                        case 1:
                                            dedoPerdido[1] = 1;
                                            break;
                                    }
                            }
                            break;
                        case "4"://4 DEDOS MANO IZQUIERDA
                            for (int i = 0; i < 4; i++)
                            {
                                if (clbDedo.GetItemChecked(i))
                                    switch (i)
                                    {
                                        case 0:
                                            dedoPerdido[0] = 0;
                                            break;
                                        case 1:
                                            dedoPerdido[1] = 0;
                                            break;
                                        case 2:
                                            dedoPerdido[2] = 0;
                                            break;
                                        case 3:
                                            dedoPerdido[3] = 0;
                                            break;
                                    }
                                else
                                    switch (i)
                                    {
                                        case 0:
                                            dedoPerdido[0] = 10;
                                            break;
                                        case 1:
                                            dedoPerdido[1] = 9;
                                            break;
                                        case 2:
                                            dedoPerdido[2] = 8;
                                            break;
                                        case 3:
                                            dedoPerdido[3] = 7;
                                            break;
                                    }
                            }
                            break;
                        case "5"://4 DEDOS MANO DERECHA
                            for (int i = 0; i < 4; i++)
                            {
                                if (clbDedo.GetItemChecked(i))
                                    switch (i)
                                    {
                                        case 0:
                                            dedoPerdido[3] = 0;
                                            break;
                                        case 1:
                                            dedoPerdido[2] = 0;
                                            break;
                                        case 2:
                                            dedoPerdido[1] = 0;
                                            break;
                                        case 3:
                                            dedoPerdido[0] = 0;
                                            break;
                                    }
                                else
                                    switch (i)
                                    {
                                        case 0:
                                            dedoPerdido[3] = 5;
                                            break;
                                        case 1:
                                            dedoPerdido[2] = 4;
                                            break;
                                        case 2:
                                            dedoPerdido[1] = 3;
                                            break;
                                        case 3:
                                            dedoPerdido[0] = 2;
                                            break;
                                    }
                            }
                            break;
                        default:
                            break;
                    }
                #endregion


                //RS_SDK.RS_SaveBitmap(imageData, imageWidth, imageHeight, param[1] + param[2] + ".bmp");
                //if (m_result != RS_SDK.RS_SUCCESS)
                //{
                //    RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                //    MsgPanel.Text = m_errorMsg;
                //}

                conn = new OracleConnection(Conexion(param[3]));
                conn.Open();

                for (int i = 0; i < numOfFingers; i++)
                {
                    dedo = 0;
                    while (dedo == 0)
                    {
                        dedo = dedoPerdido[n];
                        n++;
                    }

                    bmp = param[1] + param[2] + "_" + dedo + ".bmp";
                    wsq = param[1] + param[2] + "_" + dedo + ".wsq";


                    result = RS_SDK.RS_SaveBitmap(ImageBuffer[i], ImageWidth[i], ImageHeight[i], bmp);
                    //result = RS_SDK.RS_EncodeWSQ(ImageBuffer[i], ImageWidth[i], ImageHeight[i], 0.75, ref wsqBuffer, ref tamano);
                    //result = RealScanExtendSDK.RSE_CompressWSQ(bmp, null, 0.75, wsq);

                    FileStream fs = new FileStream(bmp, FileMode.Open, FileAccess.Read);
                    huella = new byte[fs.Length];
                    fs.Read(huella, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();

                    //result = RS_SDK.RS_SaveBitmapMem(ImageBuffer[i], ImageWidth[i], ImageHeight[i], huella);
                   
                    template = new byte[ImageWidth[i] * ImageHeight[i]];
                    Marshal.Copy(ImageBuffer[i], template, 0, ImageWidth[i] * ImageHeight[i]);

                    RegistraHuella(dedo, huella, template);

                    File.Delete(bmp);

                    //result = RealScanExtendSDK.RSE_CompressWSQ(bmp, null, 2.25, wsq);
                    //result = RealScanExtendSDK.RSE_CompressWSQBuffer(bmp, null, 0.75, memwsq, tamano);

                    if (m_result != RS_SDK.RS_SUCCESS)
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                    }
                }

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MsgPanel.Text = ex.Message;
            }
            #endregion
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

        public void RegistraHuella(int dedo, byte[] imageData, byte[] templete)
        {
            #region RegistraHuella
            bool existeRegistro;
            string select = " SELECT 1 FROM BTS.HUELLA WHERE ESTADO = " + param[4] + " AND MUNICIPIO = " + param[5] + " AND CERESO = '" + param[6] + "' AND ANO = " + param[7] + " AND FOLIO = " + param[8] + " AND DEDO = " + dedo.ToString();
            string insert = " INSERT INTO BTS.HUELLA(ESTADO, MUNICIPIO, CERESO, ANO, FOLIO, DEDO, HUELLAIMAGEN, TEMPLATE) VALUES (" + param[4] + "," + param[5] + ",'" + param[6] + "'," + param[7] + "," + param[8] + "," + dedo.ToString() + ", :BlobParameter, :BlobParameter2 )";
            //string update = " select docto from bts.ingreso_docto_pdf where pdf = ";

            try
            {
                #region select
                OracleCommand cmdSelect = new OracleCommand(select, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    existeRegistro = true;
                else
                    existeRegistro = false;
                #endregion

                if (existeRegistro == false)
                {
                    #region insert
                    OracleParameter blobParameter = new OracleParameter();
                    OracleParameter blobParameter2 = new OracleParameter();

                    blobParameter.OracleDbType = OracleDbType.Blob;
                    blobParameter.ParameterName = "BlobParameter";
                    blobParameter.Value = imageData;

                    blobParameter2.OracleDbType = OracleDbType.Blob;
                    blobParameter2.ParameterName = "BlobParameter2";
                    blobParameter2.Value = templete;

                    OracleCommand cmdInsert = new OracleCommand(insert, conn);

                    //We are passing Name and Blob byte data as Oracle parameters.  CARGAR TEMPLATE
                    cmdInsert.Parameters.Add(blobParameter);
                    cmdInsert.Parameters.Add(blobParameter2);

                    //Open connection and execute insert query.
                    cmdInsert.ExecuteNonQuery();
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MsgPanel.Text = ex.Message;

            }
            #endregion
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Form1_FormClosing
            exit_Device();
            #endregion
        }

        private bool SetPreview()
        {
            #region SetPreview
            switch (this._selectedPrevMode)
            {
                case PrevMode.directDraw:
                    RSRect rect = new RSRect();
                    RS_SDK.GetClientRect(PreviewWindow.Handle, ref rect);

                    m_result = RS_SDK.RS_SetViewWindow(this.deviceHandle, PreviewWindow.Handle, rect, false);
                    if (m_result != RS_SDK.RS_SUCCESS)
                    {
                        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                        MsgPanel.Text = m_errorMsg;
                        return false;
                    }

                    m_prevStopped = false;

                    //ClearAllOverlays.Enabled = true;
                    //DrawOverlay.Enabled = true;
                    PreviewWindow.Invalidate();
                    PreviewWindow.Show();
                    break;
                //case PrevMode.callbackDraw:
                //    m_result = RS_SDK.RS_RegisterPreviewCallback(deviceHandle, previewCallback);
                //    if (m_result != RS_SDK.RS_SUCCESS)
                //    {
                //        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                //        MsgPanel.Text = m_errorMsg;
                //    }
                //    break;
                //case PrevMode.advCallbackDraw:
                //    m_result = RS_SDK.RS_RegisterAdvPreviewCallback(deviceHandle, advPreviewCallback);
                //    if (m_result != RS_SDK.RS_SUCCESS)
                //    {
                //        RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                //        MsgPanel.Text = m_errorMsg;
                //    }
                //    break;
                default:
                    break;
            }
            return true;
            #endregion
        }

        private void clbDedo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region clbDedo_SelectedIndexChanged
            int n = 0;

            for (int i = 0; i < 4; i++)
                if (clbDedo.GetItemChecked(i))
                    n++;

            m_minCount = 4 - n;

            m_result = RS_SDK.RS_SetMinimumFinger(deviceHandle, m_minCount);
            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                MsgPanel.Text = m_errorMsg;
            }
            #endregion 
        }

        private void clbPulgar_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region clbPulgar_SelectedValueChanged
            int n = 0;

            for (int i = 0; i < 2; i++)
                if (clbPulgar.GetItemChecked(i))
                    n++;

            m_minCount = 2 - n;

            m_result = RS_SDK.RS_SetMinimumFinger(deviceHandle, m_minCount);
            if (m_result != RS_SDK.RS_SUCCESS)
            {
                RS_SDK.RS_GetErrString(m_result, ref m_errorMsg);
                MsgPanel.Text = m_errorMsg;
            }
            #endregion 
        }

        private void TakeAuto_Click(object sender, EventArgs e)
        {
            Take_Auto();
        }

    }
}
