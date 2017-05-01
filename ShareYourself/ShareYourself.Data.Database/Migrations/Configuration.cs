namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShareYourself.Data.Database.ShareYourselfContextManager>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShareYourself.Data.Database.ShareYourselfContextManager context)
        {
        }
    }
}
