using System;

namespace EfCoreDemo.Entities
{
    public class DefaultUser : IUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        protected DefaultUser()
        {

        }

        public DefaultUser(Guid id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public override string ToString()
        {
            return $"# User => Id = {Id}, UserName = {UserName}";
        }
    }
}