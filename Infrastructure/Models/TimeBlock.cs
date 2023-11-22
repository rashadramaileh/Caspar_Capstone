using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class TimeBlock
    {
        [Range(0, 255), Key, Display(Name="Time")]
        public int TimeBlockId { get; set; }

        [StringLength(20), Required, Display(Name = "Time")]
        public String? TimeName { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
