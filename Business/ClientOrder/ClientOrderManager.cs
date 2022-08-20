using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace Business
{
    public class ClientOrderManager
    {
        private static readonly ClientOrderManager instance;
        static ClientOrderManager()
        {
            instance = new ClientOrderManager();
        }
        public static ClientOrderManager Instance { get { return instance; } }


        public ClientOrderOutput RequestQuote(ClientOrder clientOrder)
        {
            OnBeforeRequestClientOrderValidation(clientOrder);

            var clientOrderOutput = new ClientOrderOutput()
            {
                TotalPrice = 0M,
                Details = new List<ClientBeerOrderOutputDetail>()
            };

            var wholesalerBeerQuotesByBeerID = WholesalerBeerQuoteManager.Instance.GetWholesalerBeerQuotesByBeerID(new GetWholesalerBeerQuotesInput()
            {
                BeerIDs = clientOrder.BeerOrders.Select(item => item.BeerID).ToList(),
                WholesalerID = clientOrder.WholesalerID
            });

            foreach (var beerOrder in clientOrder.BeerOrders)
            {
                ClientBeerOrderOutputDetail orderOutputDetail = new ClientBeerOrderOutputDetail()
                {
                    BeerName = BeerManager.Instance.GetBeerName(beerOrder.BeerID),
                    NumberOfBeers = beerOrder.NumberOfBeers,
                    Quote = Helper.GetFormattedQuotes(wholesalerBeerQuotesByBeerID, beerOrder.BeerID),
                    PricePerItem = BeerManager.Instance.GetBeerRetailPrice(beerOrder.BeerID),
                };

                if (Helper.TryMatchWholesalerBeerQuote(wholesalerBeerQuotesByBeerID, beerOrder.BeerID, beerOrder.NumberOfBeers, out WholesalerBeerQuote matchedWholesalerBeerQuote))
                    orderOutputDetail.AppliedDiscount = $"{matchedWholesalerBeerQuote.DiscountPercentage}%";

                clientOrderOutput.Details.Add(orderOutputDetail);
                clientOrderOutput.TotalPrice += orderOutputDetail.TotalPrice;
            }

            return clientOrderOutput;
        }

        //new ClientBeerOrderOutputDetail()
        //{
        //    BeerName = "test 1",
        //                  NumberOfBeers = 11,
        //                  TotalDiscountedPrice = 50,
        //                  Quote = "20% discount on order > 10"
        //             },
        //             new ClientBeerOrderOutputDetail()
        //{
        //    BeerName = "test 2",
        //                  NumberOfBeers = 11,
        //                  TotalDiscountedPrice = 30,
        //                  Quote = "20% discount on order > 10"
        //             }

        private void OnBeforeRequestClientOrderValidation(ClientOrder clientOrder)
        {
            clientOrder.ThrowIfNull("The order");

            var wholesaler = WholesalerManager.Instance.GetWholesaler(clientOrder.WholesalerID);
            wholesaler.ThrowIfNotFound("The wholesaler must exist");

            var wholesalerStocks = WholesalerStockManager.Instance.GetWholesalerStocksByBeerID(clientOrder.WholesalerID);
            if (clientOrder.BeerOrders == null || clientOrder.BeerOrders.Count == 0)
                throw new Exception("The order cannot be empty");

            HashSet<Guid> beerIDs = new HashSet<Guid>();
            foreach (var beerOrder in clientOrder.BeerOrders)
            {
                var beer = BeerManager.Instance.GetBeer(beerOrder.BeerID);
                beer.ThrowIfNotFound("Beer", beerOrder.BeerID);

                if (!wholesalerStocks.TryGetValue(beerOrder.BeerID, out WholesalerStock wholesalerStock))
                    throw new Exception("The beer must be sold by the wholesaler");

                if (wholesalerStock.NumberOfBeers < beerOrder.NumberOfBeers)
                    throw new Exception("The number of beers ordered cannot be greater than the wholesaler's stock");

                beerIDs.Add(beerOrder.BeerID);
            }

            if (beerIDs.Count != clientOrder.BeerOrders.Count)
                throw new Exception("There can't be any duplicate in the order");
        }
    }
}
