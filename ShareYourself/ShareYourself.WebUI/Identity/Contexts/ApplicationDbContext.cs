using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ShareYourself.WebUI.Identity.Models;

namespace ShareYourself.WebUI.Identity.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ShareYourselfIdentityConnection") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}