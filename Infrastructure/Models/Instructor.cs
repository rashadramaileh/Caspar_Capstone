using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Instructor : ApplicationUser
    {

        public bool Adjunct { get; set; }

    }
}
