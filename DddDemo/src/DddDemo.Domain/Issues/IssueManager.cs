using DddDemo.Users;

namespace DddDemo.Issues
{
    public class IssueManager
    {
        private readonly IIssueAssignmentPolicy _issueAssignmentPolicy;
        private readonly IIssueRepository _issueRepository;

        public IssueManager(IIssueAssignmentPolicy issueAssignmentPolicy, IIssueRepository issueRepository)
        {
            _issueAssignmentPolicy = issueAssignmentPolicy;
            _issueRepository = issueRepository;
        }

        public void Assign(Issue issue, User user)
        {
            issue.AssignTo(user, _issueAssignmentPolicy);
            _issueRepository.Update(issue);
        }
    }
}
