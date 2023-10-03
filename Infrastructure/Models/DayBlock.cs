using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class DayBlock
    {
        [Range(0, 255), Key]
        public int DaysBlockId { get; set; }

        [StringLength(20), Display(Name = "Day")]
        public string? DayName { get; set; }
    }
}
