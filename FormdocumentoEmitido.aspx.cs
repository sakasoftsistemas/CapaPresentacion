using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace CapaPresentacion
{
    public partial class FormdocumentoEmitido : System.Web.UI.Page
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
            string serieFactura = Request.QueryString["serieFactura"];
            string numFactura = Request.QueryString["numFactura"];
            List<detalleFactura> lista = detalleFactura_ne.consultarDetalleRegistrado(serieFactura, numFactura);
            gridViewDetalle.DataSource = lista;
            gridViewDetalle.DataBind();



            List<empresa> listaEmoresa = empresa_ne.obtenerEmpresa(Convert.ToInt32(Session["idEmpresa"]));
            txtnombrecomercial.Text = listaEmoresa[0].nombreComercial.ToUpper();
            txtrazonsocial.Text = listaEmoresa[0].nombreEmpresa.ToUpper();
            txtdireccion.Text = listaEmoresa[0].direccion.ToUpper();
            txtlugar.Text = listaEmoresa[0].departamento.ToUpper() + " " + listaEmoresa[0].provincia.ToUpper() + " " + listaEmoresa[0].distrito.ToUpper();
            lblruc.Text = listaEmoresa[0].ruc;
            lblnroComprobante.Text = serieFactura + "-" + numFactura;


            List<usuario> listaUsuario = usuario_ne.dataUsuario(Session["idUsuario"].ToString());
            txtnombrecliente.Text = listaUsuario[0].nombres.ToUpper() + " " + listaUsuario[0].apePaterno.ToUpper() + " " + listaUsuario[0].apeMaterno.ToUpper();
            txtnrodocumento.Text = listaUsuario[0].nroDocumento;
            txtdireccionclinte.Text = listaUsuario[0].direccion;

            lbltitulodocumento.Text = (listaUsuario[0].idTipoUsuario == 2) ? "BOLETA ELECTRÓNICA" : "FACTURA ELECTRÓNICA";

            gridViewDetalle.DataSource = preferencesPedido.listaDetalleCopia;
            gridViewDetalle.DataBind();

            int longitud = preferencesPedido.listaDetalleCopia.Count;
            for (int i = 0; i < longitud; i++)
            {
                gSubtotal += Convert.ToDouble(preferencesPedido.listaDetalleCopia[i].precio);
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

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            // Render ASPX page as HTML formatted string.
            // StringWriter sw = new StringWriter();
            // HtmlTextWriter htw = new HtmlTextWriter(sw);
            // this.Render(htw);

            //Load HTML text to DocumentModel.
            //string html = sw.ToString();
            // FormdocumentoEmitido document = new FormdocumentoEmitido();
            //document.Content.LoadText(html, LoadOptions.HtmlDefault);

            //Convert ASPX to PDF by exporting, downloading,
            //DocumentModel in PDF format from ASP.NET application.
            //document.Save(this.Response, "About.pdf");


            /* Response.ContentType = "application/pdf";
             Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
             Response.Cache.SetCacheability(HttpCacheability.NoCache);
             StringWriter sw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(sw);
             this.Page.RenderControl(hw);
             StringReader sr = new StringReader(sw.ToString());
             Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
             HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
             PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
             pdfDoc.Open();
             htmlparser.Parse(sr);
             pdfDoc.Close();
             Response.Write(pdfDoc);
             Response.End();*/


            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            // Render an HTML document or snippet as a string
            Renderer.RenderHtmlAsPdf("<h1>Hello World</h1>").SaveAs("html-string.pdf");
            // Advanced: 
            // Set a "base url" or file path so that images, javascript and CSS can be loaded  
            var PDF = Renderer.RenderHtmlAsPdf("<img src='icons/iron.png'>", @"C:\site\assets\");
            PDF.SaveAs("html-with-assets.pdf");
        }
    }
}