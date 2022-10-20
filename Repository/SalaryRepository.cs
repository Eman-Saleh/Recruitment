using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public class SalaryRepository :ISalaryRepository 
    {

        HRContext db = new HRContext();
        public List<SalaryModel> GetAllSalaries()
        {
            List<SalaryModel> salaries = new List<SalaryModel>();
            var mod = db.Salaries.ToList();
            foreach (var s in mod)
            {
                var v = new SalaryModel()
                {
                    Id = s.Id,
                    Range = s.Range
                };
                salaries.Add(v);
            }
            return salaries;
        }
        public SalaryModel GetSalary(int id)
        {
            var salary = db.Salaries .Find(id);
            var salaryModel = new SalaryModel()
            {
                Id = salary.Id,
                Range = salary.Range
            };
            return salaryModel;
        }
    }
}
