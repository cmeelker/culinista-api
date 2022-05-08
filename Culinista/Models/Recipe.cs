using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Culinista.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public Instruction[] Instructions { get; set; }
    }

    public class Ingredient
    {
        [Key]
        public string Name { get; set; }
        public string Unit { get; set; }
    }

    public class Instruction
    {
        [Key]
        public string Description { get; set; }
    }
}
