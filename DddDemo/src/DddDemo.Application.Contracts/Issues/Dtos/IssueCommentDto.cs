using DddDemo.Users;

namespace DddDemo.Issues.Dtos
{
    public class IssueCommentDto
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public BasicUserDto CreatorUser { get; set; }
    }
}