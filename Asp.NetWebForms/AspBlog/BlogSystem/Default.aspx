<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="heading">Heliodore Hater Blog</h2>
    <asp:ListView ID="lvNews" runat="server" DataKeyNames="Id" ItemType="BlogSystem.Models.News">
        <EmptyDataTemplate>
            <p>No news found.</p>
        </EmptyDataTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink12"
                NavigateUrl='News.aspx' runat="server">
                <div class="media">
                    <img class="media-object" style="width: 50px" src='<%# "~/Images/" + Item.Image %>'
                            runat="server" alt="News image">
                    <div class="media-body">
                        <h4 class="media-heading"><%#: Item.Title %></h4>
                        <%#: Item.Text %>
                    </div>
                </div>
            </asp:HyperLink>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="media-news">
                <div id="itemPlaceholder" runat="server"></div>
            </div>
        </LayoutTemplate>
    </asp:ListView>

    <br />

    <asp:ListView ID="lvCategories" runat="server"
        DataSourceID="CategoriesEDS" DataKeyNames="Id"
        ItemType="BlogSystem.Models.Category">
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1"
                NavigateUrl='<%# "~/LoggedUsers/Topics.aspx?id=" + Item.Id %>' runat="server">
           
            <li class="span4">
                <div class="thumbnail">
                    <img data-src="holder.js/300x200" runat="server"
                            src=<%# "~/Images/" + Item.Image %> alt="Just image">
                    <h3><%#: Item.Name %></h3>
                    <p><%#: Item.Description %></p>
                </div>
            </li>
            </asp:HyperLink>
        </ItemTemplate>
        <LayoutTemplate>
            <ul class="thumbnails" id="itemPlaceholderContainer">
                <div id="itemPlaceholder" runat="server"></div>
            </ul>
        </LayoutTemplate>
    </asp:ListView>

    <asp:EntityDataSource ID="CategoriesEDS" runat="server" 
        ConnectionString="name=BlogSystemEntities" DefaultContainerName="BlogSystemEntities" 
        EnableFlattening="False" EntitySetName="Categories">
    </asp:EntityDataSource>

</asp:Content>
