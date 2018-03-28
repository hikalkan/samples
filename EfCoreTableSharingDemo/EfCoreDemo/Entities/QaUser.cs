using System;

namespace EfCoreDemo.Entities
{
    public class QaUser : IUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public int Reputation { get; set; }

        protected QaUser()
        {

        }

        public QaUser(Guid id, string userName, int reputation)
        {
            Id = id;
            UserName = userName;
            Reputation = reputation;
        }

        public override string ToString()
        {
            return $"# QaUser => Id = {Id}, UserName = {UserName}, Reputation = {Reputation}";
        }
    }
}
