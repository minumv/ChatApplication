using ChatApplication.Data;
using ChatApplication.DTOs;
using ChatApplication.Entities;
using ChatApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public AuthenticateController(IAuthenticationService authenticationService, ApplicationDbContext dbContext)
        {
            _authenticationService = authenticationService;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.Login(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authenticationService.Register(request);


            //var customer = new Customer
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "null",
            //    Email = request.Email,
            //    MobileNo = "null",
            //    Address = "null",
            //    Username = request.Username,

            //};

            //await _dbContext.Customers.AddAsync(customer);
            //await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Customer Registered successfully" });



        }
    }
}
