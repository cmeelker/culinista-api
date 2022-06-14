using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culinista.Models
{
    [Table("Favorite")]
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
