using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Data;

namespace ShareYourself.Business
{
    public interface IService<TSourceDto, TDestination>
       where TDestination: IEntity
    {
        void Create(TSourceDto dto);
    }
}
