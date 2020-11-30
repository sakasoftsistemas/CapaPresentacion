using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
namespace CapaPresentacion
{
    public partial class FormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = login.Text;
            string clave = password.Text;
            if (!usuario.Equals("") && !clave.Equals(""))
            {
                List<usuario> lista = login_ne.iniciarSesion(usuario, clave);
                if (lista.Count > 0)
                {
                    Session["idUsuario"] = Convert.ToString(lista[0].idUsuario);
                    Session["usuario"] = lista[0].nombres + " " + lista[0].apePaterno + " " + lista[0].apeMaterno;
                    Session["idEmpresa"] = Convert.ToString(lista[0].idEmpresa);
                    Session["idTipoUsuario"] = Convert.ToString(lista[0].idTipoUsuario);
                    preferencesPedido.listaCabecera.Clear();
                    preferencesPedido.listaDetalle.Clear();
                    preferencesPedido.listaDetalleCopia.Clear();
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('El usuario no existe')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Usuario o contraseña incorrecto')</script>");
            }
        }
    }
}