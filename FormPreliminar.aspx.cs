using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FormPreliminar : System.Web.UI.Page
    {
        double gSubtotal = 0;
        double gValorVenta = 0;
        double gAnticipo = 0;
        double igv = 0;
        double gDescuento = 0;
        double gIsc = 0;
        double gIgv = 0;
        double gOtroCargo = 0;
        double gOtrostributos = 0;
        double gImportetotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            List<empresa> listaEmoresa = empresa_ne.obtenerEmpresa(Convert.ToInt32(Session["idEmpresa"]));
            txtnombrecomercial.Text = listaEmoresa[0].nombreComercial.ToUpper();
            txtrazonsocial.Text = listaEmoresa[0].nombreEmpresa.ToUpper();
            txtdireccion.Text = listaEmoresa[0].direccion.ToUpper();
            txtlugar.Text = listaEmoresa[0].departamento.ToUpper() + " " + listaEmoresa[0].provincia.ToUpper() + " " + listaEmoresa[0].distrito.ToUpper();
            lblruc.Text = listaEmoresa[0].ruc;

            List<usuario> listaUsuario = usuario_ne.dataUsuario(Session["idUsuario"].ToString());
            txtnombrecliente.Text = listaUsuario[0].nombres.ToUpper() + " " + listaUsuario[0].apePaterno.ToUpper() + " " + listaUsuario[0].apeMaterno.ToUpper();
            txtnrodocumento.Text = listaUsuario[0].nroDocumento;
            txtdireccionclinte.Text = listaUsuario[0].direccion;

            txtTituloDocumento.Text = (listaUsuario[0].idTipoUsuario == 1) ? "FACTURA ELECTRÓNICA" : "BOLETA ELECTRÓNICA";

            gridViewDetalle.DataSource = preferencesPedido.listaDetalle;
            gridViewDetalle.DataBind();
            int longitud = preferencesPedido.listaDetalle.Count;
            for (int i = 0; i < longitud; i++)
            {
                gSubtotal += Convert.ToDouble(preferencesPedido.listaDetalle[i].precio);
            }
            txtsubtotal.Text = " S/ " + gSubtotal;
            txtanticipo.Text = " S/ " + gAnticipo;
            txtdescuento.Text = " S/ " + gDescuento;
            gValorVenta = gSubtotal;
            txtvalorventa.Text = " S/ " + gValorVenta;
            txtisc.Text = " S/ " + gIsc;
            gIgv = (gSubtotal * 18) / 100;
            txtigv.Text = " S/ " + gIgv;
            txtotroscargos.Text = " S/ " + gOtroCargo;
            txtotrostributos.Text = " S/ " + gOtrostributos;
            gImportetotal = (gSubtotal + gIgv);
            txtimportetotal.Text = " S/ " + gImportetotal;
        }



        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            string fechaVencimiento = "2019-12-08";
            int idUsuario = Convert.ToInt32(Session["idUsuario"].ToString());
            string subTotal = Convert.ToString(gSubtotal);
            string anticipo = Convert.ToString(gAnticipo);
            string descuento = Convert.ToString(gDescuento);
            string valorVenta = Convert.ToString(gValorVenta);
            string isc = Convert.ToString(gIsc);
            string igv = Convert.ToString(gIgv);
            string otroCargo = Convert.ToString(gOtroCargo);
            string otroTributo = Convert.ToString(gOtrostributos);
            string importeTotal = Convert.ToString(gImportetotal);
            int idTipoMoneda = 1;
            int idTipoUsuario = Convert.ToInt32(Session["idTipoUsuario"]);
            string[] rppta = factura_ne.registrarFactura(
                  fechaVencimiento,
                               idUsuario,
               subTotal,
               anticipo,
               descuento,
               valorVenta,
               isc,
               igv,
               otroCargo,
               otroTributo,
               importeTotal,
               idTipoMoneda,
               idTipoUsuario
                  );
            if (rppta.Length > 0)
            {
                int contador = 0;
                int limite = preferencesPedido.listaDetalle.Count;
                foreach (detalleFactura det in preferencesPedido.listaDetalle)
                {
                    contador++;
                    detalleFactura_ne.registrarDetalleFactura(det.idProducto, det.cantidad, det.precio);
                }
                if (contador == limite)
                {
                    preferencesPedido.listaDetalle.Clear();
                    preferencesPedido.listaCabecera.Clear();
                    Response.Redirect("~/FormdocumentoEmitido.aspx?serieFactura=" + rppta[0] + "&numFactura=" + rppta[1]);
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FormDocumento.aspx");
        }
    }
}