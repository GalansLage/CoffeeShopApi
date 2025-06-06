using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Data.Entities
{
    public class Role:BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string RolName { get; set; } = "";
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
