using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class DayBlock
    {
        [Range(0, 255), Key, Display(Name = "Day"), DisplayName("Day")]
        public int DaysBlockId { get; set; }

        [StringLength(20), Display(Name = "Day"), DisplayName("Day")]
        public string? DayName { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
