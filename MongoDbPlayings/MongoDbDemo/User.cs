using System;

namespace MongoDbDemo
{
    public class User : Entity<Guid>, IUser
    {
        public string UserName { get; protected set; }

        protected User()
        {
            
        }

        public User(Guid id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}