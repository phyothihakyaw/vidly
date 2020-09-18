using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Vidly.Web.Models;

namespace Vidly.Web.ViewModels
{
    public class CustomerViewModel
    {
        public List<SelectListItem> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
