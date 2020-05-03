using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregatorProject.Models
{
    [Table("Ratings")]
    public class Rating
    {
        [Key]
        public int RateId { get; set; }

        [ForeignKey("Users")]
        public int? UserId { get; set; }

        [ForeignKey("Links")]
        public int? LinkId { get; set; }

        public int? IsRate { get; set; }
    }
}
