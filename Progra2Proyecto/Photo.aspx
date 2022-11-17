<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Photo.aspx.cs" Inherits="Progra2Proyecto.Photo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2><%: Title %>.</h2></center>
    <div class="photoContainer">
        <%--<img class="col photo" width="300" height="500" src="/Photos/12112022085656.png" alt="prueba" />--%>
        <asp:Image CssClass="col photo" Width="300" Height="500" ID="ImgPhoto" runat="server" />
        <div class="col photoDetails">
            <div class="container-btn-eliminar">
                <asp:Button Visible="false" CssClass="btn btn-danger" ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />
            </div>            
            <p class="firtItem">
                <strong>Título:</strong>                
                <asp:Label ID="LblTitulo" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <strong>Descripción:</strong>
                <asp:Label ID="LblDescription" runat="server" Text=""></asp:Label>                
            </p>
        </div>

        <div class="col-comments container">
            <div class="row comments">            
                <div class="col-lg-12">
                    <div class="form_comments">                        
                        <asp:TextBox CssClass="form_comments_text" ID="TxtComment" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary" ID="BtnComentario" runat="server" Text="Comentar" OnClick="BtnComentario_Click" />
                    </div>
                    <asp:Repeater ID="ListComments" runat="server">
                        <ItemTemplate>
                            <div class="media">
                            <img src="img/user.jpg" alt="" width="64" height="64" />
                            <div class="media-body">
                                <p class="name"><%# Eval("user") %><span><%# Eval("createdDate") %></span></p>
                                <p class="comment"><%# Eval("body") %></p>
                            </div>
                        </div>
                        </ItemTemplate>
                    </asp:Repeater>                    
                </div>                                   
            </div>
        </div>
    </div>
    
</asp:Content>
