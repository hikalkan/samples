using System;

namespace EfCoreCollectionBugRepro.Entities
{
    public class ChangeLog
    {
        public virtual Guid Id { get; protected set; }

        public virtual Guid PersonId { get; protected set; }

        public virtual string ChangeInfo { get; protected set; }

        public virtual DateTime Time { get; protected set; }

        protected ChangeLog()
        {
            
        }

        public ChangeLog(Guid personId, string changeInfo)
        {
            Id = Guid.NewGuid();

            PersonId = personId;
            ChangeInfo = changeInfo;

            Time = DateTime.Now;
        }
    }
}