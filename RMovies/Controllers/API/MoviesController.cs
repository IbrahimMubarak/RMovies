using AutoMapper;
using RMovies.DTOS;
using RMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RMovies.Controllers.API
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext ctx;
        public MoviesController()
        {
            ctx = new ApplicationDbContext();
        }
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = ctx.Movies
                .Where(m => m.numberAvilable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }
      /*  public IEnumerable<MovieDto> GetAllMovies()
        {
            return ctx.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }*/
        public IHttpActionResult GetMovieById(int id)
        {
            var movie = ctx.Movies.Where(m => m.id == id).FirstOrDefault();
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Movie,MovieDto>(movie));
            }


        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            ctx.Movies.Add(movie);
            ctx.SaveChanges();
            movieDto.id = movie.id;
            return Created(new Uri(Request.RequestUri + "/" + movie.id), movieDto);
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult Update(int id,MovieDto movieDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = ctx.Movies.Where(m => m.id == id).FirstOrDefault();
            if (movie == null)
            {
                return NotFound();
            }
            Mapper.Map<MovieDto, Movie>(movieDto, movie);
            ctx.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        public void Delete(int id)
        {
            var movie = ctx.Movies.Where(m => m.id == id).FirstOrDefault();
            ctx.Movies.Remove(movie);
            ctx.SaveChanges();
        }


    }
}
