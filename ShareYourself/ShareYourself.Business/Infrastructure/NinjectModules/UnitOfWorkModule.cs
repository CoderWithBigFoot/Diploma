using Ninject.Modules;
using System.Data.Entity;
using ShareYourself.Data;
using ShareYourself.Data.Contexts;

namespace ShareYourself.Business.Infrastructure.NinjectModules
{
    public class UnitOfWorkModule : NinjectModule
    {
        private DbContext _context;

        public UnitOfWorkModule(string connectionString)
        {
            _context = new ShareYourselfContext(connectionString);
        }

        public override void Load()
        {
            Bind<IShareYourselfUow>().To<ShareYourselfUow>().WithConstructorArgument("context", _context);
        }
    }
}
