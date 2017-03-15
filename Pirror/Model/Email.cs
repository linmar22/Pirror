using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirror.Model
{
    public class Email
    {
        public Email(string sender, string subject, string body)
        {
            Sender = sender;
            Subject = subject;
            Body = body;
        }

        public string Sender { get; }

        public string Subject { get; }

        public string Body { get; }

        public override string ToString()
        {
            return $"Sender: {Sender}, Subject: {Subject}, Body: {Body}";
        }
    }
}
