//Documentation articles: https://docs.sitefinity.com/link-widget-components

using System.Collections.Generic;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.WebFormWidgetsSamples.HelloWorld
{
    public class HelloWorldDesigner : ControlDesignerBase
    {
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.DesignerMode = ControlDesignerModes.Simple;
        }

        //Link the designer to its template

        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return HelloWorldDesigner.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        private static readonly string layoutTemplatePath = "SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner.ascx";

        //Register the control designer script

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            // get script collection
            var scripts = base.GetScriptReferences() as List<ScriptReference>;
            if (scripts == null) return base.GetScriptReferences();

            scripts.Add(new ScriptReference(scriptReference));

            return scripts.ToArray();
        }
        private string scriptReference = "~/WebFormWidgetsSamples/HelloWorld/HelloWorldDesigner.js";
    }
}