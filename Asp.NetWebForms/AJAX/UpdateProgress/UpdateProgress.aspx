<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProgress.aspx.cs" Inherits="UpdateProgress.UpdateProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    
        <asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="EmployeesGrid" runat="server"
           SelectMethod="CountriesGrid_GetData" ItemType="UpdateProgress.Employee" 
           AutoGenerateColumns="true" AutoGenerateSelectButton="true" DataKeyNames="EmployeeID"
                  OnSelectedIndexChanged="EmployeesGrid_SelectedIndexChanged" 
                    AllowPaging="true" PageSize="4"></asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
         <asp:UpdateProgress runat="server">
            <ProgressTemplate>
               <img src="Loading_Animation.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="OrdersUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="OrdersGrid" runat="server" AutoGenerateColumns="true">
                    
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </div>
    </form>
</body>
</html>
