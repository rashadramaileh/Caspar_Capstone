using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class Modality
    {
        [Key, Range(0, 255), DisplayName("Format")]
        public int ModalityId{get; set;}

        [Required, StringLength(30), DisplayName("Format")]
        public string? ModalityName{get; set;}

        [StringLength(200), Display(Name = "Description")]
        public string? ModalityDescription{get; set;}

        [DefaultValue(false)]
        public bool AdditionalWishlistInfo { get; set;}
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
