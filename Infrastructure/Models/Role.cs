using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(20)]
        public string? RoleName { get; set; }

        [StringLength(200)]
        public string RoleDescription { get; set; } = string.Empty;
    }
}
