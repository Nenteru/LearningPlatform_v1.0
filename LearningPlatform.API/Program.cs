using LearningPlatform.API.Extensions;
using LearningPlatform.Application.Interfaces.Auth;
using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Application.Services;
using LearningPlatform.Infrastructure;
using LearningPlatform.Persistence;
using LearningPlatform.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddApiAuthentication(configuration);

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddDbContext<LearningDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(LearningDbContext)));
});

services.AddScoped<IUsersRepository, UsersRepository>();
services.AddScoped<ICoursesRepository, CoursesRepository>();

services.AddScoped<UsersService>();
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

// для большей безопастности, чтобы js код не мог считывать cookie
// чтобы можно было отправлять cookie только по https протоколу
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();

app.AddMappedEndpoints();

app.Run();