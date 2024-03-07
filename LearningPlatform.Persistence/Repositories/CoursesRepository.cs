using LearningPlatform.Core.Models;
using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LearningPlatform.Persistence.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly LearningDbContext _context;

        public CoursesRepository(LearningDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Create(Course course)
        {
            var courseEntity = new CourseEntity
            {
                Title = course.Title,
                Description = course.Description,
                Price = course.Price
            };

            await _context.Courses.AddAsync(courseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> Get()
        {
            var courseEntities = await _context.Courses
                .AsNoTracking()
                .ToListAsync();

            var courses = courseEntities
                .Select(e => Course.Create(e.Id, e.Title, e.Description, e.Price))
                .ToList();

            return courses;
        }

        public async Task<Course> GetById(Guid id)
        {
            var courseEntity = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new Exception("Course not found");

            return Course.Create(courseEntity.Id, courseEntity.Title, courseEntity.Description, courseEntity.Price);
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Courses
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Title, x => title)
                    .SetProperty(x => x.Description, x => description)
                    .SetProperty(x => x.Price, x => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Courses
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

    }
}
