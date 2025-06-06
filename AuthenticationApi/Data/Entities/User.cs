using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Data.Entities
{
    public class User:BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = "";

        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
