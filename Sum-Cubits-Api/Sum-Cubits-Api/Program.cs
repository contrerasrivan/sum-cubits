using Scalar.AspNetCore;
using Sum_Cubits_Api.Installers;
using Sum_Cubits_Application;
using Sum_Cubits_Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
var authAudience = builder.Configuration["Auth0:Audience"];
var authAuthority = builder.Configuration["Auth0:Domain"];

builder.Services.InstallDatabase(connectionString);
builder.Services.InstallRepositories();


builder.Services.InstallCors();
builder.Services.InstallOpenApi();
builder.Services.AddMemoryCache();
builder.Services.AddOptions<ScalarOptions>().BindConfiguration("Scalar");
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.InstallAuthentication(authAudience, authAuthority);
builder.Services.InstallAuthorization();

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

app.Run();

