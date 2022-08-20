using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Business
{
    public class WholesalerStockManager
    {
        static IWholesalerStockDataManager _dataManager;

        private static readonly WholesalerStockManager instance;
        static WholesalerStockManager()
        {
            instance = new WholesalerStockManager();
            _dataManager = DataManagerFactory.GetDataManager<IWholesalerStockDataManager>();
        }
        public static WholesalerStockManager Instance { get { return instance; } }

        public AddItemOutput<WholesalerStock> AddOrUpdateStock(WholesalerStock wholesalerStock)
        {
            AddItemOutput<WholesalerStock> output = new AddItemOutput<WholesalerStock>()
            {
                Result = ActionResult.Succeeded
            };

            try
            {
                onBeforeAddStockValidation(wholesalerStock);

                WholesalerStock affectedWholesalerStock = _dataManager.AddOrUpdateStock(wholesalerStock);
                if (affectedWholesalerStock == null)
                {
                    output.Result = ActionResult.Failed;
                    output.Message = "Cannot affect this wholesaler stock";
                }
                else
                {
                    output.Item = affectedWholesalerStock;
                }
            }
            catch (Exception ex)
            {
                output.Result = ActionResult.Failed;
                output.Message = ex.Message;
            }

            return output;
        }

        public GetWholesalerStockDetailsOutput GetWholesalerStockDetails(GetWholesalerStockDetailsInput input)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, WholesalerStock> GetWholesalerStocksByBeerID(Guid wholesalerID)
        {
            var wholesalerStocks = _dataManager.GetWolesalerStocks(wholesalerID);
            return wholesalerStocks.ToDictionary(item => item.BeerID, item => item);
        }

        private void onBeforeAddStockValidation(WholesalerStock wholesalerStock)
        {
            wholesalerStock.ThrowIfNull("wholesalerStock");
            var beer = BeerManager.Instance.GetBeer(wholesalerStock.BeerID);
            beer.ThrowIfNotFound("Beer", wholesalerStock.BeerID);
            var wholesaler = WholesalerManager.Instance.GetWholesaler(wholesalerStock.WholesalerID);
            wholesaler.ThrowIfNotFound("Wholesaler", wholesalerStock.WholesalerID);
        }
    }
}
