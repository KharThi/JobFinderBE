using JobFinderBE.IRepository;
using JobFinderBE.Models;
using JobFinderBE.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobFinderBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyRepository companyRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public CompanyController(JobFinderContext jobFinderContext)
        {
            this.companyRepository = new CompanyRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<Company> Get(string name)
        {
            if (name == null) name = "";
            IEnumerable<Company> companys = companyRepository.GetCompanies()
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (companys != null)
            {
                return companys;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public Company Get(int id)
        {
            Company company = companyRepository.GetCompanyByID(id);
            if (company != null)
            {
                return company;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] Company company)
        {
            try
            {
                companyRepository.InsertCompany(company);
                companyRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] Company company)
        {
            try
            {
                companyRepository.UpdateCompany(company);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpDelete(template: "delete/{id}")]
        public String Delete(int id)
        {
            Company findCompany = companyRepository.GetCompanyByID(id);
            if (findCompany != null)
            {
                companyRepository.DeleteCompany(id);
                companyRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
