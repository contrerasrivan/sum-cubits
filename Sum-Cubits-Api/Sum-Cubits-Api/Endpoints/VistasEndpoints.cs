using Sum_Cubits_Api.Endpoints.Vistas;

namespace Sum_Cubits_Api.Endpoints
{
    public static class VistasEndpoints
    {
        public static IEndpointRouteBuilder MapViewEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/vistas")
                .WithTags("Vistas")
                .WithOpenApi()
                .RequireAuthorization("Default"); ;
           
            group.MapGet("", GetViewList.Handle)
                .WithName("GetViewList")
                .RequireAuthorization("Default")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
