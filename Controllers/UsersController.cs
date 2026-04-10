using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _appDbContext.login.ToListAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = await _appDbContext.login.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }
            
            _appDbContext.Entry(existingUser).CurrentValues.SetValues(updatedUser);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, existingUser);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteUser(int id)
        {
            var user = await _appDbContext.login.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            _appDbContext.login.Remove(user);

            await _appDbContext.SaveChangesAsync();

            return Ok("User deleted successfully");
        }
    }
}