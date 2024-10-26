using System.ComponentModel.DataAnnotations.Schema;

namespace App2demo.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mesagge { get; set; }
    }
}