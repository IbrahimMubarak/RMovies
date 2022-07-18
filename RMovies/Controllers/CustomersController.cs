using RMovies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMovies.Controllers
{
    [Authorize(Roles ="canManage")]
    public class CustomersController : Controller
    {
        ApplicationDbContext ctx;
        public CustomersController()
        {
            ctx = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> st = ctx.Customers.Include(c=>c.MembershipType).ToList();
            
            return View(st);
        }
        
        public ActionResult Create()
        {
            List<MembershipType> M = ctx.MembershipTypes.ToList();
            SelectList ls = new SelectList(M, "Id", "name");
            ViewBag.m = ls;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                ctx.Customers.Add(c);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<MembershipType> M = ctx.MembershipTypes.ToList();
                SelectList ls = new SelectList(M, "Id", "name");
                ViewBag.m = ls;
                return View();
            }
        }
        public ActionResult Edit(int id)
        {

            Customer c = ctx.Customers.Where(cs => cs.id == id).FirstOrDefault();
            List<MembershipType> M = ctx.MembershipTypes.ToList();
            SelectList ls = new SelectList(M, "Id", "name");
            ViewBag.m = ls;
            return View(c);
        }
        [HttpPost]
       
        public ActionResult Edit(Customer c)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(c).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Customer cs = ctx.Customers.Where(c => c.id == id).FirstOrDefault();
            ctx.Customers.Remove(cs);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Customer c = ctx.Customers.Where(cs => cs.id == id).Include(cs => cs.MembershipType).FirstOrDefault();
            return View(c);
        }
    }
}