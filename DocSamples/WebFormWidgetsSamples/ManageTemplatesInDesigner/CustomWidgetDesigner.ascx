<!-- Documentation articles: https://docs.sitefinity.com/tutorial-manage-custom-control-templates-through-the-designer -->

<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI.ControlDesign.Selectors" %>

<div>   
    <h2>
        <asp:Literal ID="literal" runat="server" Text="<%$Resources:CustomControlResources, CustomWidgetTemplate %>" />
    </h2>    
    <sf:TemplateSelector runat="server" ID="tempSelector" />
</div>  