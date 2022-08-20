using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Business
{
    public class WholesalerManager
    {
        static IWholesalerDataManager _dataManager;

        private static readonly WholesalerManager instance;
        static WholesalerManager()
        {
            instance = new WholesalerManager();
            _dataManager = DataManagerFactory.GetDataManager<IWholesalerDataManager>();
        }
        public static WholesalerManager Instance { get { return instance; } }

        public string GetWholesalerName(Guid wholesalerID)
        {
            var wholesaler = GetWholesaler(wholesalerID);
            wholesaler.ThrowIfNotFound("wholesaler", wholesalerID);
            return wholesaler.Name;
        }

        public Wholesaler GetWholesaler(Guid wholesalerID)
        {
            var wholesaler = _dataManager.GetWholesaler(wholesalerID);
            return wholesaler;
        }
    }
}
