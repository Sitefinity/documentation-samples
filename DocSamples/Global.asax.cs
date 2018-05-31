// Documentation articles: https://docs.sitefinity.com/administration-enable-asp-net-bundling-and-minification, https://docs.sitefinity.com/use-custom-video-thumbnail-generation

using System;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.Libraries.Videos.Thumbnails;
using System.Web.Hosting;
using System.Web.Optimization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initialized += new EventHandler<Telerik.Sitefinity.Data.ExecutedEventArgs>(Bootstrapper_Initialized);

            //Use the following to register the BundleConfig
            BundlingAndMinification.BundleConfig.RegisterBundles(BundleTable.Bundles);

            BundleTable.VirtualPathProvider = HostingEnvironment.VirtualPathProvider;
            BundleTable.EnableOptimizations = true;
        }

        void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {

            //Use the following to register the CustomVideoThumbnailGenerator
            if (e.CommandName == "Bootstrapped")
            {
                ObjectFactory.Container.RegisterType<IVideoThumbnailGenerator, NRecoVideoConvertor.CustomVideoThumbnailGenerator>(new ContainerControlledLifetimeManager());
            }

            //Register a virtual path for the CustomWidgetDesigner
            if (e.CommandName == "RegisterRoutes")
            {
                var virtualPathConfig = Config.Get<VirtualPathSettingsConfig>();
                var customDesignerVirtualPathConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = "~/CustomPrefix/*",
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "SitefinityWebApp"
                };
                virtualPathConfig.VirtualPaths.Add(customDesignerVirtualPathConfig);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}