<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="FormProductos.aspx.cs" Inherits="CapaPresentacion.FormProductos" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="ocultoField" runat="server" />
    <div class="main-content">
        <asp:DataList ID="listaDatos" runat="server" RepeatColumns="4" OnItemCommand="listaDatos_ItemCommand" OnItemDataBound="listaDatos_ItemDataBound">
            <ItemTemplate>
                <asp:Panel ID="Panel1" runat="server" Width="250" Height="300px">
                    <table>
                        <tr>
                            <td align="center">
                                <asp:ImageButton Width="150" Height="150" ID="ImageButton1" runat="server" ImageUrl='<%#Eval("imagen") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; color: #0020D4; font-size: 15px;">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("descripcion")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; color: #0020D4; font-size: 15px;">
                                <asp:Label ID="Label2" runat="server" Text='<%#"S/ "+Eval("precio")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">

                                <!--<asp:ImageButton CausesValidation="true"  class="btn btn-primary" data-toggle="modal" ID="ImageButton2" tite="Agregar" CommandName="add" CommandArgument='<%#Eval("idProducto") %>' runat="server" ImageUrl="~/productos/carritocompra.png" />-->
                                <asp:ImageButton CausesValidation="true" text='<%#"S/ "+Eval("idProducto")%>' tite="Agregar" CommandName="add" CommandArgument='<%#Eval("idProducto") %>' runat="server" ImageUrl="~/productos/carritocompra.png" />
                                <!--data-target="#exampleModal"-->
                                <asp:ImageButton ID="ImageButton3" tite="Finalizar" CommandName="fin" CommandArgument='<%#Eval("idProducto") %>' runat="server" ImageUrl="~/productos/finalizar.png" />

                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>





        <!--<asp:Panel ID="modalPanel" CssClass="popup roundedcorner" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Primer nombre:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox1" Font-Size="Larger" TextMode="SingleLine" runat="server"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Size="Larger" Text="Segundo nombre:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox2" Font-Size="Larger" TextMode="SingleLine" runat="server"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Size="Larger" Text="usuario:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox3" Font-Size="Larger" TextMode="SingleLine" runat="server"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Size="Larger" Text="Ciudad:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox4" Font-Size="Larger" TextMode="SingleLine" runat="server"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Submit" Font-Size="Larger" />
                    </td>
                </tr>
            </table>
        </asp:Panel>-->




    </div>






    
</asp:Content>
