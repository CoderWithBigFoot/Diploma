namespace ShareYourself.Business
{
    public interface IBaseServiceOperations
    {
        void Create<TDto>(TDto dto) where TDto : class;
        TDto Get<TDto>(int id) where TDto : class;
    }
}
