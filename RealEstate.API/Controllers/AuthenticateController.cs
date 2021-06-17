using Entities.Models;
using IdentityLibrary;
using IdentityLibrary.API_Requests;
using IdentityLibrary.Authentication;
using IdentityLibrary.Models;
using IdentityLibrary.Roles;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RealEstate.API.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserManagerRepository _userRepository;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateController(
            UserManager<ApplicationUser> userManager,
            IUserManagerRepository userRepository,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILoggerManager logger,
            ApplicationDbContext dbContext,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this._userRepository = userRepository;
            this.roleManager = roleManager;
            _configuration = configuration;
            this._logger = logger;
            this._dbContext = dbContext;
            this._signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Password & ConfirmPassowrd must match");
            }

            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            User userReflection = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Password = model.Password,
                UserId = user.Id
            };

            _userRepository.UserRepository.CreateUser(userReflection);
            _userRepository.Save();

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error($"Invalid modelstate of: {ModelState}");
                return UnprocessableEntity(ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Password & ConfirmPassowrd must match");
            }

            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            User userReflection = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Password = model.Password,
                UserId = user.Id,
            };

            

            _userRepository.UserRepository.CreateUser(userReflection);
            _userRepository.Save();

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
           
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<ActionResult> GetToken([FromForm] LoginModel loginModel, string grant_type)
        {
            if (!ModelState.IsValid)
            {
                _logger.Error("LoginModel returned from client is null.");
                return UnprocessableEntity(ModelState);
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == loginModel.Username);
            if (user == null)
            {
                return BadRequest("Login failed, user doesnt exist or invalid form.");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if (!signInResult.Succeeded)
            {
                return BadRequest("Sign in failed. Please try again.");
            }

            var tokenHelper = new TokenDtoHelper(_configuration);
            var token = tokenHelper.Helper(loginModel.Username);
            var tokenAsJson = JsonConvert.SerializeObject(token);

            return Ok(tokenAsJson);
        }
    }
}
