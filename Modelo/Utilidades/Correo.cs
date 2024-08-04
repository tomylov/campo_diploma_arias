using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Modelo.Utilidades
{
    public class Correo
    {

        private string _fromEmail = "hard-soft.tienda@hotmail.com";
        private string _clave = "";
        private string _smtpHost = "smtp.office365.com"; // Configura según tu servidor SMTP
        private int _smtpPort = 587; // Puerto SMTP para TLS

        public void SendEmail(string subject, string body, string toEmail)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                message.To.Add(toEmail);

                using (var client = new SmtpClient(_smtpHost, _smtpPort))
                {
                    client.Credentials = new NetworkCredential(_fromEmail, _clave);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
