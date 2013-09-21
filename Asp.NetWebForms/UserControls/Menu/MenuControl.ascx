<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="Menu.MenuControl" %>


    <asp:DataList ID="MenuListBox" runat="server">
    <ItemTemplate>
        
        <asp:HyperLink runat="server" NavigateUrl='<%#: Eval("Url") %>' Text=' <%#:Eval("Name") %>' ForeColor='<%#Eval("FontColor") %>' ID="LinkItem"></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>



