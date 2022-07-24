using SocialMediaApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApplication.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly socialfeeddbContext _context;
        public AdminController(IConfiguration configuration, socialfeeddbContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public IEnumerable<User> getUser(int? id)
        {
            var user = _context.Users.Where(e => e.UserId == id);
            return (user);
        }
        [HttpPut]
        [Route("updateUser/{userId}")]
        public string updateUser(int userId, [FromBody] User user)
        {
            try
            {
                var updateData = _context.Users.Where(e => e.UserId == userId).SingleOrDefault();
                updateData.Email = user.Email;
                updateData.UserName = user.UserName;
                _context.SaveChanges();
                return "User " + updateData.UserId + " has been updated";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }
        [HttpDelete]
        [Route("deleteUser/{userId}")]
        public string deleteUser(int? userId)
        {
            try
            {
                var user = _context.Users.Where(e => e.UserId == userId).SingleOrDefault();
                _context.Users.Remove(user);
                _context.SaveChanges();
                return "User Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Exception occurred: " + ex;
            }
        }
    }
}