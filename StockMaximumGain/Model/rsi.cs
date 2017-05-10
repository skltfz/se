namespace StockMaximumGain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rsi")]
    public partial class rsi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stockno { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [Column("rsi")]
        public double? rsi1 { get; set; }

        public DateTime? date { get; set; }

        public bool? ignore { get; set; }

        public double? volume { get; set; }

        [StringLength(50)]
        public string PE { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [StringLength(50)]
        public string ii { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rid { get; set; }

        public double? infl { get; set; }

        public int? sph { get; set; }
    }
}
