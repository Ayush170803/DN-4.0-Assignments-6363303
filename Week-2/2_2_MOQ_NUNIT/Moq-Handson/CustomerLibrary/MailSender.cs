using System.Net;
using System.Net.Mail;

namespace CustomerLibrary
{
    public class MailSender:IMailSender
    {
        public bool SendMail(string toAddress,string message)
        {
            try
            {
                var mail=new MailMessage();
                var smtp=new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("ayushagrawal.5288@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject="Test Mail";
                mail.Body=message;
                smtp.Port=587;
                smtp.Credentials=new NetworkCredential("username","password");
                smtp.EnableSsl=true;
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
