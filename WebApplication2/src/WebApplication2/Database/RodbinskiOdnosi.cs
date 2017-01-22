namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("RodbinskiOdnosi")]
    public partial class RodbinskiOdnosi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string korisnik1ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string korisnik2ID { get; set; }

        [Required]
        [StringLength(50)]
        public string odnos { get; set; }
    }
}
