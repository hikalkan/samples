using DddDemo.Issues.Dtos;

namespace DddDemo.Issues
{
    public interface IIssueAppService
    {
        void AssignIssueToUser(AssignIssueToUserInput input);

        void AddComment(AddCommentInput input);

        GetIssueOutput GetIssue(GetIssueInput input);
    }
}
