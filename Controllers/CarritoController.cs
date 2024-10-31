using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using App2demo.Data;
using App2demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App2demo.Helper;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Identity.Client;

namespace App2demo.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CarritoController(ILogger<CarritoController> logger, UserManager<IdentityUser> userManager,ApplicationDbContext context )
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;

        }

        public IActionResult Index()
        {
            List<Carrito> carrito = Helper.SessionExtensions.Get<List<Carrito>>(HttpContext.Session, "carritoSesion");
            if(carrito == null){
                carrito = new List<Carrito>();
            }
            return View(carrito);
        }

        public async Task<IActionResult> Add(int? id)
        {
            var userName = _userManager.GetUserName(User);
            if (userName == null)
            {
                _logger.LogInformation("No existe usuario");
                ViewData["Message"] = "Porfavor debe loguearse antes de agregar un producto";
                return RedirectToAction("Index", "Home");
            }else{
                //obtengo el carrito de memoria
                List<Carrito> carrito = Helper.SessionExtensions.Get<List<Carrito>>(HttpContext.Session, "carritoSesion");
                if(carrito == null){
                    carrito = new List<Carrito>();
                }
                //obtengo los datos del producto
                var producto = await _context.DataProducto.FindAsync(id);
                Carrito itemCarrito = new Carrito();
                itemCarrito.Producto = producto;
                itemCarrito.UserName = userName;
                itemCarrito.Cantidad = 1;
                carrito.Add(itemCarrito);
                Helper.SessionExtensions.Set<List<Carrito>>(HttpContext.Session, "carritoSesion", carrito);
                ViewData["Message"] = "Se agrego al carrito";
                _logger.LogInformation("Se agrego un producto al carrito");
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}