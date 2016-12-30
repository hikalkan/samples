namespace DddDemo.Issues
{
    public class IssueAssignmentException : OperationalException
    {
        public IssueAssignmentException(OperationalExceptionType type, string message)
            : base(type, message)
        {

        }
    }
}