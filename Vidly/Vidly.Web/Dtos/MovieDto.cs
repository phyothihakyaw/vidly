using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? ReleasedDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        public GenreDto Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}
