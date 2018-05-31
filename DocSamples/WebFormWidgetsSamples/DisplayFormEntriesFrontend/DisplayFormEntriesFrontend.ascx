<!-- Documentation articles: https://docs.sitefinity.com/for-developers-display-from-responses-on-the-frontend -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DisplayFormEntriesFrontend.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.DisplayFormEntriesFrontend.DisplayFormEntriesFrontend" %>

<asp:Literal runat="server" ID="litFormTitle"></asp:Literal>

<asp:GridView ID="rptFormResponses" runat="server"
    AutoGenerateColumns="True">
</asp:GridView>