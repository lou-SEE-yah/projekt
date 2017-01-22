using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavicajnoDrustvo.Database;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ZavicajnoDrustvo.Models
{
    public class ObjavaViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public IEnumerable<Komentar> commentList { get; set; }
        public Objava thread { get; set; }
        public string bp { get; set; }
        
    }

    public class NovaObjavaViewModel
    {
        [Required]
        public string naslov { get; set; }
        public IEnumerable<Kategorija> groupList { get; set; }
        [AllowHtml]
        [Required]
        public string sadrzaj { get; set; }
        public bool javna { get; set; }
        public Tema topic { get; set; }
    }

    public class KomentarViewModel {

        [AllowHtml]
        [Required]
        public string comment { get; set; }
        public IEnumerable<Kategorija> groupList { get; set; }
        public Objava thread { get; set; }
    }
}