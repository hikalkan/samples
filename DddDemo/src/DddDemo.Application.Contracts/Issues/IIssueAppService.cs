using DddDemo.Issues.Dtos;

namespace DddDemo.Issues
{
    public interface IIssueAppService
    {
        void AssignIssueToUser(AssignIssueToUserDto input);
    }
}
