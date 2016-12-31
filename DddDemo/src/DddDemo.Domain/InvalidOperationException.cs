namespace DddDemo.Issues
{
    public class InvalidOperationException : OperationalException
    {
        public InvalidOperationException(string message)
            :base(OperationalExceptionType.InvalidOperation, message)
        {
            
        }
    }
}