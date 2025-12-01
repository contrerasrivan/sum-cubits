using Scalar.AspNetCore;
using Sum_Cubits_Api.Endpoints;
using Sum_Cubits_Api.Installers;
using Sum_Cubits_Application;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
var authAudience = builder.Configuration["Auth0:Audience"];
var authAuthority = builder.Configuration["Auth0:Domain"];

builder.Services.InstallDatabase(connectionString);
builder.Services.InstallRepositories();
builder.Services.InstallServices();


builder.Services.InstallCors();
builder.Services.InstallOpenApi();
builder.Services.AddMemoryCache();
builder.Services.AddOptions<ScalarOptions>().BindConfiguration("Scalar");

builder.Services.InstallAuthentication(authAudience, authAuthority);
builder.Services.InstallAuthorization();

//Install Query 
builder.Services.InstallQueries();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/");
}

app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

//Endpoints Sum
app.MapPermissionEndpoints();
app.MapViewEndpoints();
app.MapRoleEndpoints();
app.MapUsersEndpoints();

app.Run();

