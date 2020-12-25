using System;

namespace EfCoreLinqWrapper.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Author()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return "[AUTHOR] " + Name + " (" + Id + ")";
        }
    }
}
