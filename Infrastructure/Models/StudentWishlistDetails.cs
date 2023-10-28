using CASPAR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CASPAR.Infrastructure.Models
{
    public class StudentWishlistDetails
    {
        [Key]
        [Range(0, 65535)]
        public int StudentWishlistDetailsId { get; set; }

        [Display(Name = "Student Notes")]
        public string? StudentNotes { get; set; }

        [Range(0, 65535), Display(Name = "Course")]
        public int CourseId { get; set; }

        [Range(0, 65535), Display(Name = "Wishlist Number")]
        public int StudentWishlistId { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        [ForeignKey("StudentWishlistId"), DeleteBehavior(DeleteBehavior.Cascade)]
        public StudentWishlist? StudentWishlist { get; set; }
    }
}