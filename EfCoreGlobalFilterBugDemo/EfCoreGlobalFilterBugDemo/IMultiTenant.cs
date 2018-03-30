using System;

namespace EfCoreGlobalFilterBugDemo
{
    public interface IMultiTenant
    {
        Guid? TenantId { get; set; }
    }
}