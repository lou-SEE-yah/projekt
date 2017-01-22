using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZavicajnoDrustvo.Database;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ZavDruDBContext ctx;
        public HomeController(ZavDruDBContext context)
        {
            ctx = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            Korisnik user = new Korisnik
            {
                korisnikID = "la",
                email = "mail@fer.hr",
                OIB = 0123445566712,
                lozinka = "lozinka",
                adresa = "lilca",
                
                datumUčlanjenja = DateTime.Today,
                ime = "ja",
                prezime ="ja",
                poštanskiBroj = 10000,
                spol = "M",
                statusID = 6
            };
            ctx.Korisnik.Add(user);
            ctx.SaveChanges();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
