<%@ Page Title="Inicio de Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Progra2Proyecto.Login2" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">                    
                    <hr />
                    <div class="row">
                        <asp:Label runat="server" CssClass="alert-danger" ID="LblError"></asp:Label>
                    </div>
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TxtUser" CssClass="col-md-2 control-label">Usuario:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TxtUser" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtUser"
                                CssClass="text-danger" ErrorMessage="El usuario es requerido." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TxtPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtPassword" 
                                CssClass="text-danger" ErrorMessage="La contraseña es requerida" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server"  Text="Ingresar" CssClass="btn btn-primary" ID="BtnIngresar" OnClick="BtnIngresar_Click" />
                        </div>
                    </div>
                </div>
                <p>                    
                    <a href="/Register">Registrar un nuevo usuario</a>
                </p>
            </section>
        </div>
    </div>
</asp:Content>
