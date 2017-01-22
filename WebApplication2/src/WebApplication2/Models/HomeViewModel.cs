using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public string query { get; set; }
        public IEnumerable<Objava> objave { get; set; }
        public string name { get; set; }
        //public string subpage { get; set; }
    }
}