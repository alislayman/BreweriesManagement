using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.SQL
{
    public class WholesalerStockDataManager : IWholesalerStockDataManager
    {
        public WholesalerStock AddOrUpdateStock(WholesalerStock wholesalerStock)
        {
            WholesalerStock existingWholesalerStock = null;
            using (var db = new Model())
            {
                var query = from ws in db.WholesalerStocks
                            where ws.BeerID == wholesalerStock.BeerID && ws.WholesalerID == wholesalerStock.WholesalerID
                            select ws;

                foreach (var item in query)
                {
                    existingWholesalerStock = item;
                }

                if (existingWholesalerStock == null)
                {
                    db.WholesalerStocks.Add(wholesalerStock);
                    db.SaveChanges();
                    foreach (var item in query)
                    {
                        existingWholesalerStock = item;
                    }
                }
                else
                {
                    db.WholesalerStocks.Attach(existingWholesalerStock);
                    existingWholesalerStock.NumberOfBeers += wholesalerStock.NumberOfBeers;
                    db.SaveChanges();
                }
            }

            return existingWholesalerStock;
        }

        public List<WholesalerStock> GetWolesalerStocks(Guid wholesalerId)
        {
            List<WholesalerStock> wholesalerStocks = new List<WholesalerStock>();
            using (var db = new Model())
            {
                var query = from ws in db.WholesalerStocks
                            where ws.WholesalerID == wholesalerId
                            select ws;

                foreach (var item in query)
                {
                    wholesalerStocks.Add(item);
                }
            }

            return wholesalerStocks;
        }
    }
}
