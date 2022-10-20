using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class VacancyQualification
    {
        public int Id { get; set; }
        public string Qualification { get; set; }
        public int VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }
    }
}
