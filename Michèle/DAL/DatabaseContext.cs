using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Michèle.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Data.Entity.Infrastructure;



namespace Michèle.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }
 
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkLang> WorkLangs { get; set; }

        //public DbSet<Blog> Blogs { get; set; }
        // public DbSet<BlogLang> BlogLangs { get; set; }
         public DbSet<Photo> Photos { get; set; }
         public DbSet<Slider> Sliders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        static DatabaseContext() { Database.SetInitializer(new DatabaseInitializer()); }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!


        }
    }
}