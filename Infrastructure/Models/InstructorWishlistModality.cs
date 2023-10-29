using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorWishlistModality
    {
        [Key]
        [Range(0, 255)]
        public int InstructorWishlistModalityId { get; set; }
        [Range(0, 255), DisplayName("Format")]
        public int? ModalityId { get; set; }
        [Range(0, 255)]
        public int? InstructorWishListDetailsId { get; set; }

        [ForeignKey("ModalityId")]
        public Modality? Modality { get; set; }

        [ForeignKey("InstructorWishListDetailsId")]
        public InstructorWishlistDetails? InstructorWishlistDetails { get; set; }
    }
}
