<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="SearchHeader" runat="server"></h1>

    <asp:ListView ID="SearchResultsListView" runat="server" DataKeyNames="Id"
        ItemType="LibrarySystem.Models.Book"
        SelectMethod="SearchResultsListView_GetData">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <a href='BookDetails.aspx?id=<%#:Item.Id %>'>
                    <%#:Item.Title %>" by <%#:Item.Author %>
                </a>(Category:<%#: Item.Category.Name%>)
            </li>
        </ItemTemplate>
    </asp:ListView>
    <div>
        <a href="Default.aspx">Back to books</a>
    </div>
</asp:Content>
