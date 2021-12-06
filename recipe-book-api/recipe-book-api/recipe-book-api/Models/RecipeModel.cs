using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Recipe_book_api.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must provide a Name.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int UserId { get; set; }
        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
    }
}
