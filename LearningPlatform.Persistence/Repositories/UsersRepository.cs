

using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Core.Models;
using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly LearningDbContext _context;

        public UsersRepository(LearningDbContext context)
        {
            this._context = context;
        }

        public async Task Add(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };

            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email)
                ?? throw new Exception("User not found");

            return User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);
        }
    }
}
