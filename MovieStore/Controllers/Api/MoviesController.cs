using AutoMapper;
using MovieStore.Dto;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieStore.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Corrigir
        //Get api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return null;
        }

        //Get api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //Create
        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            //Returni Status 201 que significa created
            //Convesão de retorno de URL na WebApi
            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);

        }

        //Corrigir
        //Update
        //PUT api/movies/
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
        
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }


    }
}
