using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorWishlist
    {
        [Key]
        [Range(0, 65535)]
        public int InstructorWishlistId { get; set; }

        [Range(0, 255)]
        public int CampusId { get; set; }

        [Range(0, 255), Display(Name = "Ranking")]
        public int InstructorRanking { get; set; }

        [StringLength(20), Display(Name = "Instructor Format")]
        public string? InstructorFormat { get; set; }

        [Display(Name = "Instructor Notes")]
        public string? InstructorNotes { get; set; }

        [Range(0, 255), Display(Name = "Meeting Time")]
        public int MeetingTimeId { get; set; }

        [Range(0, 255)]
        public int? DaysBlockId { get; set; }

        [Range(0, 65535)]
        public int SemesterId { get; set; }

        [Range(0, 65535)]
        public int InstructorId { get; set; }

        [Range(0, 65535), Display(Name = "Course")]
        public int CourseId { get; set; }

        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }

        [ForeignKey("MeetingTimeId")]
        public MeetingTime? MeetingTime { get; set; }

        [ForeignKey("DayBlockId")]
        public DayBlock? DayBlock { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor? Instructor { get; set; }
    }
}
