using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Data;
using ShareYourself.Data.Entities;

namespace ShareYourself.Business
{
    public interface IUserProfileService<TSource> : IService<TSource, UserProfile>
    {
    }
}
