using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class UserJobRepository : IDisposable, IUserJobRepository
    {
        private JobFinderContext context;
        public UserJobRepository(JobFinderContext context)
        {
            this.context = context;
        }

        public void DeleteUserJob(int Id)
        {
            UserJob userJob = context.UserJobs.Find(Id);
            context.UserJobs.Remove(userJob);
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

        public IEnumerable<UserJob> GetUserJobs()
        {
            return context.UserJobs.ToList();
        }

        public UserJob GetUserJobByID(int Id)
        {
            return context.UserJobs.Find(Id);
        }

        public void InsertUserJob(UserJob userJob)
        {
            context.UserJobs.Add(userJob);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUserJob(UserJob userJob)
        {
            context.UserJobs.Update(userJob);
            context.SaveChanges();
        }
    }
}
