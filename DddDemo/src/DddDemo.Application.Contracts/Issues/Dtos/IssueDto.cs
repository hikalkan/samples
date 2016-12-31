using DddDemo.Users;

namespace DddDemo.Issues.Dtos
{
    public class IssueDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsClosed { get; set; }

        public bool IsLocked { get; set; }

        public string CloseReason { get; set; }

        public BasicUserDto CreatorUser { get; set; }
    }
}