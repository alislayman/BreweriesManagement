using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entities
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=mainDB")
        {
        }

        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<Wholesaler> Wholesalers { get; set; }
        public virtual DbSet<WholesalerBeerQuote> WholesalerBeerQuotes { get; set; }
        public virtual DbSet<WholesalerStock> WholesalerStocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
                .Property(e => e.RetailPrice)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Beer>()
                .Property(e => e.WholesalePrice)
                .HasPrecision(20, 2);
        }
    }
}
