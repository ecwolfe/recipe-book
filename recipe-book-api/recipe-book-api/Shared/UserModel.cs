using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Shared.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Must provide a Email.")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required (ErrorMessage = "Must provide a Password.")]
        [MaxLength(50)]
        public string Password { get; set; }
        public ICollection<RecipeModel> Recipe { get; set; } = new List<RecipeModel>();
    }
}
