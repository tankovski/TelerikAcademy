<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegGroups.aspx.cs" Inherits="RegFormGroups.RegGroups" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegForm" runat="server" defaultbutton="ButtonSubmit">

        <div id="container">
            Username: 
        <asp:TextBox ID="UsernameTb" runat="server" ValidationGroup="UserInfoGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UsernameValidator" runat="server"
                 Text="*" Display="Dynamic" ErrorMessage="Username field is empty!"
                ControlToValidate="UsernameTb"></asp:RequiredFieldValidator>
            <br />
            Password:             
        <asp:TextBox ID="PasswordTb" runat="server" ValidationGroup="UserInfoGroup" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="PassValidator" runat="server"
                 Text="*" Display="Dynamic" ErrorMessage="Password field is empty!"
                ControlToValidate="PasswordTb"></asp:RequiredFieldValidator>
            <br />
            Repeat password: 
        <asp:TextBox ID="RepPasswordTb" runat="server" ValidationGroup="UserInfoGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RepPassValidator" runat="server"
                 Text="*" Display="Dynamic" ErrorMessage="Repeat password field is empty!"
                 ControlToValidate="RepPasswordTb"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ControlToCompare="PasswordTb"
                ControlToValidate="RepPasswordTb" Display="None"
                ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False"
                Text=""></asp:CompareValidator>
            <br />

            Personal info panel
            <asp:CheckBox ID="PersonalInfoGroupCheckBtn" runat="server" OnCheckedChanged="PersonalInfoGroupCheckBtn_CheckedChanged" />
            <br />
            <asp:Panel ID="PersonalInfo" runat="server" Visible="false">
                FirstName: 
        <asp:TextBox ID="FiesrNameTb" runat="server" ValidationGroup="PersonalInfoGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" Text="*"
                    ErrorMessage="First name field is empty!" Display="Dynamic"
                     ControlToValidate="FiesrNameTb"></asp:RequiredFieldValidator>
                <br />
                LastName: 
        <asp:TextBox ID="LastNameTb" runat="server" ValidationGroup="PersonalInfoGroup"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" Text="*"
                    ErrorMessage="Last name field is empty!" Display="Dynamic"
                     ControlToValidate="LastNameTb"></asp:RequiredFieldValidator>
                <br />
                Age: 
        <asp:TextBox ID="AgeTb" runat="server" ValidationGroup="PersonalInfoGroup"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="AgeValidator" runat="server" Text="*"
                    ErrorMessage="Age name field is empty!" Display="Dynamic"
                     ControlToValidate="AgeTb"></asp:RequiredFieldValidator>
            </asp:Panel>

         <%--   <br />
            Email: 
        <asp:TextBox ID="EmailTb" runat="server"></asp:TextBox>
            <br />
            Address: 
        <asp:TextBox ID="AddressTb" runat="server"></asp:TextBox>
            <br />
            Phone: 
        <asp:TextBox ID="PhoneTb" runat="server"></asp:TextBox>
            <br />--%>
            I accept
        <asp:CheckBox ID="AcceptCb" runat="server" />
            <br />

            

           <%-- <asp:RegularExpressionValidator
                ID="RegularExpressionValidatorEmail"
                runat="server" ForeColor="Red" Display="None"
                ErrorMessage="Email address is incorrect!"
                ControlToValidate="EmailTb" EnableClientScript="False"
                Text=""
                ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
            </asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidatorPhone"
                runat="server" ForeColor="Red" Display="None"
                ErrorMessage="Phone is incorrect!"
                ControlToValidate="PhoneTb" EnableClientScript="False"
                Text=""
                ValidationExpression="[0-9]{7,15}">
            </asp:RegularExpressionValidator>--%>
            <asp:Label ID="result" runat="server"></asp:Label>
            <asp:ValidationSummary ID="Summary" runat="server"
                ForeColor="Red" DisplayMode="List" />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        </div>
    </form>
</body>
</html>
