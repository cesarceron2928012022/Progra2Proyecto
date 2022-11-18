<%@ Page Title="Galeria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Progra2Proyecto.Gallery" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2><%: Title %>.</h2></center>
    <div>
        <ul class="photoGrid">
            <asp:Repeater ID="ListPhotos" runat="server">                
                <ItemTemplate>
                    <li class="photoCard">
                        <%--<image width="300" height="500" class="photo" src="/Photos/<%# Eval("photoFile") %>" alt="<%# Eval("title")%>"/>--%>
                        <a href="/Photo?id=<%# Eval("idPhoto") %>">
                            <image href width="300" height="500" class="photo" 
                                src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem, "photoFile")) %>" alt="<%# Eval("title")%>"/>
                        </a> 
                        <%--<asp:ImageButton ID="ImgPhoto" Width="300" Height="500" runat="server" ImageUrl="<%# Eval("title","/Photos/{0}") %>" AlternateText="fdsfds" />--%>
                        <div class="row"><%# Eval("title")%> </div>
                        <div class="row" style="font-size:1.5rem">Por: <%# Eval("owner")%> </div>
                        <div class="row" style="font-size:1rem">Creado en: <%# string.Format("{0:d/M/yyyy HH:mm:ss}",Eval("createdDate").ToString()) %> </div>
                        
                        <div class="row">
                        <a class="btn btn-primary btn-dark" href="/Photo?id=<%# Eval("idPhoto") %>">Ver más</a>
                        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Photo.aspx?id=1">HyperLink</asp:HyperLink>  --%>  
                        <%--<asp:Button ID="BtnPhoto" AccessKey="" CssClass="btn btn-primary btn-dark" runat="server" Text="Ver más" OnClick="BtnPhoto_Click" />--%>
                        </div>
                    </li>
                </ItemTemplate>                
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
