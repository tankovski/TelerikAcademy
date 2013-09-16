<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="CoolCompanyWithSiteMapNavigation.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Contact us</h1>
    <p>We have very much offices for more info check 
        <asp:HyperLink ID="OfficesGuperLink" runat="server" NavigateUrl="~/Offices.aspx" Text="OurOffices"></asp:HyperLink></p>
</asp:Content>
