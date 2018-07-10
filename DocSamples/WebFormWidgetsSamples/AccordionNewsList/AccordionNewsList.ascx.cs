// Documentation articles: https://docs.sitefinity.com/tutorial-build-an-accordionnewslist-widget-using-sitefinity-s-built-in-jquery

using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Modules.Pages;

namespace SitefinityWebApp.WebFormWidgetsSamples.AccordionNewsList
{
    public partial class AccordionNewsList : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            InitPage();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var newsManager = NewsManager.GetManager();

                var news = newsManager
                    .GetNewsItems()
                    .Where(n => n.Status == ContentLifecycleStatus.Live)
                    .OrderByDescending(n => n.PublicationDate);

                this.newsRepeater.DataSource = news;
                this.newsRepeater.DataBind();
            }
        }

        private void InitPage()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager == null) return;

            // Adding Sitefinity's built in jQuery
            PageManager.ConfigureScriptManager(Page, ScriptRef.JQuery);

            // Adding jQueryUI from a CDN
            scriptManager.Scripts.Add(new ScriptReference { Path = "//code.jquery.com/ui/1.10.4/jquery-ui.js" });

            // Adding a custom Javascript resource
            scriptManager.Scripts.Add(new ScriptReference { Path = "~/WebFormWidgetsSamples/AccordionNewsList/AccordionNewsList.js" });
        }
    }
}