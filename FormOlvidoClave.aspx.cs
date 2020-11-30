using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace CapaPresentacion
{
    public partial class FormOlvidoClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nroDocumento = txtdocumento.Text;
            string correo = txtcorreo.Text;
            Random rdn = new Random();
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string nuevaClave = "";
            for (int i = 0; i < 6; i++)
            {
                int numero = rdn.Next(0, 25);
                nuevaClave += letras[numero];
            }
            int r = usuario_ne.validarCorreo(nroDocumento, correo);
            if (r > 0)
            {
                Boolean flag = usuario_ne.actualizarClave(nroDocumento, nuevaClave);
                if (flag)
                {
                    enviarCorreo("Nueva clave de acceso", nuevaClave, "recatore18@gmail.com", "", "recatore_18@hotmail.com");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Se ha enviado su nueva clave a su correo')</script>");
                    txtdocumento.Text = "";
                    txtcorreo.Text = "";
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Los datos que ha proporcionado no existen')</script>");
            }
        }
        private void enviarCorreo(string asunto, string mensaje, string remitente, string claveRemitente, string destino)
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