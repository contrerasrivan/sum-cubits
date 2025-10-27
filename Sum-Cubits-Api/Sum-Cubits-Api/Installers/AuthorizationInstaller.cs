using Sum_Cubits_Api.Authorization;
using Microsoft.AspNetCore.Authorization;


namespace Sum_Cubits_Api.Installers
{
    public static class AuthorizationInstaller
    {
        public static void InstallAuthorization(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, AuthorizationHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Default", policy =>
                {
                    policy.AddRequirements(new AuthorizationRequirement());
                });
            });
        }
    }
}
