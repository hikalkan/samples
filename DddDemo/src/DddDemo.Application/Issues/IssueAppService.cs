using DddDemo.Users;

namespace DddDemo.Issues
{
    public class IssueAppService : IIssueAppService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IUserRepository _userRepository;
        private readonly IssueManager _issueManager;

        public IssueAppService(
            IIssueRepository issueRepository,
            IUserRepository userRepository, 
            IssueManager issueManager)
        {
            _issueRepository = issueRepository;
            _userRepository = userRepository;
            _issueManager = issueManager;
        }

        public void AssignIssueToUser(AssignIssueToUserDto input)
        {
            //TODO: Auth, validation, unit of work ...

            var user = _userRepository.Get(input.UserId);
            var issue = _issueRepository.Get(input.IssueId);

            _issueManager.Assign(issue, user);
        }
    }
}
