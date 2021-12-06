using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Recipe_book_api.Models;
using Recipe_book_api.Entities;
using Recipe_book_api.Services;

namespace Recipe_book_api.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService repo;

        public RecipeController(IRecipeService repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var recipes = repo.GetAll();

            var results = new List<RecipeModel>();

            foreach (var recipe in recipes)
            {
                results.Add(new RecipeModel
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    UserId = recipe.UserId
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetRecipe")]
        public IActionResult GetRecipe(int id)
        {
            var recipe = repo.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            var results = new RecipeModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                UserId = recipe.UserId
            };

            return Ok(results);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUsersRecipes(int userId)
        {
            if (!repo.UserExist(userId))
            {
                return NotFound();
            }

            var recipes = repo.GetUserRecipes(userId);
            var results = new List<RecipeModel>();

            foreach (var recipe in recipes)
            {
                results.Add(new RecipeModel
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    UserId = recipe.UserId
                });
            }

            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddRecipe(RecipeModel recipe)
        {
            if (repo.RecipeExist(recipe.Id))
            {
                return Conflict();
            }

            Recipe newRecipe = new Recipe
            {
                Name = recipe.Name,
                UserId = recipe.UserId
            };

            repo.AddRecipe(newRecipe);
            repo.Save();

            RecipeModel finalRecipe = new RecipeModel
            {
                Id = newRecipe.Id,
                Name = newRecipe.Name,
                UserId = newRecipe.UserId
            };

            return CreatedAtRoute("GetRecipe", new { id = finalRecipe.Id }, finalRecipe);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, RecipeModel recipe)
        {
            var recipeEntity = repo.Get(id);
            if (recipeEntity == null)
            {
                return NotFound();
            }

            recipeEntity.Name = recipe.Name;
            recipeEntity.UserId = recipe.UserId;

            repo.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipeEntity = repo.Get(id);
            if (recipeEntity == null)
            {
                return NotFound();
            }

            repo.Delete(recipeEntity);
            repo.Save();

            return NoContent();
        }
    }
}
