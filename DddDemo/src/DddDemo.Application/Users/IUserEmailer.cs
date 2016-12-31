using DddDemo.Issues;

namespace DddDemo.Users
{
    public interface IUserEmailer
    {
        void IssueAssigned(User user, Issue issue);
    }
}