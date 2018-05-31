<!-- Documentation articles: https://docs.sitefinity.com/for-developers-use-linq-deferred-execution -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LINQDefferedExecution.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.LINQDefferedExecution.LINQDefferedExecution" %>

<asp:Repeater ID="newsList" runat="server">
    <ItemTemplate>
        <p><asp:Label ID="title" runat="server"><%# Eval("Title") %></asp:Label></p>
    </ItemTemplate>
</asp:Repeater>