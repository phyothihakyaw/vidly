using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
