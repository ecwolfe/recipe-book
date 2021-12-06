using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe_book_api.Entities;

namespace Recipe_book_api.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User() { 
                    Id = 1,
                    Name = "John Paul Santos",
                    Password = "Password1234"
                },
                new User()
                {
                    Id = 2,
                    Name = "Nicole Reyes",
                    Password = "Password1234"
                }
                );

            modelBuilder.Entity<Recipe>()
                .HasData(new Recipe()
                {
                    Id = 1,
                    Name = "Grilled Cheese",
                    UserId = 1

                },
                new Recipe()
                {
                    Id = 2,
                    Name = "Pasta Salad",
                    UserId = 1
                },
                new Recipe()
                {
                    Id = 3,
                    Name = "Cake",
                    UserId = 2
                },
                new Recipe()
                {
                    Id = 4,
                    Name = "Macarons",
                    UserId = 2
                }
                );

            modelBuilder.Entity<Ingredient>()
                .HasData(new Ingredient()
                {
                    Id = 1,
                    Name = "Bread",
                    RecipeId = 1,
                    Obtained = false

                },
                new Ingredient()
                {
                    Id = 2,
                    Name = "Butter",
                    RecipeId = 1,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 3,
                    Name = "Cheese",
                    RecipeId = 1,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 4,
                    Name = "Chilled Pasta",
                    RecipeId = 2,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 5,
                    Name = "Vinegar",
                    RecipeId = 2,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 6,
                    Name = "Oil",
                    RecipeId = 2,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 7,
                    Name = "Sugar",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 8,
                    Name = "Butter",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 9,
                    Name = "Flour",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 10,
                    Name = "Eggs",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 11,
                    Name = "Vanilla Extract",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 12,
                    Name = "Milk",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 13,
                    Name = "Baking Powder",
                    RecipeId = 3,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 14,
                    Name = "Eggs",
                    RecipeId = 4,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 15,
                    Name = "Confectioners' Sugar",
                    RecipeId = 4,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 16,
                    Name = "Almond Flour",
                    RecipeId = 4,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 17,
                    Name = "Salt",
                    RecipeId = 4,
                    Obtained = false
                },
                new Ingredient()
                {
                    Id = 18,
                    Name = "Castor sugar",
                    RecipeId = 4,
                    Obtained = false
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
