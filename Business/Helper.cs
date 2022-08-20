using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class Helper
    {
        public static List<string> GetFormattedQuotes(Dictionary<Guid, List<WholesalerBeerQuote>> wholesalerBeerQuotesByBeerID, Guid beerID)
        {
            if (!wholesalerBeerQuotesByBeerID.TryGetValue(beerID, out List<WholesalerBeerQuote> wholesalerBeerQuotes))
                return null;

            List<string> formattedQuotes = new List<string>();
            for (int i = wholesalerBeerQuotes.Count - 1; i >= 0; i--)
            {
                var wholesalerBeerQuote = wholesalerBeerQuotes[i];
                formattedQuotes.Add($"A {wholesalerBeerQuote.DiscountPercentage}% discount is applied above {wholesalerBeerQuote.MinimumNumberOfBeers} drinks");
            }

            return formattedQuotes;
        }

        public static bool TryMatchWholesalerBeerQuote(Dictionary<Guid, List<WholesalerBeerQuote>> wholesalerBeerQuotesByBeerID, Guid beerID, int numberOfBeersRequested,
            out WholesalerBeerQuote matchedWholesalerBeerQuote)
        {
            matchedWholesalerBeerQuote = null;
            if (!wholesalerBeerQuotesByBeerID.TryGetValue(beerID, out List<WholesalerBeerQuote> wholesalerBeerQuotes))
                return false;

            foreach (var wholesalerBeerQuote in wholesalerBeerQuotes)
            {
                if (numberOfBeersRequested >= wholesalerBeerQuote.MinimumNumberOfBeers)
                {
                    matchedWholesalerBeerQuote = wholesalerBeerQuote;
                    return true;
                }
            }

            return false;
        }
    }
}
