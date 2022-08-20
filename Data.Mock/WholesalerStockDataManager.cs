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
        static List<WholesalerStock> _wholesalerStocks = new List<WholesalerStock>();
        public WholesalerStock AddOrUpdateStock(WholesalerStock wholesalerStock)
        {
            WholesalerStock existingWholesalerStock = _wholesalerStocks.Find(item => item.WholesalerID == wholesalerStock.WholesalerID && item.BeerID == wholesalerStock.BeerID);

            if (existingWholesalerStock == null)
            {
                wholesalerStock.ID = _wholesalerStocks.Count + 1;
                existingWholesalerStock = wholesalerStock;
                _wholesalerStocks.Add(wholesalerStock);
            }
            else
            {
                existingWholesalerStock.NumberOfBeers += wholesalerStock.NumberOfBeers;
            }

            return existingWholesalerStock;
        }

        public List<WholesalerStock> GetWolesalerStocks(Guid wholesalerId)
        {
            return _wholesalerStocks.Where(item => item.WholesalerID == wholesalerId).ToList();
        }
    }
}
