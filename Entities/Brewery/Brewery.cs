using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Brewery")]
    public class Brewery
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
