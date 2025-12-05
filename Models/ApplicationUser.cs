using System.ComponentModel.DataAnnotations;

namespace MyCvSite.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
