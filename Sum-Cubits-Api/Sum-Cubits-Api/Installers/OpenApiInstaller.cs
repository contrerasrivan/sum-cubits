namespace Sum_Cubits_Api.Installers
{
    public static class OpenApiInstaller
    {
        public static void InstallOpenApi(this IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddSchemaTransformer((schema, context, cancellationToken) =>
                {
                    if (schema.Properties is null)
                        return Task.CompletedTask;

                    foreach (var property in schema.Properties)
                    {
                        if (schema.Required?.Contains(property.Key) != true)
                        {
                            property.Value.Nullable = false;
                        }
                    }

                    return Task.CompletedTask;
                });
            });
        }
    }
}
