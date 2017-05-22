using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Limilabs.Mail;

namespace Lab4PR
{
    public partial class Form1 : Form
    {
        private List<OpenPop.Mime.Message> _listMailsRecieved;
        private const string HostName = "pop.gmail.com";
        private const int Port = 995;
        private const bool IsSSL = true;
        public Form1()
        {
            InitializeComponent();
            textBoxPass.PasswordChar = '*';
            _listMailsRecieved = new List<OpenPop.Mime.Message>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 210;
            button2.Visible = false;
            button3.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Log Out"))
            {
                panel1.Visible = false;
                button1.Text = "Log in";
                textBoxLogin.Enabled = true;
                textBoxPass.Enabled = true;
                while (Height > 210)
                {
                    Height--;
                    System.Threading.Thread.Sleep(1);
                };
                button2.Visible = false;
                button3.Visible = false;
                button3.Enabled = false;
                button3.Text = "Actualizare...";
                return;
            }
            else
            {
                if (!WebHelper.CheckForInternetConnection())
                    return;
                if (!WebHelper.IsEmail(textBoxLogin.Text))
                {
                    this.Height = 210;
                    MessageBox.Show("Email-ul introdus este unul gresit", "Error");
                    return;
                }
                else if (!(textBoxPass.Text.Length > 5))
                {
                    this.Height = 210;
                    MessageBox.Show("Parola introdusa este prea mica", "Error");
                    return;
                }

                WebHelper.LoggedSuccess += (o, ew) => this.BeginInvoke(new MethodInvoker(delegate
                {
                    while (Height < 300)
                    {
                        Height++;
                        System.Threading.Thread.Sleep(1);
                        if (Height + 1 == 300)
                        {
                            button2.Visible = true;
                            button3.Visible = true;
                            panel1.Visible = true;
                        }
                    };
                    button1.Text = "Log Out";
                    textBoxLogin.Enabled = false;
                    textBoxPass.Enabled = false;
                }));
                WebHelper.LooadedAllMails += (o, ew) => this.BeginInvoke(new MethodInvoker(delegate { button3.Enabled = true; button3.Text = "Open Mails"; }));
                _listMailsRecieved = await WebHelper.GmailsRetrievePOPAsync(IsSSL, Port, HostName, textBoxLogin.Text, textBoxPass.Text);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var _formSendMessage = new FormSendMail(textBoxLogin.Text, textBoxPass.Text);
            _formSendMessage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(_listMailsRecieved.Count == 0))
            {
                ShowAllMailsForm _formShowEmails = new ShowAllMailsForm(_listMailsRecieved);
                _formShowEmails.Show();
            }
            else
            {
                MessageBox.Show("Posta nu contine nici un Mail");
            }
        }
    }
}
