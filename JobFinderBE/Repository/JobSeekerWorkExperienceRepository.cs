using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class JobSeekerWorkExperienceRepository : IDisposable, IJobSeekerWorkExperienceRepository
    {
        private JobFinderContext context;
        public JobSeekerWorkExperienceRepository(JobFinderContext context)
        {
            this.context = context;
        }

        public void DeleteJobSeekerWorkExperience(int Id)
        {
            JobSeekerWorkExperience jobSeekerWorkExperience = context.JobSeekerWorkExperiences.Find(Id);
            context.JobSeekerWorkExperiences.Remove(jobSeekerWorkExperience);
        }
        private bool disposed = false;
        private JobFinderContext payrollSystemContext;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<JobSeekerWorkExperience> GetJobSeekerWorkExperiences()
        {
            return context.JobSeekerWorkExperiences.ToList();
        }

        public JobSeekerWorkExperience GetJobSeekerWorkExperienceByID(int Id)
        {
            return context.JobSeekerWorkExperiences.Find(Id);
        }

        public void InsertJobSeekerWorkExperience(JobSeekerWorkExperience jobSeekerWorkExperience)
        {
            context.JobSeekerWorkExperiences.Add(jobSeekerWorkExperience);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateJobSeekerWorkExperience(JobSeekerWorkExperience jobSeekerWorkExperience)
        {
            /*context.Entry(company).State = EntityState.Modified.;*/
            context.JobSeekerWorkExperiences.Update(jobSeekerWorkExperience);
            context.SaveChanges();
        }
    }
}
