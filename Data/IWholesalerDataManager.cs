using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IWholesalerDataManager : IDataManager
    {
        Wholesaler GetWholesaler(Guid id);
    }
}
