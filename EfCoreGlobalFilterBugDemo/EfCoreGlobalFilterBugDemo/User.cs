using System;

namespace EfCoreGlobalFilterBugDemo
{
    public class User : IMultiTenant, ISoftDelete
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }

        public string UserName { get; set; }

        public bool IsDeleted { get; set; }

        protected User()
        {

        }

        public User(Guid id, string userName, Guid? tenantId = null)
        {
            Id = id;
            UserName = userName;
        }

        public override string ToString()
        {
            return $"# QaUser => Id = {Id}, UserName = {UserName}";
        }
    }
}
