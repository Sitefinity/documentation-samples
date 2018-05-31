<!-- Documentation articles: https://docs.sitefinity.com/tutorial-build-an-accordionnewslist-widget-using-sitefinity-s-built-in-jquery -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccordionNewsList.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.AccordionNewsList.AccordionNewsList" %>

 <%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>
   
 <sf:ResourceLinks ID="resourceLinks1" runat="server">
     <sf:ResourceFile Name="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css"/>
 </sf:ResourceLinks>
   
 <div id="accordion">
     <asp:Repeater runat="server" ID="newsRepeater">
         <ItemTemplate>
             <h3>
                 <%# Eval("Title") %>
             </h3>
             <div>
                 <%# Eval("Content") %>
             </div>
         </ItemTemplate>
     </asp:Repeater>
 </div>