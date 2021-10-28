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
    public class JobController : ControllerBase
    {
        private IJobRepository jobRepository;
        private ICompanyRepository companyRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public JobController(JobFinderContext jobFinderContext)
        {
            this.jobRepository = new JobRepository(new JobFinderContext());
            this.companyRepository = new CompanyRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<Job> Get(string name)
        {
            if (name == null) name = "";
            IEnumerable<Job> jobs = jobRepository.GetJobs()
                .Where(s => s.JobName.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (jobs != null)
            {
                foreach(Job job in jobs)
                {
                    job.Company = companyRepository.GetCompanyByID((int)job.CompanyId);
                }
                return jobs;
            }
            return null;
        }

        [HttpGet(template: "getall")]
        public IEnumerable<Job> GetAll()
        {
            IEnumerable<Job> jobs = jobRepository.GetJobs();
            if (jobs != null)
            {
                foreach (Job job in jobs)
                {
                    job.Company = companyRepository.GetCompanyByID((int)job.CompanyId);
                }
                return jobs;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public Job Get(int id)
        {
            Job job = jobRepository.GetJobByID(id);
            if (job != null)
            {
                return job;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] Job company)
        {
            try
            {
                jobRepository.InsertJob(company);
                jobRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<JobController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] Job company)
        {
            try
            {
                jobRepository.UpdateJob(company);
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
            Job findJob = jobRepository.GetJobByID(id);
            if (findJob != null)
            {
                jobRepository.DeleteJob(id);
                jobRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
