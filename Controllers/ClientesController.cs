using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.BaseDeDatos;
using System.Linq;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {

        private DataBaseContext contexto;
        public ClientesController()
        {
            contexto = new DataBaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            contexto.Dispose();
        }

        public IActionResult Index()
        {
            return View(contexto.Clientes.Include(c => c.TipoMembresia).ToList());
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Detalles(int id)
        {
            var cliente = contexto.Clientes.Include(c => c.TipoMembresia).FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();
            else
                return View(cliente);
        }

    }
}
