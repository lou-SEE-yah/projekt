namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OIB { get; set; }

        [Required]
        [StringLength(50)]
        public string korisnikID { get; set; }

        [Column(TypeName = "text")]
        public string avatar { get; set; }

        public int statusID { get; set; }

        [Required]
        [StringLength(50)]
        public string lozinka { get; set; }

        [Required]
        [StringLength(50)]
        public string ime { get; set; }

        [Required]
        [StringLength(50)]
        public string prezime { get; set; }

        [Required]
        [StringLength(10)]
        public string spol { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumRođenja { get; set; }

        [Required]
        public string email { get; set; }

        [StringLength(50)]
        public string brojTelefona { get; set; }

        public int poštanskiBroj { get; set; }

        [Required]
        public string adresa { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumUčlanjenja { get; set; }

        public virtual Status Status { get; set; }

        public virtual Mjesto Mjesto { get; set; }
    }
}
