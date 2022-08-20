using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Beer")]
    public class Beer
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid BreweryID { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal AlcoholContent { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal RetailPrice { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal WholesalePrice { get; set; }

        [Column(Order = 6)]
        public bool IsDeleted { get; set; }
    }
}
