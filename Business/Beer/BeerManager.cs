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
            var beer = GetBeer(beerID);
            beer.ThrowIfNotFound("beer", beerID);
            return beer.Name;
        }

        public Beer GetBeer(Guid beerID)
        {
            var beer = _dataManager.GetBeer(beerID);
            return beer;
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
            AddItemOutput<Beer> output = new AddItemOutput<Beer>()
            {
                Item = beer,
                Result = ActionResult.Succeeded
            };

            try
            {
                OnBeforeAddBeerValidaton(beer);
                Guid? addedBeerID = _dataManager.AddBeer(beer);
                if (!addedBeerID.HasValue)
                {
                    output.Result = ActionResult.Failed;
                    output.Message = "Cannot add this beer to this brewery (Check duplication)";
                }
                else
                {
                    beer.ID = addedBeerID.Value;
                }
            }
            catch (Exception ex)
            {
                output.Result = ActionResult.Failed;
                output.Message = ex.Message;
            }

            return output;
        }

        public DeleteItemOutput<Beer> DeleteBeer(Guid beerID)
        {
            DeleteItemOutput<Beer> output = new DeleteItemOutput<Beer>()
            {
                Result = ActionResult.Succeeded
            };

            try
            {
                Beer beer = _dataManager.DeleteBeer(beerID);
                if (beer == null)
                {
                    output.Result = ActionResult.Failed;
                    output.Message = "Cannot find a beer with this ID";
                }
                else
                {
                    output.Item = beer;
                }
            }
            catch (Exception ex)
            {
                output.Result = ActionResult.Failed;
                output.Message = ex.Message;
            }

            return output;
        }

        public Decimal GetBeerRetailPrice(Guid beerID)
        {
            decimal tvaPercentage = 0M;
            var beer = _dataManager.GetBeer(beerID);
            beer.ThrowIfNotFound("beer", beerID);

            return beer.RetailPrice * (1 + (tvaPercentage / 100M));
        }

        private void OnBeforeAddBeerValidaton(Beer beer)
        {
            beer.ThrowIfNull("Beer");
            var brewery = BreweryManager.Instance.GetBrewery(beer.BreweryID);
            brewery.ThrowIfNotFound("brewery", beer.BreweryID);
        }
    }
}
