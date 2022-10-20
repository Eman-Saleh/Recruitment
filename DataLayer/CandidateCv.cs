using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class CandidateCv
    {
        public int Id { get; set; }
        public int JobTitleId { get; set; }
        public int CategoryId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public int CountryId { get; set; }
        public int? ResidenceId { get; set; }
        public string CurrentCompany { get; set; }
        public int? ExperienceId { get; set; }
        public int? CurrentSalaryRangeId { get; set; }
        public int? CountryOfNationalityId { get; set; }
        public decimal? NationalId4digits { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Cv { get; set; }
    }
}
