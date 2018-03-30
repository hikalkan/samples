namespace EfCoreGlobalFilterBugDemo
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}