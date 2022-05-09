using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace UserRelationsDemo.Entities;

public class Book : AggregateRoot<int>
{
    public string Name { get; set; }

    //public ICollection<IdentityUser> Readers { get; set; }
}

public class UserBook : BasicAggregateRoot<int>
{
    public IdentityUser User { get; set; }
    public Book Book { get; set; }
}