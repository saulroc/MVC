using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.DTOs
{
    public class PeliculaDTO
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
        public string GeneroNombre { get; set; }
    }
}
