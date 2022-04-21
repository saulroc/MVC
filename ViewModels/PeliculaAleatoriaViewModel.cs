using MVC.Models;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class PeliculaAleatoriaViewModel
    {
        public Pelicula Pelicula { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
