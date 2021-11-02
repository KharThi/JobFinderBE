using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class MarkJobRepository : IDisposable, IMarkJobRepository
    {
        private JobFinderContext context;
        public MarkJobRepository(JobFinderContext _context)
        {
            this.context = _context;
        }

        public void DeleteMarkJob(int Id)
        {
            MarkJob markJob = context.MarkJobs.Find(Id);
            context.MarkJobs.Remove(markJob);
        }
        private bool disposed = false;

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

        public IEnumerable<MarkJob> GetMarkJobs()
        {
            return context.MarkJobs.ToList();
        }

        public MarkJob GetMarkJobByID(int Id)
        {
            return context.MarkJobs.Find(Id);
        }

        public void InsertMarkJob(MarkJob markJob)
        {
            context.MarkJobs.Add(markJob);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMarkJob(MarkJob markJob)
        {
            context.MarkJobs.Update(markJob);
            context.SaveChanges();
        }
    }
}
