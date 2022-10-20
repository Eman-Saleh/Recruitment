using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Recruitment.Models
{
    public partial class CandidateCvModel
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
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }
        public string Cv { get; set; }
    }
}
