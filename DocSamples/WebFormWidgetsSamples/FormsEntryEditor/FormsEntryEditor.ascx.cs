// Documentation articles: https://docs.sitefinity.com/tutorial-create-a-web-form-with-a-form-response-editor

using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Forms;

namespace SitefinityWebApp.WebFormWidgetsSamples.FormsEntryEditor
{
    public partial class FormsEntryEditor : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormsEntryEditor" /> class.
        /// </summary>

        public FormsEntryEditor()
        {
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsManager manager = FormsManager.GetManager();

            var myForm = manager.GetFormByName("sf_mytestform");

            var res = manager.GetFormEntries(myForm).Select(response => new
            {
                Query = FormsManager.GetEncryptedQueryStringFormResponseEdit(myForm.Id, response.Id, null, false),

                // To get the ID, edit the textbox in the Form Editor and expand the Advanced: Name for developers box
                EditableTextbox = response.GetValue<string>("FormTextBox_C004"),
                HiddenTextbox = response.GetValue<string>("FormTextBox_C003"),
                ReadonlyTextbox = response.GetValue<string>("FormTextBox_C001")
            }).ToList();

            this.grid.DataSource = res;

            this.grid.RowCreated += (object s, GridViewRowEventArgs ea) =>
            {
                ea.Row.Cells[1].Visible = false;
            };

            this.grid.DataBind();
        }
    }
}