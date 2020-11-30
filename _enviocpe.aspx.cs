using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

using System.Web.Services;


namespace CapaPresentacion
{
    public partial class _enviocpe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            enviarCorreo("CPE", "Hola su comprabante de pago electronico es:", "recatore18@gmail.com", "xmlqstnoja171"
                           , "recatore_18@hotmail.com");
        }
        [System.Web.Services.WebMethod]
        public static void enviarcomprobantes()
        {
            enviarCorreo("CPE","Hola su comprabante de pago electronico es:","recatore18@gmail.com","xmlqstnoja171"
                ,"recatore_18@hotmail.com");
        }
        public static void enviarCorreo(string asunto, string mensaje, string remitente, string claveRemitente, string destino)
        {
            MailMessage message = new MailMessage();

            message.To.Add(new MailAddress(destino));
            message.Subject = asunto;
            message.SubjectEncoding = Encoding.UTF8;

            message.Body = mensaje;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.From = new MailAddress(remitente);

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(remitente, claveRemitente);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";

            smtp.Send(message);
        }
    }

}