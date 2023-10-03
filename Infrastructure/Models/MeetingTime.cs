using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class MeetingTime
    {
        [Key, Range(0, 255), Display(Name = "Meeting Time")]
        public int meetingTimeId { get; set; }
        
        [Required, StringLength(20), Display(Name = "Meeting Time")]
        public string? meetingTimeName { get; set; }
    }
}
