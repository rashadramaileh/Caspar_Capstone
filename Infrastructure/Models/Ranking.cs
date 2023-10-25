using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASPAR.Infrastructure.Models
{
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }

        [Required]
        public int? Rank { get; set; }
    }
}
