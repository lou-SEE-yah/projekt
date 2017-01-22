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
            Status stat = new Status
            {
               nazivStatus = "ja",
                statusID = 20
            };
            ctx.Status.Add(stat);
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
