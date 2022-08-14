﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IBeerDataManager : IDataManager
    {
        List<Beer> GetBeers(Guid? breweryID);
    }
}
