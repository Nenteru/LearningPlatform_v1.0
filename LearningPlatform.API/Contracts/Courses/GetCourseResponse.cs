using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Courses
{
    public record GetCourseResponse(
        [Required] Guid Id,
        [Required] string Title,
        [Required] string Description,
        [Required] decimal Price);
}
