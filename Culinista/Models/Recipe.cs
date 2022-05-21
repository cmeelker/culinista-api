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
        public virtual ICollection<IngredientUnit> Ingredients { get; set; }
        public int Servings { get; set; }
        public string Instructions { get; set; }
        public Source Source { get; set; }
        public string URL { get; set; }
        public string Image { get; set; }
    }

    public class IngredientUnit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }

    public enum Source
    {
        AH
    }
}
