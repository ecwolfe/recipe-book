using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Recipe_book_api.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Must provide a Name.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required (ErrorMessage = "Must provide a Password.")]
        [MaxLength(50)]
        public string Password { get; set; }
        public ICollection<RecipeModel> Recipe { get; set; } = new List<RecipeModel>();
    }
}
