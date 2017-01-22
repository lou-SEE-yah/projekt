namespace ZavicajnoDrustvo.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Komentar")]
    public partial class Komentar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int komentarID { get; set; }

        [Required]
        [StringLength(50)]
        public string korisničkoIme { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string sadržaj { get; set; }

        public short popularnost { get; set; }

        public int objavaID { get; set; }

        public virtual Objava Objava { get; set; }
    }
}
