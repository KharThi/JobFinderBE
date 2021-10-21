using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface IUserJobRepository : IDisposable
    {
        IEnumerable<UserJob> GetUserJobs();
        UserJob GetUserJobByID(int Id);
        void InsertUserJob(UserJob userJob);
        void DeleteUserJob(int Id);
        void UpdateUserJob(UserJob userJob);
        void Save();
    }
}
