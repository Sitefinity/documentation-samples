// Documenation articles: https://docs.sitefinity.com/example-related-data-and-custom-widgets

using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.RelatedData.Web.UI;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.WebFormWidgetsSamples.RelatedDataUserWidget
{
    public partial class RelatedDataUserWidget : UserControl, IRelatedDataView
    {
        private RelatedDataDefinition relatedDataDefinition;
        //private const string SessionsType = "Telerik.Sitefinity.DynamicTypes.Model.Parent.Parent";
        private const string SessionsType = "Telerik.Sitefinity.DynamicTypes.Model.Test.Test";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var manager = DynamicModuleManager.GetManager();
            var items = manager.GetDataItems(TypeResolutionService.ResolveType(SessionsType)).Where(item => item.Status == ContentLifecycleStatus.Live);

            this.ParentRepeater.DataSource = items;
            this.ParentRepeater.DataBind();

            this.DisplayRelatedData();
        }

        public bool? DisplayRelatedData { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public RelatedDataDefinition RelatedDataDefinition
        {
            get
            {
                if (this.relatedDataDefinition == null)
                {
                    this.relatedDataDefinition = new RelatedDataDefinition();
                }
                return this.relatedDataDefinition;
            }
            set
            {
                this.relatedDataDefinition = value;
            }
        }


        public string UrlKeyPrefix { get; set; }

        public string GetContentType()
        {
            return TypeResolutionService.ResolveType(SessionsType).FullName;
        }

        public string GetProviderName()
        {
            // Returns the default provider.
            return string.Empty;
        }
    }
}