using Sum_Cubits_Api.Endpoints.Views;

namespace Sum_Cubits_Api.Endpoints
{
    public static class VistasEndpoints
    {
        public static IEndpointRouteBuilder MapViewEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/views")
                .WithTags("Views")
                .WithOpenApi();
           
            group.MapGet("/", GetViewList.Handle)
                .WithName("GetViewList")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
