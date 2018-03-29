using System.Collections.Generic;

namespace EfCoreValueConverterDemo
{
    public interface IHasExtraProperties
    {
        Dictionary<string, object> ExtraProperties { get; }
    }
}