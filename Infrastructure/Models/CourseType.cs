using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class CourseType
    {
        [Range(0, 65535), Key, Display(Name = "Type")]
        public int CourseTypeId { get; set; }

        [StringLength(20), Required, Display(Name = "Course Type")]
        public String? CourseTypeName { get; set; }
    }
}
