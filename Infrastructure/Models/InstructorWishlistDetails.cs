using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorWishlistDetails
    {
        [Key]
        [Range(0, 65535)]
        public int InstructorWishlistDetailsId { get; set; }

        [Range(0, 255)]
        public int CampusId { get; set; }

        [Range(0, 255), Display(Name = "Instructor Ranking")]
        public int InstructorRanking { get; set; }

        [StringLength(20), Display(Name = "Instructor Format")]
        public string? InstructorFormat { get; set; }

        [Range(0, 65535), Display(Name = "Wishlist Number")]
        public int InstructorWishlistId { get; set; }

        [Range(0, 255)]
        public int? TimeBlockId { get; set; }

        [Range(0, 255)]
        public int? DayBlockId { get; set; }

        [Range(0, 65535)]
        public int SemesterId { get; set; }

        [ForeignKey("InstructorWishlistId"), DeleteBehavior(DeleteBehavior.NoAction)]
        public InstructorWishlist? InstructorWishlist { get; set; }

        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }

        [ForeignKey("TimeBlockId")]
        public TimeBlock? TimeBlock { get; set; }

        [ForeignKey("DaysBlockId")]
        public DayBlock? DayBlock { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
    }
}
