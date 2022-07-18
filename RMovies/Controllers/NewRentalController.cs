using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMovies.Controllers
{
    [Authorize(Roles = "canManage")]
    public class NewRentalController : Controller
    {
     
        public ActionResult CreateNewRental()
        {
            return View();
        }
    }
}