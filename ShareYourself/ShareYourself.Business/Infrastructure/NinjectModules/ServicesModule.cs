using Ninject.Modules;
using ShareYourself.Business.Services;

namespace ShareYourself.Business.Infrastructure.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        protected string connectionString;

        public ServicesModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUserProfileService>().To<UserProfileService>().WithConstructorArgument("connectionString", connectionString);
            Bind<IUserImageService>().To<UserImageService>().WithConstructorArgument("connectionString", connectionString);
            Bind<IUserPostService>().To<UserPostService>().WithConstructorArgument("connectionString", connectionString);
            Bind<ITagService>().To<TagService>().WithConstructorArgument("connectionString", connectionString);
        }
    }
}
