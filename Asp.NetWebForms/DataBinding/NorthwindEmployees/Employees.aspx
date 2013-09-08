<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="employeesGrid" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:HyperLinkField DataTextField="FullName" HeaderText="Employee Name"
                DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EmployeeInfo.aspx?id={0}"/>
        </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
