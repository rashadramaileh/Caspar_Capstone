using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class UniProgram
    {
        [Range(0, 65535), Key, Display(Name = "Program")]
        public int UniProgramId { get; set; }

        [StringLength(100, MinimumLength = 3), Required]
        public string? ProgramName { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
