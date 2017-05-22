using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Limilabs.Mail;
using System.IO;

namespace Lab4PR
{
    public partial class ShowAllMailsForm : Form
    {
        private List<OpenPop.Mime.Message> ListMailsRecieved;
        public ShowAllMailsForm(List<OpenPop.Mime.Message> ListMailsRecieved)
        {
            this.ListMailsRecieved = ListMailsRecieved;
            InitializeComponent();
        }

        private void ShowAllMailsForm_Load(object sender, EventArgs e)
        {
            listView1.CheckBoxes = false;
            listView1.GridLines = true;
            listView1.View = View.Tile;
            listView1.GridLines = true;

            ListMailsRecieved.ForEach(element =>
           {
               listView1.Items.Add(element.Headers.Date);
           });

            listView1.Click += (snd, ew) =>
            {
                var mail = ListMailsRecieved.FirstOrDefault(x => x.Headers.Date.Equals(listView1.SelectedItems[0].Text));
                OpenPop.Mime.MessagePart BodyString;
                if (mail.FindFirstHtmlVersion() != null)
                    BodyString = mail.FindFirstHtmlVersion();
                else
                    BodyString = mail.FindFirstPlainTextVersion();
                if (mail.FindAllAttachments().Count != 0)
                {
                    listView2.Items.Clear();
                    mail.FindAllAttachments().ForEach(element =>
                    {
                        listView2.Items.Add(element.FileName);
                    });
                    while (Width < 1115)
                        Width++;
                    panelAttachments.Visible = true;
                }
                else
                {
                    listView2.Items.Clear();
                    while (Width > 1015)
                        Width--;
                    panelAttachments.Visible = false;
                }
                const string _fileSaveMail = "lastMail.html";
                BodyString.Save(new FileInfo(_fileSaveMail));

                string _savedInstance = string.Empty;

                using (var file = new FileStream(_fileSaveMail, FileMode.Open))
                {
                    using (var stream = new StreamReader(file))
                    {
                        _savedInstance = stream.ReadToEnd();
                    }
                }

                webBrowser1.DocumentText = _savedInstance;
                return;
            };
        }
    }
}
