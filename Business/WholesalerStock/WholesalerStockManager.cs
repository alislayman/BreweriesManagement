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

        public AddItemOutput<WholesalerStock> AddStock(WholesalerStockToAdd wholesalerStockToAdd)
        {
            return _dataManager.AddStock(wholesalerStockToAdd);
        }

        public void UpdateStock(UpdateStockInput input)
        {
            throw new NotImplementedException();
        }

        public GetWholesalerStockDetailsOutput GetWholesalerStockDetails(GetWholesalerStockDetailsInput input)
        {
            throw new NotImplementedException();
        }
    }
}
