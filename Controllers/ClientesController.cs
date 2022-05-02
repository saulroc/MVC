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
            var viewModel = new FormularioClienteViewModel()
            {
                Cliente = new Cliente(),
                TiposMembresia = contexto.TipoMembresia.ToList()
            };
            return View("FormularioCliente", viewModel);
        }

        public IActionResult Detalles(int id)
        {
            var cliente = contexto.Clientes.Include(c => c.TipoMembresia).SingleOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();
            else
                return View(cliente);
        }

        public IActionResult Editar(int id)
        {
            var cliente = contexto.Clientes.Include(c => c.TipoMembresia).SingleOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();
            else
            {
                var viewModel = new FormularioClienteViewModel()
                {
                    Cliente = cliente,
                    TiposMembresia = contexto.TipoMembresia.ToList()
                };
                return View("FormularioCliente", viewModel);
            }
                
        }

        [HttpPost]
        public IActionResult Guardar(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View("FormularioCliente", new FormularioClienteViewModel()
                {
                    Cliente = cliente,
                    TiposMembresia = contexto.TipoMembresia.ToList()
                });

            if (cliente.Id == 0)
            {
                contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteDB = contexto.Clientes.Single(c => c.Id == cliente.Id);
                clienteDB.Nombre = cliente.Nombre;
                clienteDB.FechaDeNacimiento = cliente.FechaDeNacimiento;
                clienteDB.TipoMembresiaId = cliente.TipoMembresiaId;
                clienteDB.EstaSubscritoAlBoletinInformativo = cliente.EstaSubscritoAlBoletinInformativo;
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Clientes");
        }

    }
}
