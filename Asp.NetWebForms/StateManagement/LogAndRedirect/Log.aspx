<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="LogAndRedirect.Log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Ussername:
        <br />
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />
       <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />

    </div>
    </form>
</body>
</html>
