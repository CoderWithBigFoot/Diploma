namespace ShareYourself.Business
{
    public interface IBaseOperationsService
    {
        void Create<TDto>(TDto dto) where TDto: class;
    }
}
