using System;
using CASPAR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Models
{
    public class InstructorWishlistModality
    {
        [Key]
        [Range(0, 255)]
        public int? InstructorWishlistModalityId { get; set; }
        [Range(0, 255)]
        public int? ModalityId { get; set; }
        [Range(0, 255)]
        public int? InstructorWishListDetailsId { get; set; }

        [ForeignKey("ModalityId")]
        public Modality? Modality { get; set; }

        [ForeignKey("InstructorWishListDetailsId")]
        public InstructorWishlistDetails? InstructorWishlistDetails { get; set; }
    }
}
