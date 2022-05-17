using MVC.Models;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class FormularioPeliculaViewModel
    {
        public Pelicula Pelicula { get; set; }
        public IEnumerable<Genero> Genero { get; set; } = new List<Genero>();

        public string Titulo => this.Pelicula.Id == 0 ? "Nueva Película" : "Editar Película";
    }
}
