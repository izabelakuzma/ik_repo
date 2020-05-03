using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregatorProject.Models
{
    [Table("Links")]
    public class Link
    {
        [Key]
        public int LinkId { get; set; }

        [ForeignKey("Users")]
        public int? UserId { get; set; }

        [DisplayName("Tytuł")]
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [DisplayName("Link")]
        [Required(ErrorMessage = "Link jest wymagany.")]
        [Column(TypeName = "varchar(255)")]
        public string LinkAddress { get; set; }

        [DisplayName("Data dodania")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime AddingData { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
