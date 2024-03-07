using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Courses
{
    public record class UpdateCourseRequest(
        [Required] string Title,
        [Required] string Description,
        [Required] decimal Price);
}
