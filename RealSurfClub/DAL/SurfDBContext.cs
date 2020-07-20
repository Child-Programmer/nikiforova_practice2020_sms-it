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
            Database.SetInitializer(new SurfDBInitializer());
        }
        public SurbDBContext() : base("RealSurfDatabase") {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    } }