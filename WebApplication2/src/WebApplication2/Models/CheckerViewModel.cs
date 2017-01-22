using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Models
{

    public class CheckerViewModel
    {
        public IEnumerable<Objava> objave { get; set; }
        public IEnumerable<Kategorija> groupList { get; set; }
        public IEnumerable<Tema> topics { get; set; }
        public IEnumerable<Korisnik> users { get; set; }
    }
}