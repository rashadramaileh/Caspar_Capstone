using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class PartOfTerm
    {
        [Key]
        [Range(0, 255)]
        public int PartOfTermID { get; set; }

        [Required, StringLength(20), Display(Name = "Term")]
        public string? PartOfTermName { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
