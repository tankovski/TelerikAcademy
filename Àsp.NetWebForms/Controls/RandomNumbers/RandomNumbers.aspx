<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="RandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Generate random numbers</h3>
        From
        <input id="fromTb" type="text" runat="server" />
        To
        <input id="toTb" type="text" runat="server" />
        <br />
        <button id="generateBtn" runat="server" onserverclick="GenerateRandomNum_Click">Generate</button>
    </div>
    </form>
</body>
</html>
