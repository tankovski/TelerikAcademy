<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteViewState.aspx.cs" Inherits="DeleteViewState.DeleteViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.0.3.js"></script>
</head>
<body>
    
    <%--Script injection--%>
    <%--<script>
        (function () {
            $("#__VIEWSTATE").val("");
        }())
        document.location.reload();

    </script>--%>

     <%--<% this.ViewState.Clear(); %>--%>
    <form id="form1" runat="server">
    <div>
          <asp:TextBox ID="ScriptHolder" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="RunScript" runat="server" OnClick="RunScript_Click"  Text="Click"/>
        <br />
        <button id="delete-viewstate">DeleteStateView</button>
        <asp:Label ID="ScriptResult" runat="server"></asp:Label>
    </div>
    </form>

    <script>
        $(document).ready(
        $("#form1").on("click", "#delete-viewstate", function () {

            $("#__VIEWSTATE").val("");
        })
        );
    </script>
</body>
</html>
