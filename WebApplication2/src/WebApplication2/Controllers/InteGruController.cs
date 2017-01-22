using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZavicajnoDrustvo.Database;
using ZavicajnoDrustvo.Models;

namespace ZavicajnoDrustvo.Controllers
{
    public class InteGruController : Controller
    {
        private readonly ZavDruDBContext ctx;
        public InteGruController()
        {
            this.ctx = DependencyResolver.Current.GetService<ZavDruDBContext>();
        }


        public ActionResult Index(string id)
        {
            var model = new InteGruViewModel();
            model.name = id;
            var tempList = new List<Kategorija>();

            model.groupList = ctx.Kategorija.ToList();
            tempList = model.groupList.ToList();
            foreach (var group in tempList)
            {
                if (group.nazivKategorija == model.name)
                {
                    model.groupID = ctx.Kategorija.Where(k => k.kategorijaID == group.kategorijaID).First().kategorijaID;
                    model.leader = ctx.Korisnik.Where(k => k.korisnikID == group.voditeljID).First();
                    model.members = ctx.PripadnostKorisnikKategorija.Where(k => k.kategorijaID == group.kategorijaID);
                }
            }
            model.topicList = ctx.Tema.ToList();
            return View(model);
        }

        public ActionResult Member(string id)
        {
            var model = new InteGruViewModel();
            model.groupList = ctx.Kategorija.ToList();

            try
            {
                var member = new PripadnostKorisnikKategorija();

                member.korisnikID = Session["Username"].ToString();
                member.kategorijaID = Convert.ToInt32(id);
                member.datumUlazak = DateTime.Today;

                ctx.PripadnostKorisnikKategorija.Add(member);
                ctx.SaveChanges();
                model.name = model.groupList.Where(k => k.kategorijaID == member.kategorijaID).First().nazivKategorija;
                return View(model);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult ViewMembers(string id)
        {
            var model = new InteGruViewModel();
            model.groupID = Convert.ToInt32(id);
            Kategorija grupa = ctx.Kategorija.Where(k => k.kategorijaID == model.groupID).First();
            model.groupList = ctx.Kategorija.ToList();

            model.leader = ctx.Korisnik.Where(k => k.korisnikID == grupa.voditeljID).First();
            model.members = ctx.PripadnostKorisnikKategorija.Where(k => k.kategorijaID == grupa.kategorijaID);



            return View(model);
        }
    }
}
