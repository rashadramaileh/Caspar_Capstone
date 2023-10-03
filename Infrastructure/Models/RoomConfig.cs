using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class RoomConfig
    {
        [Key, Range(0, 65535), Display(Name = "Room Config")]
        public int RoomConfigId { get; set; }

        [Required, StringLength(50), Display(Name = "Room Config Name")]
        public String? RoomConfigName { get; set; }

    }
}
