using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }

        [Required]
        public string? CampusName { get; set; }

    }
}
