using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.BaseDeDatos;
using MVC.Models;
using MVC.ViewModels;
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
            var viewModel = new NuevoClienteViewModel()
            {
                Cliente = new Cliente(),
                TiposMembresia = contexto.TipoMembresia.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Detalles(int id)
        {
            var cliente = contexto.Clientes.Include(c => c.TipoMembresia).SingleOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();
            else
                return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente = contexto.Clientes.Include(c => c.TipoMembresia).SingleOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();
            else
                return View(cliente);
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            //TryUpdateModelAsync(cliente);
            return RedirectToAction("Index", "Clientes");
        }

    }
}
