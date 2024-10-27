using System.ComponentModel.DataAnnotations.Schema;
namespace App2demo.Models
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public DateTime DechaLanzamiento { get; set; }
        public int Calificacion { get; set; }
        public bool Multijuador { get; set; }
        public string? Status { get; set; }
        public string? ImagenURL { get; set; }
        public Categoria? Categoria { get; set; }
    }
}