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
        public decimal TotalPrice { get; set; }
        public string Quote { get; set; }
    }
}
