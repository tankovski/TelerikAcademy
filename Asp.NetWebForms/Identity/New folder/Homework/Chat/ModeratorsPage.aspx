<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModeratorsPage.aspx.cs" Inherits="WebFormsTemplate.ModeratorsPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Go chat</p>
    </header>
    <div>
        <asp:ListView ID="usersPosts" runat="server"
            SelectMethod="usersPosts_GetData" 
            UpdateMethod="usersPosts_UpdateItem" 
            ItemType="Data.Post"
            DataKeyNames="Id">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </div>

            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <p><span><%#: Item.AspNetUser.DisplayName %></span> sad: </p>
                    <p><%#: Item.Text %></p>
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <div>
                    <asp:TextBox ID="TextEdit" runat="server" Text='<%#: BindItem.Text %>'></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                </div>

            </EditItemTemplate>
        </asp:ListView>

        <div>
            Make Post
                   <asp:TextBox runat="server" ID="usersPostText" Columns="20" Rows="10"></asp:TextBox>

            <asp:Button ID="makePostBtn" runat="server" OnClick="makePostBtn_Click" Text="Post" />
        </div>
    </div>
</asp:Content>
