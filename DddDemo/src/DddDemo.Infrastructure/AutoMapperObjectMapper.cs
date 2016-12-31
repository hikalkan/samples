using AutoMapper;

namespace DddDemo
{
    public class AutoMapperObjectMapper : IObjectMapper
    {
        public TDestination Map<TDestination>(object obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
