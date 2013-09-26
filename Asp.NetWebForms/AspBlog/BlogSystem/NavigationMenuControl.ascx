<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMenuControl.ascx.cs" Inherits="BlogSystem.NavigationMenuControl" %>

<asp:Menu runat="server" SkipLinkText=""
    EnableViewState="False" Orientation="Horizontal" OnDataBound="MenuControl_DataBound"
    StaticDisplayLevels="2" ID="MenuControl" >
    <StaticItemTemplate>
        <span class="navbar-text menuItem"><%# Eval("Text") %></span>
    </StaticItemTemplate>
</asp:Menu>
