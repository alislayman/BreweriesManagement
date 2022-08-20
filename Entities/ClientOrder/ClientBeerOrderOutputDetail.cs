using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClientBeerOrderOutputDetail
    {
        public string BeerName { get; set; }
        public int NumberOfBeers { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return PricePerItem * NumberOfBeers;
            }
        }
        public decimal? TotalDiscountedPrice
        {
            get
            {
                if (string.IsNullOrEmpty(AppliedDiscount))
                    return null;

                return TotalPrice * (1 - (Convert.ToDecimal(AppliedDiscount.Replace("%", "")) / 100));
            }
        }
        public string AppliedDiscount { get; set; }
        public List<string> Quote { get; set; }
    }
}
