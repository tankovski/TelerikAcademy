<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>

    <asp:ListView ID="BooksListView" runat="server" DataKeyNames="Id"
        ItemType="LibrarySystem.Models.Book" SelectMethod="BooksListView_GetData">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByNameTitle"
                                CommandName="Sort" Text="Title" CommandArgument="Title" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByAuthor"
                                CommandName="Sort" Text="Author" CommandArgument="Author" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByISBN"
                                CommandName="Sort" Text="ISBN" CommandArgument="ISBN" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByWebSite"
                                CommandName="Sort" Text="Web Site" CommandArgument="WebSite" />
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortByCategory"
                                CommandName="Sort" Text="Category" CommandArgument="CategoryId" />
                        </th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </tbody>
                <tfoot>
                    <td class="pagerLine" colspan="6">
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
                <%#: Item.Title.Length > 20? Item.Title.Substring(0,17)+"..." : Item.Title %>
            </td>
            <td>
                <%#: Item.Author.Length > 20? Item.Author.Substring(0,17)+"..." : Item.Author %>
            </td>
            <td>
                <%#: Item.ISBN==null?"": Item.ISBN.Length > 20? Item.ISBN.Substring(0,17)+"..." : Item.ISBN %>
            </td>
            <td>
                <a href='<%#: Item.WebSite==null?"":Item.WebSite %>'>
                    <%#: Item.WebSite==null?"": Item.WebSite.Length > 20? 
                    Item.WebSite.Substring(0,17)+"..." : Item.WebSite %>
                </a>
                
            </td>
            <td>
                <%#: Item.Category.Name.Length > 20? Item.Category.Name.Substring(0,17)+"..." : Item.Category.Name %>
            </td>
            <td>
                <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CommandArgument="<%#: Item.Id %>"
                    OnClick="ButtonEdit_Click" />
                <asp:Button ID="ButtonDelete" runat="server" CommandArgument="<%#: Item.Id %>" Text="Delete"
                    OnClick="ButtonDelete_Click" />
            </td>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <asp:Button ID="CreateNewBookBtn" runat="server" Text="Create New" OnClick="CreateNewBookBtn_Click" />
    <br />
    <br />
    <div runat="server" id="DeleteForm" visible="false" class="form">
        <h3>Confirm Book Deletion?</h3>
        Title:
        <asp:TextBox ID="DeleteCategoryName" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="No" runat="server" OnClick="No_Click" Text="No" />
        <asp:Button ID="Yes" runat="server" Text="Yes" OnClick="Yes_Click" />
    </div>


    <div runat="server" id="InsertForm" visible="false" class="form">
        <h3>Create New Book</h3>
        Title:
        <asp:TextBox ID="BookTitleTb" placeholder="Enter book title" runat="server"></asp:TextBox>

         <asp:RequiredFieldValidator runat="server" Text="*" Display="Dynamic" EnableClientScript="false"
            ErrorMessage="Book title is requaerd" ControlToValidate="BookTitleTb"
             ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Author(s):
        <asp:TextBox ID="BookAuthorTb" placeholder="Enter book author" runat="server"></asp:TextBox>

         <asp:RequiredFieldValidator runat="server" Text="*" Display="Dynamic" EnableClientScript="false"
            ErrorMessage="Book author is requaerd" ControlToValidate="BookAuthorTb"
             ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        ISBN:
        <asp:TextBox ID="BookISBNTb" placeholder="Enter book ISBN" runat="server"></asp:TextBox>

     
        <br />
        WebSite:
        <asp:TextBox ID="BookWebSite" placeholder="Enter book website" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator runat="server" EnableClientScript="false"
            Text="*" Display="Dynamic" ErrorMessage="The web site is not in the correct format"
             ControlToValidate="BookWebSite" ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$"
             ForeColor="Red">
        </asp:RegularExpressionValidator>
        <br />
        Description
        <textarea id="BookDescriptionTa" placeholder="Enter book description" runat="server"></textarea>
        <br />
        Category:
        <asp:DropDownList ID="AllCategoriesList" runat="server"
            DataTextField="Name" DataValueField="Id"></asp:DropDownList>
        <br />

        <asp:CustomValidator ID="AllFieldsLenghtInsert" runat="server" EnableClientScript="false"
            Display="None" ErrorMessage="All fields, except book description, maximum lenght is 150"
            ForeColor="Red" OnServerValidate="AllFieldsLenghtInsert_ServerValidate">
        </asp:CustomValidator>

        <asp:CustomValidator ID="DescriptionLenghtValidatorInser" runat="server" EnableClientScript="false"
            Display="None" ErrorMessage="Descripition max lenght is 1000"
            ForeColor="Red" OnServerValidate="DescriptionLenghtValidatorInser_ServerValidate">
        </asp:CustomValidator>

        <asp:Button ID="CreateBtn" runat="server"  OnClick="CreateBtn_Click" Text="Create" />
        <asp:Button ID="CancelBtn" runat="server" CausesValidation="false"  Text="Cancel" OnClick="CancelBtn_Click" />
    </div>

    <div runat="server" id="EditForm" visible="false" class="form">
        <h3>Edit Book</h3>
        Title:
        <asp:TextBox ID="EditBookTitleTb" placeholder="Enter book title" runat="server"></asp:TextBox>

         <asp:RequiredFieldValidator runat="server" Text="*" Display="Dynamic" EnableClientScript="false"
            ErrorMessage="Book title is requaerd" ControlToValidate="EditBookTitleTb"
             ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Author(s):
        <asp:TextBox ID="EditBookAuthorTb" placeholde="Enter book author" runat="server"></asp:TextBox>

         <asp:RequiredFieldValidator runat="server" Text="*" Display="Dynamic" EnableClientScript="false"
            ErrorMessage="Book author is requaerd" ControlToValidate="EditBookAuthorTb"
             ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        ISBN:
        <asp:TextBox ID="EditBookIsbnTb" placeholder="Enter book ISBN" runat="server"></asp:TextBox>
        <br />
        WebSite:
        <asp:TextBox ID="EditWebSiteTb" placeholder="Enter book website" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator runat="server" EnableClientScript="false"
            Text="*" Display="Dynamic" ErrorMessage="The web site is not in the correct format"
             ControlToValidate="EditWebSiteTb" ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$"
             ForeColor="Red">
        </asp:RegularExpressionValidator>
        <br />
        Description
        <textarea id="EditDescriptionTa" placeholder="Enter book description" runat="server"></textarea>
        <br />
        Category:
        <asp:DropDownList ID="EditAllCategories" runat="server"
            DataTextField="Name" DataValueField="Id"></asp:DropDownList>
        <br />

        <asp:CustomValidator ID="EditAllFieldsLenght" runat="server" EnableClientScript="false"
            Display="None" ErrorMessage="All fields, except book description, maximum lenght is 150"
            ForeColor="Red" OnServerValidate="EditAllFieldsLenght_ServerValidate">
        </asp:CustomValidator>

        <asp:CustomValidator ID="EditDescriptionLenght" runat="server" EnableClientScript="false"
            Display="None" ErrorMessage="Descripition max lenght is 1000"
            ForeColor="Red" OnServerValidate="EditDescriptionLenght_ServerValidate">
        </asp:CustomValidator>

        <asp:Button ID="SaveEdit" runat="server"  OnClick="SaveEdit_Click" Text="Save" />
        <asp:Button ID="CancelEdit" runat="server" CausesValidation="false" Text="Cancel" OnClick="CancelEdit_Click" />
    </div>

    <asp:ValidationSummary ID="Summary" runat="server" ForeColor="Red" />
    <br />
    <br />
    <div><a href="../Default.aspx">Back to books</a></div>
    


</asp:Content>
