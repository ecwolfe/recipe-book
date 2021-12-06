using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe_book_api.Entities;

namespace Recipe_book_api.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAll();
        Recipe Get(int id);
        IEnumerable<Recipe> GetUserRecipes(int id);
        void AddRecipe(Recipe model);
        void Delete(Recipe model);
        bool UserExist(int userId);
        bool RecipeExist(int recipeId);
        bool Save();
    }
}
