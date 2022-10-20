using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public class VacancyRepository: IVacancyRepository
    {
        HRContext db = new HRContext();
        public List<VacancyModel> GetAllVacancies()
        {
            List<VacancyModel> _vacancies = new List<VacancyModel>();
            var mod = db.Vacancies.ToList();
            foreach (var vacancy in mod)
            {
                var vacancyModel = vacancyDataToModel(vacancy);
                _vacancies.Add(vacancyModel);
            }
            return _vacancies;
        }
        public List<VacancyModel> GetAllVacancies(int? JobTitleID, int? CategoryID, string Description, int? CountryID,
         int? YearsOfExperienceID, int? SalaryID)
        {
            List<VacancyModel> _vacancies = new List<VacancyModel>();
            var mod = db.Vacancies.ToList();
            if (CategoryID != null)
            {
                mod = mod.Where(a => a.CategoryId == CategoryID).ToList();
            }
            if (CountryID != null)
            {
                mod = mod.Where(a => a.CountryId == CountryID).ToList();
            }
            if (SalaryID != null)
            {
                mod = mod.Where(a => a.SalaryId == SalaryID).ToList();
            }
            if (YearsOfExperienceID != null)
            {
                mod = mod.Where(a => a.YearsOfExperienceId == YearsOfExperienceID).ToList();
            }
            if (JobTitleID != null)
            {
                mod = mod.Where(a => a.JobTitleId == JobTitleID).ToList();
            }
            if (Description != null)
            {
                mod = mod.Where(a => a.Description.ToLower().Contains(Description.ToLower())).ToList();
            }
            foreach (var vacancy in mod)
            {
                var vacancyModel = vacancyDataToModel(vacancy);
                _vacancies.Add(vacancyModel);
            }
            return _vacancies;
        }
        public VacancyModel GetVacancy(int id)
        {
            var vacancy = db.Vacancies.Find(id);
            var vacancyModel = vacancyDataToModel(vacancy);
            return vacancyModel;
        }
        VacancyModel vacancyDataToModel(Vacancy vacancy)
        {
            var vacancyModel = new VacancyModel()
            {
                ID = vacancy.Id,
                CategoryID = vacancy.CategoryId,
                Category = db.Categories.Find(vacancy.CategoryId).Name,
                Description = vacancy.Description,
                CountryID = vacancy.CountryId,
                Country = db.Countries.Find(vacancy.CountryId).Name,
                Gender = vacancy.Gender,
                GenderType = db.Genders.Find(vacancy.Gender).Type,
                PublishingDate = vacancy.PublishingDate.ToString("dd-MM-yyyy"),
                SalaryID = vacancy.SalaryId,
                Salary = db.Salaries.Find(vacancy.SalaryId).Range,
                YearsOfExperienceID = vacancy.YearsOfExperienceId,
                YearsOfExperience = db.Experiences.Find(vacancy.YearsOfExperienceId).YearsOfExperience,
                JobTitleID = vacancy.JobTitleId,
                JobTitle = db.JobTitles.Find(vacancy.JobTitleId).Title
            };
            return vacancyModel;
        }

    }
}
