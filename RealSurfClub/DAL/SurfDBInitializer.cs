using RealSurfClub.DLL;
using RealSurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealSurfClub.Controllers
{
    public class SurfDBInitializer : DropCreateDatabaseIfModelChanges<SurbDBContext>
    //DropCreateDatabaseAlways<SurbDBContext> 
    {
        protected override void Seed(SurbDBContext context)
        {
            var user = new User
            {
                NickName = "vsel",
                Password = "12345678", 
                LastName = "Стародубов",
                Name = "Всеволод",
                Email = "vsel@star.ru",
                About = "я такой хороший!"
            };

            var post1 = new Post
            {
                Text = "Первый текстовый пост",
                PublishDate = DateTime.Now,
                Author = user
            };

            var post2 = new Post
            {
                Text = "Второй текстовый пост",
                PublishDate = DateTime.Now,
                Author = user
            };

            context.Users.Add(user);
            context.Posts.Add(post1);
            context.Posts.Add(post2);
            context.SaveChanges();
        }
    }
}