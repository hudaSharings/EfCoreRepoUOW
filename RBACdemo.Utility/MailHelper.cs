using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Utility
{
   public class MailHelper
    {
        // constants
        private const string HtmlEmailHeader = "<html><head><title></title></head><body style='font-family:arial; font-size:14px;'>";
        private const string HtmlEmailFooter = "</body></html>";

        // properties
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailServerName { get; set; }
        // constructor
        public MailHelper()
        {
            To = new List<string>();
            CC = new List<string>();
            BCC = new List<string>();
        }

        // send
        public async Task Send()
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            foreach (var x in To)
            {
                message.To.Add(x);
            }
            foreach (var x in CC)
            {
                message.CC.Add(x);
            }
            foreach (var x in BCC)
            {
                message.Bcc.Add(x);
            }

            message.Subject = Subject;
            message.Body = string.Concat(HtmlEmailHeader, Body, HtmlEmailFooter);
            message.BodyEncoding = Encoding.UTF8;
            message.From = new MailAddress(From);
            message.SubjectEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(MailServerName);

            //new Thread(() => { client.Send(message); }).Start();
            await client.SendMailAsync(message);
        }



    }
}
