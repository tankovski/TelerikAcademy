<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="NorthwindEmployees.EmployeeInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DetailsView ID="EmployeeDetails" runat="server" AutoGenerateRows="true">
    </asp:DetailsView>
       <asp:HyperLink runat="server" NavigateUrl="~/Employees.aspx" Text="Back" ></asp:HyperLink>
    </div>
    </form>
</body>
</html>
