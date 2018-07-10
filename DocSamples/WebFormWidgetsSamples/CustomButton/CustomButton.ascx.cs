// Documentation articles: https://docs.sitefinity.com/tutorial-customize-the-label-of-the-search-button-in-a-multiple-site-project

using System;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.WebFormWidgetsSamples.CustomButton
{
    public partial class CustomButton : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var multisiteContext = SystemManager.CurrentContext as MultisiteContext;

            if (multisiteContext.CurrentSite.Name == "SecondSite")
            {
                this.searchButton.Text = "Search2";
            }

            if (multisiteContext.CurrentSite.Name == "ThirdSite")
            {
                this.searchButton.Text = "Search3";
            }
        }
    }
}