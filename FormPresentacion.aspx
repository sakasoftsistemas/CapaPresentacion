<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="FormPresentacion.aspx.cs" Inherits="CapaPresentacion.FormPresentacion" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <asp:Panel ID="Panel1" Width="250" runat="server" Height="300px">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton CommandName="next" Width="150" Height="150" ID="ImageButton1" runat="server" ImageUrl='<%#Eval("imagen") %>' CommandArgument='<%#Eval("idPresentacion") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; color: #0020D4; font-size: 15px;">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("descripcion")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
