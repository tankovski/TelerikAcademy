<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Menu.Menu" %>

<%@ Register Src="~/MenuControl.ascx" TagPrefix="controll" TagName="MenuControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <controll:MenuControl ID="MenuTest" runat="server"  FontColor="Red" FontFamily="Verdana"/> 
    </div>
    </form>
</body>
</html>
