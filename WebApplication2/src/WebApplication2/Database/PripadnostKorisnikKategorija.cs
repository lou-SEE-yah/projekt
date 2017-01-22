namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("PripadnostKorisnikKategorija")]
    public partial class PripadnostKorisnikKategorija
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kategorijaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string korisnikID { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumUlazak { get; set; }

        public bool? jeOdobren { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        //public virtual Korisnik Korisnik { get; set; }
    }
}
