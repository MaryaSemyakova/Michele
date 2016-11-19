using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Michèle.Filters;
using Michèle.DAL;
using PagedList;

namespace Michèle.Controllers
{
    public class AdminController : DefaultController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin
        [OnlyAuthorized]
        public ActionResult Index()
        {
            return View();
        }

        [OnlyAuthorized]
        public ActionResult PortfolioIndex(int? page)
        {
            var works = from s in db.Works
                           select s;
            
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(works.ToPagedList(pageNumber, pageSize));
        }
    }
}