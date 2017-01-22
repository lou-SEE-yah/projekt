using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Models
{
    public class ApproveViewModel
    {
        public IEnumerable<Objava> objave { get; set; }
        public IEnumerable<Kategorija> groupList { get; set; }
        public List<Kategorija> groupListToApprove { get; set; }
        public IEnumerable<Tema> topics { get; set; }
        public IEnumerable<PripadnostKorisnikKategorija> usersToApprove { get; set; }
        public Korisnik user { get; set; }
        public string id { get; set; }
        public string backgroundPic { get; set; }
    }

    public class VodstvoViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public Korisnik user { get; set; }
        public Korisnik predsjednik { get; set; }
        public Korisnik zamjenik { get; set; }
        public List<Korisnik> vodstvo { get; set; }
        public string id { get; set; }
        public string backgroundPic { get; set; }
    }
}