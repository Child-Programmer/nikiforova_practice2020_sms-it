using RealSurfClub.DLL;
using RealSurfClub.Helpers;
using RealSurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealSurfClub.Controllers
{
    public class FeedController : Controller
    {
        private SurbDBContext dBContext = new SurbDBContext();

        // GET: Feed
        public ActionResult Index()
        {
            var posts = dBContext.Posts.OrderByDescending(c=>c.Id).ToList();
            ViewBag.Posts = posts;
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData){

            if(imageData == null && model.Text == null)
            {
                ModelState.AddModelError(string.Empty, "Не загружено изображение или отсутствует текст");

                var postsdb = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = postsdb;

                return View("Index", model);
            }

            model.PublishDate = DateTime.Now;

            if(imageData!= null)
            {
                model.Photo = ImageSaveHelper.SaveImage(imageData);
            }
            
            var userId = Convert.ToInt32(Session["UserId"]); //берем идентификатор авторизованного пользователя
            var userInDb = dBContext.Users.FirstOrDefault(c => c.Id == userId);

            model.Author = userInDb;

            dBContext.Posts.Add(model);

            dBContext.SaveChanges();

            var posts = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;
            return View("Index");
        }
    }
}