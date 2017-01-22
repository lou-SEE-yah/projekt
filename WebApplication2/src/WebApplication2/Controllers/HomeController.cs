using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.AccountViewModels;
using ZavicajnoDrustvo.Database;
using ZavicajnoDrustvo.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

using System.Web;
//using System.Web.Mvc;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ZavDruDBContext ctx;
        public HomeController()
        {
            //this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel();
            model.objave = ctx.Objava.Where(o => o.jeOdobren == true).OrderByDescending(o => o.datumObjave).ToList();
            //Session["UserName"] = "Guest";
            model.groupList = ctx.Kategorija.ToList();
            //model.subpage = id;
            //ViewBag.HiddenFieldValue = id;
            return View(model);
        }

        /*public ActionResult Index2()
        {
            var model = new HomeViewModel();
            HttpContext.Session.SetString("Username", "Guest"); // store byte array
            model.groupList = ctx.Kategorija.ToList();
            //model.subpage = id;
            //ViewBag.HiddenFieldValue = id;
            return View(model);
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var model = new HomeViewModel();
            model.groupList = ctx.Kategorija.ToList();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var model = new HomeViewModel();
            model.groupList = ctx.Kategorija.ToList();
            return View(model);
        }

        /*public ActionResult Search(string query)
        {
            if (query != "")
            {
                var model = new HomeViewModel();
                model.groupList = ctx.Kategorija.ToList();
                model.query = query;
                model.objave = ctx.Objava.ToList().Where(o => o.jeOdobren == true);
                return View(model);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }*/

        /*public ActionResult Welcome(LoginViewModel model)
        {
            model.groupList = ctx.Kategorija.ToList();
            return View(model);
        }*/

        public IActionResult Error()
        {
            return View();
        }

        /*public ActionResult NewGroup()
        {
            var model = new HomeViewModel();
            model.groupList = ctx.Kategorija.ToList();
            return View(model);
        }*/

        /*[HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NewGroup(HomeViewModel model)
        {
            var a = Session["UserName"].ToString();
            var user = ctx.Korisnik.Where(k => k.korisnikID == a).First();
            if (ModelState.IsValid)
            {
                try
                {
                    var kategorija = new Kategorija
                    {
                        kategorijaID = ctx.Kategorija.Count() + 1,
                        nazivKategorija = model.name,
                        voditeljID = user.korisnikID,
                        jeOdobren = false
                    };
                    ctx.Kategorija.Add(kategorija);
                    ctx.SaveChanges();
                    ModelState.AddModelError("", "????");
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Greška pri dodavanju.");
                }
            }
            return RedirectToAction("Index", "Home");
        }*/
    }
}