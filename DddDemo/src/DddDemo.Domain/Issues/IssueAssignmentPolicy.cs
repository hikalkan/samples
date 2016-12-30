using DddDemo.Users;

namespace DddDemo.Issues
{
    public class IssueAssignmentPolicy : IIssueAssignmentPolicy
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IIssueAssignmentConfiguration _configuration;

        public IssueAssignmentPolicy(IIssueRepository issueRepository, IIssueAssignmentConfiguration configuration)
        {
            _issueRepository = issueRepository;
            _configuration = configuration;
        }

        public void CheckAssignment(Issue issue, User user)
        {
            if (_issueRepository.GetOpenIssueCountOfUser(user.Id) >= _configuration.MaxConcurrentOpenIssueCountForAUser)
            {
                throw new IssueAssignmentException(
                    OperationalExceptionType.MaxConcurrentOpenIssueCountForAUser,
                    $"Can not assign more than {_configuration.MaxConcurrentOpenIssueCountForAUser} open issues to a user!"
                );
            }

            //TODO: Other rules!
        }
    }
}