namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Objava")]
    public partial class Objava
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Objava()
        {
            Komentar = new HashSet<Komentar>();
            //Tema1 = new HashSet<Tema>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int objavaID { get; set; }

        [Required]
        [StringLength(50)]
        public string autor { get; set; }

        [Required]
        public string naslov { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumObjave { get; set; }

        public int temaID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string sadrzaj { get; set; }

        public bool jeJavna { get; set; }

        public bool? jeOdobren { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komentar> Komentar { get; set; }

        public virtual Tema Tema { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tema> Tema1 { get; set; }*/
    }
}
