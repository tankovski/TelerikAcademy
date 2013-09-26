<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="BlogSystem.Admin.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit user</h1>
    <asp:DetailsView ID="DetailsViewUser" runat="server" Height="50px" Width="125px" 
        AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="UserEDS">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <%--<asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />--%>
        </Fields>

    </asp:DetailsView>

    <asp:Button ID="ButtonDeleteUser" runat="server" OnClick="ButtonDeleteUser_Click" Text="Delete" />
    <asp:Button ID="ButtonRestoreUser" runat="server" OnClick="ButtonRestoreUser_Click" Text="Restore" />
    <asp:Button ID="ButtonMakeAdmin" runat="server" OnClick="ButtonMakeAdmin_Click"  Text="MakeAdmin" />

    <asp:EntityDataSource ID="UserEDS" runat="server" 
        ConnectionString="name=BlogSystemEntities" 
        DefaultContainerName="BlogSystemEntities" 
        EnableDelete="True" EnableFlattening="False" 
        EntitySetName="AspNetUsers" Where="it.Id=@id">
        <WhereParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id"
                 ConvertEmptyStringToNull="true" Type="String" />
        </WhereParameters>
    </asp:EntityDataSource>

</asp:Content>
