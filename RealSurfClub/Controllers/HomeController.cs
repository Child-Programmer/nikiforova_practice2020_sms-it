using RealSurfClub.DLL;
using RealSurfClub.Helpers;
using RealSurfClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace RealSurfClub.Controllers
{
    public class HomeController : Controller
    {
        SurbDBContext dbContext = new SurbDBContext(); 
        public ActionResult Index()
        {
            if(TempData["errorMessage"]!=null)
            {
                ViewBag.Message = TempData["errorMessage"].ToString();
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) //если заполнен и логин и пароль, то атворизация
            {
                var userInDb = dbContext.Users.FirstOrDefault(
                    c=>c.NickName == model.Nickname &&
                    c.Password == model.Password
                    );
                if(userInDb!=null)
                {
                    //храним пользователя в сессии
                    FormsAuthentication.SetAuthCookie(userInDb.NickName, model.RememberMe); // задаем куки авторизации
                    Session["UserId"] = userInDb.Id.ToString();
                    Session["Nickname"] = userInDb.NickName;
                    Session["Photo"] = ImageUrlHelper.GetUrl(userInDb.Photo);

                    return RedirectToAction("Index", "Feed"); // переход на ленту
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль");
                }
            }
            return View("Index", model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();  //завершаем сессию
            Request.Cookies.Clear();    //стираем куки
            return RedirectToAction("Index"); //переход на авторизацию
        }

    }
}