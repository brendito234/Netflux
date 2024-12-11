using Microsoft.AspNetCore.Mvc;
using OurProject.Data;
using MongoDB.Driver;
using OurProject.Data.Models;

namespace OurProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly MongoDBContext Context;
        private readonly IMongoCollection<User> Users;
        public UsersController(MongoDBContext context)
        {
            Context = context;
            Users = context.Database.GetCollection<User>("user");
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await Users.Find(_ => true).ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await Users.InsertOneAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
