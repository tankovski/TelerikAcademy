<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RnadomNumbers.aspx.cs" Inherits="RandomNumbersWebServerControlls.RnadomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Random Numbers</h3>
        From
        <asp:TextBox ID="FromTb" runat="server"></asp:TextBox>
        To
        <asp:TextBox ID="ToTb" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="GenerateBtn" runat="server" OnClick="GenerateBtn_Click" Text="Generate" />
    </div>
    </form>
</body>
</html>
