<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Progra2Proyecto.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />        
    <link href="css/login.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <div class="wrapper">
        <div class="formcontent">
            <form id="formulario_login" runat="server">
                <div class="form-control">
                    <div class="row">
                        <asp:Label runat="server" CssClass="alert-danger" ID="LblError"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:Label class="h2" ID="LblLogin" runat="server" Text="Bienvenido/a"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="LblUser" runat="server" Text="Usuario:"></asp:Label>
                        <asp:TextBox ID="TxtUser" CssClass="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="LblPassword" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="TxtPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <hr />                    
                    
                    <div class="row">
                        <asp:Button ID="BtnIngresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>   
</body>
</html>
