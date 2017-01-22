using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZavicajnoDrustvo.Models;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Controllers
{
    public class CheckerController : Controller
    {
        private readonly ZavDruDBContext ctx;

        public CheckerController()
        {
            this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }
        // GET: Checker
        public ActionResult Index()
        {
            var model = new CheckerViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.users = ctx.Korisnik.ToList();
            model.objave = ctx.Objava.ToList();
            model.topics = ctx.Tema.ToList();
            return View(model);
        }
    }
}