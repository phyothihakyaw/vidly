using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Released date")]
        public DateTime? ReleasedDate { get; set; }

        [Display(Name = "Date added")]
        public DateTime AddedDate { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public byte NumberInStock { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public byte NumberAvailable { get; set; }
    }
}
