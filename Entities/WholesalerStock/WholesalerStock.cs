using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Entities
{
    [Table("WholesalerStock")]
    public class WholesalerStock
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid BeerID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid WholesalerID { get; set; }

        [Column(Order = 3)]
        public int NumberOfBeers { get; set; }
    }
}
