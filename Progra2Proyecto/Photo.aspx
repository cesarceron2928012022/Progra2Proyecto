<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Photo.aspx.cs" Inherits="Progra2Proyecto.Photo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2><%: Title %>.</h2></center>
    <div class="photoContainer">
        <%--<img class="col photo" width="300" height="500" src="/Photos/12112022085656.png" alt="prueba" />--%>
        <asp:Image CssClass="col photo" Width="300" Height="500" ID="ImgPhoto" runat="server" />
        <div class="col photoDetails">  
            <p class="firtItem">
                <strong>Título:</strong>                
                <asp:Label ID="LblTitulo" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <strong>Descripción:</strong>
                <asp:Label ID="LblDescription" runat="server" Text=""></asp:Label>                
            </p>
        </div>
    </div>
</asp:Content>
