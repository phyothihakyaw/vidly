﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Dtos;
using Vidly.Web.Models;

namespace Vidly.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET : /api/movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList().Select(_mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        //DELETE : /api/movies/{id}
        [HttpDelete("{id}")]
        public ActionResult<MovieDto> DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            var movieDto = _mapper.Map<Movie, MovieDto>(movie);
            return Ok(movieDto);
        }
    }
}
