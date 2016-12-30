namespace DddDemo.Issues
{
    public interface IIssueAssignmentConfiguration
    {
        int MaxConcurrentOpenIssueCountForAUser { get; set; }
    }
}