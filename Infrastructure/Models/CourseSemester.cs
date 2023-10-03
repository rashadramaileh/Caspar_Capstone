using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class CourseSemester
    {
        [Key]
        public int CourseSemesterId { get; set; }

        [Range(0, 255), Required]
        public int QuantityTaught { get; set; }

        [Range(0, 65535), Required]
        public int CourseId { get; set; }

        [Range(0, 65535), Required]
        public int SemesterTypeId { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        [ForeignKey("SemesterTypeId")]
        public SemesterType? SemesterType { get; set; }
    }
}
