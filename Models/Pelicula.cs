using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Titulo { get; set; }
        public DateTime FechaDeRealizacion { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        
        [Range(1, 30)]
        public int Cantidad { get; set; }
        public byte GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
