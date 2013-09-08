<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="UserProfile.Profile" %>

<asp:Content ID="ContentHEader" ContentPlaceHolderID="head" runat="server">
    <meta name="author" content="Me" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="contentDiv">
        <asp:Image CssClass="profileImg" ImageUrl="imgs/cool-frog-sunglasses.jpg" runat="server" />
        <p>Nickname: <strong>The Cool guy</strong></p>
        <p>Sex: <strong>Male</strong></p>
        <p>Age<strong>24</strong></p>
    </div>
</asp:Content>
