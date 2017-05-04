using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using ShareYourself.Business.Infrastructure.MapperProfiles;
using ShareYourself.WebUI.Infrastructure.MapperProfiles;

namespace ShareYourself.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(new[]
            {
                typeof(UserProfileMapperProfile),
                typeof(UserProfileDtosViewModelProfile),
                typeof(UserPostMapperProfile)
            }));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
