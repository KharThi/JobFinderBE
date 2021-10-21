using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class JobSeekerEducationRepository : IDisposable, IJobSeekerEducationRepository
    {
        private JobFinderContext context;
        public JobSeekerEducationRepository(JobFinderContext context)
        {
            this.context = context;
        }

        public void DeleteJobSeekerEducation(int Id)
        {
            JobSeekerEducation jobSeekerEducation = context.JobSeekerEducations.Find(Id);
            context.JobSeekerEducations.Remove(jobSeekerEducation);
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

        public IEnumerable<JobSeekerEducation> GetJobSeekerEducations()
        {
            return context.JobSeekerEducations.ToList();
        }

        public JobSeekerEducation GetJobSeekerEducationByID(int Id)
        {
            return context.JobSeekerEducations.Find(Id);
        }

        public void InsertJobSeekerEducation(JobSeekerEducation jobSeekerEducation)
        {
            context.JobSeekerEducations.Add(jobSeekerEducation);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateJobSeekerEducation(JobSeekerEducation jobSeekerEducation)
        {
            /*context.Entry(company).State = EntityState.Modified.;*/
            context.JobSeekerEducations.Update(jobSeekerEducation);
            context.SaveChanges();
        }
    }
}
