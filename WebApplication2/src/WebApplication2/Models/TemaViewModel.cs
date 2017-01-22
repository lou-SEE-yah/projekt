using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZavicajnoDrustvo.Database;

namespace ZavicajnoDrustvo.Models
{
    public class TemaViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public IEnumerable<Objava> threadList { get; set; }
        public string topicName { get; set; }
        public string topicID { get; set; }
        public Tema topic { get; set; }
    }

    public class NovaTemaViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public string topicName { get; set; }
        public Kategorija InteGru { get; set; }
    }
}