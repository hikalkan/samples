namespace DddDemo.Authorization
{
    public interface IAuthorizationService
    {
        void CheckPermission(string permissionName);
    }
}