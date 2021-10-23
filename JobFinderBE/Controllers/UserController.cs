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
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private readonly JobFinderContext _jobFinderDBCotext;
        public UserController(JobFinderContext jobFinderContext)
        {
            this.userRepository = new UserRepository(new JobFinderContext());
            _jobFinderDBCotext = jobFinderContext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<User> Get(string name)
        {
            if (name == null) name = "";
            IEnumerable<User> users = userRepository.GetUsers()
                .Where(s => s.Fullname.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (users != null)
            {
                return users;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public User Get(int id)
        {
            User user = userRepository.GetUserByID(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        [HttpGet(template: "login")]
        public String Get(String username, String password)
        {
            IEnumerable<User> users = userRepository.GetUsers();
            foreach(User user in users)
            {

                if (user.UserName.Equals(username) && user.Password.Equals(password))
                {
                    return "Login Success";
                }
            }

            return "Worng UserName Or Password";
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] User company)
        {
            try
            {
                userRepository.InsertUser(company);
                userRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<UserController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] User company)
        {
            try
            {
                userRepository.UpdateUser(company);
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
            User findUser = userRepository.GetUserByID(id);
            if (findUser != null)
            {
                userRepository.DeleteUser(id);
                userRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
