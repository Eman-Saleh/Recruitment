using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class Category
    {
        public Category()
        {
            JobTitles = new HashSet<JobTitle>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobTitle> JobTitles { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
