using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App2demo.Models;

namespace App2demo.ViewModel
{
    public class ContactoViewModel
    {
        public Contacto? FormContacto { get; set; }
        public IEnumerable<Contacto>? ListContactos { get; set; }
    }
}