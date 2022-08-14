using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Beer : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public Guid BreweryID { get; set; }

        public decimal AlcoholContent { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal WholesalePrice { get; set; }
    }
}
