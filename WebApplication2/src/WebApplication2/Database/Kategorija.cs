namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Kategorija")]
    public partial class Kategorija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategorija()
        {
            PripadnostKorisnikKategorija = new HashSet<PripadnostKorisnikKategorija>();
            Tema = new HashSet<Tema>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kategorijaID { get; set; }

        [Required]
        [StringLength(50)]
        public string nazivKategorija { get; set; }

        [Required]
        [StringLength(50)]
        public string voditeljID { get; set; }

        public bool? jeOdobren { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PripadnostKorisnikKategorija> PripadnostKorisnikKategorija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tema> Tema { get; set; }
    }
}
