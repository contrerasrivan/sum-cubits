using Sum_Cubits_Application.Features.Permissions;

namespace Sum_Cubits_Api.Installers
{
    public static class QueryInstaller
    {
        public static IServiceCollection InstallQueries(this IServiceCollection services)
        {
            var applicationAssembly = typeof(QueryPermission).Assembly;

            var queryTypes = applicationAssembly.GetTypes()
                .Where(t => !t.IsClass &&
                !t.IsAbstract &&
                t.Name.StartsWith("Query"))
                .ToList();

            foreach (var queryType in queryTypes)
            {
                services.AddScoped(queryType);
            }

            return services;
        }

    }
}
