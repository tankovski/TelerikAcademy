<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRatingControl.ascx.cs" Inherits="BlogSystem.UserRatingControl" %>

<asp:Repeater ID="UserRepeater" runat="server" ItemType="BlogSystem.Models.UserModel">
        <HeaderTemplate>
            <table class="table table-striped usersRating">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
               <td> <%#: Item.RatingPlace %>. </td> <td> <%#: Item.Username  %> </td> <td> Posts: <%#: Item.PostsCount %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>