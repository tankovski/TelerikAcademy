<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegForm.aspx.cs" Inherits="RegistrationForm.RegForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegForm" runat="server" defaultbutton="ButtonSubmit">

        <asp:ScriptManager ID="sm1" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>

        <div id="container">
            Username: 
        <asp:TextBox ID="UsernameTb" runat="server"></asp:TextBox>
            <br />
            Password: 
        <asp:TextBox ID="PasswordTb" runat="server"></asp:TextBox>
            <br />
            Repeat password: 
        <asp:TextBox ID="RepPasswordTb" runat="server"></asp:TextBox>
            <br />
            FirstName: 
        <asp:TextBox ID="FiesrNameTb" runat="server"></asp:TextBox>
            <br />
            LastName: 
        <asp:TextBox ID="LastNameTb" runat="server"></asp:TextBox>
            <br />
            Age: 
        <asp:TextBox ID="AgeTb" runat="server"></asp:TextBox>
            <br />
            Email: 
        <asp:TextBox ID="EmailTb" runat="server"></asp:TextBox>
            <br />
            Address: 
        <asp:TextBox ID="AddressTb" runat="server"></asp:TextBox>
            <br />
            Phone: 
        <asp:TextBox ID="PhoneTb" runat="server"></asp:TextBox>
            <br />
            I accept
        <asp:CheckBox ID="AcceptCb" runat="server" />
            <br />
            <asp:CustomValidator ID="AtLeastOneContact" runat="server"
                ErrorMessage="All fields are required"
                Display="None"
                OnServerValidate="AtLeastOneContact_ServerValidate"
                ForeColor="Red"
                EnableClientScript="false"
                 />

            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ControlToCompare="PasswordTb"
                ControlToValidate="RepPasswordTb" Display="None"
                ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False"
                Text=""></asp:CompareValidator>

            <asp:RegularExpressionValidator
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
            </asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidatorAge"
                runat="server" ForeColor="Red" Display="None"
                ErrorMessage="Age is not incorrect!"
                ControlToValidate="AgeTb" EnableClientScript="False"
                Text=""
                ValidationExpression="[1][8-9]|[2-7][0-9]|80|81">
            </asp:RegularExpressionValidator>
            <asp:Label ID="result" runat="server"></asp:Label>
            <asp:ValidationSummary ID="Summary" runat="server" 
                ForeColor="Red" DisplayMode="List"/>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        </div>
    </form>
</body>
</html>
