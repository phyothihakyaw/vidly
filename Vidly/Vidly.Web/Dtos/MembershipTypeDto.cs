using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
