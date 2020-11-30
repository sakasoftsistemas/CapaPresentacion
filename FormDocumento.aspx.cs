using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FormDocumento : System.Web.UI.Page
    {
        double subtotal = 0;
        double valorVenta = 0;
        double igv = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<usuario> lista = usuario_ne.dataUsuario(Session["idUsuario"].ToString());
            txtnumerodocumento.Text = lista[0].nroDocumento;
            txtrazonsocial.Text = lista[0].nombres + " " + lista[0].apePaterno + " " + lista[0].apeMaterno;
            txtdireccioncliente.Text = lista[0].direccion;

            cargarDatos();


            int longitud = preferencesPedido.listaDetalle.Count;
            for (int i = 0; i < longitud; i++)
            {
                subtotal += Convert.ToDouble(preferencesPedido.listaDetalle[i].precio);
            }
            txtsubtotal.Text = " S/ " + subtotal;
            txtanticipo.Text = " S/ 0";
            txtdescuento.Text = " S/ 0";
            valorVenta = subtotal;
            txtvalorventa.Text = " S/ " + valorVenta;
            txtisc.Text = " S/ 0";
            igv = (subtotal * 18) / 100;
            txtigv.Text = " S/ " + igv;
            txtotroscargos.Text = " S/ 0";
            txtotrostributos.Text = " S/ 0";
            txtimportetotal.Text = " S/ " + (subtotal + igv);
        }

        private void cargarDatos()
        {
            gridViewDetalle.DataSource = preferencesPedido.listaDetalle;
            gridViewDetalle.DataBind();
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (preferencesPedido.listaDetalle.Count > 0)
            {
                Response.Redirect("~/FormPreliminar.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El pedido no puede quedar vacío')", true);
            }
        }

        protected void gridViewDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int cont = 1;
            int itemNum = Convert.ToInt32(gridViewDetalle.Rows[i].Cells[0].Text);
            for (int ii = 0; ii < preferencesPedido.listaDetalle.Count; ii++)
            {
                if (preferencesPedido.listaDetalle[ii].idProducto == itemNum)
                {
                    preferencesPedido.listaDetalle.RemoveAll(x => x.numItem == itemNum);
                    preferencesPedido.listaDetalleCopia.RemoveAll(x => x.numItem == itemNum);
                    break;
                }
                cont++;
            }
            cargarDatos();
        }
    }
}