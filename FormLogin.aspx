<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="CapaPresentacion.FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles/LoginStyle.css" rel="stylesheet" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">

        <h1>Iniciar&nbsp;sesi&oacute;n</h1>
        <div class="inset">
            <p>
                <label for="email">USUARIO</label>
                <asp:TextBox CssClass="input" ID="login" placeholder=" Usuario" runat="server"></asp:TextBox>
            </p>
            <p>
                <label for="password">CONTRASE&Ntilde;A</label>
                <asp:TextBox CssClass="input" ID="password" placeholder=" Contraseña" runat="server" TextMode="Password"></asp:TextBox>
            </p>
        </div>
        <p class="p-container">

            <asp:Button ID="btnIngresar" CssClass="boton" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            <a class="referencia" href="FormNuevoUsuario.aspx">Registrar</a><br />
            <a class="referencia" href="FormOlvidoClave.aspx">¿Olvidó&nbsp;clave?</a>
        </p>
    </form>
</body>
</html>
