using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClientBeerOrder
    {
        public Guid BeerID { get; set; }
        public int NumberOfBeers { get; set; }
    }
}
