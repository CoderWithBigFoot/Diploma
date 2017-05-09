using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using ShareYourself.Business.Infrastructure.MapperProfiles;
using ShareYourself.Business;
using ShareYourself.WebUI.Infrastructure.MapperProfiles;
using Ninject;


namespace ShareYourself.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.AddProfile<UserProfileMapperProfile>();
                cfg.AddProfile<UserPostMapperProfile>();
                cfg.AddProfile<ViewModelsMapperProfile>();
            });

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
