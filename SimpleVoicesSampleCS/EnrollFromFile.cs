using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;

namespace Neurotec.Samples
{
	public partial class EnrollFromFile : UserControl
	{
		#region Public constructor

		public EnrollFromFile()
		{
			InitializeComponent();
		}

		#endregion

		#region Private fields

		private const string TextDependent = "Extract text dependent features";
		private const string TextIndependent = "Extract text independent features";

		private NBiometricClient _biometricClient;
		private NSubject _subject;
		private NVoice _voice;
		private bool _defaultExtractFeatures;

		#endregion

		#region Public properties

		public NBiometricClient BiometricClient
		{
			get { return _biometricClient; }
			set
			{
				_biometricClient = value;
				_defaultExtractFeatures = _biometricClient.VoicesExtractTextDependentFeatures;
				extractFeatures.SelectedItem = _defaultExtractFeatures ? TextDependent : TextIndependent;
			}
		}

		#endregion

		#region Private methods

		private void DisableControls()
		{
			lblSoundFile.Text = string.Empty;
			lblStatus.Text = string.Empty;
			btnExtract.Enabled = false;
			btnSaveTemplate.Enabled = false;
			btnSaveVoice.Enabled = false;
		}

		private void OnExtractionCompleted(NBiometricTask task)
		{
			NBiometricStatus status = task.Status;
			if (status == NBiometricStatus.Ok)
			{
				btnSaveTemplate.Enabled = true;
				btnSaveVoice.Enabled = true;
				lblStatus.Text = @"Template extracted";
			}
			else
			{
				lblStatus.Text = string.Format("Extraction failed: {0}.", status);
			}
		}

		#endregion

		#region Private form events

		private void EnrollFromFileLoad(object sender, EventArgs e)
		{
			extractFeatures.Items.Add(TextDependent);
			extractFeatures.Items.Add(TextIndependent);
			DisableControls();
		}

		private void BtnOpenClick(object sender, EventArgs e)
		{
			_subject = null;
			_voice = null;

			DisableControls();

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Create a subject with voice record
				_voice = new NVoice { FileName = openFileDialog.FileName };
				_subject = new NSubject();
				_subject.Voices.Add(_voice);

				lblSoundFile.Text = openFileDialog.FileName;
				btnExtract.Enabled = true;
			}
		}

		private async void BtnExtractClickAsync(object sender, EventArgs e)
		{
			btnSaveVoice.Enabled = false;
			btnSaveTemplate.Enabled = false;
			lblStatus.Text = string.Empty;

			if (extractFeatures.SelectedIndex == -1)
			{
				MessageBox.Show(@"No features configured to extract", @"Invalid options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				_voice.PhraseId = Convert.ToInt32(nudPhraseId.Value);
				// Do voice extraction and segment voice from audio
				NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Segment | NBiometricOperations.CreateTemplate, _subject);
				var performedTask = await _biometricClient.PerformTaskAsync(task);
				OnExtractionCompleted(performedTask);
			}
			catch (Exception ex)
			{
				Utils.ShowException(ex);
			}
		}

		private void BtnSaveTemplateClick(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					File.WriteAllBytes(saveFileDialog.FileName, _subject.GetTemplateBuffer().ToArray());
				}
				catch (Exception ex)
				{
					Utils.ShowException(ex);
				}
			}
		}

		private void BtnSaveVoiceClick(object sender, EventArgs e)
		{
			if (saveVoiceFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					NVoice voice = _subject.Voices.Last();
					File.WriteAllBytes(saveVoiceFileDialog.FileName, voice.SoundBuffer.Save().ToArray());
				}
				catch (Exception ex)
				{
					Utils.ShowException(ex);
				}
			}
		}
		
		private void EnrollFromFileVisibleChanged(object sender, EventArgs e)
		{
			if (Visible && _biometricClient != null)
			{
				nudPhraseId.Value = 0;
				SetSettings();
			}
		}

		private void ExtractFeaturesSelectedIndexChanged(object sender, EventArgs e)
		{
			SetSettings();
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
	}
}
