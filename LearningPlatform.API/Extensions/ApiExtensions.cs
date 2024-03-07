using LearningPlatform.API.Endpoints;
using LearningPlatform.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LearningPlatform.API.Extensions
{
    public static class ApiExtensions
    {
        public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCoursesEndpoints();
            // app.MapLessonsEndpoints();
            app.MapUsersEndpoints();
        }

        public static void AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            // схема по которой должен действовать API,
            // когда к нему хочет аутентифицироваться пользователь
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions!.SecretKey)),
                    };
                    // делаем валидацию не из headers, а из cookie

                    options.Events = new JwtBearerEvents
                    {
                        // подписка на событие OnMessageReceived
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["tasty-cookies"];

                            return Task.CompletedTask;
                        }
                    };

                });

            services.AddAuthorization();
        }
    }
}
