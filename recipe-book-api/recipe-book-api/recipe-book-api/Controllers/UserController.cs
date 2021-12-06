using Microsoft.AspNetCore.Mvc;
using Recipe_book_api.Models;
using Recipe_book_api.Entities;
using Recipe_book_api.Services;

namespace Recipe_book_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService repo;

        public UserController(IUserService repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = repo.Get(id);

            if (user == null)
            {
                return NotFound();
            }
            var results = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };

            return Ok(results);
        }

        [HttpGet("name/{userName}", Name = "GetUserByName")]
        public IActionResult GetUserByName(string userName)
        {
            var user = repo.GetUserByName(userName);

            if (user == null)
            {
                return NotFound();
            }
            var results = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };

            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel user)
        {
            if (repo.GetUserByName(user.Name) != null)
            {
                return Conflict();
            }

            User newUser = new User
            {
                Name = user.Name,
                Password = user.Password
            };

            repo.AddUser(newUser);
            repo.Save();

            UserModel finalUser = new UserModel
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Password = newUser.Password
            };

            return CreatedAtRoute("GetUser", new { id = finalUser.Id }, finalUser);
        }
    }
}
