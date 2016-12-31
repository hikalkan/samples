using DddDemo.Authorization;
using DddDemo.Issues.Dtos;
using DddDemo.Session;
using DddDemo.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DddDemo.Issues
{
    public class IssueAppService : IIssueAppService
    {
        public IAuthorizationService AuthorizationService { get; set; }
        public ISessionService SessionService { get; set; }
        public ILogger Logger { get; set; }

        private readonly IIssueRepository _issueRepository;
        private readonly IUserRepository _userRepository;
        private readonly IssueManager _issueManager;
        private readonly IValidationService _validationService;
        private readonly IUserEmailer _userEmailer;

        public IssueAppService(
            IIssueRepository issueRepository,
            IUserRepository userRepository, 
            IssueManager issueManager,
            IValidationService validationService, 
            IUserEmailer userEmailer)
        {
            _issueRepository = issueRepository;
            _userRepository = userRepository;
            _issueManager = issueManager;
            _validationService = validationService;
            _userEmailer = userEmailer;

            AuthorizationService = NullAuthorizationService.Instance;
            SessionService = NullSessionService.Instance;
            Logger = NullLogger.Instance;
        }

        public void AssignIssueToUser(AssignIssueToUserDto input)
        {
            //TODO: Unit of work / transaction management

            AuthorizationService.CheckPermission("TaskAssignmentPermission");
            _validationService.Validate(input);

            var user = _userRepository.Get(input.UserId);
            var issue = _issueRepository.Get(input.IssueId);

            _issueManager.Assign(issue, user);

            if (SessionService.UserId != user.Id)
            {
                _userEmailer.IssueAssigned(user, issue);
            }

            Logger.LogInformation($"Assigned issue {issue} to user {user}");
        }
    }
}
