using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorTime
    {
        [Key]
        [Range(0, 255)]
        public int InstructorTimeId { get; set; }
        [Range(0, 255)]
        public int? DaysBlockId { get; set; }
        [Range(0, 255), Display(Name = "Time")]
        public int MeetingTimeId { get; set; }
        [Range(0, 255)]
        public int CampusId { get; set; }
        [Range(0, 255)]
        public int InstructorWishlistModalityId { get; set; }

        [ForeignKey("InstructorWishlistModalityId")]
        public InstructorWishlistModality? InstructorWishlistModality { get; set; }

        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }
        [ForeignKey("MeetingTimeId")]
        public MeetingTime? MeetingTime { get; set; }

        [ForeignKey("DaysBlockId")]
        public DayBlock? DayBlock { get; set; }
    }
}
