using DddDemo.Users;

namespace DddDemo.Issues
{
    public class IssueManager
    {
        private readonly IIssueAssignmentPolicy _issueAssignmentPolicy;

        public IssueManager(IIssueAssignmentPolicy issueAssignmentPolicy)
        {
            _issueAssignmentPolicy = issueAssignmentPolicy;
        }

        public void Assign(Issue issue, User user)
        {
            issue.AssignTo(user, _issueAssignmentPolicy);
        }
    }
}
