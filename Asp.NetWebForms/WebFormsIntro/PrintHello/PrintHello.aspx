<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintHello.aspx.cs" Inherits="PrintHello.PrintHello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="SayHelloForm" runat="server">
        <div>
            <asp:Label ID="EnterNameLabel" Text="Enter Name" runat="server"></asp:Label>
            <asp:TextBox ID="EnterNameTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="PrintNameButton" runat="server" OnClick="PrintName" Text="Print" />
        </div>
    </form>
</body>
</html>
