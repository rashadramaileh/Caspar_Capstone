using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorWishlist
    {
        [Key]
        [Range(0, 65535)]
        public int InstructorWishlistId { get; set; }


        [Range(0, 65535)]
        public int SemesterId { get; set; }

        [Range(0, 65535)]
        public int InstructorId { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor? Instructor { get; set; }
    }
}
