using CRUD.Data;
using CRUD.DTOs;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly AppDbContext _appDbContext;

        public AuthController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthrequestDto request)
        {
            if (await _appDbContext.login.AnyAsync(u => u.Email == request.Email))
            {
                return BadRequest("Email already in use");
            }

            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _appDbContext.login.Add(newUser);
            await _appDbContext.SaveChangesAsync();

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _appDbContext.login.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return Unauthorized("Invalid email or password");
            }

            var tokenPlaceHolder = Guid.NewGuid().ToString(); // Simulate token generation

            return Ok(new {Token = tokenPlaceHolder, Message = "Login successfully"});
        }
    }
}