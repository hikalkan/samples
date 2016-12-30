using System;
using JetBrains.Annotations;

namespace DddDemo.Users
{
    public class User //Aggregate Root
    {
        [NotNull]
        public string Id { get; protected set; }

        [NotNull]
        public string UserName { get; }

        public User([NotNull] string userName)
        {
            Id = Guid.NewGuid().ToString("D");

            UserName = userName;
        }
    }
}