using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class Salary
    {
        public Salary()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Range { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
