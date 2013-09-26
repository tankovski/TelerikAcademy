<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:ListView ID="BookDetailsListView" runat="server" DataKeyNames="Id"
        ItemType="LibrarySystem.Models.Book" SelectMethod="BookDetailsListView_GetData">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <h2>
                <%#:Item.Title %>
            </h2>
            <div>
                by <%#: Item.Author %>
            </div>
            <br />
            <div>
                ISBN 
                <%#: Item.ISBN %>
            </div>
            <br />
            <div>
                Web site 
                <%#:Item.WebSite %>
            </div>
            <br />
            <div>
                <%#:Item.Description %>
            </div>
            <br />

        </ItemTemplate>
    </asp:ListView>
    <div>
        <a href="Default.aspx">Back to books</a>
    </div>
</asp:Content>
