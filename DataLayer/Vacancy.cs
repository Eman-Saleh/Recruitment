using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class Vacancy
    {
        public Vacancy()
        {
            VacancyDescriptions = new HashSet<VacancyDescription>();
            VacancyQualifications = new HashSet<VacancyQualification>();
        }

        public int Id { get; set; }
        public int JobTitleId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public DateTime PublishingDate { get; set; }
        public int CountryId { get; set; }
        public int Gender { get; set; }
        public int YearsOfExperienceId { get; set; }
        public int SalaryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Country Country { get; set; }
        public virtual Gender GenderNavigation { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual Salary Salary { get; set; }
        public virtual Experience YearsOfExperience { get; set; }
        public virtual ICollection<VacancyDescription> VacancyDescriptions { get; set; }
        public virtual ICollection<VacancyQualification> VacancyQualifications { get; set; }
    }
}
