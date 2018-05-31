<!-- Documentation articles: https://docs.sitefinity.com/for-developers-pass-dynamic-items-through-workflow-notification-system -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestForm.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.TestForm.TestForm" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>

<div id="FormPanel" runat="server" class="sfcommentsFormWithAvatarWrp">
    <sf:SitefinityLabel runat="server" ID="TitleBox"/> 
    <sf:SitefinityLabel runat="server" ID="NameBox" />
    <sf:SitefinityLabel runat="server" ID="NumberBox" />
    <sf:SitefinityLabel runat="server" ID="ApprovalLbl" />
</div>