using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZavicajnoDrustvo.Database;

namespace WebApplication2.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public IEnumerable<Kategorija> groupList { get; set; }

        [Required]
        [Display(Name = "OIB")]
        [StringLength(13, ErrorMessage = "OIB ima 13 znamenki.", MinimumLength = 13)]
        public string OIB { get; set; }

        [Required]
        [Display(Name = "Kor. ime")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string ime { get; set; }

        [Required]
        [Display(Name = "Prezime")]
        public string prezime { get; set; }

        [Required]
        [Display(Name = "Spol")]
        public string spol { get; set; }

        [Display(Name = "Datum rođenja")]
        public DateTime datumRođenja { get; set; }

        [Display(Name = "Tel. br.")]
        public string brojTelefona { get; set; }

        [Display(Name = "Pošt. broj")]
        public int poštanskiBroj { get; set; }

        [Required]
        [Display(Name = "Adresa")]
        public string adresa { get; set; }

        [Required]
        [EmailAddress]
        //[EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
