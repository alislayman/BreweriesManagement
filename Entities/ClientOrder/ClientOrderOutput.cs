using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClientOrderOutput
    {
        public decimal TotalPrice { get; set; }
        public List<ClientBeerOrderOutputDetail> Details { get; set; }
    }
}
