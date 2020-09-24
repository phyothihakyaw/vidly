using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
