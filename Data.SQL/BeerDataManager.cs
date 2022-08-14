using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.SQL
{
    public class BeerDataManager : IBeerDataManager
    {
        public List<Beer> GetBeers(Guid? breweryID)
        {
            throw new NotImplementedException();
        }
    }
}
