using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZavicajnoDrustvo.Database;

public class EditModel
{
    public IEnumerable<Kategorija> groupList { get; set; }
    public Korisnik user;
    [Required]
    [Display(Name = "OIB")]
    [StringLength(13, ErrorMessage = "OIB ima 13 znamenki.", MinimumLength = 13)]
    public string OIB { get; set; }

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

    [Display(Name = "Tel. broj")]
    public string brojTelefona { get; set; }

    [Required]
    [Display(Name = "Adresa")]
    //todo provjera adrese
    public string adresa { get; set; }

    [Required]
    //[EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    public string bpic { get; set; }

}
