using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public class JobTitleRepository : IJobTitleRepository
    {
        HRContext db = new HRContext();


        public List<JobTitleModel> GetAllJobTitles()
        {
            List<JobTitleModel> _JobTitles= new List<JobTitleModel>();
            var mod = db.JobTitles.ToList();
            foreach (var s in mod)
            {
                var v = new JobTitleModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    CategoryId=s.CategoryId
                };
                _JobTitles.Add(v);
            }
            return _JobTitles;
        }
        public List<JobTitleModel> GetJobTitleByCategory(int Categoryid)
        {
            List<JobTitleModel> _JobTitles = new List<JobTitleModel>();
            var mod = db.JobTitles.Where (a=>a.CategoryId ==Categoryid ).ToList();
            foreach (var s in mod)
            {
                var v = new JobTitleModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    CategoryId = s.CategoryId
                };
                _JobTitles.Add(v);
            }
            return _JobTitles;
        }
    }
    
}
