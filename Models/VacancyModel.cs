using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Models
{
    public class VacancyModel
    {
        public int ID { get; set; }
        public int JobTitleID { get; set; }
        public string JobTitle { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string  PublishingDate { get; set; }
        public int CountryID { get; set; }
        public string Country { get; set; }
        public int Gender { get; set; }
        public string GenderType { get; set; }
        public int YearsOfExperienceID { get; set; }
        public string YearsOfExperience { get; set; }
        public int SalaryID { get; set; }
        public string Salary { get; set; }
    }
    public class VacancySearchViewModel{
        public int? JobTitleID { get; set; }
        public int? CategoryID { get; set; }
        public string Description { get; set; }
        public int? CountryID { get; set; }
        public int? Gender { get; set; }
        public int? YearsOfExperienceID { get; set; }
        public int? SalaryID { get; set; }
        public List<VacancyModel > vacancyModels { get; set; }

    }
}
