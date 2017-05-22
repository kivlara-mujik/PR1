using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4PR
{
    public partial class HTMLBodyForm : Form
    {
        public Dictionary<string, string> AttachmentsDictionary = new Dictionary<string, string>();
        public string DocumentString = string.Empty;
        private const string _mainPageIntro = "<html><head></head><body>";
        private const string _mainPageOutro = "</body></html>";
        public bool isHTML = true;
        public HTMLBodyForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                Guid _identifier = Guid.NewGuid();
                var _contentID = "image" + _identifier;
                DocumentString += "<img src='cid:" + _contentID + "'/><br>";
                AttachmentsDictionary.Add(_contentID, _dialog.FileName);
            }
            webBrowser1.DocumentText = DocumentString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSalvare_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonTitleAdd_Click(object sender, EventArgs e)
        {
            DocumentString += "<h3> " + textBoxTitlu.Text + "</h3>";
            if (!textBoxTitlu.Text.Equals(string.Empty))
                buttonTitleAdd.Enabled = false;
            webBrowser1.DocumentText = DocumentString;
        }

        private void buttonTextAdd_Click(object sender, EventArgs e)
        {
            DocumentString += "<p> " + textBoxText.Text + "</p>";
            webBrowser1.DocumentText = DocumentString;
        }

        private void buttonLinkAdd_Click(object sender, EventArgs e)
        {
            DocumentString += "<a href='" + textBoxLink.Text + "'>" + textBoxLinkname.Text + "</a><br>";
            webBrowser1.DocumentText = DocumentString;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog _dialogHTML = new OpenFileDialog();
            if (_dialogHTML.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamHTML = new StreamReader(_dialogHTML.FileName))
                {
                    DocumentString = await streamHTML.ReadToEndAsync();
                    webBrowser1.DocumentText = DocumentString;
                    return;
                }
            }
        }
    }
}
