using CASPAR.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class InstructorLoad
    {
        [Key]
        public int InstructorLoadId { get; set; }

        [Range(0, 12)]
        public int LoadAmount { get; set; }

        public string ApplicationUserId { get; set; }

        [Range(1, 65535)]
        public int SemesterTypeId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("SemesterTypeId")]
        public SemesterType? SemesterType { get; set; }
    }
}
