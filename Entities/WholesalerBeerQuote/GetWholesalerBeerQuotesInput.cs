using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GetWholesalerBeerQuotesInput
    {
        public Guid WholesalerID { get; set; }
        public List<Guid> BeerIDs { get; set; }
    }
}
