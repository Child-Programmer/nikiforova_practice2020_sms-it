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

            if(!ModelState.IsValid)
            {
                var postsdb = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = postsdb;
                return View("Index", model);
            }
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
                if (!ImageFormatHelper.IsJpg(imageData))
                {
                    ModelState.AddModelError(string.Empty, "Загруженное изображение не картинка формата JPG");
                    var postsdb = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
                    ViewBag.Posts = postsdb;
                    return View("Index", model);
                }

                model.Photo = ImageSaveHelper.SaveImage(imageData);
            }
            
            var userId = Convert.ToInt32(Session["UserId"]); //берем идентификатор авторизованного пользователя
            var userInDb = dBContext.Users.FirstOrDefault(c => c.Id == userId);

            if (userInDb == null)
            {
                //пользователь не авторизован
                TempData["errorMessage"] = "Время сессии истекло. Авторизуйтесь повторно";
                return RedirectToAction("Index", "Home");
            }
            model.Author = userInDb;

            dBContext.Posts.Add(model);

            dBContext.SaveChanges();

            var posts = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;

            ModelState.Clear();//для очищения модели (для очищения текстового поля)

            return View("Index");
        }
    }
}