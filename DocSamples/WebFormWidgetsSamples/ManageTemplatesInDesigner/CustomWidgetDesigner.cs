//Documentation articles: https://docs.sitefinity.com/tutorial-manage-custom-control-templates-through-the-designer

using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Sitefinity.Web.UI.ControlDesign.Selectors;

namespace SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner
{
    public class CustomWidgetDesigner : ControlDesignerBase
    {
        protected internal virtual TemplateSelector TempSelector
        {
            get
            {
                return this.Container.GetControl<TemplateSelector>("tempSelector", true);
            }
        }

        public override string LayoutTemplatePath
        {
            get
            {
                return CustomWidgetDesigner.layoutTemplatePath;
            }
        }

        #region Private members & constants

        public static readonly string layoutTemplatePath = "~/CustomPrefix/SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.ascx";
        
        #endregion

        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.DesignerMode = ControlDesignerModes.Simple;
            this.TempSelector.DesignedControlType = this.PropertyEditor.Control.GetType().FullName;
        }

        public override IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

            descriptor.AddComponentProperty("tempSelector", this.TempSelector.ClientID);
            
            return scriptDescriptors;
        }

        #region Private members & constants

        public const string scriptReference = "SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.js";

        #endregion

    }
}