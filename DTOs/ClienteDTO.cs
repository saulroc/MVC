using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public bool EstaSubscritoAlBoletinInformativo { get; set; }
        public byte TipoMembresiaId { get; set; }
        public string TipoMembresiaNombre { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
    }
}
