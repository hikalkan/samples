namespace DddDemo.Issues
{
    public class IssueAssignmentException : OperationalException
    {
        public IssueAssignmentException(string type, string message)
            : base(type, message)
        {

        }
    }
}