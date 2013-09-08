<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="StudentSystem.StudentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label AssociatedControlID="firstNameTb" runat="server" ID="fnLabel" Text="EnterFirstName" />
            <asp:TextBox ID="firstNameTb" runat="server" />
            <br />
            <asp:Label AssociatedControlID="lastNameTb" runat="server" ID="lnLabel" Text="EnterLastName" />
            <asp:TextBox ID="lastNameTb" runat="server" />
            <br />
            <asp:Label AssociatedControlID="facultyNumberTb" runat="server" ID="nuberLabel" Text="EnterFacultyNumber" />
            <asp:TextBox ID="facultyNumberTb" runat="server" />
            <br />
            <asp:Label AssociatedControlID="universitysDropDown" runat="server" ID="universityLabel" Text="ChooseUniversity" />
            <asp:DropDownList ID="universitysDropDown" runat="server">
                <asp:ListItem Value="UNSS">UNSS</asp:ListItem>
                <asp:ListItem Value="SofiaUniversity">SofiaUniversity</asp:ListItem>
                <asp:ListItem Value="NBU">NBU</asp:ListItem>
            </asp:DropDownList>
            <asp:CheckBoxList ID="coursesList" runat="server" SelectionMode="Multiple">
                <asp:ListItem Value="Css">Css</asp:ListItem>
                <asp:ListItem Value="Html">Html</asp:ListItem>
                <asp:ListItem Value="Php">Php</asp:ListItem>
                <asp:ListItem Value="Javascript">Javascript</asp:ListItem>
                <asp:ListItem Value="Java">Java</asp:ListItem>
            </asp:CheckBoxList>

            <asp:Button ID="submitBtn" OnClick="submitBtn_Click" runat="server" Text="submit" />
            <asp:Label ID="result" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
