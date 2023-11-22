using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class StudentWishlist
    {
        [Key]
        [Range(0, 65535)]
        public int StudentWishlistId { get; set; }


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
