<!-- Documenation articles: https://docs.sitefinity.com/example-related-data-and-custom-widgets -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedDataUserWidget.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.RelatedDataUserWidget.RelatedDataUserWidget" %>

<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="designers" Namespace="Telerik.Sitefinity.RelatedData" %>

<table class="list-sessions">
     <asp:Repeater runat="server" ID="ParentRepeater">
         <ItemTemplate>
             <tr>
                 <td>
                     <h3>
                         <%# Eval("Title")%>
                         <span>
                             <asp:Repeater runat="server" ID="ChildRepeater"  DataSource='<%# Eval("Child")%>'>
                                 <ItemTemplate>
                                     <%# Eval("Title") %>
                                 </ItemTemplate>
                             </asp:Repeater>
                         </span>
                     </h3>
                 </td>
             </tr>
         </ItemTemplate>
     </asp:Repeater>
 </table>