<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarsStore.aspx.cs" Inherits="CarsStore.CarsStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ProducersDropDown" runat="server" DataTextField="Name" AutoPostBack="true"
                OnSelectedIndexChanged="ProducersDropDown_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ModelsDropDown" runat="server"></asp:DropDownList>
            <asp:CheckBoxList ID="ExtrasCheckBoxList" runat="server" DataTextField="Name"></asp:CheckBoxList>
            <asp:RadioButtonList ID="EnginesRadioButtons" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
            <br />
            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
