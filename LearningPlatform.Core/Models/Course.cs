

namespace LearningPlatform.Core.Models
{
    public class Course
    {
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        private Course(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public static Course Create(Guid id, string title, string description, decimal price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || price < 0)
            {
                throw new Exception("is not valid params by Lesson");
            }

            return new Course(id, title, description, price);
        }
    }
}
