using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_book_api.Entities
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
