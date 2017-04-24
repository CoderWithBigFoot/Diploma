using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourself.Data.Contexts;

namespace ShareYourself.Data.Database
{
    public class ShareYourselfContextManager : ShareYourselfContext
    {
        public ShareYourselfContextManager() : base("ShareYourself") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
