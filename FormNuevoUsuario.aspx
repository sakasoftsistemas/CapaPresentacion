<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormNuevoUsuario.aspx.cs" Inherits="CapaPresentacion.FormNuevoUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles/NuevoUsuario.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form runat="server">
        <h5>Nuevo usuario</h5>
        <label for="fechaNacimiento">Tipo&nbsp;usuario:&nbsp;</label>
        <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoUsuario_SelectedIndexChanged"></asp:DropDownList>
        <label for="dni">Documento/Ruc:&nbsp;</label>
        <asp:TextBox name="dni" ID="numerodocumento" runat="server" MaxLength="11" placeholder="Documento/Ruc"></asp:TextBox>

        <label for="nombre">Nombre:&nbsp;</label>
        <asp:TextBox name="nombre" ID="nombre" runat="server" placeholder="Nombre"></asp:TextBox>

        <label for="apellidoPaterno">Ap&nbsp;pater:&nbsp;</label>
        <asp:TextBox name="apellidoPaterno" ID="apellidoPaterno" runat="server" placeholder="Ape paterno"></asp:TextBox>

        <label for="apellidoMaterno">Ap&nbsp;mater:&nbsp;</label>
        <asp:TextBox name="apellidoMaterno" ID="apellidoMaterno" runat="server" placeholder="Ape materno"></asp:TextBox>


        <label for="direccion">Direcci&oacute;n:&nbsp;</label>
        <asp:TextBox name="direccion" ID="direccion" runat="server" placeholder="Direccion"></asp:TextBox>

        <label for="telefono">Telefono:&nbsp;</label>
        <asp:TextBox name="telefono" ID="telefono" runat="server" placeholder="Telefono"></asp:TextBox>

        <label for="telefono">Razon social:&nbsp;</label>
        <asp:TextBox name="telefono" ID="txtrazonsical" runat="server" placeholder="Razon social"></asp:TextBox>



        <label for="correo">Correo:&nbsp;</label>
        <asp:TextBox name="correo" ID="correo" runat="server" placeholder="Correo"></asp:TextBox>

        <label for="usuario">Usuario:&nbsp;</label>
        <asp:TextBox name="usuario" ID="usuario" runat="server" placeholder="Usuario"></asp:TextBox>

        <label for="clave">Clave:&nbsp;</label>
        <asp:TextBox name="clave" TextMode="Password" ID="clave" runat="server" placeholder="Clave"></asp:TextBox>

        <label for="clave">Conf Clave:&nbsp;</label>
        <asp:TextBox name="clave" TextMode="Password" ID="ConfClave" runat="server" placeholder="Confirme Clave"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Registrar" OnClick="Button1_Click" />
    </form>
</body>
</html>
