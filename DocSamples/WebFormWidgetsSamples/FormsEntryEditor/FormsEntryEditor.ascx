<!-- Documentation articles: https://docs.sitefinity.com/tutorial-create-a-web-form-with-a-form-response-editor -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormsEntryEditor.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.FormsEntryEditor.FormsEntryEditor" %>

 <!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">

 <head>
   <title>Forms entry editor example</title>
   <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
 </head>

 <body>

   <form id="formsViewer" runat="server">
     <div style="margin: 0 auto; width: 50%">
       <asp:GridView ID="grid" runat="server">
         <Columns>
           <asp:TemplateField>
             <ItemTemplate>
               <input type="button"
                 value="edit"
                 data-query="<%# Eval("Query") %>"
                 class="editButton" />
             </ItemTemplate>
           </asp:TemplateField>
         </Columns>
       </asp:GridView>
     </div>
   </form>
  
   <script type="text/javascript">
       (function () {
           $(".editButton").on("click", function (e) {
               window.location.href = "http://localhost/form-page?" + $(this).attr('data-query');
           });
       })()
   </script>
 
 </body>
 
</html>