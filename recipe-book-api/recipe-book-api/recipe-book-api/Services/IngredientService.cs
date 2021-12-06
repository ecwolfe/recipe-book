using Recipe_book_api.Context;
using Recipe_book_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_book_api.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly DataContext context;

        public IngredientService(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<Ingredient> GetAll()
        {
            return context.Ingredients.ToList();
        }
        public Ingredient Get(int id)
        {
            return context.Ingredients.Where(u => u.Id == id).FirstOrDefault();
        }
        public IEnumerable<Ingredient> GetRecipeIngredients(int recipeId)
        {
            return context.Ingredients.Where(i => i.RecipeId == recipeId).ToList();
        }
        public void AddIngredient(Ingredient ingredient)
        {
            context.Ingredients.Add(ingredient);
        }
        public bool RecipeExist(int recipeId)
        {
            return context.Recipes.Any(r => r.Id == recipeId);
        }
        public bool IngredientExist(int ingredientId)
        {
            return context.Ingredients.Any(i => i.Id == ingredientId);
        }
        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }
        public void Delete(Ingredient ingredient)
        {
            context.Ingredients.Remove(ingredient);
        }
    }
}
