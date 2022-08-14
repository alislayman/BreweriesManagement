using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Mock
{
    public class BreweryDataManager : IBreweryDataManager
    {
        static List<Brewery> _breweries = new List<Brewery>()
        {
            new Brewery()
            {
                ID = new Guid("77F2B686-AABF-4ED1-B9E4-506D5E9BDA88"),
                Name = "Brasserie Dupont"
            },
            new Brewery()
            {
                ID = new Guid("10BF3CFC-AFD1-437C-BC33-7527C5593938"),
                Name = "Brasserie Lindemans"
            },
            new Brewery()
            {
                ID = new Guid("1B4F49C2-9CA8-4E87-BEBB-D83D200680C7"),
                Name = "Van Steenberge"
            }
        };

        public Brewery GetBrewery(Guid id)
        {
            return _breweries.Find(item => item.ID == id);
        }
    }
}
