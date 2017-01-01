using DddDemo.Issues.Dtos;

namespace DddDemo.Web.Models.Issues
{
    public class IssueDetailViewModel : GetIssueOutput
    {
        public string CurrentUserId { get; set; }

        public string GetStateText()
        {
            if (Issue.IsClosed)
            {
                return "Closed (" + Issue.CloseReason + ")";
            }
            else
            {
                return "Open";
            }
        }

        public bool CanDeleteComment(IssueCommentDto comment)
        {
            return comment.CreatorUser.Id == CurrentUserId;
        }
    }
}