using System.Collections.Generic;

namespace MongoDbDemo
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
    
    public interface IHasExtraProperties
    {
        IDictionary<string, object> ExtraProperties { get; set; }
    }
}