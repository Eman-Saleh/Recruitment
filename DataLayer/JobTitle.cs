using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
