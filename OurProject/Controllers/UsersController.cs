using Microsoft.AspNetCore.Mvc;
using OurProject.Data;
using MongoDB.Driver;
using OurProject.Data.Models;

namespace OurProject.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UsersController : ControllerBase
    {
        private readonly MongoDBContext Context;

        public UsersController(MongoDBContext context)
        {
            Context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await Context.Users.Find(_ => true).ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await Context.Users.InsertOneAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
