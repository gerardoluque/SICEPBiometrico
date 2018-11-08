using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CrossMatch.Biometrics.Utils;
using System.IO;
using System.Media;
using CrossMatch.BioBaseDotNet;
using System.Xml;


namespace BioBaseDotNetDemo
{
    public partial class Form1 : Form
    {
        Dictionary<DeviceCategory, BioDeviceCollector> m_Collectors = new Dictionary<DeviceCategory, BioDeviceCollector>();
        SoundPlayer m_SoundPlayer;
        string[] param;

        enum CapturaOjo
        {
            Ambos,
            Derecho,
            Izquierdo
        };

        public Form1(string[] args)
        {
            InitializeComponent();

            m_SoundPlayer = new SoundPlayer(Properties.Resources.blip_blip);
            m_SoundPlayer.LoadAsync();
            param = args;
            EnableControls();
        }

        # region Properties
        /// <summary>
        /// the device ID for the current selection in the devices list box
        /// </summary>
        string DeviceId
        {
            get
            {
                string deviceId = string.Empty;
                if (listBoxDevices.SelectedItem != null)
                    deviceId = listBoxDevices.SelectedItem.ToString();
                return deviceId;
            }
        }

        DeviceCategory SelectedDeviceCategory
        {
            get
            {
                if (listBoxDeviceCategory.Items.Count == 0 || listBoxDeviceCategory.SelectedItem == null)
                    // Default to IScan Essentials...
                    return DeviceCategory.IScanEssentials;

                DeviceCategory category = (DeviceCategory)Enum.Parse(typeof(DeviceCategory), listBoxDeviceCategory.SelectedItem.ToString());

                return category;
            }
        }

        BioDeviceCollector SelectedDeviceCollector
        {
            get
            {
                BioDeviceCollector collector = null;
                try
                {
                    DeviceCategory category = SelectedDeviceCategory;
                    if (!m_Collectors.TryGetValue(category, out collector))
                    {
                        return null;
                    }
                }
                catch (BioBaseException ex)
                {
                    ShowBioBaseError(ex);
                }

                return collector;
            }
        }

        void collector_DeviceCountChanged(object sender, DeviceCountEventArgs e)
        {
            string msg = string.Format("Device Count Changed: {0}", e.Count.ToString());
            LogEvent(msg);

            InitializeDeviceCatetory();

        }

        void collector_Warning(object sender, BioBaseWarningEventArgs e)
        {
            MessageBox.Show("BioBase Warning: " + e.Message);
        }

        /// <summary>
        /// the BioDevice object for the currently selection in the devices list box
        /// </summary>
        BioDevice SelectedDevice
        {
            get
            {
                if (DeviceId.Length == 0 || SelectedDeviceCollector == null || !SelectedDeviceCollector.Devices.ContainsKey(DeviceId))
                    return null;

                return SelectedDeviceCollector.Devices[DeviceId];
            }
        }
        /// <summary>
        /// Check if latent device
        /// </summary>
        bool SelectedDeviceLatent
        {
            get
            {
                if (DeviceId.Length == 0 || SelectedDeviceCollector == null || !SelectedDeviceCollector.Devices.ContainsKey(DeviceId))
                    return false;

                return DeviceId.EndsWith("L");
            }
        }
        #endregion

        # region Device Events
        void device_Disconnected(object sender, EventArgs e)
        {
            LogEvent("Disconnected event");

            BioDevice device = (BioDevice)sender;
            UnloadDevice(device, true);

            listBoxDevices.Enabled = true;
            listBoxDevices.Items.Remove(device.DeviceId);

            EnableControls();
        }

        void device_DataAvailable(object sender, DataAvailableEventArgs e)
        {
            #region device_DataAvailable
            LogEvent("Data available event");

            SaveDataAvailable(e);

            byte[] bioData = e.GetBiometricData();

            if (bioData.Length > 0)
            {
                CmtIris cmtIris = null;
                try
                {
                    // use the CmtIris object to pull pieces of data from the IIR
                    cmtIris = new CmtIris(bioData);
                }
                catch (BioBaseException ex)
                {
                    ShowBioBaseError(ex);
                }

                BiometricPosition position = EquivalenciaOjo(); //(BiometricPosition)TypeDescriptor.GetConverter(typeof(BiometricPosition)).ConvertFromString(comboBoxBiometricPosition.SelectedItem.ToString());
                Bitmap imgRight = null;
                Bitmap imgLeft = null;
                switch (position)
                {
                    case BiometricPosition.IrisBoth:
                        imgRight = cmtIris.GetBitmap(IrisPosition.Right);
                        imgRight.Save(param[1], ImageFormat.Bmp);
                        
                        imgLeft = cmtIris.GetBitmap(IrisPosition.Left);
                        imgLeft.Save(param[0], ImageFormat.Bmp);

                        break;
                    case BiometricPosition.IrisLeft:
                        imgLeft = cmtIris.GetBitmap(IrisPosition.Left);
                        imgLeft.Save(param[0], ImageFormat.Bmp);
                        break;
                    case BiometricPosition.IrisRight:
                        imgRight = cmtIris.GetBitmap(IrisPosition.Right);
                        imgRight.Save(param[1], ImageFormat.Bmp);
                        break;
                }
            }

            BioDevice device = (BioDevice)sender;

            if (SelectedDeviceCategory == DeviceCategory.MobileEssentials)
            {
                InitializeDeviceCatetory();
            }

            if (e.Status != BioBaseError.BIOB_SUCCESS)
            {
                string msg = string.Format("Data Available indicated the following warning or error code: {0}", e.Status.ToString());
                MessageBox.Show(this, msg, "Data Status");
            }

            EnableControls();
            #endregion
        }

        void device_AcquisitionComplete(object sender, EventArgs e)
        {
            m_SoundPlayer.Play();
            LogEvent("Acquire complete event");
            EnableControls();
        }

        void device_AcquistionStart(object sender, EventArgs e)
        {
            LogEvent("Acquire start event");
        }

        void device_Preview(object sender, DataAvailableEventArgs e)
        {
            #region device_Preview
            Byte[] bioData = e.GetBiometricData();
            if (e.DataFormat == DataFormat.IIR)
            {
                CmtIris cmtIris;
                cmtIris = new CmtIris(bioData);
                if (bioData.Length != 0)
                {
                    IrisPosition which_eye = cmtIris.GetEyePosition();
                    // LogEvent("Preview event: " + which_eye.ToString());   // generates too many previews in the log

                    // We have valid eye in IIR record.
                    // TODO: Set AnnotatedEye to IrisPosition.Left or IrisPosition.Right
                    //       to annotated/skip the eye during normal capture.
                    IrisPosition AnnotatedEye = IrisPosition.Unknown;
                    if (which_eye == AnnotatedEye)
                    {
                        SelectedDevice.ForceCapture();     // skip to next eye
                    }

                    UpdateLatentSettings();

                }
                cmtIris.Dispose();
            }
            //LogEvent( "Preview event" ); // generates too many previews in the log

            //uncommenting the line below will pop up a viewer with the preview image data
            //ShowImage( e.ImageData, e.Width, e.Height );
            #endregion
        }

        void SelectedDevice_UserInput(object sender, UserInputEventArgs e)
        {
            LogEvent("UserInput:" + e.UserInput + " event");
        }

        void SelectedDevice_OutputCommandCompleted(object sender, OutputCommandCompletedEventArgs e)
        {
            LogEvent("OutputCommandComplete:" + e.OutputData.TransactionID.ToString() + " event");

        }

        void SelectedDevice_LiveState(object sender, LiveStateEventArgs e)
        {
            LogEvent("LiveState:" + e.ValidLiveState.ToString() + " event");
        }

        void SelectedDevice_BiometricObjectPresent(object sender, BiometricObjectPresentEventArgs e)
        {
            LogEvent("ObjectPresent:" + e.DeviceDectionAreaState.ToString() + " event");
        }

        void SelectedDevice_Connected(object sender, EventArgs e)
        {
            BioDevice device = (BioDevice)sender;

            if (!listBoxDevices.Items.Contains(device.DeviceId))
                listBoxDevices.Items.Add(((BioDevice)sender).DeviceId);

            EnableControls();
            RefreshConnectedEvents(device); // make sure we are listening for both connected and disconnected events again
            LogEvent("Connected event");
        }

        void SelectedDevice_InitProgress(object sender, InitProgressEventArgs e)
        {
            float i = e.ProgressValue * 100.0f;
            LogEvent("InitProgress:" + i.ToString() + "% event");
        }

        void SelectedDevice_BiometricObjectCount(object sender, ObjectCountEventArgs e)
        {
            LogEvent("Count:" + e.ObjectCountCode.ToString() + " event");
        }

        void SelectedDevice_BiometricObjectQuality(object sender, ObjectQualityEventArgs e)
        {
            string quality = string.Empty;

            // ISE: Right eye in [0], Left eye in [1]
            int i = 0;
            foreach (ObjectQualityCode code in e.QualityCodeList)
            {
                string msg = string.Format("  [{0}]: {1}", i, code.ToString());
                quality += msg;
                i++;
            }

            LogEvent("Biometric Object Quality:" + quality + " event");
        }
        #endregion

        # region Control Events
        private void buttonOpenDevice_Click(object sender, EventArgs e)
        {
            #region buttonOpenDevice_Click
            Cursor origCursor = Cursor.Current;
            DeviceCategory category = SelectedDeviceCategory;
            try
            {
                if (SelectedDevice == null)
                    return;

                Cursor.Current = Cursors.WaitCursor;

                // setup the event delegates
                SelectedDevice.InitProgress += new InitProgressEventHandler(SelectedDevice_InitProgress);
                SelectedDevice.AcquistionStart += new EventHandler(device_AcquistionStart);
                SelectedDevice.AcquisitionComplete += new EventHandler(device_AcquisitionComplete);
                SelectedDevice.Preview += new DataAvailableEventHandler(device_Preview);
                SelectedDevice.BiometricObjectQuality += new ObjectQualityEventHandler(SelectedDevice_BiometricObjectQuality);
                SelectedDevice.BiometricObjectCount += new ObjectCountEventHandler(SelectedDevice_BiometricObjectCount);
                SelectedDevice.DataAvailable += new DataAvailableEventHandler(device_DataAvailable);
                SelectedDevice.BiometricObjectPresent += new BiometricObjectPresentEventHandler(SelectedDevice_BiometricObjectPresent);
                SelectedDevice.LiveState += new LiveStateEventHandler(SelectedDevice_LiveState);
                SelectedDevice.OutputCommandCompleted += new OutputCommandCompletedEventHandler(SelectedDevice_OutputCommandCompleted);
                SelectedDevice.UserInput += new UserInputEventHandler(SelectedDevice_UserInput);

                RefreshConnectedEvents(SelectedDevice);

                SelectedDevice.Open();

                LayoutVisualizers();

                // each device has one or more visualizers, create a window control on which
                // biobase will draw "live" images during acquistion, then assign that control
                // to the visualizer
                foreach (string key in SelectedDevice.Visualizers.Keys)
                {
                    // add a group box just for labeling and calculating sizes for the visualizer controls
                    GroupBox groupBox = new GroupBox();
                    groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    groupBox.Text = key.Replace("Wnd", ""); // remove the Wnd from the visualizer name, just for cosmetics
                    groupBox.Resize += new EventHandler(groupBox_Resize);

                    // this panel control will be drawn on the the device is acquiring
                    //Panel panel = new Panel();
                    //panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    //panel.BackColor = System.Drawing.Color.White;
                    //panel.Location = new Point( 10, 15 );

                    ImageCtrl pictureBox = new ImageCtrl();
                    pictureBox.BackColor = System.Drawing.Color.White;
                    pictureBox.Location = new Point(10, 15);
                    pictureBox.Tag = key;

                    groupBox.Controls.Add(pictureBox);
                    tableLayoutPanel1.Controls.Add(groupBox);




                    SelectedDevice.Visualizers[key].DeviceControl = pictureBox;
                    //SelectedDevice.Visualizers[key].DeviceControl.
                }



                if (category == DeviceCategory.IScanEssentials)
                {
                    if (!SelectedDeviceLatent)
                    {
                        /*******************************************************************************
                        * Uncomment the following lines below if you desire to allow manual capture of non iris images
                        *******************************************************************************/
                        /** Enable Manual capture ****
                        SelectedDevice.SetProperty("MANUAL_CAPTURE_ENABLE", "TRUE");
                        ** Enable Manual capture ****/

                        /*******************************************************************************
                         * Uncomment the following lines below if you desire to turn off image compensation of iris images
                        *******************************************************************************/
                        /** Enable image compensation ****
                        SelectedDevice.SetProperty("IMAGE_COMPENSATION", "FALSE");
                        ** Enable image compensation ****/

                        /*******************************************************************************
                         * Uncomment the following lines below if you desire to acquire a bitmap image of 480x480 (width x height)
                         * Also, don't forget to resize the preview left and right iris boxes to accomodation the new image size.
                         * The file needs to accomodate then new image dimensions. The file to edit is IScanMFCDemo.rc form IDD_FORMVIEW Dialog.
                        *******************************************************************************/
                        /** ADJUST IMAGE SIZE****
                        SelectedDevice.SetProperty("IMAGE_WIDTH", "480");
                        SelectedDevice.SetProperty("IMAGE_HEIGHT", "480");
                        ** ADJUST IMAGE SIZE****/
                    }

                }

                // match the auto capture checkbox to the setting on the device
                SetAutoCaptureCheckbox();

                LayoutVisualizers();
                listBoxDevices.Enabled = false;



                /////////////////////////////////////////////////////////////////////////
                // The following code is optional and is here to show how to parse 
                // DeviceProperties data. 
                // The first option is to parse the XML data.
                // The second option is to use the ProductIdentifier
                // 
                // the lines below are just to test that we can get to the properties xml
                /////////////////////////////////////////////////////////////////////////

                // Optional #1: reading and parsing Device Properties XML data
                try
                {
                    string propertiesXml = SelectedDevice.DeviceProperties.PropertiesXml;
                    // Get XML Document object
                    XmlDocument XmlDoc = new XmlDocument();
                    XmlDoc.LoadXml(propertiesXml);

                    // Get the node with "ApiProperties" 
                    XmlNodeList deviceNodes = XmlDoc.SelectNodes("//DeviceProperties");
                    LogEvent("DeviceProperties:");
                    // Get and log each node name and value
                    foreach (XmlNode root in deviceNodes)
                    {
                        if (root.HasChildNodes)
                        {
                            for (int i = 0; i < root.ChildNodes.Count; i++)
                            {
                                string msg = string.Format("\t {0} = {1}", root.ChildNodes[i].Name.ToString(), root.ChildNodes[i].InnerText.Trim(new char[] { ' ', '\r', '\n', '\t' }).ToString());
                                LogEvent(msg);
                            }
                        }
                    }
                }
                catch (BioBaseException ex)
                {
                    ShowBioBaseError(ex);
                }

                // Optional #2: use the SelectedDevice object properties
                string msg2 = string.Format("Device {0} opened", SelectedDevice.DeviceId.ToString());
                LogEvent(msg2);

                msg2 = string.Format("\t IBIA Device ID:{0}", SelectedDevice.ProductIdentifier.IbiaDeviceId);
                LogEvent(msg2);
                msg2 = string.Format("\t IBIA Vendor ID:{0}", SelectedDevice.ProductIdentifier.IbiaVendorId);
                LogEvent(msg2);
                msg2 = string.Format("\t IBIA Version:{0}", SelectedDevice.ProductIdentifier.IbiaVersion);
                LogEvent(msg2);
                msg2 = string.Format("\t Model:{0}", SelectedDevice.ProductIdentifier.ProductModel);
                LogEvent(msg2);


            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            EnableControls();
            Cursor.Current = origCursor;
            #endregion
        }


        private void buttonCloseDevice_Click(object sender, EventArgs e)
        {
            #region buttonCloseDevice_Click
            Cursor origCursor = Cursor.Current;
            try
            {
                if (SelectedDevice == null)
                    return;

                Cursor.Current = Cursors.WaitCursor;

                buttonCancel_Click(sender, e);

                int deviceCnt = listBoxDevices.Items.Count;
                DeviceCategory category = SelectedDeviceCategory;
                if (category == DeviceCategory.MobileEssentials)
                {
                    for (int i = 0; i < deviceCnt; i++)
                    {
                        listBoxDevices.SelectedIndex = i;
                        UnloadDevice(SelectedDevice, false);
                    }
                }
                else
                {
                    UnloadDevice(SelectedDevice, false);
                }
                listBoxDevices.Enabled = true;

                SelectedDevice.Close();

                string msg = string.Format("Device {0} closed", SelectedDevice.DeviceId.ToString());
                LogEvent(msg);
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            EnableControls();
            Cursor.Current = origCursor;
            #endregion
        }


        private void buttonAcquire_Click(object sender, EventArgs e)
        {
            #region buttonAcquire_Click
            Cursor origCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                BiometricPosition position = EquivalenciaOjo();// (BiometricPosition)TypeDescriptor.GetConverter(typeof(BiometricPosition)).ConvertFromString(comboBoxBiometricPosition.SelectedItem.ToString());
                ImpressionType impressionType = (ImpressionType)TypeDescriptor.GetConverter(typeof(ImpressionType)).ConvertFromString(comboBoxImpressionType.SelectedItem.ToString());

                // TODO: Check if position and impressionType are valid for this scanner.

                // refresh the visualizers in case their size or position has changed on the screen
                // to assure the "live" images are drawn in the correct location
                foreach (Visualizer visualizer in SelectedDevice.Visualizers.Values)
                {
                    visualizer.RefreshVisualizer();
                }

                SelectedDevice.Acquire(position, impressionType);

                EnableControls();

                string msg = string.Format("Device {0} acquisition started", SelectedDevice.DeviceId.ToString());
                LogEvent(msg);
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            EnableControls();
            Cursor.Current = origCursor;
            #endregion
        }


        private void buttonForce_Click(object sender, EventArgs e)
        {
            #region buttonForce_Click
            Cursor origCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SelectedDevice.ForceCapture();

                string msg = string.Format("Device {0} forced capture", SelectedDevice.DeviceId.ToString());
                LogEvent(msg);
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            EnableControls();
            Cursor.Current = origCursor;
            #endregion 
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cursor origCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (SelectedDevice.IsOpen == true)
                    SelectedDevice.Cancel();

                string msg = string.Format("Device {0} acquisition canceled", SelectedDevice.DeviceId.ToString());
                LogEvent(msg);
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            EnableControls();
            Cursor.Current = origCursor;
        }


        private void checkBoxAutoCapture_CheckedChanged(object sender, EventArgs e)
        {
            #region checkBoxAutoCapture_CheckedChanged
            Cursor origCursor = Cursor.Current;
            try
            {
                if (!SelectedDevice.DeviceProperties.PropertyDictionary.ContainsKey("AUTOCAPTURE_ON"))
                    return;

                Cursor.Current = Cursors.WaitCursor;
                string value;
                if (checkBoxAutoCapture.Checked)
                    value = "TRUE";
                else
                    value = "FALSE";

                // calling BioDevice.SetPropery will allow you to set the value before the device is opened.
                // When the device is opened this value will be passed to the device
                SelectedDevice.SetProperty("AUTOCAPTURE_ON", value);
            }
            catch (BioBaseException ex)
            {
                if (!ex.Message.Contains("BIOB_PROPERTIES_ALL_READONLY"))
                    ShowBioBaseError(ex);
            }

            //todo: Read in SelectedDevice.GetProperty("AUTOCAPTURE_ON", value) and set Checke box accordingly
            Cursor.Current = origCursor;
            #endregion

        }


        private void buttonCloseCategory_Click(object sender, EventArgs e)
        {
            #region buttonCloseCategory_Click
            Cursor origCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // close and dispose for each open category
                // Application only supports one open category at a time.
                foreach (BioDeviceCollector collector in m_Collectors.Values)
                {


                    string msg = string.Format("Category {0} closed", collector.DeviceCategory.ToString());

                    buttonCloseDevice_Click(sender, e);

                    collector.Close();
                    collector.Dispose();

                    LogEvent(msg);

                }
                m_Collectors.Clear();

                buttonOpenCategory.Enabled = true;
                listBoxDeviceCategory.Enabled = true;


            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            finally
            {
                this.labelDeviceCount.Text = "0";
                listBoxDevices.Items.Clear();
                EnableControls();
                Cursor.Current = origCursor;
            }
            #endregion
        }


        private void buttonOpenCategory_Click(object sender, EventArgs e)
        {
            #region buttonOpenCategory_Click
            BioDeviceCollector collector = null;
            Cursor origCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                buttonCloseCategory_Click(sender, e);

                DeviceCategory category = SelectedDeviceCategory;
                if (!m_Collectors.TryGetValue(category, out collector))
                {
                    collector = new BioDeviceCollector(category);
                    m_Collectors.Add(category, collector);
                    collector.ParentControl = this;
                    collector.Warning += new EventHandler<BioBaseWarningEventArgs>(collector_Warning);
                    collector.DeviceCountChanged += new DeviceCountEventHandler(collector_DeviceCountChanged);

                    /* Populate listBoxDevices because we didn’t register DeviceCountChanged 
                     * too late. Device Count already detected devices and made callback. 
                     * We could overload BioDeviceCollector and pass it the 
                     * DeviceCountEventHandler as a second parameter.
                     */
                    InitializeDeviceCatetory();
                }
                /*
                string msg = string.Format("Category {0} opened", category.ToString());
                LogEvent(msg);
                if (category == DeviceCategory.MobileEssentials)
                    StartMobileCallbacks();
                buttonOpenCategory.Enabled = false;
                listBoxDeviceCategory.Enabled = false;
                 * */

            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            Cursor.Current = origCursor;
            #endregion

        }


        void groupBox_Resize(object sender, EventArgs e)
        {
            #region groupBox_Resize
            DeviceCategory category = SelectedDeviceCategory;

            // resize the visualizer control according to how big its containing group box became
            // during this resize
            if (sender.GetType() == typeof(GroupBox))
            {
                GroupBox groupBox = (GroupBox)sender;
                if (groupBox.Size.Height > groupBox.Size.Width)
                {
                    if (groupBox.Controls.Count == 1)
                    {
                        if (category == DeviceCategory.IScanEssentials)
                        {   // 4:3 is default aspect ratio for iris images
                            groupBox.Controls[0].Width = groupBox.Width - 25;
                            groupBox.Controls[0].Height = (groupBox.Width - 25) * 3 / 4;
                        }
                        else
                        {
                            // square - Height = Width
                            groupBox.Controls[0].Width = groupBox.Width - 25;
                            groupBox.Controls[0].Height = groupBox.Width - 25;
                        }
                    }
                }
                else
                {
                    if (groupBox.Controls.Count == 1)
                    {
                        if (category == DeviceCategory.IScanEssentials)
                        {   // 4:3 is default aspect ratio for iris images
                            groupBox.Controls[0].Width = (groupBox.Height - 25) * 4 / 3;
                            groupBox.Controls[0].Height = groupBox.Height - 25;
                        }
                        else
                        {
                            // square - Width = Height
                            groupBox.Controls[0].Width = groupBox.Height - 25;
                            groupBox.Controls[0].Height = groupBox.Height - 25;
                        }
                    }
                }
            }
            #endregion
        }

        void LatentSettings_Changed(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(NumericUpDown))
            {
                NumericUpDown LSlider = (NumericUpDown)sender;

                // Get Checkbox child Control from LSlider
                if (LSlider.HasChildren)
                {
                    foreach (Control childControl in LSlider.Controls)
                    {
                        if (childControl.GetType() == typeof(CheckBox))
                        {
                            CheckBox CB = (CheckBox)childControl;

                            // Set flag the scanner needs to be updated with new settings
                            CB.CheckState = CheckState.Checked;
                        }
                    }
                }

            }

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region listBox1_SelectedIndexChanged
            EnableControls();

            if (SelectedDevice != null)
            {
                // TODO: We could check that only valid comboBoxBiometricPosition and 
                // comboBoxImpressionType are shown for for the selected scanner.
                if (SelectedDevice.GetType() == typeof(IrisDevice))
                {
                    if (!SelectedDeviceLatent)
                    {
                        comboBoxBiometricPosition.SelectedItem = CapturaOjo.Ambos.ToString();// BiometricPosition.IrisBoth.ToString();
                        comboBoxImpressionType.SelectedItem = ImpressionType.IrisRegular.ToString();
                    }
                    else
                    {
                        comboBoxBiometricPosition.SelectedItem = CapturaOjo.Ambos.ToString();// BiometricPosition.UnknownFinger.ToString();
                        comboBoxImpressionType.SelectedItem = ImpressionType.FingerUnknown.ToString();
                    }

                }
                else if (SelectedDevice.GetType() == typeof(FacialCaptureDevice))
                {
                    comboBoxBiometricPosition.SelectedItem = CapturaOjo.Ambos.ToString();// BiometricPosition.UnknownFace.ToString();
                    comboBoxImpressionType.SelectedItem = ImpressionType.FaceUnknown.ToString();
                }
                else if (SelectedDevice.GetType() == typeof(FingerDevice))
                {
                    comboBoxBiometricPosition.SelectedItem = CapturaOjo.Ambos.ToString();// BiometricPosition.LeftIndex.ToString();
                    comboBoxImpressionType.SelectedItem = ImpressionType.FingerFlat.ToString();
                }

                RefreshConnectedEvents(SelectedDevice); //listen for connected and disconnected events
            }

            LayoutVisualizers();
            #endregion
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                //buttonCloseCategory_Click first calls buttonCloseDevice_Click
                buttonCloseCategory_Click(sender, e);
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            #region Form1_Load
            BioDeviceCollector collector = null;
            DeviceCategory category = (DeviceCategory)Enum.Parse(typeof(DeviceCategory), DeviceCategory.IScanEssentials.ToString());

            if (!m_Collectors.TryGetValue(category, out collector))
            {
                collector = new BioDeviceCollector(category);
                m_Collectors.Add(category, collector);
                collector.ParentControl = this;
                collector.Warning += new EventHandler<BioBaseWarningEventArgs>(collector_Warning);
                collector.DeviceCountChanged += new DeviceCountEventHandler(collector_DeviceCountChanged);
                InitializeDeviceCatetory();
            }

            // fill the impressionTypes combobox
            string[] impressionTypeNames = Enum.GetNames(typeof(ImpressionType));
            foreach (string name in impressionTypeNames)
                comboBoxImpressionType.Items.Add(name);


            comboBoxBiometricPosition.Items.Add(CapturaOjo.Ambos.ToString());
            comboBoxBiometricPosition.Items.Add(CapturaOjo.Derecho.ToString());
            comboBoxBiometricPosition.Items.Add(CapturaOjo.Izquierdo.ToString());

            comboBoxBiometricPosition.SelectedItem = CapturaOjo.Ambos.ToString();// BiometricPosition.IrisBoth.ToString();
            comboBoxImpressionType.SelectedItem = ImpressionType.IrisRegular.ToString();

            try
            {
                if (SelectedDevice == null)
                    return;

                // setup the event delegates
                SelectedDevice.InitProgress += new InitProgressEventHandler(SelectedDevice_InitProgress);
                SelectedDevice.AcquistionStart += new EventHandler(device_AcquistionStart);
                SelectedDevice.AcquisitionComplete += new EventHandler(device_AcquisitionComplete);
                SelectedDevice.Preview += new DataAvailableEventHandler(device_Preview);
                SelectedDevice.BiometricObjectQuality += new ObjectQualityEventHandler(SelectedDevice_BiometricObjectQuality);
                SelectedDevice.BiometricObjectCount += new ObjectCountEventHandler(SelectedDevice_BiometricObjectCount);
                SelectedDevice.DataAvailable += new DataAvailableEventHandler(device_DataAvailable);
                SelectedDevice.BiometricObjectPresent += new BiometricObjectPresentEventHandler(SelectedDevice_BiometricObjectPresent);
                SelectedDevice.LiveState += new LiveStateEventHandler(SelectedDevice_LiveState);
                SelectedDevice.OutputCommandCompleted += new OutputCommandCompletedEventHandler(SelectedDevice_OutputCommandCompleted);
                SelectedDevice.UserInput += new UserInputEventHandler(SelectedDevice_UserInput);

                RefreshConnectedEvents(SelectedDevice);

                SelectedDevice.Open();

                LayoutVisualizers();

                // each device has one or more visualizers, create a window control on which
                // biobase will draw "live" images during acquistion, then assign that control
                // to the visualizer
                foreach (string key in SelectedDevice.Visualizers.Keys)
                {
                    // add a group box just for labeling and calculating sizes for the visualizer controls
                    GroupBox groupBox = new GroupBox();
                    groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    groupBox.Text = key.Replace("Wnd", ""); // remove the Wnd from the visualizer name, just for cosmetics
                    groupBox.Resize += new EventHandler(groupBox_Resize);

                    // this panel control will be drawn on the the device is acquiring
                    //Panel panel = new Panel();
                    //panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    //panel.BackColor = System.Drawing.Color.White;
                    //panel.Location = new Point( 10, 15 );

                    ImageCtrl pictureBox = new ImageCtrl();
                    pictureBox.BackColor = System.Drawing.Color.White;
                    pictureBox.Location = new Point(10, 15);
                    pictureBox.Tag = key;

                    groupBox.Controls.Add(pictureBox);
                    tableLayoutPanel1.Controls.Add(groupBox);




                    SelectedDevice.Visualizers[key].DeviceControl = pictureBox;
                    //SelectedDevice.Visualizers[key].DeviceControl.
                }


                // match the auto capture checkbox to the setting on the device
                SetAutoCaptureCheckbox();

                LayoutVisualizers();

            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            EnableControls();
            #endregion
        }


        private BiometricPosition EquivalenciaOjo()
        {
            BiometricPosition posicion = new BiometricPosition();
            string ambos = CapturaOjo.Ambos.ToString();
            string derecho = CapturaOjo.Derecho.ToString();
            string izquierdo =CapturaOjo.Izquierdo.ToString();
            switch (comboBoxBiometricPosition.SelectedItem.ToString())
            {
                case "Ambos":
                    posicion = BiometricPosition.IrisBoth;
                    break;
                case "Derecho":
                    posicion = BiometricPosition.IrisRight;
                    break;
                case "Izquierdo":
                    posicion = BiometricPosition.IrisLeft;
                    break;
            }

            return posicion;
        }

        private void listBoxDeviceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void InitializeDeviceCatetory()
        {
            #region InitializeDeviceCatetory
            Cursor origCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            BioDeviceCollector collector = SelectedDeviceCollector;

            if (collector == null)
                return;

            try
            {
                collector.GetDevices();
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }

            // clear the device list
            listBoxDevices.Items.Clear();

            // add each detected device to a list box
            foreach (string deviceId in collector.Devices.Keys)
            {
                if (collector.Devices[deviceId].IsConnected)
                    this.listBoxDevices.Items.Add(deviceId);

                // set the parent control to make sure all event come back to this thread
                collector.Devices[deviceId].ParentControl = this;
            }

            labelDeviceCount.Text = listBoxDevices.Items.Count.ToString();


            if (listBoxDevices.Items.Count > 0)
            {
                listBoxDevices.SelectedIndex = 0;
            }

            /////////////////////////////////////////////////////////////////////////
            // The following code is optional and is here to show how to parse 
            // API Properties XML data.
            /////////////////////////////////////////////////////////////////////////
            try
            {
                string StrXml;
                collector.GetApiProperties(out StrXml);

                // Get XML Document object
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(StrXml);

                // Get the node with "ApiProperties" 
                XmlNodeList deviceNodes = XmlDoc.SelectNodes("//ApiProperties");
                LogEvent("ApiProperties:");

                // Get and log each node name and value
                foreach (XmlNode root in deviceNodes)
                {
                    if (root.HasChildNodes)
                    {
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {
                            string msg = string.Format("\t {0} = {1}", root.ChildNodes[i].Name.ToString(), root.ChildNodes[i].InnerText.ToString());
                            LogEvent(msg);
                        }
                    }
                }
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }
            finally
            {
                // Continue with enabling controls...
                EnableControls();
                Cursor.Current = origCursor;
            }
            #endregion
        }

        private void SetAutoCaptureCheckbox()
        {
            #region SetAutoCaptureCheckbox
            try
            {
                if (SelectedDevice != null)
                {
                    if (SelectedDevice.DeviceProperties.PropertyDictionary.ContainsKey("AUTOCAPTURE_ON"))
                        checkBoxAutoCapture.Checked =
                            SelectedDevice.GetProperty("AUTOCAPTURE_ON") == "TRUE"; //pwConst_ReadOnlyT
                }
            }
            catch (BioBaseException ex)
            {
                ShowBioBaseError(ex);
            }
            #endregion
        }

        private void SetDeviceProperty(string propertyName, string value)
        {
            if (SelectedDevice.DeviceProperties.PropertyDictionary.ContainsKey(propertyName))
                SelectedDevice.DeviceProperties.PropertyDictionary[propertyName].CurrentValue = value;
        }

        private void UnloadDevice(BioDevice device, bool listenForReconnect)
        {
            #region UnloadDevice
            if (device == null)
                return;

            // the device is either closing or it recieved a disconnected event
            // so we want to clean up the UI to reflect this

            // remove the visualizer controls that we created for the device
            List<GroupBox> emptyGroupBoxList = new List<GroupBox>();
            foreach (Visualizer visualizer in device.Visualizers.Values)
            {
                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    if (control.GetType() == typeof(GroupBox))
                    {
                        GroupBox groupBox = (GroupBox)control;
                        if (groupBox.Contains(visualizer.DeviceControl))
                        {
                            groupBox.Controls.Remove(visualizer.DeviceControl);

                            // keep track of the group boxes so we can delete them later
                            emptyGroupBoxList.Add(groupBox);
                        }
                    }
                }
            }
            // delete the empty group boxes
            foreach (GroupBox groupBox in emptyGroupBoxList)
            {
                tableLayoutPanel1.Controls.Remove(groupBox);
            }

            // if we are unloading because of a disconnect event, keep the connected event delegate
            // around so we know if it is reconnected
            if (!listenForReconnect)
                device.Connected -= new EventHandler(SelectedDevice_Connected);

            // remove all of the other event delegates so we start with a clean slate next time the
            // device is reopened
            device.InitProgress -= new InitProgressEventHandler(SelectedDevice_InitProgress);
            device.AcquistionStart -= new EventHandler(device_AcquistionStart);
            device.AcquisitionComplete -= new EventHandler(device_AcquisitionComplete);
            device.Preview -= new DataAvailableEventHandler(device_Preview);
            device.BiometricObjectQuality -= new ObjectQualityEventHandler(SelectedDevice_BiometricObjectQuality);
            device.BiometricObjectCount -= new ObjectCountEventHandler(SelectedDevice_BiometricObjectCount);
            device.DataAvailable -= new DataAvailableEventHandler(device_DataAvailable);
            device.Disconnected -= new EventHandler(device_Disconnected);
            device.BiometricObjectPresent -= new BiometricObjectPresentEventHandler(SelectedDevice_BiometricObjectPresent);
            device.LiveState -= new LiveStateEventHandler(SelectedDevice_LiveState);
            device.OutputCommandCompleted -= new OutputCommandCompletedEventHandler(SelectedDevice_OutputCommandCompleted);
            device.UserInput -= new UserInputEventHandler(SelectedDevice_UserInput);
            #endregion
        }

        private void LayoutVisualizers()
        {
            #region LayoutVisualizers
            DeviceCategory category = SelectedDeviceCategory;
            // visualizer controls are added to a table layout panel
            // this code just arranges the panel according to the number of
            // controls that are on the panel

            if (tableLayoutPanel1.Controls.Count > 1)
                tableLayoutPanel1.ColumnStyles[0].Width = 50;
            else
                tableLayoutPanel1.ColumnStyles[0].Width = 100;

            int rowCount = GetVisualizerRowCount();
            switch (rowCount)
            {
                case 0:
                    tableLayoutPanel1.Visible = false;
                    break;
                case 1:
                    tableLayoutPanel1.Visible = true;
                    tableLayoutPanel1.RowStyles[0].Height = 100;
                    tableLayoutPanel1.RowStyles[1].Height = 0;
                    break;
                case 2:
                    tableLayoutPanel1.Visible = true;
                    tableLayoutPanel1.RowStyles[0].Height = 50;
                    tableLayoutPanel1.RowStyles[1].Height = 50;
                    break;
            }
            #endregion
        }

        private int GetVisualizerRowCount()
        {
            // determine how many rows of visualizer controls we have
            int maxRow = 0;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                int row = tableLayoutPanel1.GetPositionFromControl(control).Row;
                if (row + 1 > maxRow)
                    maxRow = row + 1;
            }
            return maxRow;
        }

        private void RefreshConnectedEvents(BioDevice device)
        {
            device.Connected -= new EventHandler(SelectedDevice_Connected);
            device.Connected += new EventHandler(SelectedDevice_Connected);
            device.Disconnected -= new EventHandler(device_Disconnected);
            device.Disconnected += new EventHandler(device_Disconnected);
        }

        int m_EventCount = 0;
        void LogEvent(string eventName)
        {
            m_EventCount++;

            if (m_EventCount == 501)
            {
                this.textBoxLog.Text += "Log stopped at 500";
            }
            else if (m_EventCount < 501)
            {
                this.textBoxLog.Text += eventName + "\r\n";
                this.textBoxLog.SelectionStart = textBoxLog.TextLength;
                this.textBoxLog.ScrollToCaret();
            }
        }

        void UpdateLatentSettings()
        {
            // Check each slider to see if we have to update scanner with new settings
            foreach (Control childCtl in this.groupBoxLatentControls.Controls)
                if (childCtl.GetType() == typeof(NumericUpDown))
                {
                    NumericUpDown LSlider = (NumericUpDown)childCtl;
                    foreach (Control childControl in LSlider.Controls)
                        if (childControl.GetType() == typeof(CheckBox))
                        {
                            CheckBox CB = (CheckBox)childControl;

                            // Get flag the scanner needs to be updated with new settings
                            if (CB.CheckState == CheckState.Checked)
                            {

                                CB.CheckState = CheckState.Unchecked;
                            }
                        }
                }
        }


        void EnableControls()
        {
            #region EnableControls
            bool deviceSelected = SelectedDevice != null;

            bool acquiring = false;
            bool open = false;
            bool connected = false;
            bool canSetPosition = false;
            bool canSetMode = false;
            bool canSendData = false;

            DeviceCategory category = SelectedDeviceCategory;
            if (m_Collectors.ContainsKey(category))
            {
                if (deviceSelected)
                {
                    open = SelectedDevice.IsOpen;
                    acquiring = SelectedDevice.IsAcquiring;
                    canSetPosition = (SelectedDevice.GetType() == typeof(FingerDevice)) ||
                                      ((SelectedDevice.GetType() == typeof(IrisDevice)) && !SelectedDeviceLatent);
                    canSetMode = SelectedDevice.GetType() == typeof(FingerDevice);
                    canSendData = SelectedDevice.GetType() == typeof(MobileDevice);
                    connected = SelectedDevice.IsConnected;
                }
            }

            buttonOpen.Enabled = deviceSelected && !open && connected && !canSendData;
            buttonClose.Enabled = deviceSelected && open && connected;
            buttonCancel.Enabled = deviceSelected && acquiring && connected;
            buttonForce.Enabled = deviceSelected && acquiring && connected;
            buttonAcquire.Enabled = deviceSelected && open && !acquiring && connected;
            //buttonSend.Enabled                  = deviceSelected && canSendData;
            comboBoxBiometricPosition.Enabled = deviceSelected && canSetPosition && connected;
            comboBoxImpressionType.Enabled = deviceSelected && canSetMode && connected;
            checkBoxAutoCapture.Enabled = false;
            #endregion
        }


        void SaveDataAvailable(DataAvailableEventArgs e)
        {
            //METODO PARA GRABAR ARCHIVO IIR
            string extension = e.DataFormat.ToString();
            string folderName = string.Format("{2}{0}BioBaseData{0}{1}{0}", Path.DirectorySeparatorChar, SelectedDeviceCategory, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            DirectoryInfo info = Directory.CreateDirectory(folderName);

            using (FileStream stream = new FileStream(param[2], FileMode.Create))
            {
                byte[] bioData = e.GetBiometricData();
                stream.Write(bioData, 0, bioData.Length);
                stream.Close();
                stream.Dispose();
                string log = string.Format("File {0} saved.", param[2]);
                LogEvent(log);

            }
        }

        private void ShowBioBaseError(BioBaseException ex)
        {
            string msg;
            if (ex.BioBaseError != 0)
                msg = string.Format("{0}\n{1}", ex.Message, ex.BioBaseError.ToString());
            else
                msg = ex.Message;
            MessageBox.Show(msg, "BioBase Error");
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(param[0]))
                File.Delete(param[0]);

            if (File.Exists(param[1]))
                File.Delete(param[1]);

            if (File.Exists(param[2]))
                File.Delete(param[2]);

            buttonCloseCategory_Click(sender, e);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonCloseCategory_Click(sender, e);
            Close();
        }
    }
}
