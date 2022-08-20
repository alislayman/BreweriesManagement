using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Business
{
    public class WholesalerBeerQuoteManager
    {
        static IWholesalerBeerQuoteDataManager _dataManager;

        private static readonly WholesalerBeerQuoteManager instance;
        static WholesalerBeerQuoteManager()
        {
            instance = new WholesalerBeerQuoteManager();
            _dataManager = DataManagerFactory.GetDataManager<IWholesalerBeerQuoteDataManager>();
        }
        public static WholesalerBeerQuoteManager Instance { get { return instance; } }

        public Dictionary<Guid, List<WholesalerBeerQuote>> GetWholesalerBeerQuotesByBeerID(GetWholesalerBeerQuotesInput input)
        {
            Dictionary<Guid, List<WholesalerBeerQuote>> wholesalerBeerQuotesByBeerID = new Dictionary<Guid, List<WholesalerBeerQuote>>();
            List<WholesalerBeerQuote> wholesalerBeerQuotes = _dataManager.GetWholesalerBeerQuotes(input);
            foreach (var wholesalerBeerQuote in wholesalerBeerQuotes)
            {
                if (wholesalerBeerQuotesByBeerID.TryGetValue(wholesalerBeerQuote.BeerID, out List<WholesalerBeerQuote> existingWholesalerBeerQuotes))
                {
                    existingWholesalerBeerQuotes.Add(wholesalerBeerQuote);
                    existingWholesalerBeerQuotes.Sort((item1, item2) =>  -1*item1.DiscountPercentage.CompareTo(item2.DiscountPercentage)); // order by discount descending
                }
                else
                {
                    wholesalerBeerQuotesByBeerID.Add(wholesalerBeerQuote.BeerID, new List<WholesalerBeerQuote>() { wholesalerBeerQuote });
                }
            }

            return wholesalerBeerQuotesByBeerID;
        }
    }
}
