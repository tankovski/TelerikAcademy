<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="WebFormsTemplate.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Go chat</p>
    </header>
    <div>
       <asp:ListView ID="usersPosts" runat="server"
            SelectMethod="usersPosts_GetData" ItemType="Data.Post">
           <LayoutTemplate> 
               <div>
                   <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
               </div>
               
           </LayoutTemplate>
           <ItemTemplate>
               <div>
                   <p><span><%#: Item.AspNetUser.DisplayName %></span> sad: </p>
                   <p><%#: Item.Text %></p>
               </div>
           </ItemTemplate>
       </asp:ListView>

            <div>
                   Make Post
                   <asp:TextBox  runat="server" ID="usersPostText" Columns="20" Rows="10"></asp:TextBox>
                   
                   <asp:Button ID="makePostBtn"  runat="server" OnClick="makePostBtn_Click" Text="Post" />
               </div>
    </div>
</asp:Content>
