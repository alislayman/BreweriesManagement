using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.SQL
{
    public class WholesalerDataManager : IWholesalerDataManager
    {
        public Wholesaler GetWholesaler(Guid id)
        {
            Wholesaler wholesaler = null;
            using (var db = new Model())
            {
                var query = from w in db.Wholesalers
                            where w.ID == id
                            select w;

                foreach (var item in query)
                {
                    wholesaler = item;
                }
            }

            return wholesaler;
        }
    }
}
