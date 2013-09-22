<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheControl.ascx.cs" Inherits="TemplateForCache.CacheControl" %>
<%@ OutputCache Duration="20" VaryByParam="none" Shared="true" %>

<h2>This is in the cahe 20 seconds</h2>
<strong><%=DateTime.Now %></strong>
