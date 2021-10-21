using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class JobRepository : IDisposable, IJobRepository
    {
        private JobFinderContext context;
        public JobRepository(JobFinderContext context)
        {
            this.context = context;
        }

        public void DeleteJob(int Id)
        {
            Job job = context.Jobs.Find(Id);
            context.Jobs.Remove(job);
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

        public IEnumerable<Job> GetJobs()
        {
            return context.Jobs.ToList();
        }

        public Job GetJobByID(int Id)
        {
            return context.Jobs.Find(Id);
        }

        public void InsertJob(Job job)
        {
            context.Jobs.Add(job);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateJob(Job job)
        {
            context.Jobs.Update(job);
            context.SaveChanges();
        }
    }
}
