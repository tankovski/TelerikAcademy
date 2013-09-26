<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>

    <asp:ListView runat="server" ID="EditCategoriesList" DataKeyNames="Id"
        ItemType="LibrarySystem.Models.Category" SelectMethod="EditCategoriesList_GetData">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByNameCategory"
                                CommandName="Sort" Text="Category Name" CommandArgument="Name" />
                        </th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </tbody>
                <tfoot>
                        <td class="pagerLine" colspan="2">
                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                        </td>
                    </tfoot>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <td>
                <%#: Item.Name %>
            </td>
            <td>
                <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CommandArgument="<%#: Item.Id %>" 
                     OnClick="ButtonEdit_Click" />
                <asp:Button ID="ButtonDelete" runat="server" CommandArgument="<%#: Item.Id %>" Text="Delete" 
                    OnClick="ButtonDelete_Click" />
            </td>
        </ItemTemplate>

        

        <ItemSeparatorTemplate>
            <tr></tr>
        </ItemSeparatorTemplate>
    </asp:ListView>
    <br />
    <asp:Button ID="CreateNewCategoryBtn" runat="server" Text="Create New" OnClick="CreateNewCategoryBtn_Click" />
    <br />
    <br />

    <div runat="server" id="DeleteForm" visible="false" class="form">
        <h3>Confirm Category Deletion?</h3>
        Category:
        <asp:TextBox ID="DeleteCategoryName" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="No" runat="server" OnClick="No_Click" Text="No" />
        <asp:Button ID="Yes" runat="server" Text="Yes"  OnClick="Yes_Click"/>
    </div>

    <div runat="server" id="InsertForm" visible="false" class="form">
        <h3>Create New Category</h3>
        Category:
        <asp:TextBox ID="CategoryTitleTb" runat="server" placeholder="Enter category title"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" Text="*" Display="Dynamic" EnableClientScript="false"
            ErrorMessage="Category title is requaerd" ControlToValidate="CategoryTitleTb"
             ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="LenghtValidator" runat="server" EnableClientScript="false"
            ControlToValidate="CategoryTitleTb" OnServerValidate="LenghtValidator_ServerValidate"
            ErrorMessage="CategoryTitle must be maximum 150 symbols" Display="None">
        </asp:CustomValidator>
        <br />
        <asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" Text="Create" />
        <asp:Button ID="CancelBtn" CausesValidation="false" runat="server" Text="Cancel" OnClick="CancelBtn_Click"/>
    </div>


    <div runat="server" id="EditCategoryForm" visible="false" class="form">
        <h3>Edit Category</h3>
        Category:
        <asp:TextBox ID="EditCategoryTitle" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" Text="*" Display="Dynamic" EnableClientScript="false"
            ErrorMessage="Category title is requaerd" ControlToValidate="EditCategoryTitle"
             ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="EditTitleLenghtValidator" runat="server" EnableClientScript="false"
            ControlToValidate="EditCategoryTitle" OnServerValidate="EditTitleLenghtValidator_ServerValidate"
            ErrorMessage="CategoryTitle must be maximum 150 symbols" Display="None">
        </asp:CustomValidator>
        <br />
        <asp:Button ID="SaveEditCategory" runat="server" Text="Save" OnClick="SaveEditCategory_Click"/>
        <asp:Button ID="CancelEditCategory" runat="server" CausesValidation="false" Text="Cancel" OnClick="CancelEditCategory_Click"/>
    </div>

    <asp:ValidationSummary ID="Summary" runat="server" ForeColor="Red" />
    <div><a href="../Default.aspx">Back to books</a></div>
</asp:Content>
