<%@ Page Title="Agregar Foto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPhoto.aspx.cs" Inherits="Progra2Proyecto.NewPhoto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <asp:Label runat="server" CssClass="alert-danger" ID="LblError"></asp:Label>
    </div>
    <asp:ValidationSummary runat="server" CssClass="text-danger" />
    <div class="form-horizontal">
        <h4>Compartir una nueva foto</h4>
        <hr />        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TxtTitle" CssClass="col-md-2 control-label">Titulo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TxtTitle" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtTitle"
                    CssClass="text-danger" ErrorMessage="El título es requerido." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FilePhoto" CssClass="col-md-2 control-label">Foto</asp:Label>
            <div class="col-md-10">
                <asp:FileUpload runat="server" ID="FilePhoto" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FilePhoto"
                    CssClass="text-danger" ErrorMessage="La foto es requerida." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TxtDescription" CssClass="col-md-2 control-label">Descripción</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TxtDescription" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtDescription"
                    CssClass="text-danger" ErrorMessage="La descripción es requerida." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreatePhoto_Click" Text="Registrar" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
