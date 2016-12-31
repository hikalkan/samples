namespace DddDemo.Authorization
{
    public interface IAuthorizationService
    {
        void CheckPermission(string permissionName);

        void CheckPermission(string permissionName, string entityId);

        void CheckLogin();
    }
}