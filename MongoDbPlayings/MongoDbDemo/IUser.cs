using System;

namespace MongoDbDemo
{
    public interface IUser : IEntity<Guid>
    {
        string UserName { get; }
    }
}