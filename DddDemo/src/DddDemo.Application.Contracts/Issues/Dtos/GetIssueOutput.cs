using System.Collections.Generic;

namespace DddDemo.Issues.Dtos
{
    public class GetIssueOutput
    {
        public IssueDto Issue { get; set; }

        public List<IssueCommentDto> Comments { get; set; }
    }
}