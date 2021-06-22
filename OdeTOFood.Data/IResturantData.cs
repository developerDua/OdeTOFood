using OdeTOFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeTOFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Restuarant> GetRestuarants();
        IEnumerable<Restuarant> GetRestuarantByName(string name);
        Restuarant GetRestuarantById(int id);
        Restuarant Update(Restuarant restuarant);
        int Commit();
        bool Delete(int restuarantId);
        Restuarant Add(Restuarant restuarant);
    }

}
