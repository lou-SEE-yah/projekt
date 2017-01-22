using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZavicajnoDrustvo.Database;

namespace WebApplication2.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
