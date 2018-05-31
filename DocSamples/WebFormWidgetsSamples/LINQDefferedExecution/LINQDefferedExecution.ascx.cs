// Documentation articles: https://docs.sitefinity.com/for-developers-use-linq-deferred-execution

using System;
using Telerik.Sitefinity;

namespace SitefinityWebApp.WebFormWidgetsSamples.LINQDefferedExecution
{
    public partial class LINQDefferedExecution : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void BindRepeater()
        {
            var news = App.WorkWith().NewsItems().Get();
            this.newsList.DataSource = news;
            this.newsList.DataBind();
        }
    }
}