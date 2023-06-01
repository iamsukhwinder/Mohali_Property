using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public class SendEmail
    {
        public void Sendmail(string tosend, string subject, string body)
        {
            String SendMailFrom = "uic.17bca1097@gmail.com";
            String SendMailTo = tosend;// my office email id
            String SendMailSubject = subject;
            String SendMailBody = body;

            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage email = new MailMessage();
                // START
                email.From = new MailAddress(SendMailFrom);
                email.To.Add(SendMailTo);
                email.CC.Add(SendMailFrom);
                email.Subject = SendMailSubject;
                email.Body = SendMailBody;
                email.IsBodyHtml = true;
                //END
                SmtpServer.Timeout = 10000;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "uzglmarzmwvvibzq");
                SmtpServer.Send(email);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
