using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Models
{
    public class InteGruViewModel
    {
        public string name { get; set; }
        public Korisnik leader { get; set; }
        public int groupID { get; set; }
        public IEnumerable<Kategorija> groupList { get; set; }
        public IEnumerable<Tema> topicList { get; set; }
        public IEnumerable<PripadnostKorisnikKategorija> members { get; set; }
    }
}