using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface ICovidTestPaperRepository : IDisposable
    {
        IEnumerable<CovidTestPaper> GetCovidTestPapers();
        CovidTestPaper GetCovidTestPaperByID(int Id);
        void InsertCovidTestPaper(CovidTestPaper covidTestPaper);
        void DeleteCovidTestPaper(int Id);
        void UpdateCovidTestPaper(CovidTestPaper covidTestPaper);
        void Save();
    }
}
