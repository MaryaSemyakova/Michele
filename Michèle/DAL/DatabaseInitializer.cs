using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Michèle.Models;

namespace Michèle.DAL
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Security.CreateRole("mmgod");
            Security.CreateRole("user");
            Security.CreateUser("mashenka5252", "K.ljdbr-14", "mmgod");
            var languages = new List<Language>
            {
            new Language { name = "ru",},
            new Language { name = "en",},
            };
            languages.ForEach(s => context.Languages.Add(s));
            

            var categoryes = new List<Category>
            {
            new Category { CategoryID = 1, Name = "Illustration"},
            new Category { CategoryID = 2, Name = "Web"},
            };
            categoryes.ForEach(s => context.Categories.Add(s));
            

            var works = new List<Work>
            {
            new Work{ CategoryID = new int []{ 2 }, WorkID=1, MainPhoto="img/композиция_01.tif"},
            new Work{ CategoryID = new int []{ 2 }, WorkID=2, MainPhoto="img/фешн_скетч_без_фона_01.png"},

            };
            works.ForEach(s => context.Works.Add(s));


            context.SaveChanges();
            base.Seed(context);
        }
    }
}