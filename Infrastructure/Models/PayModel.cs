using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class PayModel
    {
        [Key, Range(0, 65535)]
        public int PayModelId { get; set; }
        //[Required, StringLength(20), Display(Name = "Pay Model")]
        [Required, StringLength(20)]
        public String? PayType { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
