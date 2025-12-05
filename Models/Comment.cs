using System.ComponentModel.DataAnnotations;

namespace MyCvSite.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string AuthorName { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Text { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int LikesCount { get; set; } = 0;
    }
}
