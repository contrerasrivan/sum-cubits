using Sum_Cubits_Application.Features.Permisos;

namespace Sum_Cubits_Api.Installers
{
    public static class QueryInstaller
    {
        public static IServiceCollection InstallQueries(this IServiceCollection services)
        {
            var applicationAssembly = typeof(QueryPermiso).Assembly;

            var queryTypes = applicationAssembly.GetTypes()
                .Where(t => t.IsClass &&
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
