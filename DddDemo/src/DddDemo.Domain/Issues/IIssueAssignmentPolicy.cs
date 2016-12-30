using DddDemo.Users;

namespace DddDemo.Issues
{
    public interface IIssueAssignmentPolicy
    {
        void CheckAssignment(Issue issue, User user);
    }
}