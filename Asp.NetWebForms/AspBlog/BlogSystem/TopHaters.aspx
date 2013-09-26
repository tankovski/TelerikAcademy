<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopHaters.aspx.cs" Inherits="BlogSystem.TopHaters" %>

<%@ Register Src="~/UserRatingControl.ascx" TagPrefix="userControls" TagName="UserRatingControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<userControls:UserRatingControl runat="server" ID="UserRatingControl" />    

</asp:Content>
