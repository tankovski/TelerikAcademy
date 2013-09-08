<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="resultTb" runat="server"></asp:Label>
            <br />
            <asp:Button CssClass="equalButtons" runat="server" Text="1" CommandName="1" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="2" CommandName="2" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="3" CommandName="3" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="+" CommandName="+" OnCommand="Operation_Click" />
            <br />
            <asp:Button CssClass="equalButtons" runat="server" Text="4" CommandName="4" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="5" CommandName="5" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="6" CommandName="6" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="-" CommandName="-" OnCommand="Operation_Click" />
            <br />
            <asp:Button CssClass="equalButtons" runat="server" Text="7" CommandName="7" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="8" CommandName="8" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="9" CommandName="9" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="x" CommandName="x" OnCommand="Operation_Click" />
            <br />
            <asp:Button ID="clear" runat="server" Text="Clear" OnClick="Clear_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="0" CommandName="0" OnCommand="Number_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="/" CommandName="/" OnCommand="Operation_Click" />
            <asp:Button CssClass="equalButtons" runat="server" Text="&radic;" CommandName="root" OnCommand="Operation_Click" />
            <br />
            <asp:Button ID="equal" runat="server" Text="=" OnClick="Result_Click" />


        </div>
    </form>
</body>
</html>
