using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.BaseDeDatos;
using MVC.Models;
using MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
        private DataBaseContext contexto;
        public PeliculasController()
        {
            contexto= new DataBaseContext();
        }
        protected override void Dispose(bool disposing)
        {
            contexto.Dispose();
        }

        public IActionResult Aleatorio()
        {
            var pelicula = new Pelicula() {  Id = 1, Titulo = "Gorilas en la niebla"};
            var clientes = new List<Cliente>()
            {
                new Cliente() { Id = 2, Nombre = "Paco" },
                new Cliente() { Id= 3, Nombre = "Juan" },
                new Cliente(){ Id = 4, Nombre = "Pepe" }
            };
            return View(new PeliculaAleatoriaViewModel()
            {
                Pelicula = pelicula,
                Clientes = clientes
            });
        }

        public IActionResult Index()
        {
            return View(contexto.Peliculas.Include(p => p.Genero).ToList());
        }

        public IActionResult Detalles(int id)
        {
            var pelicula = contexto.Peliculas.Include(p => p.Genero).SingleOrDefault(p => p.Id == id);
            return View(pelicula);
        }

        [Route("peliculas/porFecha/{year:int}/{month:int}")]
        public IActionResult PorFecha(int year, int month)
        {
            return Content($"Año: {year}, Mes: {month}");
        }
        
    }
}
