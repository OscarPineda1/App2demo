using System.ComponentModel.DataAnnotations.Schema;

namespace App2demo.Models
{
    [Table("t_categoria")]
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}