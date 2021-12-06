using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe_book_api.Entities;

namespace Recipe_book_api.Services
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient Get(int id);
        IEnumerable<Ingredient> GetRecipeIngredients(int recipeId);
        void AddIngredient(Ingredient model);
        bool RecipeExist(int recipeId);
        bool IngredientExist(int ingredientId);
        bool Save();
        void Delete(Ingredient model);

    }
}
