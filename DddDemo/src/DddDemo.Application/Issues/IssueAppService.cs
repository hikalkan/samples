using System.Collections.Generic;
using System.Linq;
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
        private readonly IObjectMapper _objectMapper;

        public IssueAppService(
            IIssueRepository issueRepository,
            IUserRepository userRepository, 
            IssueManager issueManager,
            IValidationService validationService, 
            IUserEmailer userEmailer,
            IObjectMapper objectMapper)
        {
            _issueRepository = issueRepository;
            _userRepository = userRepository;
            _issueManager = issueManager;
            _validationService = validationService;
            _userEmailer = userEmailer;
            _objectMapper = objectMapper;

            AuthorizationService = NullAuthorizationService.Instance;
            SessionService = NullSessionService.Instance;
            Logger = NullLogger.Instance;
        }

        public void AssignIssueToUser(AssignIssueToUserInput input)
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

        public void AddComment(AddCommentInput input)
        {
            //TODO: Unit of work / transaction management

            AuthorizationService.CheckPermission("AddComment", input.IssueId);
            _validationService.Validate(input);

            var currentUser = _userRepository.Get(SessionService.UserId);
            var issue = _issueRepository.Get(input.IssueId);

            var comment = issue.AddComment(currentUser, input.Message);

            _userEmailer.AddedIssueComment(currentUser, issue, comment);
        }

        public GetIssueOutput GetIssue(GetIssueInput input)
        {
            AuthorizationService.CheckLogin();
            _validationService.Validate(input);

            var issue = _issueRepository.Get(input.Id);

            return new GetIssueOutput
            {
                Issue = _objectMapper.Map<IssueDto>(issue),
                Comments = GetIssueCommentDtos(issue.Id)
            };
        }

        private List<IssueCommentDto> GetIssueCommentDtos(string issueId)
        {
            return _issueRepository
                .GetCommentsWithCreatorUsers(issueId)
                .Select(c =>
                {
                    var commentDto = _objectMapper.Map<IssueCommentDto>(c.Comment);
                    commentDto.CreatorUser = _objectMapper.Map<BasicUserDto>(c.CreatorUser);
                    return commentDto;
                })
                .ToList();
        }
    }
}
