namespace Sum_Cubits_Api.Installers
{
    public static class CorsInstaller
    {
        public static void InstallCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.WithOrigins(
                        "https://localhost:4001", //Dev
                        "https://sum-cubits-qa.vulktech.com", //QA
                        "https://sum-cubits.vulktech.com" //Prod
                        );
                });
            });
        }
    }
}
