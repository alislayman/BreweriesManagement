using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Mock
{
    public class WholesalerBeerQuoteDataManager : IWholesalerBeerQuoteDataManager
    {
        static List<WholesalerBeerQuote> _wholesalerBeerQuotes = new List<WholesalerBeerQuote>()
        {
            new WholesalerBeerQuote(){ID = 1, BeerID = new Guid("6c9626e4-5ff0-4425-bdab-d390fd9e7353"), WholesalerID = new Guid("481b8ced-3fa6-4bc1-beee-2077e4f27fab"), DiscountPercentage = 5, MinimumNumberOfBeers = 10 },
            new WholesalerBeerQuote(){ID = 2, BeerID = new Guid("fc3e35c3-a0f4-47b2-adf5-6b72499c921a"), WholesalerID = new Guid("a2fa5b28-77be-47e9-92d9-851d28b8831d"), DiscountPercentage = 10, MinimumNumberOfBeers = 20 },
            new WholesalerBeerQuote(){ID = 3, BeerID = new Guid("6c9626e4-5ff0-4425-bdab-d390fd9e7353"), WholesalerID = new Guid("481b8ced-3fa6-4bc1-beee-2077e4f27fab"), DiscountPercentage = 10, MinimumNumberOfBeers = 20 }
        };

        public List<WholesalerBeerQuote> GetWholesalerBeerQuotes(GetWholesalerBeerQuotesInput input)
        {
            return _wholesalerBeerQuotes.Where(wbc => wbc.WholesalerID == input.WholesalerID && input.BeerIDs.Contains(wbc.BeerID)).ToList();
        }
    }
}
