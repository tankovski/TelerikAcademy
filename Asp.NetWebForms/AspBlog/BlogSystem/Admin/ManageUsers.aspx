<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="BlogSystem.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Manage users</h1>
    <asp:ListView ID="ListView1" runat="server" 
        DataKeyNames="Id" DataSourceID="UsersEDS"
        ItemType="BlogSystem.Models.AspNetUser">
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Eval("IsActive") %>' Enabled="false" />
                </td>
                <td>
                    <asp:LinkButton Text="Edit" runat="server"
                                    CommandName="Vote" 
                                    CommandArgument="<%#: Item.Id %>"
                                    OnCommand="EditUser_Command"/>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">UserName</th>
                                <th runat="server">IsActive</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:EntityDataSource ID="UsersEDS" runat="server" ConnectionString="name=BlogSystemEntities" DefaultContainerName="BlogSystemEntities" EnableFlattening="False" EntitySetName="AspNetUsers">
    </asp:EntityDataSource>


</asp:Content>
