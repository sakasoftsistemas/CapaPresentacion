
using System;
using System.Collections.Generic;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class _tipoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static List<tipoProducto> obtenerTipoProductos()
        {
            return tipoProducto_ne.obtenerTipoProductos();
        }
    }
}