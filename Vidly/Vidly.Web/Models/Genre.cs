using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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

        internal static List<SelectListItem> ConverToSelectListItem(List<Genre> genres)
        {
            return genres.ConvertAll(g =>
            {
                return new SelectListItem
                {
                    Text = g.Name,
                    Value = g.Id.ToString()
                };
            });
        }
    }
}
