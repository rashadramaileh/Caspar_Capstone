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

        [Range(0, 255), Display(Name = "Instructor Ranking")]
        public int InstructorRanking { get; set; }

        [Display(Name = "Instructor Notes")]
        public string? InstructorNotes { get; set; }

        [Range(0, 65535), Display(Name = "Course")]
        public int CourseId { get; set; }

        [Range(0, 65535), Display(Name = "Wishlist Number")]
        public int InstructorWishlistId { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        [ForeignKey("InstructorWishlistId"), DeleteBehavior(DeleteBehavior.NoAction)]
        public InstructorWishlist? InstructorWishlist { get; set; }

    }
}
