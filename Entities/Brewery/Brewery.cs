using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Brewery : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
