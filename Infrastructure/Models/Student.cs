using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Student : ApplicationUser
    { 

        public int MajorId { get; set; }

        [ForeignKey("MajorId")]
        public Major? Major { get; set; }

    }
}
