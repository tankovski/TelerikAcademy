<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Chat.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="ChatForm" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <asp:ListView ID="AllMassageslistView" runat="server" DataKeyNames="Id"
            ItemType="Chat.Models.Message">
            <LayoutTemplate>
               <asp:UpdatePanel runat="server">
                   <Triggers>
                       <asp:AsyncPostBackTrigger EventName="Tick" ControlID="ChatRefreshTimer" />
                   </Triggers>
                   <ContentTemplate>
                       <div id="itemPlaceHolder" runat="server"></div>
                   </ContentTemplate>
               </asp:UpdatePanel>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="SingleMessageContainer">
                    <p><%#: Item.Text %></p>
                    by <strong><%#: Item.Username %></strong> on <time><%#:Item.TimeOfCreation %></time>
                </div>
            </ItemTemplate>
        </asp:ListView>

        <div class="EnterMessagesPanel">
            Enter message:
            <asp:TextBox ID="NewMassageTextTb" runat="server" placeholder="Enter message"></asp:TextBox>
            <br />
             Enter username:
            <asp:TextBox ID="NewMassageUserTb" runat="server" placeholder="Enter Username"></asp:TextBox>
            <br />
            <asp:Button ID="SendMsgBtn" runat="server" Text="SendMsg" OnClick="SendMsgBtn_Click" />
        </div>
        <asp:Timer ID="ChatRefreshTimer" runat="server" Interval="3000" ></asp:Timer>
    </div>
    </form>
</body>
</html>
