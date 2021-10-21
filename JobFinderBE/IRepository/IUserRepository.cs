using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int Id);
        void InsertUser(User user);
        void DeleteUser(int Id);
        void UpdateUser(User user);
        void Save();
    }
}
