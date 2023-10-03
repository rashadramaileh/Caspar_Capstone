using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class User
    {
        [Key, Range(0, 65535)]
        public int UserId { get; set; }

        [StringLength(20), Display(Name = "First Name")]
        public string? UserFirst { get; set; }

        [StringLength(20), Display(Name = "Last Name")]
        public string? UserLast { get; set; }

        [StringLength(30), Display(Name = "Email")]
        public string? UserEmail { get; set; }

        [StringLength(20)]
        public string? UserPassword { get; set; }
        
        /*
        [NotMapped, Display(Name = "Name")]
        public string FullName { get { return UserFirst + " " + UserLast; } }
        */
    }
}
