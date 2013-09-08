<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="UserProfile.Friends" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
     <meta name="author" content="Me" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <div class="contentDiv">
       <p class="friendContent"><asp:Image ImageUrl="imgs/cool.jpg" CssClass="friendImg"  runat="server"/>
           <br />
           <strong>Joreca</strong>
       </p>

         <p class="friendContent"><asp:Image ImageUrl="imgs/Cool-emoticon.jpg" CssClass="friendImg"  runat="server"/>
           <br />
           <strong>Vankata</strong>
       </p>

         <p class="friendContent"><asp:Image ImageUrl="imgs/images.jpg" CssClass="friendImg"  runat="server"/>
           <br />
           <strong>The evil metal</strong>
       </p>
    </div>
</asp:Content>
