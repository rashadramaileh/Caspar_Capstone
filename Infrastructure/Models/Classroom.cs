using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Classroom
    {
        [Key, Range(0, 65535)]
        public int ClassroomId { get; set; }

        [Required, StringLength(10), Display(Name = "Room Number")]
        public string? RoomNumber { get; set; }

        [Required, Range(0, 65535)]
        public int Capacity { get; set; }

        //[Required, Range(0, 65535), Display(Name = "Room Config")]
        //public int RoomConfigId { get; set; }

        [Required, Range(0, 65535)]
        public int BuildingId { get; set; }

        //[ForeignKey("RoomConfigId")]
        //public RoomConfig? RoomConfig { get; set; }

        [ForeignKey("BuildingId")]
        public Building? Building { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
