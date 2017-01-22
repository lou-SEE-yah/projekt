using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;
using ZavicajnoDrustvo.Models;
using System.Web.Mvc;

namespace ZavicajnoDrustvo.Controllers
{
    public class SearchController : Controller
    {
        ZavDruDBContext ctx;
        public SearchController() {
            this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }
        // GET: Search
        public ActionResult Index(string id)
        {
            var model = new SearchViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.query = id;
            return View(model);
        }
    }
}