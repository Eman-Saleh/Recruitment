using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class Gender
    {
        public Gender()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
