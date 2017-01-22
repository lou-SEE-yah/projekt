using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZavicajnoDrustvo.Database;
using ZavicajnoDrustvo.Models;

namespace ZavicajnoDrustvo.Controllers
{
    public class ObjavaController : Controller
    {
        private readonly ZavDruDBContext ctx;
        public ObjavaController()
        {
            this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }

        // GET: Objava
        public ActionResult Index(string id,string bp)
        {
            var model = new ObjavaViewModel();
            var model2 = new KomentarViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.bp = bp;
            model.thread = ctx.Objava.ToList().Where(o => o.objavaID.ToString() == id).Single();
            model2.thread = model.thread;
            ///model.commentList=;
            return View(model);
        }

        public ActionResult Comment(string id)
        {
            var model = new KomentarViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.thread = ctx.Objava.ToList().Where(o => o.objavaID.ToString() == id).Single();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Comment(KomentarViewModel model, string id)
        {
            model.groupList = ctx.Kategorija.ToList();
            //Session["UserName"] = "Guest";
            if (ModelState.IsValid)
            {
                try
                {
                    if (Session["UserName"] == null || Session["UserName"].ToString() == "")
                    {
                        Session["UserName"] = "Guest";
                    }
                    var kom = new Komentar
                    {
                        korisničkoIme = Session["UserName"].ToString(),
                        sadržaj = model.comment,
                        komentarID = ctx.Komentar.Count() + 1,
                        popularnost = 0,
                        objavaID = Convert.ToInt32(id)
                    };
                    ctx.Komentar.Add(kom);
                    ctx.SaveChanges();
                    ModelState.AddModelError("", "????");
                    return RedirectToAction("Index", "Objava", new { id = id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Greška pri dodavanju.");
                }
            }
            return View(model);
        }

        public ActionResult NewPost(string id)
        {
            var model = new NovaObjavaViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.topic = ctx.Tema.ToList().Where(o => o.temaID.ToString() == id).Single();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NewPost(NovaObjavaViewModel model, string id)
        {
            model.groupList = ctx.Kategorija.ToList();
            //Session["UserName"] = "Guest";
            if (ModelState.IsValid)
            {
                try
                {
                    var objava = new Objava
                    {
                        autor = Session["UserName"].ToString(),
                        naslov = model.naslov,
                        sadrzaj = model.sadrzaj,
                        temaID = Convert.ToInt32(id),
                        objavaID = ctx.Objava.Count() + 1,
                        datumObjave = DateTime.UtcNow,
                        jeJavna = model.javna,
                        jeOdobren = false
                    };
                    Tema tema = ctx.Tema.Where(t => t.temaID == objava.temaID).First();
                    Kategorija kategorija = ctx.Kategorija.Where(k => k.kategorijaID == tema.kategorijaID).First();
                    var voditeljID = kategorija.voditeljID;
                    var admin = ctx.Korisnik.Where(kor => kor.statusID == 1).First();
                    if (objava.autor == voditeljID || objava.autor == admin.korisnikID)
                    {
                        objava.jeOdobren = true;
                    }
                    ctx.Objava.Add(objava);
                    ctx.SaveChanges();
                    ModelState.AddModelError("", "????");
                    return RedirectToAction("Index", "Objava", new { id = objava.objavaID.ToString() ,bp=tema.temaID.ToString()});
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