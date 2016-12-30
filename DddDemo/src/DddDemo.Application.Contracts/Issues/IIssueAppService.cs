using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DddDemo.Issues
{
    public interface IIssueAppService
    {
        void AssignIssueToUser(AssignIssueToUserDto input);
    }

    public class AssignIssueToUserDto
    {
        public string IssueId { get; set; }

        public string UserId { get; set; }
    }
}
