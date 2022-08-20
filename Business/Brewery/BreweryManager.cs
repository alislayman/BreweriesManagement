using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Business
{
    public class BreweryManager
    {
        static IBreweryDataManager _dataManager;

        private static readonly BreweryManager instance;
        static BreweryManager()
        {
            instance = new BreweryManager();
            _dataManager = DataManagerFactory.GetDataManager<IBreweryDataManager>();
        }
        public static BreweryManager Instance { get { return instance; } }

        public string GetBreweryName(Guid breweryID)
        {
            var brewery = _dataManager.GetBrewery(breweryID);
            brewery.ThrowIfNotFound("brewery", breweryID);
            return brewery.Name;
        }

        public Brewery GetBrewery(Guid breweryID)
        {
            var brewery = _dataManager.GetBrewery(breweryID);
            return brewery;
        }
    }
}
