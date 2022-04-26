using System;

namespace MVC.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeRealizacion { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public int Cantidad { get; set; }
        public byte GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
