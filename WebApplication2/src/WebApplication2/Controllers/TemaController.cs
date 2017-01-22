using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZavicajnoDrustvo.Database;
using ZavicajnoDrustvo.Models;
using System.Threading.Tasks;

namespace ZavicajnoDrustvo.Controllers
{
    public class TemaController : Controller
    {
        private readonly ZavDruDBContext ctx;

        public TemaController()
        {
            this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }

        // GET: Tema
        public ActionResult Index(string id)
        {
            var model = new TemaViewModel();
            model.topicName = id;
            model.groupList = ctx.Kategorija.ToList();
            model.threadList = ctx.Objava.Where(o => o.Tema.nazivTema.ToString() == id).ToList();
            model.topicID = ctx.Tema.Where(o => o.nazivTema == id).First().temaID.ToString();
            model.topic = ctx.Tema.Where(o => o.nazivTema == id).First();
            return View(model);
        }

        public ActionResult NewTopic(string id)
        {
            var model = new NovaTemaViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.InteGru = ctx.Kategorija.ToList().Where(o => o.kategorijaID.ToString() == id).Single();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NewTopic(NovaTemaViewModel model, string id)
        {
            model.groupList = ctx.Kategorija.ToList();
            //Session["UserName"] = "Guest";
            if (ModelState.IsValid)
            {
                try
                {
                    var tema = new Tema
                    {
                        temaID = ctx.Tema.Count() + 1,
                        kategorijaID = Convert.ToInt32(id),
                        nazivTema = model.topicName,
                        jeOdobren = false
                    };
                    Kategorija kategorija = ctx.Kategorija.Where(k => k.kategorijaID == tema.kategorijaID).First();
                    var voditeljID = kategorija.voditeljID;
                    var admin = ctx.Korisnik.Where(kor => kor.statusID == 1).First();
                    var user = Session["Username"].ToString();
                    if (user == voditeljID || user == admin.korisnikID)
                    {
                        tema.jeOdobren = true;
                    }
                    ctx.Tema.Add(tema);
                    ctx.SaveChanges();
                    ModelState.AddModelError("", "????");
                    return RedirectToAction("Index", "Home", new{id = id});
                    //return RedirectToAction("Index", "InteGru", new { id = id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Greška pri dodavanju.");
                }
            }
            return View(model);
        }
    }
}