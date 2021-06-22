using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeTOFood.Core;

namespace OdeTOFood.Data
{
    public class InMemoryResturantData : IResturantData
    {
        private List<Restuarant> _restuarants;

        public InMemoryResturantData()
        {
            _restuarants = new List<Restuarant>()
            {
                new Restuarant()
                {
                    CusineType = CusineType.None,
                    Id = 1,
                    Name = "N_1",
                    Location = "L_1"
                },
                new Restuarant()
                {
                    CusineType = CusineType.Itialian,
                    Name = "N_2",
                    Id = 2,
                    Location = "L_2"
                }
            };
        }

        public IEnumerable<Restuarant> GetRestuarants()
        {
            return from r in _restuarants
                orderby r.Id
                select r;
        }

        public IEnumerable<Restuarant> GetRestuarantByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetRestuarants();
            return _restuarants.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
        }

        public Restuarant GetRestuarantById(int id)
        {
            return _restuarants.FirstOrDefault(x => x.Id == id);
        }

        public int Commit()
        {
            return 1;
        }

        public Restuarant Update(Restuarant model)
        {
            var restaurant = _restuarants.FirstOrDefault(x => x.Id == model.Id);
            if (restaurant != null)
            {
                restaurant.Name = model.Name;
                restaurant.CusineType = model.CusineType;
                restaurant.Location = model.Location;
                return restaurant;
            }

            return null;
        }

        public bool Delete(int restuarantId)
        {
            var restaurant = _restuarants.FirstOrDefault(x => x.Id == restuarantId);
            if (restaurant != null)
            {
                _restuarants.Remove(restaurant);
            }
            return true;
        }

        public Restuarant Add(Restuarant restuarant)
        {
            _restuarants.Add(restuarant);
            return restuarant;
        }


    }
}
