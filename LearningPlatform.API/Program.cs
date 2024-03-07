using LearningPlatform.API.Endpoints;
using LearningPlatform.Application.Interfaces.Auth;
using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Application.Services;
using LearningPlatform.Core.Models;
using LearningPlatform.Infrastructure;
using LearningPlatform.Persistence;
using LearningPlatform.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

//services.AddAuthorization();

// services.AddAuthentication();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddDbContext<LearningDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(LearningDbContext)));
});

services.AddScoped<IUsersRepository, UsersRepository>();

services.AddScoped<CoursesService>();

services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseExceptionHandler();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();

//app.UseAuthorization();

app.MapUsersEndpoints();

app.Run();