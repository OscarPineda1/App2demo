using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App2demo.Data;
using App2demo.Models;
using App2demo.ViewModel;

namespace App2demo.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactoController(ILogger<ContactoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var miscontactos = from econtactos in _context.DataContacto select econtactos;
            var viewModel = new ContactoViewModel{
                FormContacto = new Contacto(),
                ListContactos = miscontactos
            };
            return View(miscontactos.ToList());
        }

        [HttpPost]
        public IActionResult Enviar(ContactoViewModel viewModel)
        {
            _logger.LogDebug("Ingreso al enviar mensaje");

            var contacto = new Contacto{
                Name = viewModel.FormContacto.Name,
                Email = viewModel.FormContacto.Email,
                Mesagge = viewModel.FormContacto.Mesagge
            };
                _context.Add(contacto);
                _context.SaveChanges();
                ViewData["Message"] = "Se registro el contacto";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}