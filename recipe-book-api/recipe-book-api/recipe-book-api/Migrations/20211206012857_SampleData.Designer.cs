﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipe_book_api.Context;

namespace Recipe_book_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211206012857_SampleData")]
    partial class SampleData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Recipe_book_api.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Obtained")
                        .HasColumnType("bit");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bread",
                            Obtained = false,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Butter",
                            Obtained = false,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cheese",
                            Obtained = false,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chilled Pasta",
                            Obtained = false,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Vinegar",
                            Obtained = false,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Oil",
                            Obtained = false,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sugar",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "Butter",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 9,
                            Name = "Flour",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 10,
                            Name = "Eggs",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 11,
                            Name = "Vanilla Extract",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 12,
                            Name = "Milk",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 13,
                            Name = "Baking Powder",
                            Obtained = false,
                            RecipeId = 3
                        },
                        new
                        {
                            Id = 14,
                            Name = "Eggs",
                            Obtained = false,
                            RecipeId = 4
                        },
                        new
                        {
                            Id = 15,
                            Name = "Confectioners' Sugar",
                            Obtained = false,
                            RecipeId = 4
                        },
                        new
                        {
                            Id = 16,
                            Name = "Almond Flour",
                            Obtained = false,
                            RecipeId = 4
                        },
                        new
                        {
                            Id = 17,
                            Name = "Salt",
                            Obtained = false,
                            RecipeId = 4
                        },
                        new
                        {
                            Id = 18,
                            Name = "Castor sugar",
                            Obtained = false,
                            RecipeId = 4
                        });
                });

            modelBuilder.Entity("Recipe_book_api.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Grilled Cheese",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pasta Salad",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cake",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Macarons",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Recipe_book_api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Paul Santos",
                            Password = "Password1234"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nicole Reyes",
                            Password = "Password1234"
                        });
                });

            modelBuilder.Entity("Recipe_book_api.Entities.Ingredient", b =>
                {
                    b.HasOne("Recipe_book_api.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Recipe_book_api.Entities.Recipe", b =>
                {
                    b.HasOne("Recipe_book_api.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Recipe_book_api.Entities.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Recipe_book_api.Entities.User", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
