using System.Collections.Generic;
using DddDemo.Issues.Comments;

namespace DddDemo.Issues
{
    public interface IIssueRepository
    {
        Issue Get(string id);

        int GetOpenIssueCountOfUser(string userId);

        void Update(Issue issue);

        List<IssueCommentWithCreatorUser> GetCommentsWithCreatorUsers(string issueId);
    }
}