<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="BlogSystem.Admin.Topic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article>
        <header>
            <h1 id="name" runat="server"></h1>
        </header>
        <section>
            <img id="img" runat="server" />
            <p id="descr" runat="server"></p>
        </section>
        <footer>
            <asp:ListView runat="server" ID="posts">
                <LayoutTemplate>
                    <div id="itemPlaceholder" runat="server"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <article>
                        <section>
                            <asp:Image ID="imgPost" ImageUrl='<%#: "~/Images/" + Eval("Image") %>'
                                Visible='<%# (Convert.ToBoolean(Eval("Image") != null)) %>' runat="server" />
                            <p>
                                <%#: Eval("PostContent") %>
                            </p>
                        </section>
                        <footer>
                            <asp:Button ID="editPost" runat="server" Text="Edit"
                                PostBackUrl='<%#: "~/Admin/EditPost.aspx?id=" + Eval("Id") %>' />
                            <asp:Button ID="deletePost" runat="server" Text="Delete" />
                        </footer>
                    </article>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <h3>No posts.</h3>
                </EmptyDataTemplate>
            </asp:ListView>
        </footer>
    </article>
</asp:Content>
