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
        public string ApplicationUserId { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
