namespace DddDemo
{
    public interface IObjectMapper
    {
        TDestination Map<TDestination>(object obj);
    }
}