using LearningPlatform.Core.Models;

namespace LearningPlatform.Persistence.Repositories
{
    public interface ICoursesRepository
    {
        Task Create(Course course);
        Task<Guid> Delete(Guid id);
        Task<List<Course>> Get();
        Task<Course> GetById(Guid id);
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}