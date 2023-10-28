using CASPAR.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CASPAR.Infrastructure.Models
{
    public class StudentWishlistModality
    {
        [Key]
        [Range(0, 255)]
        public int StudentWishlistModalityId { get; set; }
        [Range(0, 255)]
        public int? ModalityId { get; set; }
        [Range(0, 255)]
        public int? StudentWishListDetailsId { get; set; }

        [ForeignKey("ModalityId")]
        public Modality? Modality { get; set; }

        [ForeignKey("StudentWishListDetailsId")]
        public StudentWishlistDetails? StudentWishlistDetails { get; set; }
    }
}
