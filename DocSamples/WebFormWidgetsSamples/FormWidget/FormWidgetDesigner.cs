// Documentation articles: https://docs.sitefinity.com/tutorial-build-a-form-widget

using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.WebFormWidgetsSamples.FormWidget
{
    public class FormWidgetDesigner : ControlDesignerBase
    {
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.DesignerMode = ControlDesignerModes.Simple;
        }
    }
}