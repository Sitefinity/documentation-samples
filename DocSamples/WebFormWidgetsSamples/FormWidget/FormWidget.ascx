<!-- Documentation articles: https://docs.sitefinity.com/tutorial-build-a-form-widget -->

<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
  
<asp:Label runat="server" ID="titleLabel" CssClass="sfTxtLbl" Text="title label" AssociatedControlID="TextBox1" />

<div class="sfFieldWrp">
    <asp:TextBox ID="TextBox1" CssClass="sfTxt" runat="server" />
    <sf:SitefinityLabel runat="server" ID="descriptionLabel" WrapperTagName="div" CssClass="sfDescription"/>
    <sf:SitefinityLabel runat="server" ID="exampleLabel" WrapperTagName="div" CssClass="sfExample"/>
</div>