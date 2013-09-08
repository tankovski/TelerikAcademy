<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployeesWithFormView.Employees" %>

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
                        DataNavigateUrlFormatString="Employees.aspx?id={0}" />
                </Columns>
            </asp:GridView>

            <asp:FormView ID="FormViewEmployee" runat="server" AllowPaging="True">
                <ItemTemplate>
                    <h3><%#: Eval("FirstName") + " " + Eval("LastName") %></h3>
                    <table border="0">
                        <tr>
                            <td>Title:</td>
                            <td><%#: Eval("Title")%></td>
                        </tr>
                        <tr>
                            <td>TitleOfCourtesy:</td>
                            <td><%#: Eval("TitleOfCourtesy")%></td>
                        </tr>
                        <tr>
                            <td>BirthDate:</td>
                            <td><%#: Eval("BirthDate")%></td>
                        </tr>
                        <tr>
                            <td>HireDate:</td>
                            <td><%#: Eval("HireDate")%></td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td><%#: Eval("Address")%></td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td><%#: Eval("City")%></td>
                        </tr>
                           <tr>
                        <td>Region:</td>
                        <td><%#: Eval("Region")%></td>
                    </tr>
                           <tr>
                        <td>PostalCode:</td>
                        <td><%#: Eval("PostalCode")%></td>
                    </tr>
                           <tr>
                        <td>Country:</td>
                        <td><%#: Eval("Country")%></td>
                    </tr>
                           <tr>
                        <td>HomePhone:</td>
                        <td><%#: Eval("HomePhone")%></td>
                    </tr>
                    </table>
                    <hr />
                    <asp:HyperLink runat="server" NavigateUrl="~/Employees.aspx" Text="Close"></asp:HyperLink>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
