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
    public class UserJobController : ControllerBase
    {
        private IUserJobRepository userJobRepository;
        private IUserRepository userRepository;
        private IJobRepository jobRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public UserJobController(JobFinderContext jobFinderContext)
        {
            this.userJobRepository = new UserJobRepository(new JobFinderContext());
            this.userRepository = new UserRepository(new JobFinderContext());
            this.jobRepository = new JobRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<UserJob> Get(int userID, int jobID)
        {
            if(userID == 0 && jobID == 0)
            {
                IEnumerable<UserJob> userJobs = userJobRepository.GetUserJobs();
                if (userJobs != null)
                {
                    foreach(UserJob userJob in userJobs)
                    {
                        userJob.User = userRepository.GetUserByID((int)userJob.UserId);
                        userJob.Job = jobRepository.GetJobByID((int)userJob.JobId);
                    }
                    return userJobs;
                }
            }
            else if(userID !=0 && jobID == 0)
            {
                IEnumerable<UserJob> userJobs = userJobRepository.GetUserJobs()
                .Where(s => s.UserId.Equals(userID));
                if (userJobs != null)
                {
                    foreach (UserJob userJob in userJobs)
                    {
                        userJob.User = userRepository.GetUserByID((int)userJob.UserId);
                        userJob.Job = jobRepository.GetJobByID((int)userJob.JobId);
                    }
                    return userJobs;
                }
            }else if(userID == 0 && jobID != 0)
            {
                IEnumerable<UserJob> userJobs = userJobRepository.GetUserJobs()
                .Where(s => s.JobId.Equals(jobID));
                if (userJobs != null)
                {
                    foreach (UserJob userJob in userJobs)
                    {
                        userJob.User = userRepository.GetUserByID((int)userJob.UserId);
                        userJob.Job = jobRepository.GetJobByID((int)userJob.JobId);
                    }
                    return userJobs;
                }
            }
            else
            {
                IEnumerable<UserJob> userJobs = userJobRepository.GetUserJobs()
                .Where(s => s.UserId.Equals(userID))
                .Where(s => s.JobId.Equals(jobID));
                if (userJobs != null)
                {
                    foreach (UserJob userJob in userJobs)
                    {
                        userJob.User = userRepository.GetUserByID((int)userJob.UserId);
                        userJob.Job = jobRepository.GetJobByID((int)userJob.JobId);
                    }
                    return userJobs;
                }
            }
            

            return null;
        }

        [HttpGet(template: "find/{id}")]
        public UserJob Get(int id)
        {
            UserJob userJob = userJobRepository.GetUserJobByID(id);
            if (userJob != null)
            {
                userJob.User = userRepository.GetUserByID((int)userJob.UserId);
                userJob.Job = jobRepository.GetJobByID((int)userJob.JobId);
                return userJob;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] UserJob company)
        {
            try
            {
                userJobRepository.InsertUserJob(company);
                userJobRepository.Save();
            }
            catch (Exception e)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<UserJobController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] UserJob company)
        {
            try
            {
                userJobRepository.UpdateUserJob(company);
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
            UserJob findUserJob = userJobRepository.GetUserJobByID(id);
            if (findUserJob != null)
            {
                userJobRepository.DeleteUserJob(id);
                userJobRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
