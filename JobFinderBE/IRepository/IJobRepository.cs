using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface IJobRepository: IDisposable
    {
        IEnumerable<Job> GetJobs();
        Job GetJobByID(int Id);
        void InsertJob(Job job);
        void DeleteJob(int Id);
        void UpdateJob(Job job);
        void Save();
    }
}
