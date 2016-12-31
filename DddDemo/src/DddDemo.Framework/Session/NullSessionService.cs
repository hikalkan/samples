namespace DddDemo.Session
{
    public class NullSessionService : ISessionService
    {
        public static NullSessionService Instance { get; } = new NullSessionService();

        public string UserId { get; set; }

        private NullSessionService()
        {
            
        }
    }
}