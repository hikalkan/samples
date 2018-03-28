using System;

namespace MongoDbDemo
{
    public class QaUserActivity
    {
        public Guid UserId { get; set; }

        public string ActivityDefinition { get; set; }

        public DateTime Time { get; set; }
    }
}