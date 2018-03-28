using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MongoDbDemo
{
    public class QaUser : Entity<Guid>, IUser, IHasExtraProperties
    {
        public virtual string UserName { get; protected set; }

        public virtual float Reputation { get; set; }

        public virtual Collection<QaUserActivity> Activities { get; set; }

        public virtual IDictionary<string, object> ExtraProperties { get; set; }

        protected QaUser()
        {
            Activities = new Collection<QaUserActivity>();
        }

        public virtual void ChangeUserName(string userName)
        {
            UserName = userName;
        }
    }
}