using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class CovidPassportRepository : IDisposable, ICovidPassportRepository
    {
        private JobFinderContext context;
        public CovidPassportRepository(JobFinderContext context)
        {
            this.context = context;
        }

        public void DeleteCovidPassport(int Id)
        {
            CovidPassport covidPassport = context.CovidPassports.Find(Id);
            context.CovidPassports.Remove(covidPassport);
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

        public IEnumerable<CovidPassport> GetCovidPassports()
        {
            return context.CovidPassports.ToList();
        }

        public CovidPassport GetCovidPassportByID(int Id)
        {
            return context.CovidPassports.Find(Id);
        }

        public void InsertCovidPassport(CovidPassport covidPassport)
        {
            context.CovidPassports.Add(covidPassport);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCovidPassport(CovidPassport covidPassport)
        {
            /*context.Entry(company).State = EntityState.Modified.;*/
            context.CovidPassports.Update(covidPassport);
            context.SaveChanges();
        }
    }
}
