using RealSurfClub.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealSurfClub.Controllers
{
    public class SellerController : Controller
    {
        SurbDBContext dbContext = new SurbDBContext();
        // GET: Seller
        public ActionResult Index()
        {
            var user = dbContext.Users.FirstOrDefault();
            //ViewBag.sell = user;
            return View(user);


            //return View();
        }
    }
}