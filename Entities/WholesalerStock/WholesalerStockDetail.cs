using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WholesalerStockDetail
    {
        public WholesalerStock WholesalerStockEntity { get; set; }
        public string BeerName { get; set; }
        public string WholesalerName { get; set; }
    }
}
