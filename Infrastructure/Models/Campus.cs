using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CASPAR.Infrastructure.Models
{
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }

        [Required]
        public string? CampusName { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
