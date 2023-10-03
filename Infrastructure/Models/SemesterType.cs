﻿using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class SemesterType
    {
        [Key]
        public int SemesterTypeId { get; set; }
        
        [Required, Display(Name = "Semester")]
        public String? SemesterName { get; set; }

    }
}
