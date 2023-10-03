using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Building
    {
        [Key, Range(0, 65535)]
        public int BuildingId { get; set; }

        [Required, StringLength(50), Display(Name="Building Name")]
        public string? BuildingName { get; set; }

        [Required, Range (0,255)]
        public int CampusId { get; set; }

        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }
    }
}
