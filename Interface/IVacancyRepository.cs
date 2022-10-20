using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Interface
{
    public interface IVacancyRepository
    {
        public List<VacancyModel> GetAllVacancies();
        public List<VacancyModel> GetAllVacancies(int? JobTitleID, int? CategoryID, string Description, int? CountryID,
         int? YearsOfExperienceID, int? SalaryID);
        public VacancyModel GetVacancy(int id);
    }
}
