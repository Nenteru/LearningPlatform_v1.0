using LearningPlatform.API.Contracts.Users;
using LearningPlatform.Application.Services;
using System.IdentityModel.Tokens.Jwt;

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

        private static async Task<IResult> Login(LoginUserRequest request, UsersService usersService)
        {
            // Проверить email и пароль
            // Создать токен 
            var token = await usersService.Login(request.Email, request.Password);

            // сохранить токен в куки
            return Results.Ok(token);
        }
    }
}
