using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Mock
{
    public class WholesalerDataManager : IWholesalerDataManager
    {
        static List<Wholesaler> _wholesalers = new List<Wholesaler>()
        {
            new Wholesaler()
            {
                ID = new Guid("481B8CED-3FA6-4BC1-BEEE-2077E4F27FAB"),
                Name = "Belgibeer"
            },
            new Wholesaler()
            {
                ID = new Guid("A2FA5B28-77BE-47E9-92D9-851D28B8831D"),
                Name = "Carlsberg Importers"
            },
            new Wholesaler()
            {
                ID = new Guid("3F9FF53E-BA16-449D-B999-CC34D15A7BBC"),
                Name = "Drinks Center Fontana"
            }
        };

        public Wholesaler GetWholesaler(Guid id)
        {
            return _wholesalers.Find(item => item.ID == id);
        }
    }
}
