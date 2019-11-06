using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Theory.Model;

namespace Theory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly TheoryContext _context;


        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TheoryContext contex)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = contex;

        }

        [HttpGet]
        [Route("Users")]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.ApplicationUsers;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register

        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {

            model.Roles = "Student";
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                matric = model.Matric
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Roles);

                return Ok(result);
            }
            catch(Exception ex)
            {

                throw ex;

            }

        }

        [HttpPost]
        [Route("Login")]
        //Post : /api/ApplicationUser/Login

        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user !=null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                //Get roles assigned
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0123456789012345")), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });

            }
            else
                return BadRequest(new { message = "Matric Number or Password is incorrect." });


        }
    }
}