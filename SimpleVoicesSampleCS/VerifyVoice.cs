using System;
using System.IO;
using System.Windows.Forms;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.IO;

namespace Neurotec.Samples
{
	public partial class VerifyVoice : UserControl
	{
		#region Public constructor

		public VerifyVoice()
		{
			InitializeComponent();
		}

		#endregion

		#region Private fields

		private NBiometricClient _biometricClient;
		private NSubject _subject1;
		private NSubject _subject2;

		private int _defaultFar;
		private bool _defaultUniquePhrases;

		#endregion

		#region Public properties

		public NBiometricClient BiometricClient
		{
			get { return _biometricClient; }
			set
			{
				_biometricClient = value;
				_defaultUniquePhrases = _biometricClient.VoicesUniquePhrasesOnly;
				_defaultFar = _biometricClient.MatchingThreshold;
				chbUniquePhrases.Checked = _defaultUniquePhrases;
				cbMatchingFAR.Text = Utils.MatchingThresholdToString(_defaultFar);
			}
		}

		#endregion

		#region Private methods

		private async System.Threading.Tasks.Task<Tuple<string, NSubject>> OpenTemplateOrFileAsync()
		{
			NSubject subject = null;
			lblMsg.Text = string.Empty;
			string fileName = string.Empty;

			openFileDialog.FileName = null;
			openFileDialog.Title = @"Open voice template or audio file";
			if (openFileDialog.ShowDialog() == DialogResult.OK) // load template
			{
				fileName = openFileDialog.FileName;

				// Check if given file is a template
				var fileData = new NBuffer(File.ReadAllBytes(openFileDialog.FileName));
				try
				{
					NTemplate.Check(fileData);
					subject = new NSubject();
					subject.SetTemplateBuffer(fileData);
				}
				catch { }

				// If file is not a template, try to load it as audio file
				if (subject == null)
				{
					// Create voice object
					var voice = new NVoice { FileName = fileName };
					subject = new NSubject();
					subject.Voices.Add(voice);

					// Extract a template from the subject
					try
					{
						var status = await _biometricClient.CreateTemplateAsync(subject);
						if (status != NBiometricStatus.Ok)
						{
							MessageBox.Show(string.Format("The template was not extracted: {0}.", status), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					catch (Exception ex)
					{
						Utils.ShowException(ex);
					}
				}
			}
			return new Tuple<string, NSubject>(fileName, subject);
		}

		private void EnableVerifyButton()
		{
			btnVerify.Enabled = IsSubjectValid(_subject1) && IsSubjectValid(_subject2);
		}

		private bool IsSubjectValid(NSubject subject)
		{
			return subject != null && (subject.Status == NBiometricStatus.Ok
				|| subject.Status == NBiometricStatus.MatchNotFound
				|| subject.Status == NBiometricStatus.None && subject.GetTemplateBuffer() != null);
		}

		private void OnVerifyCompleted(NBiometricStatus status)
		{
			var verificationStatus = string.Format("Verification status: {0}", status);
			if (status == NBiometricStatus.Ok)
			{
				// Get matching score
				int score = _subject1.MatchingResults[0].Score;
				string msg = string.Format("Score of matched templates: {0}", score);
				lblMsg.Text = msg;
				MessageBox.Show(string.Format("{0}\n{1}", verificationStatus, msg));
			}
			else
			{
				lblMsg.Text = verificationStatus;
				MessageBox.Show(verificationStatus);
			}
		}

		private void SetFar()
		{
			_biometricClient.VoicesUniquePhrasesOnly = chbUniquePhrases.Checked;

			try
			{
				_biometricClient.MatchingThreshold = Utils.MatchingThresholdFromString(cbMatchingFAR.Text);
				cbMatchingFAR.Text = Utils.MatchingThresholdToString(_biometricClient.MatchingThreshold);
				EnableVerifyButton();
			}
			catch
			{
				MessageBox.Show(@"FAR is not valid", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbMatchingFAR.Select();
			}
		}

		private void SetDefaultFar()
		{
			cbMatchingFAR.Text = Utils.MatchingThresholdToString(_defaultFar);
			btnDefault.Enabled = false;
			SetFar();
		}

		#endregion

		#region Private form events

		private async void BtnVerifyClickAsync(object sender, EventArgs e)
		{
			if (_subject1 != null && _subject2 != null)
			{
				btnVerify.Enabled = false;
				try
				{
					var status = await _biometricClient.VerifyAsync(_subject1, _subject2);
					OnVerifyCompleted(status);
				}
				catch (Exception ex)
				{
					Utils.ShowException(ex);
				}
			}
		}

		private void BtnDefaultClick(object sender, EventArgs e)
		{
			SetDefaultFar();
		}

		private async void BtnOpen1ClickAsync(object sender, EventArgs e)
		{
			var resultTuple = await OpenTemplateOrFileAsync();
			lblFirstTemplate.Text = resultTuple.Item1;
			_subject1 = resultTuple.Item2;
			EnableVerifyButton();
		}

		private async void BtnOpen2ClickAsync(object sender, EventArgs e)
		{
			var resultTuple = await OpenTemplateOrFileAsync();
			lblSecondTemplate.Text = resultTuple.Item1;
			_subject2 = resultTuple.Item2;
			EnableVerifyButton();
		}

		private void CbMatchingFAREnter(object sender, EventArgs e)
		{
			btnDefault.Enabled = true;
		}

		private void VerifyVoiceLoad(object sender, EventArgs e)
		{
			lblMsg.Text = string.Empty;
			lblFirstTemplate.Text = string.Empty;
			lblSecondTemplate.Text = string.Empty;
			try
			{
				cbMatchingFAR.BeginUpdate();
				cbMatchingFAR.Items.Add(0.001.ToString("P1"));
				cbMatchingFAR.Items.Add(0.0001.ToString("P2"));
				cbMatchingFAR.Items.Add(0.00001.ToString("P3"));
			}
			finally
			{
				cbMatchingFAR.EndUpdate();
			}
		}

		private void CbMatchingFARLeave(object sender, EventArgs e)
		{
			SetFar();
		}

		private void VerifyVoiceVisibleChanged(object sender, EventArgs e)
		{
			if (Visible && _biometricClient != null)
			{
				SetDefaultFar();
			}
		}

		private void chbUniquePhrasesCheckedChanged(object sender, EventArgs e)
		{
			_biometricClient.VoicesUniquePhrasesOnly = chbUniquePhrases.Checked;
		}

		#endregion
	}
}
