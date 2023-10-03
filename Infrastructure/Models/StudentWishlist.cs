using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class StudentWishlist
    {
        [Key]
        public int StudentWishListId { get; set; }

        [StringLength(20), Display(Name = "Format")]
        public string? StudentFormat { get; set; }

        [Required]
        [Display(Name = "Student")]
        [Range(1, 65535)]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Course")]
        [Range(1, 65535)]
        public int CourseId { get; set; }

      
        [Display(Name = "Time Block")]
        [Range(1, 255)]
        public int TimeblockId { get; set; }

        [Display(Name = "Day Block")]
        [Range(1, 255)]
        public int DayBlockId { get; set; }

        [Required]
        [Display(Name = "Semester")]
        [Range(1, 65535)]
        public int SemesterId { get; set; }


        [ForeignKey("StudentId")]
        
        public Student? Student { get; set; }
       

        [ForeignKey("CourseId")]
        
        public Course? Course { get; set; }

        [ForeignKey("TimeBlockId")]
       
        public TimeBlock? TimeBlock { get; set; }

        [ForeignKey("DayBlockId")]
        public DayBlock? DayBlock { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
    }
}
