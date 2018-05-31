// Documentation articles: https://docs.sitefinity.com/for-developers-pass-dynamic-items-through-workflow-notification-system

using System;
using System.Collections.Generic;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Workflow;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Model;
using System.Text.RegularExpressions;

namespace SitefinityWebApp.WebFormWidgetsSamples.TestForm
{
    public partial class TestForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            // Get the fields value of the form
            var title = this.TitleBox.Text;
            var name = this.NameBox.Text;
            var number = this.NumberBox.Text;

            this.FormPanel.Visible = false;
            this.TitleBox.Text = "";
            this.NameBox.Text = "";
            this.NumberBox.Text = "";
            this.ApprovalLbl.Text = "The Form has been sent for approval";

            // Create new Dynamic Item
            var providerName = String.Empty;
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName);
            Type testType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Test.Test");
            DynamicContent testItem = dynamicModuleManager.CreateDataItem(testType);

            // Set the values in the new Dynamic Item fields
            testItem.SetValue("Title", title);
            testItem.SetValue("Name", name);
            testItem.SetValue("TelephoneNumber", number);
            var urlName = Regex.Replace(title, @"[\\~#%&*{}/:<>?|""@ ]", "-").ToLower();
            testItem.SetString("UrlName", urlName);

            // FIRST Check-out the Item
            dynamicModuleManager.Lifecycle.CheckOut(testItem);

            // THEN Save the changes
            dynamicModuleManager.SaveChanges();

            // Send the Item for approval
            var bag = new Dictionary<string, string>();
            bag.Add("ContentType", testItem.GetType().FullName);
            WorkflowManager.MessageWorkflow(testItem.Id, testItem.GetType(),
            dynamicModuleManager.Provider.ToString(), "SendForApproval", false, bag);
        }
    }
}