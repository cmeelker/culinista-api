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
        public string Tags { get; set; }
        public string URL { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public string Favicon { get; set; }
    }
}
