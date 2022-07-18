using RMovies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMovies.Controllers
{
    [AllowAnonymous]
    public class MoviesController : Controller
    {
        // GET: Movies
        ApplicationDbContext ctx;
        
        public MoviesController()
        {
            ctx = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.IsInRole("canManage"))
            {
                List<Movie> m = ctx.Movies.ToList();
                return View("Index",m);
            }
            else
            {
                List<Movie> m = ctx.Movies.ToList();
                return View("ReadOnlyIndex", m);
            }
        }

        [Authorize(Roles ="canManage")]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "canManage")]
        public ActionResult Create(Movie c)
        {
            if (ModelState.IsValid)
            {
                ctx.Movies.Add(c);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }

        [Authorize(Roles = "canManage")]
        public ActionResult Edit(int id)
        {
            
            Movie c = ctx.Movies.Where(cs => cs.id == id).FirstOrDefault();
            return View(c);
        }
        

        
        [HttpPost]

        [Authorize(Roles = "canManage")]
        public ActionResult Edit(Movie c)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(c).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }

        [Authorize(Roles = "canManage")]
        public ActionResult Delete(int id)
        {
            Movie cs = ctx.Movies.Where(c => c.id == id).FirstOrDefault();
            ctx.Movies.Remove(cs);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "canManage")]
        public ActionResult Details(int id)
        {
            Movie m = ctx.Movies.Where(c => c.id == id).FirstOrDefault();
            return View(m);
        }
    }
}