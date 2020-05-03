using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregatorProject.Models
{
    [NotMapped]
    public class LinkRatingViewModel
    {       
        public int LinkId { get; set; }
        public string LinkAddress { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AddingData { get; set; }

        public int IsRate { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public int Sum { get; set; }

        public int? RateId { get; set; }

    }
}
