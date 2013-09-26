<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="MainPageHeader">Books</h1>
    <div class="searchContainer">
        <asp:TextBox ID="SearchTb" runat="server">
        </asp:TextBox>
         <asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click"  Text="Search"/>
        <br />
       
        <asp:CustomValidator ID="LenghtValidate" runat="server" EnableClientScript="false"
            ControlToValidate="SearchTb" OnServerValidate="LenghtValidate_ServerValidate"
             ErrorMessage="Max symbols for search 1000" ForeColor="Red"></asp:CustomValidator>
       

    </div>
    <div class="row">
        <asp:ListView ID="CategoriesListView" runat="server" DataKeyNames="Id"
            ItemType="LibrarySystem.Models.Category" SelectMethod="CategoriesListView_GetData">

            <LayoutTemplate>

                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>

            </LayoutTemplate>
            <ItemTemplate>
                <div class="categoryContainer">
                    <h2>
                        <%#:Item.Name %>
                    </h2>
                    <%# Item.Books.Count==0? "No books in this category.":"" %>
                    <ul class="BooksUl">
                        <asp:Repeater ID="BooksRepeater" runat="server" DataSource="<%#Item.Books %>"
                            ItemType="LibrarySystem.Models.Book">
                            <ItemTemplate>
                                <li>
                                    <a href='BookDetails.aspx?id=<%#:Item.Id %>'> 
                                        <%#:Item.Title %>" by <%#:Item.Author %>
                                    </a>
                                   
                                </li>
                            </ItemTemplate>
                           
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>
            
        </asp:ListView>
    </div>
</asp:Content>
