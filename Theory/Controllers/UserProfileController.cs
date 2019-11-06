using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theory.Model;

namespace Theory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }

        [HttpGet]
        [Authorize]
        //GET: /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                user.UserName,
                user.matric,
                user.Id
            };
        }


        [HttpGet]
        [Authorize(Roles="Lecturer")]
        [Route("ForLecturer")]
        public string GetForLecturer()
        {
            return "Web for Lecturer";
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        [Route("ForStudent")]
        public string GetForStudent()
        {
            return "Web for Student";
        }

        [HttpGet]
        [Authorize(Roles = "Lecturer, Student")]
        [Route("ForLecturerOrStudent")]
        public string GetForLecturerOrStudent()
        {
            return "Web for Lecturer or Student";
        }


    }
}