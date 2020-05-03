using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregatorProject.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [DisplayName("Adres email")]
        [Required(ErrorMessage = "Adres email jest wymagany.")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [DisplayName("Hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DisplayName("Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasło nie pasuje.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public virtual ICollection<Link> Links { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
