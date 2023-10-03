using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class Modality
    {
        [Key, Range(0, 255)]
        public int ModalityId{get; set;}

        [Required, StringLength(30), Display(Name = "Modality")]
        public string? ModalityName{get; set;}

        [StringLength(200), Display(Name = "Description")]
        public string? ModalityDescription{get; set;}
    }
}
