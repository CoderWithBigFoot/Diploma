using System.Data.Entity;
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
