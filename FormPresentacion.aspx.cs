using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FormPresentacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idTipoProducto = Request.QueryString["idTipoProducto"].ToString();
                ObtenerPresentacion(Convert.ToInt32(idTipoProducto));
            }
        }
        private void ObtenerPresentacion(int idTipoProducto)
        {
            List<presentacion> lista = presentacion_ne.obtenerPresentacion(idTipoProducto);
            DataList1.DataSource = lista;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "next")
            {
                Response.Redirect("FormProductos.aspx?idPresentacion=" + e.CommandArgument.ToString());
            }
        }
    }
}