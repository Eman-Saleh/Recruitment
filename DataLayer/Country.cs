﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class Country
    {
        public Country()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
