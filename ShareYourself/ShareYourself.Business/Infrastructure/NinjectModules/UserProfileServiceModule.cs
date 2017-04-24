using Ninject.Modules;
using ShareYourself.Business.Services;

namespace ShareYourself.Business.Infrastructure.NinjectModules
{
    public class UserProfileServiceModule : NinjectModule
    {
        protected string connectionString;

        public UserProfileServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUserProfileService>().To<UserProfileService>().WithConstructorArgument("connectionString", connectionString);
        }
    }
}
