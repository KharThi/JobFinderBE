using JobFinderBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinderBE.IRepository
{
    public interface ICompanyRepository : IDisposable
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompanyByID(int Id);
        void InsertCompany(Company company);
        void DeleteCompany(int Id);
        void UpdateCompany(Company company);
        void Save();
    }
}