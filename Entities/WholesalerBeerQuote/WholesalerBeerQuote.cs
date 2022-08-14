using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Entities
{
    [Table("WholesalerBeerQuote")]
    public class WholesalerBeerQuote
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid BeerID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid WholesalerID { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal DiscountPercentage { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MinimumNumberOfBeers { get; set; }
    }
}
