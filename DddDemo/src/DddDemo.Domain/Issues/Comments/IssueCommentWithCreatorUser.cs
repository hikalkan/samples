using DddDemo.Users;

namespace DddDemo.Issues.Comments
{
    /// <summary>
    /// An object to handle a <see cref="IssueComment"/> and it's Creator <see cref="User"/>.
    /// </summary>
    public class IssueCommentWithCreatorUser
    {
        public IssueComment Comment { get; set; }

        public User CreatorUser { get; set; }
    }
}