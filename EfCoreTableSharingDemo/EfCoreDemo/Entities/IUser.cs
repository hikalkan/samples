using System;

namespace EfCoreDemo.Entities
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }
    }
}
