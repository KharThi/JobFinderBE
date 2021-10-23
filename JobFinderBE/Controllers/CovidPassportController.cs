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
    public class CovidPassportController : ControllerBase
    {
        private ICovidPassportRepository covidPassportRepository;
        private IUserRepository userRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public CovidPassportController(JobFinderContext jobFinderContext)
        {
            this.covidPassportRepository = new CovidPassportRepository(new JobFinderContext());
            this.userRepository = new UserRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<CovidPassport> Get(int level, int userID)
        {
            if(level == 0 && userID == 0)
            {
                IEnumerable<CovidPassport> covidPassports = covidPassportRepository.GetCovidPassports();
                if (covidPassports != null)
                {
                    foreach(CovidPassport covidPassport in covidPassports)
                    {
                        covidPassport.User = userRepository.GetUserByID((int)covidPassport.UserId);
                    }
                    return covidPassports;
                }
            }else if(level != 0 && userID == 0)
            {
                IEnumerable<CovidPassport> covidPassports = covidPassportRepository.GetCovidPassports()
                    .Where(s => s.Level.Equals(level));
                if (covidPassports != null)
                {
                    foreach (CovidPassport covidPassport in covidPassports)
                    {
                        covidPassport.User = userRepository.GetUserByID((int)covidPassport.UserId);
                    }
                    return covidPassports;
                }
            }else if(level == 0 && userID != 0)
            {
                IEnumerable<CovidPassport> covidPassports = covidPassportRepository.GetCovidPassports()
                    .Where(s => s.UserId.Equals(userID));
                if (covidPassports != null)
                {
                    foreach (CovidPassport covidPassport in covidPassports)
                    {
                        covidPassport.User = userRepository.GetUserByID((int)covidPassport.UserId);
                    }
                    return covidPassports;
                }
            }
            else
            {
                IEnumerable<CovidPassport> covidPassports = covidPassportRepository.GetCovidPassports()
                    .Where(s => s.UserId.Equals(userID))
                    .Where(s => s.Level.Equals(level));
                if (covidPassports != null)
                {
                    foreach (CovidPassport covidPassport in covidPassports)
                    {
                        covidPassport.User = userRepository.GetUserByID((int)covidPassport.UserId);
                    }
                    return covidPassports;
                }
            }
            
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public CovidPassport Get(int id)
        {
            CovidPassport covidPassport = covidPassportRepository.GetCovidPassportByID(id);
            if (covidPassport != null)
            {
                return covidPassport;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] CovidPassport company)
        {
            try
            {
                covidPassportRepository.InsertCovidPassport(company);
                covidPassportRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CovidPassportController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] CovidPassport company)
        {
            try
            {
                covidPassportRepository.UpdateCovidPassport(company);
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
            CovidPassport findCovidPassport = covidPassportRepository.GetCovidPassportByID(id);
            if (findCovidPassport != null)
            {
                covidPassportRepository.DeleteCovidPassport(id);
                covidPassportRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
