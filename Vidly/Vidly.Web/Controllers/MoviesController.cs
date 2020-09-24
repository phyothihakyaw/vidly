using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Web.Data;
using Vidly.Web.Models;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET : Movies
        public IActionResult Index()
        {

            return View();
        }

        // GET : Movies/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies.Include(m => m.Genre).SingleAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        // GET : Movies/New
        public async Task<IActionResult> New()
        {
            var genres = await _context.Genres.ToListAsync();
            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),
                Genres = Genre.ConverToSelectListItem(genres)
            };
            ViewData["Title"] = "Add new movie";

            return View("MovieForm", viewModel);
        }

        // POST : Movies/Add
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id,Name,GenreId,ReleasedDate,NumberInStock")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),
                Genres = Genre.ConverToSelectListItem(await _context.Genres.ToListAsync())
            };
            ViewData["Title"] = "Add new movie";

            return View("MovieForm", viewModel);
        }

        // GET : Movies/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies.SingleAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            var viewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = Genre.ConverToSelectListItem(await _context.Genres.ToListAsync())
            };
            ViewData["Title"] = "Edit Movie";

            return View("MovieForm", viewModel);
        }

        // POST : Movies/Save
        [HttpPost]
        public async Task<IActionResult> Save(int id, [Bind("Id,Name,GenreId,ReleasedDate,NumberInStock")] Movie movie)
        {
            if (id != movie.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                    // Using _context.Update() will bind more fields from viewmodel
                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.ReleasedDate = movie.ReleasedDate;
                    movieInDb.NumberInStock = movie.NumberInStock;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = Genre.ConverToSelectListItem(await _context.Genres.ToListAsync())
            };
            ViewData["Title"] = "Edit Movie";

            return View("CustomerForm", viewModel);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }
    }
}
