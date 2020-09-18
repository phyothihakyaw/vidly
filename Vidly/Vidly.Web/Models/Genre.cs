using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Genre")]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
