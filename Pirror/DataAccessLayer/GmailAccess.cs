using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
//using EAGetMail;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Pirror.Model;

namespace Pirror.DataAccessLayer
{
    class GmailAccess
    {
//        private MailServer _oServer;
//        private MailClient _oClient;
//
//        private Stack<MailInfo> _mailInfoStack = new Stack<MailInfo>();
        private List<Email> _processedEmails = new List<Email>();

        private ImapClient _mailClient;

        public void CheckMail()
        {
            _mailClient = new ImapClient();
            _mailClient.ConnectAsync("imap.gmail.com", 993, true);
            _mailClient.Connected += OnClientConnected;

        }

        private void OnClientConnected(object sender, EventArgs eventArgs)
        {
            _mailClient.Authenticated += OnClientAuthenticated;
            _mailClient.AuthenticateAsync("linas.martusevicius@gmail.com", "spaikas22");

        }

        private void OnClientAuthenticated(object sender, AuthenticatedEventArgs authenticatedEventArgs)
        {
            _processedEmails.Clear();
            var inbox = _mailClient.Inbox;
            inbox.Open(FolderAccess.ReadOnly);


            Debug.WriteLine("~~~ Total messages: {0}", inbox.Count);
            Debug.WriteLine("~~~ Recent messages: {0}", inbox.Recent);
            Debug.WriteLine("~~~ Unread messages: {0}", inbox.Unread);


            var query = SearchQuery.GMailRawSearch("is:unread in:inbox -category:promotions");

            foreach (var uid in inbox.Search(query))
            {
                var message = inbox.GetMessage(uid);
//                Debug.WriteLine($"~~~ {uid}: {message.Subject}:");

                string nameToDisplay;
                if (message.Sender != null)
                {
                    var senderName = message.Sender.ToString();
                    var senderAddress = message.Sender.Address;
                    if (string.IsNullOrEmpty(senderName))
                    {
                        nameToDisplay = senderAddress;
                    }
                    else
                    {
                        nameToDisplay = senderName;
                    }
                }
                else
                {
                    nameToDisplay = message.From.ToString().Replace("\"",string.Empty).Replace("<", "- ").Replace(">",string.Empty);
                }

                var toAdd = new Email(nameToDisplay, message.Subject, message.TextBody);
                Debug.WriteLine(toAdd.ToString());
                _processedEmails.Add(toAdd);
                
            }

            _mailClient.DisconnectAsync(true);
            OnMailChecked(new MailArgs(_processedEmails));
        }

        public event EventHandler MailChecked;

        protected virtual void OnMailChecked(MailArgs e)
        {
            Debug.WriteLine("!!! - OnMailCheckedFired");
            this.MailChecked?.Invoke(this, e);
        }
    }

    public class MailArgs : EventArgs
    {
        private readonly List<Email> _mailList;

        public MailArgs(List<Email> emails)
        {
            _mailList = emails;
        }

        public List<Email> PiMails
        {
            get { return _mailList; }
        }
    }
}
