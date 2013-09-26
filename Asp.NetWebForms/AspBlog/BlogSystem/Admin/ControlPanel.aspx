<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ControlPanel.aspx.cs" Inherits="BlogSystem.Admin.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Admin page</h1>
    <asp:ListView runat="server" ID="categories" ItemType="BlogSystem.Models.Category">
        <LayoutTemplate>
            <ul class="thumbnails" id="itemPlaceholderContainer">
                <div id="itemPlaceholder" runat="server"></div>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1"
                NavigateUrl='<%# "~/Admin/Category.aspx?id=" + Item.Id %>' runat="server">
                <li class="span4">
                    <div class="thumbnail">
                        <asp:Image ID="img" ImageUrl='<%#: "~/Images/" + Eval("Image") %>'
                            Visible='<%# (Convert.ToBoolean(Eval("Image") != null)) %>' runat="server" />
                        <h3><%#: Item.Name %></h3>
                        <p><%#: Item.Description %></p>
                        <div id="admin-buttons">
                            <asp:Button ID="editCategory" runat="server" Text="Edit"
                                PostBackUrl='<%#: "~/Admin/EditCategory.aspx?id=" + Eval("Id") %>' />
                            <asp:Button ID="deleteCategory" CommandArgument='<%#: Eval("Id") %>'
                                runat="server" Text="Delete" OnCommand="deleteCategory_Click" />
                        </div>
                    </div>
                </li>
            </asp:HyperLink>
        </ItemTemplate>
        <EmptyDataTemplate>
            <h3>No Categories.</h3>
        </EmptyDataTemplate>
    </asp:ListView>

    <article class="new Category">
        <fieldset>
            <legend>Create new category</legend>
            <section>
                <ul class="nav nav-tabs nav-stacked">
                    <li>Name: 
                    <asp:TextBox runat="server" ID="name"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="ValidateName" runat="server" Display="Dynamic"
                            EnableClientScript="false" ControlToValidate="name" ErrorMessage="You must enter Name!"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CustomValidator ID="ValidateTitleLength" runat="server" Display="Dynamic"
                            EnableClientScript="false"
                            ErrorMessage="The name is too long" ForeColor="Red"></asp:CustomValidator>
                    </li>
                    <li>Description: 
                    <asp:TextBox runat="server" ID="descr"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="ValidateDescription" runat="server" Display="Dynamic"
                            EnableClientScript="false" ControlToValidate="descr"
                            ErrorMessage="You must enter Description!"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                    </li>
                    <li>
                        <asp:Image ID="img" runat="server" />
                        <asp:FileUpload ID="PostImgUpload" runat="server" />
                    </li>
                </ul>
            </section>
            <footer>
                <asp:Button runat="server" ID="saveBtn" OnClick="saveBtn_Click" Text="Create category" />
            </footer>
        </fieldset>
    </article>

</asp:Content>
