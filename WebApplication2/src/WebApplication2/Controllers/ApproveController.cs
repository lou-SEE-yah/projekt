using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZavicajnoDrustvo.Database;
using ZavicajnoDrustvo.Models;

namespace WebApplication2.Controllers
{
    public class ApproveController : Controller
    {

        private readonly ZavDruDBContext ctx;
        public ApproveController()
        {
            this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }
        // GET: Approve
        public ActionResult Index()
        {
            var model = new ApproveViewModel();
            model.groupList = ctx.Kategorija.ToList();
            var a = Session["UserName"].ToString();
            model.user = ctx.Korisnik.Where(kor => (kor.korisnikID == a)).First();
            var koris = model.user;
            if (model.user.statusID == 1)
            {
                model.groupListToApprove = model.groupList.ToList();
            }
            else
            {
                model.groupListToApprove = ctx.Kategorija.Where(kat => kat.voditeljID == koris.korisnikID).ToList();
            }
            return View(model);
        }


        public ActionResult ApproveKategorija(string id)
        {
            var model = new ApproveViewModel();
            try
            {
                var kategorija = ctx.Kategorija.Where(k => k.kategorijaID.ToString() == id).First();
                if (kategorija.jeOdobren == null || kategorija.jeOdobren == false)
                {
                    kategorija.jeOdobren = true;
                }
                else
                {
                    kategorija.jeOdobren = false;
                }
                var member = new PripadnostKorisnikKategorija();
                member.korisnikID = kategorija.voditeljID;
                member.kategorijaID = kategorija.kategorijaID;
                member.datumUlazak = DateTime.Today;
                ctx.Kategorija.AddOrUpdate(kategorija);
                ctx.PripadnostKorisnikKategorija.Add(member);
                ctx.SaveChanges();
                //return View(model);
            }
            catch { }
            return RedirectToAction("Index", "Approve");
        }

        public ActionResult EditKategorija(string id)
        {
            var model = new ApproveViewModel();
            model.id = id;
            model.groupList = ctx.Kategorija.ToList();
            model.topics = ctx.Tema.Where(t => t.kategorijaID.ToString() == id).ToList();
            model.usersToApprove = ctx.PripadnostKorisnikKategorija.Where(pkk => pkk.kategorijaID.ToString() == id).ToList();
            return View(model);
        }

        public ActionResult ApproveTema(string id1, string id2)
        {
            var model = new ApproveViewModel();
            var tema = new Tema();
            try
            {
                tema = ctx.Tema.Where(t => t.temaID.ToString() == id1).First();
                if (tema.jeOdobren == null || tema.jeOdobren == false)
                {
                    tema.jeOdobren = true;
                }
                else
                {
                    tema.jeOdobren = false;
                }
                ctx.Tema.AddOrUpdate(tema);
                ctx.SaveChanges();
            }
            catch { }
            return RedirectToAction("EditKategorija", "Approve", new { id = id2 });
        }

        public ActionResult ApproveKorisnik(string id, string korid )
        {
            var model = new ApproveViewModel();
            var pkk= new PripadnostKorisnikKategorija();
            var kor = new Korisnik();
            try
            {
                pkk = ctx.PripadnostKorisnikKategorija.Where(t => t.kategorijaID.ToString() == id&&t.korisnikID==korid).First();
                if (pkk.jeOdobren == null || pkk.jeOdobren == false)
                {
                    pkk.jeOdobren = true;
                }
                else
                {
                    pkk.jeOdobren = false;
                }
                ctx.PripadnostKorisnikKategorija.AddOrUpdate(pkk);
                ctx.SaveChanges();
            }
            catch { }
            return RedirectToAction("EditKategorija", "Approve", new { id = id });
        }

        public ActionResult EditTema(string id)
        {
            var model = new ApproveViewModel();
            model.id = id;
            model.groupList = ctx.Kategorija.ToList();
            model.objave = ctx.Objava.Where(o => o.temaID.ToString() == id).ToList();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> EditTema(string id, ApproveViewModel model)
        {
            var tema = ctx.Tema.Where(t => t.temaID.ToString() == id).First();
            model.id = id;
            model.groupList = ctx.Kategorija.ToList();
            model.objave = ctx.Objava.Where(o => o.temaID.ToString() == id).ToList();
            tema.backgroundPicture = model.backgroundPic;
            ctx.Tema.AddOrUpdate(tema);
            ctx.SaveChanges();
            return View(model);
        }

        public ActionResult ApproveObjava(string id)
        {
            var objava = new Objava();
            try
            {
                objava = ctx.Objava.Where(o => o.objavaID.ToString() == id).First();
                if (objava.jeOdobren == null || objava.jeOdobren == false)
                {
                    objava.jeOdobren = true;
                }
                else
                {
                    objava.jeOdobren = false;
                }
                ctx.Objava.AddOrUpdate(objava);
                ctx.SaveChanges();
            }
            catch { }
            return RedirectToAction("EditTema", "Approve", new { id = objava.temaID.ToString() });
        }

        public ActionResult MakeObjavaPublic(string id)
        {
            var objava = new Objava();
            try
            {
                objava = ctx.Objava.Where(o => o.objavaID.ToString() == id).First();
                if (objava.jeJavna == false)
                {
                    objava.jeJavna = true;
                }
                else
                {
                    objava.jeJavna = false;
                }
                ctx.Objava.AddOrUpdate(objava);
                ctx.SaveChanges();
            }
            catch { }
            return RedirectToAction("EditTema", "Approve", new { id = objava.temaID.ToString() });
        }

        public ActionResult ViewObjava(string id)
        {
            var model = new ApproveViewModel();
            model.groupList = ctx.Kategorija.ToList();
            model.objave = ctx.Objava.Where(o => o.objavaID.ToString() == id).ToList();
            return View(model);
        }

        public ActionResult Vodstvo()
        {
            var model = new VodstvoViewModel();
            model.groupList = ctx.Kategorija.ToList();
            var a = Session["UserName"].ToString();
            model.user = ctx.Korisnik.Where(kor => (kor.korisnikID == a)).First();
            var koris = model.user;
            if (model.user.statusID == 1)
            {
                try
                {
                    Random rand = new Random();
                    List<Korisnik> izbor =
                        ctx.Korisnik.Where(s => s.statusID != 1).OrderBy(r => Guid.NewGuid()).Take(7).ToList();
                    var predsjednik = new Službe();
                    predsjednik.korisnikID = izbor.ElementAt(0).korisnikID;
                    predsjednik.statusID = 2;
                    predsjednik.datumPocetak = DateTime.Today;
                    
                    model.predsjednik = izbor.Where(k => k.korisnikID == predsjednik.korisnikID).First();
                    var zamjenik = new Službe();
                    zamjenik.korisnikID = izbor.ElementAt(1).korisnikID;
                    zamjenik.statusID = 3;
                    zamjenik.datumPocetak = DateTime.Today;
                    model.zamjenik = izbor.Where(k => k.korisnikID == zamjenik.korisnikID).First();
                    
                    var vodstvo = new List<Korisnik>();
                    vodstvo = izbor.Skip(Math.Max(0, izbor.Count() - 5)).ToList();
                    model.vodstvo = vodstvo;
                    foreach (var clan in vodstvo)
                    {
                        var vijece = new Službe();
                        vijece.korisnikID = clan.korisnikID;
                        vijece.statusID = 4;
                        vijece.datumPocetak = DateTime.Today;
                        ctx.Službe.Add(vijece);
                    }
                    ctx.Službe.Add(zamjenik);
                    ctx.Službe.Add(predsjednik);
                    ctx.SaveChanges();
                    return View(model);
                }
                catch (Exception ex)
                {
                    
                }

            }

            return View(model);
        }
    }
}
