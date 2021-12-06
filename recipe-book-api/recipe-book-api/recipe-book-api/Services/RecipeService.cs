using Recipe_book_api.Context;
using Recipe_book_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_book_api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly DataContext context;

        public RecipeService(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<Recipe> GetAll()
        {
            return context.Recipes.ToList();
        }
        public Recipe Get(int id)
        {
            return context.Recipes.Where(u => u.Id == id).FirstOrDefault();
        }
        public IEnumerable<Recipe> GetUserRecipes(int id)
        {
            return context.Recipes.Where(u => u.UserId == id).ToList();
        }
        public void AddRecipe(Recipe recipe)
        {
            context.Recipes.Add(recipe);
        }
        public void Delete(Recipe recipe)
        {
            context.Recipes.Remove(recipe);
        }
        public bool UserExist(int userId)
        {
            return context.Users.Any(u => u.Id == userId);
        }
        public bool RecipeExist(int recipeId)
        {
            return context.Recipes.Any(r => r.Id == recipeId);
        }
        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

    }
}
