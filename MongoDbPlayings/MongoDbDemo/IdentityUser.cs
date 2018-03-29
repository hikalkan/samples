using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MongoDbDemo
{
    public class IdentityUser : Entity<Guid>, IUser, IHasExtraProperties
    {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public Collection<IdentityUserRole> Roles { get; protected set; }
        public IDictionary<string, object> ExtraProperties { get; set; }

        protected IdentityUser()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        public IdentityUser(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Roles = new Collection<IdentityUserRole>();
            ExtraProperties = new Dictionary<string, object>();
        }
    }
}