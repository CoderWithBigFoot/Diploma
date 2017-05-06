using System.Collections.Generic;

namespace ShareYourself.Business
{
    public interface ITagService : IBaseOperations
    {
        TDto Get<TDto>(string tagName) where TDto : class; // 
        IEnumerable<TDto> Get<TDto>() where TDto : class;
        bool Contains(string tagName);
    }
}
