using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Mock
{
    public class WholesalerStockDataManager : IWholesalerStockDataManager
    {
        public AddItemOutput<WholesalerStock> AddStock(WholesalerStockToAdd wholesalerStockToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
