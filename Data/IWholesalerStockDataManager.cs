using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IWholesalerStockDataManager : IDataManager
    {
        WholesalerStock AddOrUpdateStock(WholesalerStock wholesalerStock);
        List<WholesalerStock> GetWolesalerStocks(Guid wholesalerId);
    }
}
