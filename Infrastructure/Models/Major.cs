﻿using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class Major
    {
        [Key]
        public int MajorID { get; set; }

        [Required]
        public string? MajorName { get; set; }
    }
}
