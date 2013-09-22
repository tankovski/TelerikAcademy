<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TemplateForCache.Contact" %>

<%@ Register Src="~/CacheControl.ascx" TagPrefix="uc1" TagName="CacheControl" %>





<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>This is not in the cahe: </h2> <strong><%=DateTime.Now %></strong>
    <uc1:CacheControl runat="server" id="CacheControl" />
</asp:Content>
