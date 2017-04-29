using ShareYourself.Data;

namespace ShareYourself.Business.Services
{
    public class BaseService
    {
        protected IShareYourselfUow uow;

        public BaseService(IShareYourselfUow uow)
        {
            this.uow = uow;
        }
    }
}
