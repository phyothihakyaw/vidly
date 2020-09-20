using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Vidly.Web.Models;

namespace Vidly.Web.ViewModels
{
    public class MovieViewModel
    {
        public List<SelectListItem> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}
