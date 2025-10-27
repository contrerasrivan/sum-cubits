
namespace Sum_Cubits_Application.Interfaces
{
    public interface IUserService
    {
        Task<int?> GetRoleId(string? userId, string? email = null);
    }
}
