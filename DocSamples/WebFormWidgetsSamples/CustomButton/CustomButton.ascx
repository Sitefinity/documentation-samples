<!-- Documentation articles: https://docs.sitefinity.com/tutorial-customize-the-label-of-the-search-button-in-a-multiple-site-project -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomButton.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.CustomButton.CustomButton" %>

<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
    
<fieldset id="main" class="sfsearchBox" runat="server">

    <asp:TextBox ID="searchTextBox" runat="server" CssClass="sfsearchTxt" />
    <asp:Button  ID="searchButton" runat="server" Text="<%$Resources:SearchResources, Search %>" OnClientClick="return false;" CssClass="sfsearchSubmit" />

</fieldset>