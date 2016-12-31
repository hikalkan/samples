using DddDemo.Issues;
using DddDemo.Issues.Comments;

namespace DddDemo.Users
{
    public interface IUserEmailer
    {
        void IssueAssigned(User user, Issue issue);

        void AddedIssueComment(User user, Issue issue, IssueComment comment);
    }
}