using System;

namespace EfCoreValueConverterDemo
{
    public interface IUser : IEntity<Guid>
    {
        string UserName { get; }
    }
}