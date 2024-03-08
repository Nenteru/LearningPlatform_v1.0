using LearningPlatform.API.Contracts.Users;
using LearningPlatform.Application.Services;
using LearningPlatform.Infrastructure;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LearningPlatform.API.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterUserRequest request, UsersService usersService)
        {
            await usersService.Register(request.UserName, request.Email, request.Password);
            
            return Results.Ok();
        }

        private static async Task<IResult> Login(LoginUserRequest request, UsersService usersService, HttpContext context)
        {
            try
            {
                // Проверить email и пароль
                // Создать токен 
                var token = await usersService.Login(request.Email, request.Password);

                // сохранить токен в куки
                context.Response.Cookies.Append("tasty-cookies", token);
            }
            catch(Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
            return Results.Ok();
        }
    }
}
