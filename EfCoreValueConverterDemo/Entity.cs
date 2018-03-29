using Newtonsoft.Json;

namespace EfCoreValueConverterDemo
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        public override string ToString()
        {
            return "# " + GetType().Name + ": " + JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}