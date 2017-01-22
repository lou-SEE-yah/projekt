namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Službe
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int statusID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string korisnikID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime datumPocetak { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datumKraj { get; set; }

        public virtual Status Status { get; set; }
    }
}
