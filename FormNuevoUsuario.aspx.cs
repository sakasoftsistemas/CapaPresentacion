using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
using System.Drawing;

namespace CapaPresentacion
{
    public partial class FormNuevoUsuario : System.Web.UI.Page
    {
        private static string idTipoUsuario = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<tipoUsuario> lista = tipoUsuario_ne.obtenerTipoUsuario();
                ddlTipoUsuario.DataSource = lista;
                ddlTipoUsuario.DataTextField = "descripcion";
                ddlTipoUsuario.DataValueField = "idTipoUsuario";
                ddlTipoUsuario.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string doc = "";
            doc = numerodocumento.Text;
            string nombres = "";
            string apellidoP = "";
            apellidoP = apellidoPaterno.Text;
            string apellidoM = "";
            apellidoM = apellidoMaterno.Text;
            string direcc = "";
            direcc = direccion.Text;
            string telef = "";
            telef = telefono.Text;
            if (nombre.Text.ToString().Equals(""))
                nombres = txtrazonsical.Text;
            else
                nombres = nombre.Text;
            //string ruc = txtruc.Text;
            string corre = "";
            corre = correo.Text;
            string user = "";
            user = usuario.Text;
            string clav = "";
            clav = clave.Text;
            string confcla = "";
            confcla = ConfClave.Text;
            if (!doc.Equals("") && !nombres.Equals("") && !direcc.Equals("") && !telef.Equals("") && !corre.Equals("") && !user.Equals("") && !clav.Equals("") && !confcla.Equals(""))
            {
                if (clav.Equals(confcla))
                {
                    Boolean flag = usuario_ne.registrarusuario(Convert.ToInt32(idTipoUsuario), doc, nombres, apellidoP, apellidoM, direcc, telef, corre, user, clav);
                    if (flag)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Usuario creado con exito')</script>");
                        Response.Redirect("FormLogin.aspx");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Las contraseñas no coinciden')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Faltan datos')</script>");
            }
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipoUsuario = ddlTipoUsuario.SelectedValue;
            if (idTipoUsuario.Equals("1"))
            {
                apellidoPaterno.Enabled = false;
                apellidoMaterno.Enabled = false;
                txtrazonsical.Enabled = true;
                nombre.Enabled = false;
                nombre.BackColor = Color.FromArgb(153, 153, 153);
                apellidoPaterno.BackColor = Color.FromArgb(153, 153, 153);
                apellidoMaterno.BackColor = Color.FromArgb(153, 153, 153);
                txtrazonsical.BackColor = Color.FromArgb(246, 246, 246);
            }
            else
            {
                apellidoPaterno.Enabled = true;
                apellidoMaterno.Enabled = true;
                txtrazonsical.Enabled = false;
                nombre.Enabled = true;
                apellidoPaterno.BackColor = Color.FromArgb(246, 246, 246);
                apellidoMaterno.BackColor = Color.FromArgb(246, 246, 246);
                txtrazonsical.BackColor = Color.FromArgb(153, 153, 153);
                nombre.BackColor = Color.FromArgb(246, 246, 246);
            }
        }
    }
}