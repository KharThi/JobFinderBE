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
    public class JobSeekerWorkExperienceController : ControllerBase
    {
        private IJobSeekerWorkExperienceRepository jobSeekerWorkExperienceRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public JobSeekerWorkExperienceController(JobFinderContext jobFinderContext)
        {
            this.jobSeekerWorkExperienceRepository = new JobSeekerWorkExperienceRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<JobSeekerWorkExperience> Get(int userID)
        {
            if(userID != 0)
            {
                IEnumerable<JobSeekerWorkExperience> jobSeekerWorkExperiences = jobSeekerWorkExperienceRepository.GetJobSeekerWorkExperiences()
                .Where(s => s.UserId.Equals(userID));
                if (jobSeekerWorkExperiences != null)
                {
                    return jobSeekerWorkExperiences;
                }
            }
            else
            {
                IEnumerable<JobSeekerWorkExperience> jobSeekerWorkExperiences = jobSeekerWorkExperienceRepository.GetJobSeekerWorkExperiences();
                if (jobSeekerWorkExperiences != null)
                {
                    return jobSeekerWorkExperiences;
                }
            }

            return null;
        }

        [HttpGet(template: "find/{id}")]
        public JobSeekerWorkExperience GetByID(int id)
        {
            JobSeekerWorkExperience jobSeekerWorkExperience = jobSeekerWorkExperienceRepository.GetJobSeekerWorkExperienceByID(id);
            if (jobSeekerWorkExperience != null)
            {
                return jobSeekerWorkExperience;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] JobSeekerWorkExperience company)
        {
            try
            {
                jobSeekerWorkExperienceRepository.InsertJobSeekerWorkExperience(company);
                jobSeekerWorkExperienceRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<JobSeekerWorkExperienceController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] JobSeekerWorkExperience company)
        {
            try
            {
                jobSeekerWorkExperienceRepository.UpdateJobSeekerWorkExperience(company);
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
            JobSeekerWorkExperience findJobSeekerWorkExperience = jobSeekerWorkExperienceRepository.GetJobSeekerWorkExperienceByID(id);
            if (findJobSeekerWorkExperience != null)
            {
                jobSeekerWorkExperienceRepository.DeleteJobSeekerWorkExperience(id);
                jobSeekerWorkExperienceRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
