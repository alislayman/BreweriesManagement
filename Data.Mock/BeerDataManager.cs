using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Mock
{
    public class BeerDataManager : IBeerDataManager
    {
        static List<Beer> _beers = new List<Beer>()
        {
            new Beer() { ID  = new Guid("6C9626E4-5FF0-4425-BDAB-D390FD9E7353") ,Name  ="Saison Dupont - Organic Belgian Beer" ,BreweryID =new Guid("77F2B686-AABF-4ED1-B9E4-506D5E9BDA88") ,AlcoholContent = 5.50M ,RetailPrice = 2.35M ,WholesalePrice = 2.20M, IsDeleted = false }
            ,new Beer() { ID  = new Guid("812A4BD9-366F-487E-A6E1-9CD2C9A82F9D") ,Name  ="Organic Moinette - Belgian Beer" ,BreweryID =new Guid("77F2B686-AABF-4ED1-B9E4-506D5E9BDA88") ,AlcoholContent = 7.50M ,RetailPrice = 2.60M ,WholesalePrice = 2.45M , IsDeleted = false}
            ,new Beer() { ID  = new Guid("0A6D73D8-4802-4D42-B365-D2E626B2509D") ,Name  ="Lindemans Faro Lambic - Red Belgian Beer" ,BreweryID =new Guid("10BF3CFC-AFD1-437C-BC33-7527C5593938") ,AlcoholContent = 4.50M ,RetailPrice = 1.60M ,WholesalePrice = 1.50M, IsDeleted = false }
            ,new Beer() { ID  = new Guid("FC3E35C3-A0F4-47B2-ADF5-6B72499C921A") ,Name  ="Lindemans Pécheresse - Peach Beer" ,BreweryID =new Guid("10BF3CFC-AFD1-437C-BC33-7527C5593938") ,AlcoholContent = 2.50M ,RetailPrice = 2.0M ,WholesalePrice = 1.90M , IsDeleted = false}
            ,new Beer() { ID  = new Guid("933EAC73-BD99-47E3-B6C6-8095B4778B00") ,Name  ="Strawberries Lindemans Framboise" ,BreweryID =new Guid("10BF3CFC-AFD1-437C-BC33-7527C5593938") ,AlcoholContent = 2.50M ,RetailPrice = 2.0M ,WholesalePrice = 1.80M, IsDeleted = false }
            ,new Beer() { ID  = new Guid("F3AD8206-A1AA-41E0-9E65-03D11E160B1D") ,Name  ="Corsendonk Pater Dubbel Ale" ,BreweryID =new Guid("1B4F49C2-9CA8-4E87-BEBB-D83D200680C7") ,AlcoholContent = 6.50M ,RetailPrice = 3.25M ,WholesalePrice = 3.10M, IsDeleted = false }
            ,new Beer() { ID  = new Guid("3B556575-FB25-4EA2-AD33-AD41E6C0E69C") ,Name  ="Corsendonk white beer" ,BreweryID =new Guid("1B4F49C2-9CA8-4E87-BEBB-D83D200680C7") ,AlcoholContent = 4.80M ,RetailPrice = 1.80M ,WholesalePrice = 1.50M , IsDeleted = false}
            ,new Beer() { ID  = new Guid("25527540-745C-4622-96CE-96ED205137CB") ,Name  ="Gulden Draak - Dark Belgian Beer" ,BreweryID =new Guid("1B4F49C2-9CA8-4E87-BEBB-D83D200680C7") ,AlcoholContent = 10.50M ,RetailPrice = 2.45M ,WholesalePrice = 2.10M, IsDeleted = false }
        };

        public List<Beer> GetBeers(Guid? breweryID)
        {
            if (!breweryID.HasValue)
                return _beers;

            return _beers.Where(item => (!item.IsDeleted) && item.BreweryID == breweryID.Value).ToList();
        }

        public Beer GetBeer(Guid beerID)
        {
            return _beers.Find(item => item.ID == beerID);
        }

        public Guid? AddBeer(Beer beer)
        {
            var existingBeer = GetBeers(beer.BreweryID).Find(item => string.Compare(item.Name, beer.Name, true) == 0);
            if (existingBeer != null)
                return null;

            Guid newBeerID = Guid.NewGuid();
            beer.ID = newBeerID;
            _beers.Add(beer);
            return newBeerID;
        }

        public Beer DeleteBeer(Guid beerID)
        {
            var existingBeer = GetBeer(beerID);
            if (existingBeer == null)
                return null;

            existingBeer.IsDeleted = true;
            return existingBeer;
        }
    }
}
