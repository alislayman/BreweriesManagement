using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Entities;

namespace Testing
{
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            ConfigurationManager.AppSettings["OverriddenDataAssembly"] = "Data.Mock";
        }

        [TestMethod]
        public void GetBeersByBrewery_Succeeded()
        {
            var getBeersByBreweryOutput = BeerManager.Instance.GetBeersByBrewery(new GetBeersByBreweryInput()
            {
                BreweryID = new Guid("77F2B686-AABF-4ED1-B9E4-506D5E9BDA88")
            });

            Assert.AreEqual(getBeersByBreweryOutput != null && getBeersByBreweryOutput.BeerDetails != null && getBeersByBreweryOutput.BeerDetails.Count >= 2, true);
        }

        [TestMethod]
        public void GetBeersByBrewery_InvalidBreweryID()
        {
            var getBeersByBreweryOutput = BeerManager.Instance.GetBeersByBrewery(new Entities.GetBeersByBreweryInput()
            {
                BreweryID = new Guid("1112B686-AABF-4ED1-B9E4-506D5E9BDA88")
            });

            Assert.AreEqual(getBeersByBreweryOutput != null && getBeersByBreweryOutput.BeerDetails != null && getBeersByBreweryOutput.BeerDetails.Count == 0, true);
        }

        [TestMethod]
        public void AddBeer_Succeeded()
        {
            var addBeerOutput = BeerManager.Instance.AddBeer(new Beer()
            {
                BreweryID = new Guid("77F2B686-AABF-4ED1-B9E4-506D5E9BDA88"),
                Name = "new Beer"
            });

            Assert.AreEqual(addBeerOutput.Result,
               ActionResult.Succeeded);
        }

        [TestMethod]
        public void AddBeer_AlreadyExists()
        {
            var addBeerOutput = BeerManager.Instance.AddBeer(new Beer()
            {
                BreweryID = new Guid("77F2B686-AABF-4ED1-B9E4-506D5E9BDA88"),
                Name = "Saison Dupont - Organic Belgian Beer"
            });

            Assert.AreEqual(addBeerOutput.Result,
               ActionResult.Failed);
        }

        [TestMethod]
        public void AddBeer_InvalidBrewery()
        {
            var addBeerOutput = BeerManager.Instance.AddBeer(new Beer()
            {
                BreweryID = new Guid("11111111-AABF-4ED1-B9E4-506D5E9BDA88"),
                Name = "Saison Dupont - Organic Belgian Beer"
            });

            Assert.AreEqual(addBeerOutput.Result,
               ActionResult.Failed);
        }
    }
}
