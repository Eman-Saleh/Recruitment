using System;
using System.Collections.Generic;

#nullable disable


namespace Recruitment.DataLayer
{
    public partial class Experience
    {
        public Experience()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string YearsOfExperience { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
