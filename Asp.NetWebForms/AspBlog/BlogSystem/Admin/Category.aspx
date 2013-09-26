<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="BlogSystem.Admin.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article>
        <header>
            <h1 id="name" runat="server"></h1>
        </header>
        <section>
            <img src="" id="imgCategory" runat="server" />
            <p id="descr" runat="server"></p>
            <h3>Topics: </h3>
        </section>
        <footer>
            <asp:ListView runat="server" ID="topics">
                <LayoutTemplate>
                    <div id="itemPlaceholder" runat="server"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <article>
                        <header>
                            <asp:HyperLink runat="server" Font-Size="20"
                                Text='<%#: Eval("Name") %>'
                                NavigateUrl='<%#: "~/Admin/Topic.aspx?id=" + Eval("Id") %>' />
                        </header>
                        <section>
                            <asp:Image ID="imgTopic" ImageUrl='<%#: "~/Images/" + Eval("Image") %>'
                                Visible='<%# (Convert.ToBoolean(Eval("Image") != null)) %>' runat="server" />
                            <p>
                                <%#: Eval("Name") %>
                            </p>
                        </section>
                        <footer>
                            <asp:Button ID="editTopic" runat="server" Text="Edit"
                                PostBackUrl='<%#: "~/Admin/EditTopic.aspx?id=" + Eval("Id") %>' />
                            <asp:Button ID="deleteCategory" runat="server" Text="Delete" CssClass="btn"/>
                        </footer>
                    </article>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <h4>No topics.</h4>
                </EmptyDataTemplate>
            </asp:ListView>
        </footer>
    </article>
</asp:Content>
