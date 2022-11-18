<%@ Page Title="Galeria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Progra2Proyecto.Gallery" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2><%: Title %>.</h2></center>
    <div>
        <ul class="photoGrid">
            <asp:Repeater ID="ListPhotos" runat="server">                
                <ItemTemplate>
                    <li class="photoCard">                        
                        <a href="/Photo?id=<%# Eval("idPhoto") %>">
                            <image href width="300" height="500" class="photo" 
                                src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem, "photoFile")) %>" alt="<%# Eval("title")%>"/>
                        </a>                         
                        <div class="row"><%# Eval("title")%> </div>
                        <div class="row" style="font-size:1.5rem">Por: <%# Eval("owner")%> </div>
                        <div class="row" style="font-size:1rem">Creado en: <%# string.Format("{0:d/M/yyyy HH:mm:ss}",Eval("createdDate").ToString()) %> </div>                        
                        <div class="row">
                            <a class="btn btn-primary btn-dark" href="/Photo?id=<%# Eval("idPhoto") %>">Ver más</a>
                        </div>
                    </li>
                </ItemTemplate>                
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
