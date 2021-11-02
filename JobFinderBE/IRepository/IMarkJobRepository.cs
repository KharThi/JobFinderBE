using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface IMarkJobRepository : IDisposable
    {
        IEnumerable<MarkJob> GetMarkJobs();
        MarkJob GetMarkJobByID(int Id);
        void InsertMarkJob(MarkJob markJob);
        void DeleteMarkJob(int Id);
        void UpdateMarkJob(MarkJob markJob);
        void Save();
    }
}
