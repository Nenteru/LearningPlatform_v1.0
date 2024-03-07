

using LearningPlatform.Core.Models;
using LearningPlatform.Persistence.Repositories;

namespace LearningPlatform.Application.Services
{
    public class CoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        
        public async Task CreateCourse(Course course)
        {
            await _coursesRepository.Create(course);
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _coursesRepository.Get();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _coursesRepository.GetById(id);
        }

        public async Task<Guid> UpdateCourse(Guid id, string title, string description, decimal price)
        {
            return await _coursesRepository.Update(id, title, description, price);
        }

        public async Task<Guid> DeleteCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
    }
}
