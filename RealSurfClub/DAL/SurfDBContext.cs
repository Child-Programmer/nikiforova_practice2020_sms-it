using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RealSurfClub.Controllers;
using RealSurfClub.Models.DBModels;

namespace RealSurfClub.DLL
{
    public class SurbDBContext : DbContext
    {
        
        static SurbDBContext()
        {
            //БД будет инициализироваться при обращении контексту
            Database.SetInitializer(new SurfDBInitializer());
        }

        //вызываем бызовый конструктор, в который передаем имя БД
        public SurbDBContext() : base("RealSurfDatabase") {

        }

        //указываем, что будут создаваться таблицы типа 
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    } }