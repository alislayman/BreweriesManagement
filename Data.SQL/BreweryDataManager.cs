using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.SQL
{
    public class BreweryDataManager : IBreweryDataManager
    {
        public Brewery GetBrewery(Guid id)
        {
            Brewery brewery = null;
            using (var db = new Model())
            {
                var query = from b in db.Breweries
                            where b.ID == id
                            select b;

                foreach (var item in query)
                {
                    brewery = item;
                }
            }

            return brewery;
        }
    }
}
