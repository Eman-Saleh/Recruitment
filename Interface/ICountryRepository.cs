using Recruitment.Models;
using System.Collections.Generic;

namespace Recruitment.Interface
{
    public interface ICountryRepository
    {
        List<CountryModel> GetAllCountries();
        CountryModel GetCountry(int id);
    }
}
