using System;

namespace EfCoreDemo.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public Guid CreatorUserId { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return $"# Question => Text = {Text}";
        }
    }
}
