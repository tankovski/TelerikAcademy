<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="TotoList.TodoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="CategoriesList" runat="server"
                SelectMethod="CategoriesList_GetData" DataKeyNames="Id"
                InsertItemPosition="None"
                OnItemInserted="CategoriesList_ItemInserted" ItemType="TotoList.Category"
                InsertMethod="CategoriesList_InsertItem"
                DeleteMethod="CategoriesList_DeleteItem"
                UpdateMethod="CategoriesList_UpdateItem"
                 OnSelectedIndexChanged="CategoriesList_SelectedIndexChanged">
                <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th></th>
                                <th>
                                    <asp:LinkButton ID="SortCategoryName" runat="server" CommandName="Sort" Text="Countrie Name" CommandArgument="Name"></asp:LinkButton>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tbody>
                        <tfoot>
                            <td class="pagerLine" colspan="3">
                                <asp:Button ID="ButtonInsertCatrgory" Text="Insert" runat="server"
                                    OnClick="ButtonInsertCatrgory_Click" />
                                |
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
                <ItemSeparatorTemplate>
                    <tr></tr>
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <td>
                        <asp:Button ID="SelectCategoryBtn" runat="server" CommandName="Select" Text="Select" />
                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                    </td>
                    <td>
                        <%#:Item.Name %>
                    </td>
                </ItemTemplate>
                <InsertItemTemplate>
                    <td>
                        <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" />

                    </td>
                    <td>
                        <asp:TextBox ID="CategoryNameInput" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
                    </td>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <td>
                        <asp:Button ID="ButtonInsert" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="CategoryEditTb" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
                    </td>
                </EditItemTemplate>
            </asp:ListView>

            <asp:ListView ID="TodosListView" runat="server"
                SelectMethod="TodosListView_GetData" DataKeyNames="Id"
                InsertItemPosition="None"
                OnItemInserted="TodosListView_ItemInserted" ItemType="TotoList.Todo"
                InsertMethod="TodosListView_InsertItem"
                DeleteMethod="TodosListView_DeleteItem"
                UpdateMethod="TodosListView_UpdateItem">
                <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th></th>
                                <th>
                                    <asp:LinkButton ID="SortTodoTitle" runat="server" CommandName="Sort" Text="Title"
                                         CommandArgument="Title"></asp:LinkButton>
                                </th>
                                <th>
                                    <asp:LinkButton ID="SortByTodoText" runat="server" CommandName="Sort"
                                         Text="Text" CommandArgument="Text"></asp:LinkButton>
                                </th>
                                 <th>
                                    <asp:LinkButton ID="SortByCategory" runat="server" CommandName="Sort" 
                                        Text="Category" ></asp:LinkButton>
                                </th>
                                <th>
                                    <asp:LinkButton ID="SortByDate" runat="server" CommandName="Sort" 
                                        Text="LastChange" CommandArgument="LastChangeDate"></asp:LinkButton>
                                </th>                            
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tbody>
                        <tfoot>
                            <td class="pagerLine" colspan="3">
                                <asp:Button ID="ButtonInsertTodo" Text="Insert" runat="server"
                                    OnClick="ButtonInsertTodo_Click" />
                                |
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
                <ItemSeparatorTemplate>
                    <tr></tr>
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <td>
                        <asp:Button ID="SelectCategoryBtn" runat="server" CommandName="Select" Text="Select" />
                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                    </td>
                    <td>
                        <%#:Item.Title %>
                    </td>
                     <td>
                        <%#:Item.Text %>
                    </td>
                     <td>
                        <%#:Item.Category.Name %>
                    </td>
                     <td>
                        <%#:Item.LastChangeDate %>
                    </td>                
                </ItemTemplate>
                <InsertItemTemplate>
                    <td>
                        <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" />

                    </td>
                     <td>
                        Title:
                        <asp:TextBox ID="TodoTitleEditTb" runat="server" Text='<%#: BindItem.Title %>'></asp:TextBox>
                    </td>
                    <td>
                        Text:
                        <asp:TextBox ID="TodoTextEditTb" runat="server" Text='<%#: BindItem.Text %>'></asp:TextBox>
                    </td>
                    <td>
                        CategoryId:
                        <asp:TextBox ID="TodoDateEditTb" runat="server" Text='<%#: BindItem.CategoryId %>'></asp:TextBox>
                    </td>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <td>
                        <asp:Button ID="ButtonInsert" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        Title:
                        <asp:TextBox ID="TodoTitleEditTb" runat="server" Text='<%#: BindItem.Title %>'></asp:TextBox>
                    </td>
                    <td>
                        Text:
                        <asp:TextBox ID="TodoTextEditTb" runat="server" Text='<%#: BindItem.Text %>'></asp:TextBox>
                    </td>
                    <td>
                        CategoryId:
                        <asp:TextBox ID="TodoDateEditTb" runat="server" Text='<%#: BindItem.CategoryId %>'></asp:TextBox>
                    </td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <td><asp:Button ID="ButtonInsertTodo" Text="Insert" runat="server"
                                    OnClick="ButtonInsertTodo_Click" /></td>
                </EmptyDataTemplate>
                    
           
            </asp:ListView>
            <asp:Label ID="results" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
