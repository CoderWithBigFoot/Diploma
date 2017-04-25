using ShareYourself.Data;

namespace ShareYourself.Business.Services
{
    public class BaseService
    {
        protected IShareYourselfUow _uow;

        public BaseService(IShareYourselfUow uow)
        {
            _uow = uow;
        }
    }
}
