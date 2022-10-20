using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.Models
{
    public partial class VacancyDescriptionModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int VacancyId { get; set; }

        public VacancyModel Vacancy { get; set; }
    }
}
