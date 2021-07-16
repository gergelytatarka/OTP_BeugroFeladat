using Newtonsoft.Json;
using OTP_BeugroFeladata.Common;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinformsApplication
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Base64Converter _base64Converter;

        public Form()
        {
            InitializeComponent();
            _base64Converter = new Base64Converter();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            FillListBoxOfFiles();
        }

        private void FillListBoxOfFiles()
        {
            ListBoxOfFiles.Items.Clear();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:8430/api/dokumentumok");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Regex reg = new Regex("\"([^\"]*?)\"");

            var matches = reg.Matches(content);

            foreach (Match match in matches)
            {
                var theData = match.Groups[1].Value;
                ListBoxOfFiles.Items.Add(theData);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var uri = new Uri(@"http://localhost:8430/api/dokumentumok");
                var fileBytes = ReadFileBytes(openFileDialog.OpenFile());
                try
                {
                    var request = new FileRequestResponse
                    {
                        Content = _base64Converter.ConvertBytesToBase64(fileBytes),
                        FileName = Path.GetFileName(openFileDialog.FileName)
                    };
                    var requestAsJson = JsonConvert.SerializeObject(request);

                    var client = new HttpClient();
                    var stringContent = new StringContent(requestAsJson, UnicodeEncoding.UTF8, "application/json");
                    client.PostAsync(uri, stringContent).Wait();

                    FillListBoxOfFiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private byte[] ReadFileBytes(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }


        private void ListBoxOfFiles_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxOfFiles.SelectedItem != null)
            {
                var selectedFileName = ListBoxOfFiles.SelectedItem.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://localhost:8430/api/dokumentumok/{selectedFileName}");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var responseObject = JsonConvert.DeserializeObject<FileRequestResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                var fileBytes = Convert.FromBase64String(responseObject.Content);

                saveFileDialog.FileName = selectedFileName;
                saveFileDialog.Filter = $"All files |*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, fileBytes);
                }
            }
        }
    }
}
