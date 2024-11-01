using System.Collections.Generic;
using App2demo.Models;

namespace App2demo.ViewModels
{
    public class CatalogoViewModel
    {
        public IEnumerable<Categoria> itemCategorias { get; set; }
        public IEnumerable<Producto> itemCatalogos { get; set; }
    }
}
