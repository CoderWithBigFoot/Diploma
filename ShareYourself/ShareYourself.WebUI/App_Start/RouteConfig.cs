using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShareYourself.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LoginRoute",
                url: "login",
                defaults: new { controller = "Account", action = "Login" }
                );

            routes.MapRoute(
                name: "RegistrationRoute",
                url: "registration",
                defaults: new { controller = "Account", action = "Register" }
                );

            routes.MapRoute(
                name: "ErrorRoute",
                url: "error/{message}",
                defaults: new { controller = "Account", action = "Error" }
                );



            routes.MapRoute(
                name: "UserProfileRoute",
                url: "profile/id{id}",
                defaults: new { controller = "UserProfile", action = "ProfilePage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TagCloudRoute",
                url: "tagCloud",
                defaults: new { controller = "Post", action = "TagCloud" }
                );

            routes.MapRoute(
                name: "TagPostsRoute",
                url: "tagCloud/{tag}",
                defaults: new { controller = "Post", action = "TagPosts" }
                );

            routes.MapRoute(
                name: "EditUserProfileRoute",
                url: "edit",
                defaults: new { controller = "UserProfile", action = "EditUserProfile"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserProfile", action = "ProfilePage", id = UrlParameter.Optional}
            );          
        }
    }
}
