<%@ Page Title="Galeria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Progra2Proyecto.Gallery" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2><%: Title %>.</h2></center>
    <div>
        <ul class="photoGrid">
            <asp:Repeater ID="ListPhotos" runat="server">                
                <ItemTemplate>
                    <li class="photoCard">
                        <image width="300" height="500" class="photo" src="/Photos/<%# Eval("photoFile") %>" alt="<%# Eval("title")%>"/>
                        <div><%# Eval("title")%></div>
                    </li>
                </ItemTemplate>                
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
