using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Data;

namespace Business
{
    public class BeerManager
    {
        static IBeerDataManager _dataManager;

        private static readonly BeerManager instance;
        static BeerManager()
        {
            instance = new BeerManager();
            _dataManager = DataManagerFactory.GetDataManager<IBeerDataManager>();
        }
        public static BeerManager Instance { get { return instance; } }

        public string GetBeerName(Guid beerID)
        {
            throw new NotImplementedException();
        }

        public GetBeersByBreweryOutput GetBeersByBrewery(GetBeersByBreweryInput input)
        {
            input.ThrowIfNull("GetBeersByBreweryInput");

            List<BeerDetail> beerDetails = new List<BeerDetail>();
            var beers = _dataManager.GetBeers(input.BreweryID);
            if (beers != null)
            {
                foreach (var beer in beers)
                {
                    beerDetails.Add(new BeerDetail()
                    {
                        BeerEntity = beer,
                        BreweryName = BreweryManager.Instance.GetBreweryName(beer.BreweryID)
                    });
                }
            }

            return new GetBeersByBreweryOutput()
            {
                BeerDetails = beerDetails
            };
        }

        public AddItemOutput<Beer> AddBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public DeleteItemOutput<Beer> DeleteBeer(Guid beerID)
        {
            throw new NotImplementedException();
        }

        public Decimal GetBeerRetailPrice(Guid beerID)
        {
            throw new NotImplementedException();
        }
    }
}
