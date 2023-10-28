using CASPAR.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CASPAR.Infrastructure.Models
{
    public class StudentTime
    {

        [Key]
        [Range(0, 255)]
        public int StudentTimeId { get; set; }
        [Range(0, 255)]
        public int? TimeBlockId { get; set; }
        public int CampusId { get; set; }
        [Range(0, 255)]
        public int StudentWishlistModalityId { get; set; }

        [ForeignKey("StudentWishlistModalityId")]
        public StudentWishlistModality? StudentWishlistModality { get; set; }

        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }
        [ForeignKey("TimeBlockId")]
        public TimeBlock? TimeBlock { get; set; }

    }
}
