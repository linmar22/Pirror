using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using EAGetMail;
using Pirror.Model;

namespace Pirror.DataAccessLayer
{
    class GmailAccess
    {
        private MailServer _oServer;
        private MailClient _oClient;

        private Stack<MailInfo> _mailInfoStack = new Stack<MailInfo>();
        private List<Email> _processedEmails = new List<Email>();

        public GmailAccess()
        {
            _oServer = new MailServer("imap.gmail.com", "linas.martusevicius@gmail.com", "spaikas22", ServerProtocol.Imap4);
            
            _oClient = new MailClient("TryIt");

            _oClient.Authorized += OnAuthorized;

            _oServer.SSLConnection = true;
            _oServer.Port = 993;
        }

        public async void CheckMail()
        {
            await _oClient.ConnectAsync(_oServer);
        }

        private void OnAuthorized(object sender, ClientStatusEventArgs clientStatusEventArgs)
        {
            Debug.WriteLine("!!! Connected to GMail" + clientStatusEventArgs.Status.ToString());
            CheckMailInternal();
        }

        private void CheckMailInternal()
        {
            try
            {
                var infoResult = _oClient.GetMailInfosAsync();
                infoResult.Completed = ProcessMailInfo;
            }
            catch (Exception ep)
            {
                Debug.WriteLine(ep.Message);
            }
        }

        private void ProcessMailInfo(IAsyncOperation<IList<MailInfo>> asyncInfo, AsyncStatus asyncStatus)
        {
  
            var infoList = asyncInfo.GetResults();
            
            Debug.WriteLine("Result count =" + infoList.Count);

            foreach (var mailInfo in infoList)
            {
                if (!mailInfo.Read)
                {
                    _mailInfoStack.Push(mailInfo);
                }
            }

            ProcessMailStack();

        }

        private void ProcessMailStack()
        {
            if (_mailInfoStack.Count != 0)
            {
                var currentMailInfo = _mailInfoStack.Pop();

                var stuff = _oClient.GetMailAsync(currentMailInfo);
                stuff.Completed = MailDetailsReceived;
            }
            else
            {
                OnMailChecked(new MailArgs(_processedEmails));
            }
        }

        private void MailDetailsReceived(IAsyncOperation<Mail> asyncInfo, AsyncStatus asyncStatus)
        {

            var res = asyncInfo.GetResults();
            
            var toAdd = new Email(res.From.ToString(), res.Subject, res.TextBody);
            _processedEmails.Add(toAdd);

            Debug.WriteLine(toAdd);

            ProcessMailStack();
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

        public List<Email> Weather
        {
            get { return _mailList; }
        }
    }
}
