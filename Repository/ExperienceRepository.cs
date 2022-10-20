using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        HRContext db = new HRContext();

        public List<ExperienceModel> GetAllExperiencies()
        {
            List<ExperienceModel> _Experiencies = new List<ExperienceModel>();
            var mod = db.Experiences.ToList(); 
                foreach (var s in mod)
                {
                    var v = new ExperienceModel()
                    {
                        Id = s.Id,
                        YearsOfExperience=s.YearsOfExperience
                    };
                    _Experiencies.Add(v);
                }
                return _Experiencies;
        }

        public ExperienceModel GetExperience(int id)
        {
            var Experience = db.Experiences.Find (id);
            var ExperienceModel = new ExperienceModel()
            {
                Id = Experience.Id,
                YearsOfExperience = Experience.YearsOfExperience
            };
            return ExperienceModel;
        }

    }
}
