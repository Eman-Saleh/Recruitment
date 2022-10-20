using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public class CountryRepository : ICountryRepository
    {
        HRContext db = new HRContext();

        public List<CountryModel> GetAllCountries()
        {
            List<CountryModel> _Countries = new List<CountryModel>();
            var mod = db.Countries.ToList();
            foreach (var s in mod)
            {
                var v = new CountryModel()
                {
                    Id = s.Id,
                    Name = s.Name
                };
                _Countries.Add(v);
            }
            return _Countries;
        }
        public CountryModel GetCountry(int id)
        {
            var Country = db.Countries.Find(id);
            var CountryModel = new CountryModel()
            {
                Id = Country.Id,
                Name = Country.Name
            };
            return CountryModel;
        }
    }
}
