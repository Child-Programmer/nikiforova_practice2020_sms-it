using RealSurfClub.DLL;
using RealSurfClub.Helpers;
using RealSurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealSurfClub.Controllers
{
    public class RegisterController : Controller
    {
        SurbDBContext dbContext = new SurbDBContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(User model, HttpPostedFileBase imageData)//получать данные с формы и сохранять инфу в БД
        {
            if (ModelState.IsValid)
            {
                //регистрация
                if (model.Password != model.PasswordConfirm)//если пароли 
                {
                    ModelState.AddModelError(string.Empty, "Введенные пароли не совпадают!");
                    return View("Index", model);
                }
                //проверка для никнэйма
                var userInDb = dbContext.Users.FirstOrDefault(c => c.NickName == model.NickName);
                if (userInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким псевдонимом уже существует!");
                    return View("Index", model);
                }

                //проверка для почты
                var userEmailInDb = dbContext.Users.FirstOrDefault(c => c.Email == model.Email);
                if (userEmailInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с такой почтой уже существует!");
                    return View("Index", model);
                }

                if (imageData != null)
                {
                    model.Photo = ImageSaveHelper.SaveImage(imageData);
                }
                dbContext.Users.Add(model);
                dbContext.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.NickName, false); // задаем куки авторизации
                Session["UserId"] = model.Id.ToString();
                Session["Nickname"] = model.NickName;
                Session["Photo"] = ImageUrlHelper.GetUrl(model.Photo);

                return RedirectToAction("Index", "Feed"); // переход на ленту

            }
            return View("Index", model);
        }
    }
}