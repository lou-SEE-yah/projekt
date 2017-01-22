namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Tema")]
    public partial class Tema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tema()
        {
            Objava = new HashSet<Objava>();
            Objava1 = new HashSet<Objava>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int temaID { get; set; }

        [Required]
        [StringLength(50)]
        public string nazivTema { get; set; }

        public int kategorijaID { get; set; }

        [Column(TypeName = "text")]
        public string backgroundPicture { get; set; }

        public bool? jeOdobren { get; set; }

        public virtual Kategorija Kategorija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objava> Objava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objava> Objava1 { get; set; }
    }
}
