using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CASPAR.Infrastructure.Models
{
    public class Course
    {
        [Range(0, 65535), Key, Display(Name = "Course")]
        public int CourseId { get; set; }

        [StringLength(10), Required, Display(Name = "Prefix")]
        public String? CoursePrefix { get; set; }

        [Range(0, 65535), Required, Display(Name = "Number")]
        public int CourseNumber { get; set; }

        [StringLength(150), Required, Display(Name = "Name")]
        public String? CourseName { get; set; }

        [StringLength(1000), Required, Display(Name = "Description")]
        public String? CourseDesc { get; set; }

        [Range(0, 5), Required, Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }

        [Range(0, 65535), Required, Display(Name = "Program")]
        public int UniProgramId { get; set; }

        [ForeignKey("UniProgramId")]
        public UniProgram? UniProgram { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
        [NotMapped]
        public string FullName { get { return CoursePrefix + " " + CourseNumber; } }
    }
}
