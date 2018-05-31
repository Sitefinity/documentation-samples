// Documentation articles: https://docs.sitefinity.com/for-developers-assign-classes-to-the-body-tags-of-pages-using-a-master-page

using System;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.WebFormWidgetsSamples.BodyClassMasterPage
{
    public partial class BodyClassMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var provider = SiteMapBase.GetCurrentProvider() as SiteMapBase;
            var siteNode = provider.CurrentNode as PageSiteNode;
            if (siteNode != null)
            {
                var bodyClass = siteNode.GetCustomFieldValue("BodyClass").ToString();
                this.bodyTag.Attributes.Add("class", bodyClass);
            }
        }
    }
}