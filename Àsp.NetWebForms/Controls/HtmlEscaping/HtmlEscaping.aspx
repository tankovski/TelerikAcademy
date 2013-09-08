<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="HtmlEscaping.HtmlEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Enter text:
        <asp:TextBox ID="textInputTb" runat="server"></asp:TextBox>
        <asp:Button ID="printTextBtn" runat="server" text="Print" OnClick="printTextBtn_Click" />
        <br />
        Result:
        <asp:TextBox ID="resultTb" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
