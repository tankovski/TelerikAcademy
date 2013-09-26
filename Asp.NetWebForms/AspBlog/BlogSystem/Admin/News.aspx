<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="BlogSystem.Admin.News" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="NewsRepeater" ItemType="BlogSystem.Models.News">
        <ItemTemplate>
            <div class="newsItem media">
                <h2><%#: Item.Title %></h2>

                <p class="newsText media-body">
                    <img class="newsImage media-object" src='<%#: "../Images/" + Item.Image %>' alt='<%#: Item.Image %>' />
                    <%#: Item.Text %>
                </p>

                <asp:Button ID="editNews" runat="server" Text="Edit"
                    PostBackUrl='<%#: "~/Admin/EditNews.aspx?id=" + Eval("Id") %>' />
                <asp:Button ID="deleteNews" runat="server" CommandArgument=<%#: Eval("Id") %> 
                    Text="Delete" OnCommand="deleteNews_Command" />
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="new News">
        <section>
            <ul>
                <li>Title: 
                    <asp:TextBox runat="server" ID="title"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="ValidateTitle" runat="server" Display="Dynamic"
                        EnableClientScript="false" ControlToValidate="title" ErrorMessage="You must enter Title!"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="ValidateTitleLenght" runat="server" Display="Dynamic"
                        EnableClientScript="false" 
                        ErrorMessage="The tilte is too long" ForeColor="Red"></asp:CustomValidator>
                    <br />
                </li>
                <li>Content: 
                    <asp:TextBox runat="server" ID="text"></asp:TextBox>
                </li>
                <li>
                    <asp:Image ID="img" runat="server" />
                    <asp:FileUpload ID="PostImgUpload" runat="server" />
                </li>
            </ul>
        </section>
        <footer>
            <asp:Button runat="server" ID="saveBtn" OnClick="saveBtn_Click" Text="Save" />
        </footer>
    </div>

</asp:Content>
