using System;

namespace EfCoreDemo.Entities
{
    public class IdentityUser : IUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        protected IdentityUser()
        {

        }

        public IdentityUser(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public override string ToString()
        {
            return $"# IdentityUser => Id = {Id}, UserName = {UserName}, Password = {Password}";
        }
    }
}