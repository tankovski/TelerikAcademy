<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="BlogSystem.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Repeater runat="server" ID="NewsRepeater" ItemType="BlogSystem.Models.News">
        <ItemTemplate>
            <div class="newsItem media">
                <h2><%#: Item.Title %></h2>

                <p class="newsText media-body">
                    <img class="newsImage media-object"   
                        src='Images/<%#: Item.Image %>' alt='<%#: Item.Image %>' />
                    <%#: Item.Text %>
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
