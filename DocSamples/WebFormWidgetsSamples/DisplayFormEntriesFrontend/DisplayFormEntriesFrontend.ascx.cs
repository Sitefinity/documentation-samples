// Documentation articles: https://docs.sitefinity.com/for-developers-display-from-responses-on-the-frontend

using System;
using System.Linq;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Forms;

namespace SitefinityWebApp.WebFormWidgetsSamples.DisplayFormEntriesFrontend
{
    public partial class DisplayFormEntriesFrontend : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsManager formsManager = FormsManager.GetManager();
            var formName = "sf_myform1";
            var form = formsManager.GetFormByName(formName);
            var entries = formsManager.GetFormEntries(form.EntriesTypeName);
            var entry = formsManager.GetFormEntries(form.EntriesTypeName).FirstOrDefault();

            if (entry != null)
            {
                // Get the fields of the form
                var fields = (from ctrl in form.Controls.Where(c => c.Properties.Count(c2 => c2.Name.Equals("MetaField")) > 0).Cast<FormControl>()
                              select new ControlForDisplay
                              {
                                  fieldName = ctrl.Properties.FirstOrDefault(p => p.Name.Equals("MetaField")).ChildProperties.FirstOrDefault(cp => cp.Name == "FieldName").Value,
                                  fieldTitle = ctrl.Properties.FirstOrDefault(p => p.Name.Equals("MetaField")).ChildProperties.FirstOrDefault(cp => cp.Name == "FieldName").Value,
                                  siblingId = ctrl.SiblingId,
                                  Id = ctrl.Id,
                                  controlType = "formField"
                              }).ToList<ControlForDisplay>();


                // Get field values for specified entry
                var formResponse = from fld in fields
                                   select new
                                   {
                                       Title = fld.fieldTitle,
                                       Response = entry.GetValue(fld.fieldName).ToString(),
                                       ControlType = fld.controlType
                                   };


                litFormTitle.Text = form.Title;
                rptFormResponses.DataSource = formResponse;
                rptFormResponses.DataBind();
            }

        }

        private class ControlForDisplay
        {
            public string fieldName { get; set; }
            public string fieldTitle { get; set; }
            public Guid siblingId { get; set; }
            public Guid Id { get; set; }
            public string controlType { get; set; }
        }

    }
}