using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Lab4PR
{
    public partial class FormSendMail : Form
    {
        private string Login;
        private string Password;
        private List<string> AttachmentsList;
        private Dictionary<string, string> AttachmentsHTML;
        private bool isHTML = false;

        public FormSendMail(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
            InitializeComponent();
            AttachmentsList = new List<string>();
            AttachmentsHTML = new Dictionary<string, string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMail();
        }
        private void SendMail()
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(Login, Password);

            MailMessage message = new MailMessage();
            message.To.Add(textBox1To.Text);
            message.From = new MailAddress(Login);
            message.Subject = textBox2Subject.Text;
            message.Body = textBoxMessage.Text;

            if (!(AttachmentsList.Count == 0))
            {
                AttachmentsList.ForEach(element =>
                {
                    var _attachment = new Attachment(element);
                    message.Attachments.Add(_attachment);
                });
            }

            if (!(AttachmentsHTML.Count == 0))
            {
                foreach (var element in AttachmentsHTML)
                {
                    var _attachment = new Attachment(element.Value);
                    _attachment.ContentId = element.Key;
                    message.Attachments.Add(_attachment);

                };
            }
            if (isHTML)
                message.IsBodyHtml = true;

            string userToken = Login + "__Token";
            client.SendCompleted += (s, ee) =>
            {
                MessageBox.Show("Succesfull!!", "Sent!");
                Close();
            };
            try
            {
                client.SendAsync(message, userToken);

            }
            catch (Exception ex)
            {
                var response = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                switch (response)
                {
                    case DialogResult.Retry:
                        {
                            SendMail();
                        }
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog _filesDialog = new OpenFileDialog();
            if (_filesDialog.ShowDialog() == DialogResult.OK)
            {
                labelAttachments.Text = _filesDialog.FileName.ToString().Split('/').LastOrDefault();
                AttachmentsList.Add(_filesDialog.FileName);
            }
        }

        private void buttonHTMLBody_Click(object sender, EventArgs e)
        {
            using (var form = new HTMLBodyForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBoxMessage.Text = form.DocumentString;
                    AttachmentsHTML = form.AttachmentsDictionary;
                    isHTML = form.isHTML;
                }
            }
        }

          private void textBox1To_TextChanged(object sender, EventArgs e)
          {

          }

        private void FormSendMail_Load(object sender, EventArgs e)
        {

        }
    }
}
