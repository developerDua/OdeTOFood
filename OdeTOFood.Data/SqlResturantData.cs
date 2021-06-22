using OdeTOFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OdeTOFood.Data
{
    public class SqlResturantData : IResturantData
    {
        public OdeToFoodDbContext DbContext;
        public SqlResturantData(OdeToFoodDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public bool Delete(int restuarantId)
        {
            var r = DbContext.Resturants.FirstOrDefault(x => x.Id == restuarantId);
            if (r != null)
            {
                DbContext.Resturants.Remove(r);
            }
            return true;
        }


        public Restuarant GetRestuarantById(int id)
        {
            var r = DbContext.Resturants.FirstOrDefault(x => x.Id == id);
            return r;
        }

        public IEnumerable<Restuarant> GetRestuarantByName(string name)
        {
            var r = DbContext.Resturants.Where(x => x.Name == name);
            return r;
        }

        public IEnumerable<Restuarant> GetRestuarants()
        {
            return DbContext.Resturants;
        }

        public Restuarant Update(Restuarant restuarant)
        {
            var entity = DbContext.Resturants.Attach(restuarant);
            entity.State = EntityState.Modified;
            return restuarant;
        }

        public Restuarant Add(Restuarant restuarant)
        {
            DbContext.Add(restuarant);
            return restuarant;
        }

    }
}
