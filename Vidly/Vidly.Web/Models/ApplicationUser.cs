using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public override string UserName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "DrivingLicense")]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
