using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class Maestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<tipoProducto> lista = tipoProducto_ne.obtenerTipoProductos();
            if (Session["usuario"] != null)
            {
                lbluser.Text = Session["usuario"].ToString();
            }
        }

        protected void lnkCallHyperlink_Click(object sender, EventArgs e)
        {
            hlDetails_Click(null, null);
        }
        protected void hlDetails_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            preferencesPedido.listaDetalleCopia.Clear();
            Response.Redirect("~/Home.aspx");
        }
    }
}