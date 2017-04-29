namespace ShareYourself.Business
{
    public interface IBaseOperations
    {
        void Create<TDto>(TDto dto) where TDto : class;
        TDto Get<TDto>(int id) where TDto : class;
    }
}
