using JobFinderBE.IRepository;
using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.Repository
{
    public class CovidTestPaperRepository : IDisposable, ICovidTestPaperRepository
    {
        private JobFinderContext context;
        public CovidTestPaperRepository(JobFinderContext context)
        {
            this.context = context;
        }

        public void DeleteCovidTestPaper(int Id)
        {
            CovidTestPaper covidTestPaper = context.CovidTestPapers.Find(Id);
            context.CovidTestPapers.Remove(covidTestPaper);
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

        public IEnumerable<CovidTestPaper> GetCovidTestPapers()
        {
            return context.CovidTestPapers.ToList();
        }

        public CovidTestPaper GetCovidTestPaperByID(int Id)
        {
            return context.CovidTestPapers.Find(Id);
        }

        public void InsertCovidTestPaper(CovidTestPaper covidTestPaper)
        {
            context.CovidTestPapers.Add(covidTestPaper);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCovidTestPaper(CovidTestPaper covidTestPaper)
        {
            /*context.Entry(company).State = EntityState.Modified.;*/
            context.CovidTestPapers.Update(covidTestPaper);
            context.SaveChanges();
        }
    }
}
