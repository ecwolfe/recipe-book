using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Recipe_book_api.Models;
using Recipe_book_api.Entities;
using Recipe_book_api.Services;

namespace Recipe_book_api.Controllers
{ 
    [ApiController]
    [Route("api/ingredient")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService repo;

        public IngredientsController(IIngredientService repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ingredients = repo.GetAll();

            var results = new List<IngredientModel>();

            foreach (var ingredient in ingredients)
            {
                results.Add(new IngredientModel
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    RecipeId = ingredient.RecipeId,
                    Obtained = ingredient.Obtained
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetIngredient")]
        public IActionResult GetIngredient(int id)
        {
            var ingredient = repo.Get(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            var results = new IngredientModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                RecipeId = ingredient.RecipeId,
                Obtained = ingredient.Obtained
            };

            return Ok(results);
        }

        [HttpGet("recipe/{recipeId}")]
        public IActionResult GetRecipeIngreds(int recipeId)
        {
            if (!repo.RecipeExist(recipeId))
            {
                return NotFound();
            }

            var ingredients = repo.GetRecipeIngredients(recipeId);
            var results = new List<IngredientModel>();

            foreach (var ingredient in ingredients)
            {
                results.Add(new IngredientModel
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    RecipeId = ingredient.RecipeId,
                    Obtained = ingredient.Obtained
                });
            }

            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddIngredient(IngredientModel ingredient) 
        {
            if (repo.IngredientExist(ingredient.Id))
            {
                return Conflict();
            }

            Ingredient newIngredient = new Ingredient
            {
                Name = ingredient.Name,
                Obtained = ingredient.Obtained,
                RecipeId = ingredient.RecipeId
            };

            repo.AddIngredient(newIngredient);
            repo.Save();

            IngredientModel finalIngredient = new IngredientModel
            {
                Id = newIngredient.Id,
                Name = newIngredient.Name,
                Obtained = newIngredient.Obtained,
                RecipeId = newIngredient.RecipeId
            };

            return CreatedAtRoute("GetRecipe", new { id = finalIngredient.Id }, finalIngredient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIngredient(int id, IngredientModel ingredient)
        {
            var ingredientEntity = repo.Get(id);
            if (ingredientEntity == null)
            {
                return NotFound();
            }

            ingredientEntity.Name = ingredient.Name;
            ingredientEntity.Obtained = ingredient.Obtained;
            ingredientEntity.RecipeId = ingredient.RecipeId;

            repo.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIngredient(int id)
        {
            var ingredientEntity = repo.Get(id);
            if (ingredientEntity == null)
            {
                return NotFound();
            }

            repo.Delete(ingredientEntity);
            repo.Save();

            return NoContent();
        }
    }
}
