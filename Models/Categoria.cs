using System.ComponentModel.DataAnnotations.Schema;

namespace App2demo.Models
{
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}