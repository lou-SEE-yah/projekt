using System.Collections.Generic;
using ZavicajnoDrustvo.Database;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models.AccountViewModels
{
    public class AccountInfoModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        public Korisnik userInfo { get; set; }
        public Korisnik userCurrent { get; set; }
        public string userCurrentID { get; set; }
        public bool member { get; set; }
    }
}
