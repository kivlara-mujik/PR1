using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop.Pop3;

namespace Lab4PR
{
    class WebHelper
    {

        public static bool IsEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public static Task<List<OpenPop.Mime.Message>> GmailsRetrievePOPAsync(bool UseSSL, int Port, string Hostname, string Login, string Password)
        {

            return Task.Run(() =>
            {
                List<OpenPop.Mime.Message> _emailList = new List<OpenPop.Mime.Message>();
                if (!CheckForInternetConnection())
                    return _emailList;
                using (Pop3Client _pop3Client = new Pop3Client())
                {
                    _pop3Client.Connect(Hostname, Port, UseSSL);
                    try
                    {
                        _pop3Client.Authenticate("recent:" + Login, Password, AuthenticationMethod.UsernameAndPassword);
                    }
                    catch
                    {
                        MessageBox.Show("Wrong credentials", "Error");
                        return _emailList;
                    }

                    //autentificat cu success
                    OnLoggedSuccess(EventArgs.Empty);

                    int MailsCount = _pop3Client.GetMessageCount();

                    for (var i = MailsCount; i > 0; i--)
                    {
                        _emailList.Add(_pop3Client.GetMessage(i));
                    }
                    OnLoadedAllMails(EventArgs.Empty);
                }
                return _emailList;

            });

        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("No internet connection found!", "Error");
                return false;
            }
        }
        public static void OnLoggedSuccess(EventArgs e)
        {
            EventHandler handler = LoggedSuccess;
            if (handler != null)
            {
                handler(new object(), e);
            }
        }
        public static void OnLoadedAllMails(EventArgs e)
        {
            EventHandler handler = LooadedAllMails;
            if (handler != null)
            {
                handler(new object(), e);
            }
        }

        public static event EventHandler LoggedSuccess;
        public static event EventHandler LooadedAllMails;

    }
}
