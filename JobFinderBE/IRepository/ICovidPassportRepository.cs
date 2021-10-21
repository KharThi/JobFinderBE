using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface ICovidPassportRepository : IDisposable
    {
        IEnumerable<CovidPassport> GetCovidPassports();
        CovidPassport GetCovidPassportByID(int Id);
        void InsertCovidPassport(CovidPassport covidPassport);
        void DeleteCovidPassport(int Id);
        void UpdateCovidPassport(CovidPassport covidPassport);
        void Save();
    }
}
