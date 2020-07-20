using Microsoft.Ajax.Utilities;
using RealSurfClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace RealSurfClub.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {

            var my = new MyModel { Name = "Стефания", Age = 17 };
            ViewBag.My = my;
            return View();
        }

        public ActionResult AboutMe()
        {
            var my = new MyModel { Name = "Агафья", Age = 27 };

            ViewBag.Price = new int[] { 100, 120, 140, 99 };

            return View(my);
        }
    }
}