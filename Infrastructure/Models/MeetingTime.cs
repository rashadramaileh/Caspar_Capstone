using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class MeetingTime
    {
        [Key, Range(0, 255), Display(Name = "Time")]
        public int meetingTimeId { get; set; }
        
        [Required, StringLength(20), Display(Name = "Time")]
        public string? meetingTimeName { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
