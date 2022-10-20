using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class VacancyDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }
    }
}
