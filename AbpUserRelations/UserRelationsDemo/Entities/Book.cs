using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace UserRelationsDemo.Entities;

public class Book : AggregateRoot<int>
{
    public string Name { get; set; }

    public Collection<UserBook> UserBooks { get; set; }
}

public class UserBook : BasicAggregateRoot<int>
{
    public IdentityUser User { get; set; }
    public Book Book { get; set; }
}