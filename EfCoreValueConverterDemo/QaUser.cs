using System;
using System.Collections.Generic;

namespace EfCoreValueConverterDemo
{
    public class QaUser : Entity<Guid>, IUser, IHasExtraProperties
    {
        public virtual string UserName { get; protected set; }

        public virtual Dictionary<string, object> ExtraProperties { get; protected set; }

        protected QaUser()
        {
            //ExtraProperties = new Dictionary<string, object>();
        }

        public QaUser(string userName)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            ExtraProperties = new Dictionary<string, object>();
        }
    }
}