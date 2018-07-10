// Documentation articles: https://docs.sitefinity.com/tutorial-build-a-form-widget

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Sitefinity.Web.UI.Fields;
using Telerik.Sitefinity.Web.UI.Fields.Enums;

namespace SitefinityWebApp.WebFormWidgetsSamples.FormWidget
{
    [DatabaseMapping(UserFriendlyDataType.ShortText)]
    [PropertyEditorTitle("FormWidget Properties"), Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(SitefinityWebApp.WebFormWidgetsSamples.FormWidget.FormWidgetDesigner))]
    public class FormWidget : FieldControl, IFormFieldControl
    {
        public FormWidget()
        {
            this.Title = "FormWidget";
        }

        public override string Example { get; set; }

        public override string Title { get; set; }

        public override string Description { get; set; }

        protected internal virtual Label TitleLabel
        {
            get
            {
                return this.Container.GetControl<Label>("titleLabel", true);
            }
        }

        protected internal virtual Label DescriptionLabel
        {
            get
            {
                return Container.GetControl<Label>("descriptionLabel", true);
            }
        }

        protected internal virtual Label ExampleLabel
        {
            get
            {
                return this.Container.GetControl<Label>("exampleLabel", this.DisplayMode == FieldDisplayMode.Write);
            }
        }

        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            var descriptor = new ScriptControlDescriptor(typeof(FormWidget).FullName, this.ClientID);
            descriptor.AddElementProperty("textbox", this.TextBox1.ClientID);
            descriptor.AddProperty("dataFieldName", this.MetaField.FieldName); //the field name of the corresponding widget
            return new[] { descriptor };
        }

        protected override void InitializeControls(GenericContainer container)
        {
            // Set the label values
            this.ExampleLabel.Text = this.Example;
            this.TitleLabel.Text = this.Title;
            this.DescriptionLabel.Text = this.Description;

            this.TextBox1.Text = GetCurrentSitefinityUser();
        }

        private static string GetCurrentSitefinityUser()
        {
            var identity = ClaimsManager.GetCurrentIdentity();
            var userId = identity.UserId;


            if (userId != Guid.Empty)
            {
                var userProfile = UserProfileManager.GetManager().GetUserProfiles(userId).FirstOrDefault() as Telerik.Sitefinity.Security.Model.SitefinityProfile;
                if (userProfile != null)
                {
                    return userProfile.FirstName + " " + userProfile.LastName;
                }
            }
            return String.Empty;
        }

        protected override WebControl TitleControl
        {
            get
            {
                return this.TitleLabel;
            }
        }

        protected override WebControl DescriptionControl
        {
            get
            {
                return this.DescriptionLabel;
            }
        }

        protected override WebControl ExampleControl
        {
            get
            {
                return this.ExampleLabel;
            }
        }


        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return FormWidget.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        public static readonly string layoutTemplatePath = "SitefinityWebApp.WebFormWidgetsSamples.FormWidget.FormWidget.ascx";

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IMetaField MetaField
        {
            get
            {
                if (this.metaField == null)
                {
                    this.metaField = this.LoadDefaultMetaField();
                }

                return this.metaField;
            }
            set
            {
                this.metaField = value;
            }
        }

        public override object Value
        {
            get
            {
                return this.TextBox1.Text;
            }

            set
            {
                this.TextBox1.Text = value.ToString();
            }
        }

        protected virtual TextBox TextBox1
        {
            get
            {
                return this.Container.GetControl<TextBox>("TextBox1", true);
            }
        }

        private IMetaField metaField = null;
        public const string scriptReference = "~/WebFormWidgetsSamples/FormWidget/FormWidget.js";
    }
}