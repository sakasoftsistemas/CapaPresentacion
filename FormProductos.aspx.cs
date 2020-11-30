using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FormProductos : System.Web.UI.Page
    {
         int numItem = preferencesPedido.listaDetalle.Count;
        static List<producto> lista;
        static int contador = 0;
        detalleFactura cabecera = new detalleFactura();
        detalleFactura detalle;

        int idUsuario = 1;
        double subTotal = 20;
        double anticipo = 20;
        double descuento = 20;
        double valorVenta = 20;
        double isc = 20;
        double igv = 20;
        double otroCargo = 20;
        double otroTributo = 20;
        double importeTotal = 20;
        int idTipoMoneda;

        int idProducto = 17;
        int cantidad;
        double precio;
        protected void Page_Load(object sender, EventArgs e)
        {
            numItem = preferencesPedido.listaDetalle.Count;
            if (!Page.IsPostBack)
            {

                string idPresentacion = Request.QueryString["idPresentacion"].ToString();
                lista = producto_ne.obtenerProductos(Convert.ToInt32(idPresentacion));
                obtenerProductos(lista);
            }
        }
        private void obtenerProductos(List<producto> lista)
        {
            listaDatos.DataSource = lista;
            listaDatos.DataBind();
        }
        protected void listaDatos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            /*if (e.CommandName == "add")
            {
                int posicion = e.Item.ItemIndex;
                idproducto_name.Text = Convert.ToString(lista[posicion].idProducto);

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' UNO " + e.CommandArgument.ToString() + "')", true);
            }*/
            //else

            if (e.CommandName == "add")
            {
                if (contador >= 0)
                {
                    if (contador == 0)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' UNO " + e.CommandArgument.ToString() + "')", true);
                    }
                    int posicion = e.Item.ItemIndex;
                    detalle = new detalleFactura();
                    numItem++;
                    detalle.numItem = preferencesPedido.listaDetalle.Count+1;
                    detalle.idProducto = lista[posicion].idProducto;
                    detalle.descripcion = lista[posicion].descripcion;
                    detalle.cantidad = 1;
                    detalle.precio = lista[posicion].precio;

                    preferencesPedido.listaDetalle.Add(detalle);
                    preferencesPedido.listaDetalleCopia.Add(detalle);

                }
                contador++;
            }
            if (e.CommandName == "fin")
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/FormLogin.aspx");
                }
                else
                {
                    if (preferencesPedido.listaDetalle.Count > 0)
                    {
                        Response.Redirect("~/FormDocumento.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No hay productos agregados al carrito')", true);
                    }
                }
            }
        }


        protected void listaDatos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string behaviorID = "mpe1Behavior" + modalPanel.ClientID;


                // modalPopupExtender1.BehaviorID = behaviorID;


                //button1.OnClientClick = string.Format("$find('{0}').hide()", behaviorID);
            }
        }
    }
}