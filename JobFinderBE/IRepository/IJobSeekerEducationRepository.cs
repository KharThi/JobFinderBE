using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface IJobSeekerEducationRepository : IDisposable
    {
        IEnumerable<JobSeekerEducation> GetJobSeekerEducations();
        JobSeekerEducation GetJobSeekerEducationByID(int Id);
        void InsertJobSeekerEducation(JobSeekerEducation jobSeekerEducation);
        void DeleteJobSeekerEducation(int Id);
        void UpdateJobSeekerEducation(JobSeekerEducation jobSeekerEducation);
        void Save();
    }
}
