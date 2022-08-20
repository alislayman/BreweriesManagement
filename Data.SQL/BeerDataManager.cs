using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.SQL
{
    public class BeerDataManager : IBeerDataManager
    {
        public List<Beer> GetBeers(Guid? breweryID)
        {
            List<Beer> beers = new List<Beer>();
            using (var db = new Model())
            {
                var query = from b in db.Beers
                            where !breweryID.HasValue || b.BreweryID == breweryID.Value
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    beers.Add(item);
                }
            }

            return beers;
        }

        public Beer GetBeer(Guid beerID)
        {
            Beer beer = null;
            using (var db = new Model())
            {
                var query = from b in db.Beers
                            where b.ID == beerID
                            select b;

                foreach (var item in query)
                {
                    beer = item;
                }
            }

            return beer;
        }

        public Guid? AddBeer(Beer beer)
        {
            var existingBeer = GetBeers(beer.BreweryID).Find(item => string.Compare(item.Name, beer.Name, true) == 0);
            if (existingBeer != null)
                return null;

            Guid newBeerID = Guid.NewGuid();
            using (var db = new Model())
            {
                beer.ID = newBeerID;
                db.Beers.Add(beer);
                db.SaveChanges();
            }

            return newBeerID;
        }

        public Beer DeleteBeer(Guid beerID)
        {
            Beer existingBeer = null;
            using (var db = new Model())
            {
                var query = from b in db.Beers
                            where b.ID == beerID && (!b.IsDeleted)
                            select b;

                foreach (var item in query)
                {
                    existingBeer = item;
                }

                if(existingBeer != null)
                {
                    db.Beers.Attach(existingBeer);
                    existingBeer.IsDeleted = true;
                    db.SaveChanges();
                }
            }

            return existingBeer;
        }
    }
}
