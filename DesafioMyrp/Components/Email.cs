using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DesafioMyrp.Models
{
    public class Email
    {
        public string Destinatario { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string Anexo { get; set; }

        private const string email = "myrpgregory@gmail.com";
        private const string senha = "Abc12345!@#";
        private const string host = "smtp.gmail.com";
        private const int porta = 587;

        public Email(string destinatario, string titulo, string corpo, string anexo)
        {
            Destinatario = destinatario;
            Titulo = titulo;
            Corpo = corpo;
            Anexo = anexo;
        }

        public bool EnviarEmail(out string mensagem)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = porta;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(email, senha);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(email);
                        mail.To.Add(new MailAddress(Destinatario));
                        mail.Subject = Titulo;
                        mail.Body = Corpo;
                        mail.Attachments.Add(new Attachment(Anexo));

                        smtp.Send(mail);

                        mensagem = string.Empty;
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                mensagem = e.Message;
                return false;
            }
        }
    }

}