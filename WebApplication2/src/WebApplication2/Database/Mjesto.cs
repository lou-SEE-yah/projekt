namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Mjesto")]
    public partial class Mjesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mjesto()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int poštanskiBroj { get; set; }

        [Required]
        [StringLength(50)]
        public string imeMjesta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
