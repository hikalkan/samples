using System;
using System.Collections.Generic;

namespace EfCoreCollectionBugRepro.Entities
{
    public class Person
    {
        public virtual Guid Id { get; private set; }

        public virtual string Name { get; private set; }

        public virtual List<ChangeLog> ChangeLogs { get; private set; }

        private Person()
        {
            
        }

        public Person(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            ChangeLogs = new List<ChangeLog>();
            ChangeLogs.Add(new ChangeLog(Id, $"Created the person with Name = {Name}"));
        }

        public virtual void ChangeName(string name)
        {
            ChangeLogs.Add(new ChangeLog(Id, $"Changed name from {Name} to {name}"));
            Name = name;
        }
    }
}
