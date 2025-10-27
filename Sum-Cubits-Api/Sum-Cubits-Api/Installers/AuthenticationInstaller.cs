using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Runtime.CompilerServices;

namespace Sum_Cubits_Api.Installers
{
    public static class AuthenticationInstaller
    {
        public static void InstallAuthentication(this IServiceCollection services, string? audience, string? authority)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Audience = audience;
                    options.Authority = authority;
                });
        }
    }
}
