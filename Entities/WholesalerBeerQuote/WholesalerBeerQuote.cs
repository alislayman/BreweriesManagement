using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WholesalerBeerQuote : BaseEntity<int>
    {
        public Guid WholesalerID { get; set; }
        public Guid BeerID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int MinimumNumberOfBeers { get; set; }
    }
}
