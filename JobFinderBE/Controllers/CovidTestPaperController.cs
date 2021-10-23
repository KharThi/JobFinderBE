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
    public class CovidTestPaperController : ControllerBase
    {
        private ICovidTestPaperRepository covidTestPaperRepository;
        private IUserRepository userRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public CovidTestPaperController(JobFinderContext jobFinderContext)
        {
            this.covidTestPaperRepository = new CovidTestPaperRepository(new JobFinderContext());
            this.userRepository = new UserRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<CovidTestPaper> Get(int userID)
        {
            if(userID != 0)
            {
                IEnumerable<CovidTestPaper> covidTestPapers = covidTestPaperRepository.GetCovidTestPapers()
                .Where(s => s.UserId.Equals(userID));
                if (covidTestPapers != null)
                {                  
                    return covidTestPapers;
                }
            }
            else
            {
                IEnumerable<CovidTestPaper> covidTestPapers = covidTestPaperRepository.GetCovidTestPapers();
                if (covidTestPapers != null)
                {
                    return covidTestPapers;
                }
            }
            
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public CovidTestPaper GetByID(int id)
        {
            CovidTestPaper covidTestPaper = covidTestPaperRepository.GetCovidTestPaperByID(id);
            if (covidTestPaper != null)
            {
                return covidTestPaper;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] CovidTestPaper company)
        {
            try
            {
                covidTestPaperRepository.InsertCovidTestPaper(company);
                covidTestPaperRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CovidTestPaperController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] CovidTestPaper company)
        {
            try
            {
                covidTestPaperRepository.UpdateCovidTestPaper(company);
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
            CovidTestPaper findCovidTestPaper = covidTestPaperRepository.GetCovidTestPaperByID(id);
            if (findCovidTestPaper != null)
            {
                covidTestPaperRepository.DeleteCovidTestPaper(id);
                covidTestPaperRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
