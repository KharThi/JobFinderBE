using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class UserRepository:IDisposable, IUserRepository
    {
        private JobFinderContext context;
        public UserRepository(JobFinderContext _context)
        {
            this.context = _context;
        }

        public void DeleteUser(int Id)
        {
            User user = context.Users.Find(Id);
            context.Users.Remove(user);
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

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int Id)
        {
            return context.Users.Find(Id);
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
