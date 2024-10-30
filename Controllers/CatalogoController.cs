using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App2demo.Data;
using System.Dynamic;

namespace App2demo.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(ILogger<CatalogoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = from o in _context.DataCategoria select o;
            var catalogos = from o in _context.DataProducto select o;
            dynamic model = new ExpandoObject();
            model.itemsCategorias = categorias;
            model.itemsCatalogos = catalogos;
            return View(catalogos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}