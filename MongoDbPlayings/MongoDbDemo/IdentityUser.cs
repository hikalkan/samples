using System;
using System.Collections.ObjectModel;

namespace MongoDbDemo
{
    public class IdentityUser : Entity<Guid>, IUser
    {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public Collection<IdentityUserRole> Roles { get; protected set; }

        protected IdentityUser()
        {

        }

        public IdentityUser(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Roles = new Collection<IdentityUserRole>();
        }
    }
}