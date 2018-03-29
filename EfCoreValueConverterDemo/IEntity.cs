namespace EfCoreValueConverterDemo
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}