<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="FormPreliminar.aspx.cs" Inherits="CapaPresentacion.FormPreliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
  .contenedor-global {
            text-align: center;
            width: 800px;
            margin: auto;
            border: 1px solid;
            overflow: hidden;
            padding: 2px;
        }

        .cabecera {
            text-align: center;
            margin: auto;
            border-bottom: 1px solid;
            border-top: 1px solid;
            overflow: hidden;
        }

        .izquerda {
            margin: 2px;
            float: left;
            text-align: right;
            padding: 4px;

        }

        .derecho {
            margin-top: 20px;
            float: right;
            text-align: center;
            padding: 10px;
            margin-right: 30px;
            border:1px solid;
        }

        .detalle {
            margin-top: 2px;
            border: 1px solid;
        }

        .cont-detalle {
            text-align: center;
            overflow: hidden;
        }

        .calculos {
            margin-top: 2px;
        }

        .cont-calculos {
            text-align: right;
            overflow: hidden;
        }

        .botones {
            margin-top: 10px;
            position: abasolute;
            text-align: center;
            padding: 4px;
        }

        #txtnombrecomercial,
        #txtrazonsocial,
        #txtdireccion,
        #txtlugar {
            width: 300px;
        }

        .titulogeneral {
            text-align: center;
            padding: 5px;
            font-weight: bold;
            font-size: 17px;
        }

        .cabeceraabajo {
            margin: 2px;
            padding: 4px;
            text-align: right;
            width: 500px;
        }

        .datacliente {
            width: 360px;
        }
        #btnSiguiente{
            padding:4px;
        }
    </style>



    <div class="main-content">
       <div class="contenedor-global">
        <div class="titulogeneral">
            PRELIMINAR DE COMPROBANTE ELECTRONICA
        </div>
        <div class="cabecera">
            <div class="izquerda">
                <asp:TextBox class="datacliente" ReadOnly ID="txtnombrecomercial" runat="server"></asp:TextBox><br />
                  <asp:TextBox class="datacliente" ReadOnly ID="txtrazonsocial" runat="server"></asp:TextBox><br />
                  <asp:TextBox class="datacliente" ReadOnly ID="txtdireccion" runat="server"></asp:TextBox><br />
                  <asp:TextBox class="datacliente" ReadOnly ID="txtlugar" runat="server"></asp:TextBox>
            </div>
            <div class="derecho">
                <asp:Label ID="txtTituloDocumento" runat="server" Text="Label"></asp:Label><br />
                RUC&nbsp;<asp:Label ID="lblruc" runat="server" Text="Label"></asp:Label><br />
            </div>
        </div>
        <div class="cabeceraabajo">
            Fecha&nbsp;vencimiento:&nbsp;<asp:TextBox class="datacliente"  ID="TextBox1" runat="server"></asp:TextBox><br />
            Fecha&nbsp;emision:&nbsp;<asp:TextBox class="datacliente"  ID="txtfechaemision" runat="server"></asp:TextBox><br />
            Señor(es):&nbsp;<asp:TextBox class="datacliente" ReadOnly ID="txtnombrecliente" runat="server"></asp:TextBox><br />
            Documento:&nbsp;<asp:TextBox class="datacliente" ReadOnly ID="txtnrodocumento" runat="server"></asp:TextBox><br />
            Direccion:&nbsp;cliente:&nbsp;<asp:TextBox ReadOnly class="datacliente"  ID="txtdireccionclinte" runat="server"></asp:TextBox><br />
            Tipo:&nbsp;moneda:&nbsp;<asp:TextBox class="datacliente" ReadOnly ID="txttipomoneda" runat="server"></asp:TextBox><br />
            Observacion:&nbsp;<asp:TextBox class="datacliente" ReadOnly  ID="txtobservacion" runat="server"></asp:TextBox><br />
        </div>
        <div class="detalle">
            <div class="cont-detalle">
 <asp:GridView Width="800px" HorizontalAlign="Center" ID="gridViewDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                    <Columns>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="idProducto" HeaderText="ID Producto">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="descripcion" HeaderText="Producto">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="cantidad" HeaderText="Cantidad">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="precio" HeaderText="Precio">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
        </div>
        <div class="calculos">
            <div class="cont-calculos">
                Sub&nbsp;total:&nbsp;ventas:&nbsp;<asp:TextBox class="" ReadOnly ID="txtsubtotal" runat="server"></asp:TextBox><br />
                Anticipo:&nbsp;<asp:TextBox class="" ReadOnly ID="txtanticipo" runat="server"></asp:TextBox><br />
                Descuento:&nbsp;<asp:TextBox class="" ReadOnly ID="txtdescuento" runat="server"></asp:TextBox><br />
                Valor&nbsp;venta:&nbsp;<asp:TextBox class="" ReadOnly  ID="txtvalorventa" runat="server"></asp:TextBox><br />
                ISC:&nbsp;;<asp:TextBox class=""  ID="txtisc" ReadOnly runat="server"></asp:TextBox><br />
                IGV:&nbsp;<asp:TextBox class=""  ID="txtigv" ReadOnly runat="server"></asp:TextBox><br />
                Otros&nbsp;cargos:&nbsp;<asp:TextBox class="" ReadOnly ID="txtotroscargos" runat="server"></asp:TextBox><br />
                Otros:&nbsp;tributos:&nbsp;<asp:TextBox class="" ReadOnly ID="txtotrostributos" runat="server"></asp:TextBox><br />
                Importe:&nbsp;total:&nbsp;<asp:TextBox class="" ReadOnly ID="txtimportetotal" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="botones"><br />
              <asp:Button ID="btnAtras" Height="40" Width="100" runat="server" Text="Atras" OnClick="btnAtras_Click"  />
            <asp:Button ID="btnSiguiente" Height="40" Width="100" runat="server" Text="Emitir" OnClick="btnSiguiente_Click" />
        </div>
    </div>

    </div>

    
   
</asp:Content>
