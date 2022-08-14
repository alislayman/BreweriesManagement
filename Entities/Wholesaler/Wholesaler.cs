using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Wholesaler : BaseEntity<Guid>
    {
        public string WholesalerName { get; set; }
    }
}
