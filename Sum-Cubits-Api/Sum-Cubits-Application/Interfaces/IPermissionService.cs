
namespace Sum_Cubits_Application.Interfaces
{
    public interface IPermissionService
    {
        Task<bool> CheckPermission (int roleId, string action, string controller);

        void RecomePermissionListFromCache(int roleId);
    }
}
