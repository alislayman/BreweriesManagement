using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClientOrder
    {
        public int WholesalerID { get; set; }
        public List<ClientBeerOrder> BeerOrders { get; set; }
    }
}
