<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionState.aspx.cs" Inherits="SessionState.SessionState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Input" runat="server"></asp:TextBox>
        <asp:Button ID="GetInput" runat="server" OnClick="GetInput_Click"  Text="Push"/>
        <br />
        <asp:Label ID="Result" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
