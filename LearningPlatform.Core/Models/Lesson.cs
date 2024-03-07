

namespace LearningPlatform.Core.Models
{
    public class Lesson
    {
        public Guid Id { get; }
        public string Theme { get; } = string.Empty;
        public string Content { get; } = string.Empty;
        private Lesson(Guid id, string theme, string content)
        {
            Id = id;
            Theme = theme;
            Content = content;
        }
        public static Lesson Create(Guid id, string theme, string content)
        {
            if(string.IsNullOrEmpty(theme) || string.IsNullOrEmpty(content))
            {
                throw new Exception("is not valid params by Lesson");
            }

            return new Lesson(id,theme,content);
        }
    }


}
