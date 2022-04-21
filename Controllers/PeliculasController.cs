using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
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
            return View(GetPeliculas());
        }

        [Route("peliculas/porFecha/{year:int}/{month:int}")]
        public IActionResult PorFecha(int year, int month)
        {
            return Content($"Año: {year}, Mes: {month}");
        }

        private List<Pelicula> GetPeliculas()
        {
            return new List<Pelicula>()
            {
                new Pelicula() { Id = 1, Titulo = "Gorilas en la Niebla" },
                new Pelicula() { Id = 2, Titulo = "Men In Black" }
            };
        }
    }
}
