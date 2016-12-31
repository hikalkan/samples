namespace DddDemo.Authorization
{
    public class NullAuthorizationService : IAuthorizationService
    {
        public static NullAuthorizationService Instance { get; } = new NullAuthorizationService();

        private NullAuthorizationService()
        {
            
        }

        public void CheckPermission(string permissionName)
        {
            
        }

        public void CheckPermission(string permissionName, string entityId)
        {
            
        }
    }
}