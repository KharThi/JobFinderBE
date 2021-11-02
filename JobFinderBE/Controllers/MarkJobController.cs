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
    public class MarkJobController : ControllerBase
    {
        private IMarkJobRepository markJobRepository;
        private IUserRepository userRepository;
        private IJobRepository jobRepository;
        private ICompanyRepository companyRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public MarkJobController(JobFinderContext jobFinderContext)
        {
            this.markJobRepository = new MarkJobRepository(new JobFinderContext());
            this.userRepository = new UserRepository(new JobFinderContext());
            this.jobRepository = new JobRepository(new JobFinderContext());
            this.companyRepository = new CompanyRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<MarkJob> Get(int userID, int jobID)
        {
            if(userID ==0 && jobID == 0)
            {
                IEnumerable<MarkJob> markJobs = markJobRepository.GetMarkJobs();
                if (markJobs != null)
                {
                    foreach( MarkJob markJob in markJobs)
                    {
                        markJob.User = userRepository.GetUserByID((int)markJob.UserId);
                        markJob.Job = jobRepository.GetJobByID((int)markJob.JobId);
                        if(markJob.Job != null)
                        {
                            markJob.Job.Company = companyRepository.GetCompanyByID((int)markJob.Job.CompanyId);
                        }
                    }
                    return markJobs;
                }
            }else if(userID != 0 && jobID == 0)
            {
                IEnumerable<MarkJob> markJobs = markJobRepository.GetMarkJobs()
                    .Where(s =>s.UserId.Equals(userID));
                if (markJobs != null)
                {
                    foreach (MarkJob markJob in markJobs)
                    {
                        markJob.User = userRepository.GetUserByID((int)markJob.UserId);
                        markJob.Job = jobRepository.GetJobByID((int)markJob.JobId);
                        if (markJob.Job != null)
                        {
                            markJob.Job.Company = companyRepository.GetCompanyByID((int)markJob.Job.CompanyId);
                        }
                    }
                    return markJobs;
                }
            }else if(userID ==0 & jobID != 0)
            {
                IEnumerable<MarkJob> markJobs = markJobRepository.GetMarkJobs()
                                    .Where(s => s.JobId.Equals(jobID));
                if (markJobs != null)
                {
                    foreach (MarkJob markJob in markJobs)
                    {
                        markJob.User = userRepository.GetUserByID((int)markJob.UserId);
                        markJob.Job = jobRepository.GetJobByID((int)markJob.JobId);
                        if (markJob.Job != null)
                        {
                            markJob.Job.Company = companyRepository.GetCompanyByID((int)markJob.Job.CompanyId);
                        }
                    }
                    return markJobs;
                }
            }
            else
            {
                IEnumerable<MarkJob> markJobs = markJobRepository.GetMarkJobs()
                                    .Where(s => s.JobId.Equals(jobID))
                                    .Where(s => s.UserId.Equals(userID));
                if (markJobs != null)
                {
                    foreach (MarkJob markJob in markJobs)
                    {
                        markJob.User = userRepository.GetUserByID((int)markJob.UserId);
                        markJob.Job = jobRepository.GetJobByID((int)markJob.JobId);
                        if (markJob.Job != null)
                        {
                            markJob.Job.Company = companyRepository.GetCompanyByID((int)markJob.Job.CompanyId);
                        }
                    }
                    return markJobs;
                }
            }

            return null;
        }

        [HttpGet(template: "find/{id}")]
        public MarkJob Get(int id)
        {
            MarkJob markJob = markJobRepository.GetMarkJobByID(id);
            if (markJob != null)
            {
                markJob.User = userRepository.GetUserByID((int)markJob.UserId);
                markJob.Job = jobRepository.GetJobByID((int)markJob.JobId);
                if (markJob.Job != null)
                {
                    markJob.Job.Company = companyRepository.GetCompanyByID((int)markJob.Job.CompanyId);
                }
                return markJob;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] MarkJob company)
        {
            try
            {
                markJobRepository.InsertMarkJob(company);
                markJobRepository.Save();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "Add Success";
        }

        // PUT api/<MarkJobController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] MarkJob company)
        {
            try
            {
                markJobRepository.UpdateMarkJob(company);
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
            MarkJob findMarkJob = markJobRepository.GetMarkJobByID(id);
            if (findMarkJob != null)
            {
                markJobRepository.DeleteMarkJob(id);
                markJobRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
