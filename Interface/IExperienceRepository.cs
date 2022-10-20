using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Interface
{
    public interface IExperienceRepository 
    {
        List<ExperienceModel> GetAllExperiencies();
        ExperienceModel GetExperience(int id);
    }
}
