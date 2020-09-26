using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Dtos;
using Vidly.Web.Models;

namespace Vidly.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST : Rentals/Create
        [HttpPost]
        public ActionResult<NewRentalDto> CreateNewRentals([FromForm] NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
