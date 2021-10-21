using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface IJobSeekerWorkExperienceRepository : IDisposable
    {
        IEnumerable<JobSeekerWorkExperience> GetJobSeekerWorkExperiences();
        JobSeekerWorkExperience GetJobSeekerWorkExperienceByID(int Id);
        void InsertJobSeekerWorkExperience(JobSeekerWorkExperience jobSeekerWorkExperience);
        void DeleteJobSeekerWorkExperience(int Id);
        void UpdateJobSeekerWorkExperience(JobSeekerWorkExperience jobSeekerWorkExperience);
        void Save();
    }
}
