using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Interface
{
    public interface ISalaryRepository 
    {
        public List<SalaryModel> GetAllSalaries();
        public SalaryModel GetSalary(int id);
    }
}
