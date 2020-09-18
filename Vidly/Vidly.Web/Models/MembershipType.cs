using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        [Range(1, 12)]
        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}
