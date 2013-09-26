<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="BlogSystem.Admin.EditNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article class="news-edit">
        <header>
            <asp:TextBox runat="server" ID="title"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="ValidateName" runat="server" Display="Dynamic"
                EnableClientScript="false" ControlToValidate="title" ErrorMessage="You must enter Name!"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:CustomValidator ID="ValidateTitleLength" runat="server" Display="Dynamic"
                EnableClientScript="false" OnServerValidate="ValidateTitleLength_ServerValidate"
                ErrorMessage="The title is too long" ForeColor="Red"></asp:CustomValidator>

            <asp:TextBox runat="server" ID="text"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="ValidateText" runat="server" Display="Dynamic"
                EnableClientScript="false" ControlToValidate="text"
                ErrorMessage="You must enter some text!"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </header>
        <section>
            <img id="img" runat="server" />
            <asp:FileUpload ID="PostImgUpload" runat="server" />
        </section>
        <footer>
            <asp:Button runat="server" ID="saveBtn" OnClick="saveBtn_Click" Text="Save" />
            <asp:Button runat="server" ID="deleteBtn" OnClick="deleteBtn_Click" Text="Delete" />
        </footer>
    </article>
</asp:Content>
