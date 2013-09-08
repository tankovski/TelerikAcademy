<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="InternacionalCompany.MainPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:HyperLink runat="server" NavigateUrl="~/English/EnglishHome.aspx" 
        Text="" CssClass="English"/>
    <asp:HyperLink runat="server" NavigateUrl="~/Deutsch/GermanHome.aspx" 
        Text="" CssClass="Deutsch"/>
    <asp:HyperLink runat="server" NavigateUrl="~/Bulgarian/BulgarianHome.aspx" 
        Text="" CssClass="Bulgarian"/>
</asp:Content>
