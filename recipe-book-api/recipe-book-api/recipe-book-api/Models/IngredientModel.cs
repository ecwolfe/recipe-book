using System.ComponentModel.DataAnnotations;

namespace Recipe_book_api.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "Must provide a Name.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Obtained { get; set; }
        [Required(ErrorMessage = "Must provide a RecipeId.")]
        public int RecipeId { get; set; }
    }
}
