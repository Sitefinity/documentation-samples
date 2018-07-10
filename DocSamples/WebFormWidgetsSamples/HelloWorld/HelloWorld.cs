//Documentation articles: https://docs.sitefinity.com/link-widget-components

using System;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.WebFormWidgetsSamples.HelloWorld
{
    [ControlDesigner(typeof(HelloWorldDesigner))]
    public class HelloWorld : SimpleView
    {
        public string Name { get; set; }

        protected internal virtual Label NameLabel
        {
            get
            {
                return this.Container.GetControl<Label>("nameLabel", true);
            }
        }

        protected override void InitializeControls(GenericContainer container)
        {
            if (String.IsNullOrEmpty(Name))
            {
                this.NameLabel.Text = "World!";
            }
            else
            {
                this.NameLabel.Text = Name;
            }
        }

        //Link the widget to its template

        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return HelloWorld.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        private static readonly string layoutTemplatePath = "~/WebFormWidgetsSamples/HelloWorld/HelloWorld.ascx";
    }
}