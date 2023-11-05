using Volo.Abp.Domain.Entities;

namespace ComplexTypeDemo.Entities;

public class Customer : AggregateRoot<Guid>
{
    public string Name { get; set; }
    public Address HomeAddress { get; set; }
    public Address BusinessAddress { get; set; }
}