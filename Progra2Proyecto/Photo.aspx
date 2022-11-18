<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Photo.aspx.cs" Inherits="Progra2Proyecto.Photo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2><%: Title %>.</h2></center>
    <div class="photoContainer">        
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
            <p>
                <strong>Creado por:</strong>
                <asp:Label ID="LblOwner" runat="server" Text=""></asp:Label>                
            </p>
            <p>
                <strong>Creado en:</strong>
                <asp:Label ID="LblCreatedDate" runat="server" Text=""></asp:Label>                
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
                            <img src="data:image/jpeg;base64,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" alt="" width="64" height="64" />
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
