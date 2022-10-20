using Recruitment.Models;
using System.Collections.Generic;

namespace Recruitment.Interface
{
    public interface IJobTitleRepository
    { 
        List<JobTitleModel> GetAllJobTitles();
        List<JobTitleModel> GetJobTitleByCategory(int Categoryid);
    }
}
