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
    public class JobSeekerEducationController : ControllerBase
    {
        private IJobSeekerEducationRepository jobSeekerEducationRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public JobSeekerEducationController(JobFinderContext jobFinderContext)
        {
            this.jobSeekerEducationRepository = new JobSeekerEducationRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<JobSeekerEducation> Get(int userID)
        {
            if(userID != 0)
            {
                IEnumerable<JobSeekerEducation> jobSeekerEducations = jobSeekerEducationRepository.GetJobSeekerEducations()
                .Where(s => s.UserId.Equals(userID));
                if (jobSeekerEducations != null)
                {
                    return jobSeekerEducations;
                }
            }
            else
            {
                IEnumerable<JobSeekerEducation> jobSeekerEducations = jobSeekerEducationRepository.GetJobSeekerEducations();
                if (jobSeekerEducations != null)
                {
                    return jobSeekerEducations;
                }
            }
            
            
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public JobSeekerEducation GetByID(int id)
        {
            JobSeekerEducation jobSeekerEducation = jobSeekerEducationRepository.GetJobSeekerEducationByID(id);
            if (jobSeekerEducation != null)
            {
                return jobSeekerEducation;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] JobSeekerEducation company)
        {
            try
            {
                jobSeekerEducationRepository.InsertJobSeekerEducation(company);
                jobSeekerEducationRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<JobSeekerEducationController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] JobSeekerEducation company)
        {
            try
            {
                jobSeekerEducationRepository.UpdateJobSeekerEducation(company);
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
            JobSeekerEducation findJobSeekerEducation = jobSeekerEducationRepository.GetJobSeekerEducationByID(id);
            if (findJobSeekerEducation != null)
            {
                jobSeekerEducationRepository.DeleteJobSeekerEducation(id);
                jobSeekerEducationRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
