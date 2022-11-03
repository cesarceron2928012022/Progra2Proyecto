<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Progra2Proyecto.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
</head>
<body>
    <script>        
        document.cookie = "user=; expires= Thu, 21 Aug 2014 20:00:00 UTC";
        window.location.href = "/Login";        
    </script>     
</body>
</html>
