using ShareYourself.Data;
using GenericRepository.Data.EntityFramework;
using ShareYourself.Data.Entities;
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
