using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.SQL
{
    public class WholesalerBeerQuoteDataManager : IWholesalerBeerQuoteDataManager
    {
        public List<WholesalerBeerQuote> GetWholesalerBeerQuotes(GetWholesalerBeerQuotesInput input)
        {
            List<WholesalerBeerQuote> wholesalerBeerQuotes = new List<WholesalerBeerQuote>();
            using (var db = new Model())
            {
                var query = from wbc in db.WholesalerBeerQuotes
                            where wbc.WholesalerID == input.WholesalerID && input.BeerIDs.Contains(wbc.BeerID)
                            select wbc;

                foreach (var item in query)
                {
                    wholesalerBeerQuotes.Add(item);
                }
            }

            return wholesalerBeerQuotes;
        }
    }
}
