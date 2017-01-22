using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public string query { get; set; }
    }
}