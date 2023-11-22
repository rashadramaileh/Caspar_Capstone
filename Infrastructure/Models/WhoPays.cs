using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class WhoPays
    {
        [Key, Range(0, 65535)]
        public int WhoPaysId { get; set; }
        
        [Required, StringLength(20), Display(Name = "Payment")]
        public string? WhoPaysName { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
