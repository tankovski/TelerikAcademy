<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="BlogSystem.Admin.EditPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article>
        <section>
            <img id="img" runat="server" />
            <asp:FileUpload ID="PostImgUpload" runat="server" />
            <asp:TextBox runat="server" ID="content"></asp:TextBox>

            <asp:RequiredFieldValidator ID="ValidateDescription" runat="server" Display="Dynamic"
                EnableClientScript="false" ControlToValidate="content"
                ErrorMessage="You must enter some Content!"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </section>
        <footer>
            <asp:Button runat="server" ID="saveBtn" OnClick="saveBtn_Click" Text="Save" />
            <asp:Button runat="server" ID="deleteBtn" OnClick="deleteBtn_Click" Text="Delete" />
        </footer>
    </article>
</asp:Content>
