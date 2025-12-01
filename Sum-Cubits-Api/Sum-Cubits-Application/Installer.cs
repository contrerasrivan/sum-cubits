using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sum_Cubits_Application.Infrastructure.Database;
using System.Reflection;

namespace Sum_Cubits_Application
{
    public static class Installer
    {
        public static void InstallDatabase(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOption =>
                {
                    sqlServerOption.CommandTimeout(5);
                    sqlServerOption.EnableRetryOnFailure();
                    sqlServerOption.MigrationsAssembly("migration_history");
                });
            });
        }

        public static void InstallRepositories(this IServiceCollection services)
        {
            var repositoryType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => !type.IsInterface &&
                type.FullName != null &&
                type.FullName.EndsWith("Repository"));

            foreach (var type in repositoryType)
            {
                var typeInterface = type.GetInterfaces()[0];
                services.AddScoped(typeInterface, type);
            }
        }

        public static void InstallServices(this IServiceCollection services)
        {
            var serviceTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => !type.IsInterface &&
                               !type.IsAbstract &&
                               type.FullName != null &&
                               type.FullName.EndsWith("Service"));

            foreach (var type in serviceTypes)
            {
                var interfaces = type.GetInterfaces();

                if (interfaces.Length > 0)
                {
                    var typeInterface = interfaces[0];
                    services.AddScoped(typeInterface, type);
                }
                else
                {
                    // Registrar la clase concreta directamente
                    services.AddScoped(type);
                }
            }
        }

    }
}
