namespace DddDemo.Issues
{
    public class IssueLockedException : OperationalException
    {
        public string IssueId { get; }

        public IssueLockedException(string issueId)
            : base(OperationalExceptionType.IssueLocked)
        {
            IssueId = issueId;
        }
    }
}