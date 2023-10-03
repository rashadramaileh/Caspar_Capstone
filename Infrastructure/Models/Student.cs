using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public int MajorId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("MajorId")]
        public Major? Major { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

    }
}
