<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="BlogSystem.Admin.EditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article>
        <section>
            Name: 
            <asp:TextBox runat="server" ID="name"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="ValidateName" runat="server" Display="Dynamic"
                EnableClientScript="false" ControlToValidate="name" ErrorMessage="You must enter Name!"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:CustomValidator ID="ValidateTitleLength" runat="server" Display="Dynamic"
                EnableClientScript="false" OnServerValidate="ValidateNameLength_ServerValidate"
                ErrorMessage="The name is too long" ForeColor="Red"></asp:CustomValidator>
            <br />
            Description: 
            <asp:TextBox runat="server" ID="descr"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="ValidateDescription" runat="server" Display="Dynamic"
                EnableClientScript="false" ControlToValidate="descr"
                ErrorMessage="You must enter Description!"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <img id="img" runat="server" />
            <asp:FileUpload ID="PostImgUpload" runat="server" />
        </section>
        <footer>
            <asp:Button runat="server" ID="saveBtn" OnClick="saveBtn_Click" Text="Save" />
        </footer>
    </article>


</asp:Content>
