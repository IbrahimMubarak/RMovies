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
    
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext ctx;
        public NewRentalsController()
        {
            ctx = new ApplicationDbContext();
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
            {
            var customer = ctx.Customers.Single(c => c.id == newRental.CustomerId);
            var movies = ctx.Movies.Where(m => newRental.MoviesIds.Contains(m.id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.numberAvilable == 0)
                    return BadRequest("Movie is not avilable");
                movie.numberAvilable--;
                var rental = new Rental()
                {
                    Customer=customer,
                    Movie=movie,
                    DateRented=DateTime.Now
                };
                ctx.Rentals.Add(rental);
            }
            ctx.SaveChanges();
            return Ok();
        }
    }
}
